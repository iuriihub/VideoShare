using System.Net;

namespace VideoShare.Infrastructure.Dtos.Generic
{
    public class HttpResponseDto<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Content { get; set; }
        public string HttpContent { get; set; }
    }
}
