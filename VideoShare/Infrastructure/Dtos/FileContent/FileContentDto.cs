using Newtonsoft.Json;

namespace VideoShare.Infrastructure.Dtos.FileContent
{
    public class FileContentDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
