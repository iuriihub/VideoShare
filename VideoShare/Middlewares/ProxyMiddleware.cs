using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VideoShare.Infrastructure.Interfaces;

namespace VideoShare.Middlewares
{
    public class ProxyMiddleware
    {
        private const string HttpsPort = "443";
        private const string HttpPort = "80";
        private const string Https = "https";
        private const string Http = "http";

        private readonly HttpClient _httpClient;
        private readonly IProxySettings _proxySettings;
        private readonly RequestDelegate _next;

        public ProxyMiddleware(RequestDelegate next, IProxySettings proxySettings, IHttpClientFactory httpClientFactory)
        {
            _proxySettings = proxySettings ?? throw new ArgumentNullException(nameof(proxySettings));
            if (httpClientFactory == null) throw new ArgumentNullException(nameof(httpClientFactory));

            if (string.IsNullOrEmpty(_proxySettings.Port))
            {
                _proxySettings.Port = string.Equals(_proxySettings.Scheme, Https, StringComparison.OrdinalIgnoreCase)
                    ? HttpsPort
                    : HttpPort;
            }

            if (string.IsNullOrEmpty(_proxySettings.Scheme))
            {
                _proxySettings.Scheme = Http;
            }

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(600);

            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!IsValidForRouting(context.Request))
            {
                var invokeCounter = 0;
                while (invokeCounter < 1)
                {
                    try
                    {
                        await _next.Invoke(context);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    invokeCounter++;
                }
                return;
            }

            var requestMessage = new HttpRequestMessage();
            if (!string.Equals(context.Request.Method, "GET", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(context.Request.Method, "HEAD", StringComparison.OrdinalIgnoreCase))
            {
                var streamContent = new StreamContent(context.Request.Body);
                requestMessage.Content = streamContent;
            }

            foreach (var header in context.Request.Headers)
            {
                if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()))
                {
                    requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                }
            }

            requestMessage.Headers.Host = _proxySettings.Host + ":" + _proxySettings.Port;
            var uriString = $"{_proxySettings.Scheme}://{_proxySettings.Host}:{_proxySettings.Port}{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}";
            requestMessage.RequestUri = new Uri(uriString);
            requestMessage.Method = new HttpMethod(context.Request.Method);

            using (var responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted))
            {
                context.Response.StatusCode = (int)responseMessage.StatusCode;

                foreach (var header in responseMessage.Content.Headers)
                {
                    context.Response.Headers[header.Key] = header.Value.ToArray();
                }

                context.Response.Headers.Remove("transfer-encoding");
                await responseMessage.Content.CopyToAsync(context.Response.Body);
            }
        }

        private bool IsValidForRouting(HttpRequest httpRequest)
        {
            if (string.Equals(httpRequest.Method, "DELETE", StringComparison.OrdinalIgnoreCase)
                || string.Equals(httpRequest.Method, "TRACE", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!_proxySettings.RoutingRules.Any(p => httpRequest.Path.Value.StartsWith(p.MatchingUrl, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            return true;
        }
    }
}
