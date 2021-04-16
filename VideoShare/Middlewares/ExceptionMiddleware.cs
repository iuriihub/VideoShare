using System;
using System.Threading.Tasks;
using CorrelationId;
using Microsoft.AspNetCore.Http;
using VideoShare.Infrastructure.Interfaces;

namespace VideoShare.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExtendedLogger _logger;
        private readonly ICorrelationContextAccessor _correlationContextAccessor;

        public ExceptionMiddleware(RequestDelegate next,
            IExtendedLogger<ExceptionMiddleware> logger,
            ICorrelationContextAccessor correlationContextAccessor)
        {
            _logger = logger;
            _next = next;
            _correlationContextAccessor = correlationContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var correlationId = _correlationContextAccessor.CorrelationContext.CorrelationId;

                _logger.LogError(
                    $"Exception Details: {ex.Message}, {ex.InnerException}, {ex?.InnerException?.Message}, {ex.StackTrace}", correlationId);
                throw;
            }
        }
    }
}
