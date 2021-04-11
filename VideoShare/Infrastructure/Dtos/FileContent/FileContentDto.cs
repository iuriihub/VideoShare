using Newtonsoft.Json;

namespace VideoShare.Infrastructure.Dtos.FileContent
{
    public class FileContentDto
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }
    }
}
