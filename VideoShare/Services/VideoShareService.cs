using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VideoShare.Infrastructure.Dtos.FileContent;
using VideoShare.Infrastructure.Dtos.Generic;
using VideoShare.Infrastructure.Interfaces;

namespace VideoShare.Services
{
    public class VideoShareService : IVideoShareService
    {

        private readonly IVideoShareServiceSettings _videoShareServiceSettings;

        public VideoShareService(IVideoShareServiceSettings videoShareServiceSettings)
        {
            _videoShareServiceSettings = videoShareServiceSettings ?? throw new ArgumentNullException(nameof(videoShareServiceSettings));
        }

        /// <summary>
        /// Get host settings
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseDto<List<FileContentDto>>> GetVideoResources()
        {
            HttpResponseDto<List<FileContentDto>> response;

            var files = Directory.GetFiles(_videoShareServiceSettings.VideoShareResourceBasePath);
            var fileContents = files.ToList().Select(o => Path.GetFileName(o)).Select(o => new FileContentDto() { Name = o, Content = o });

            response = new HttpResponseDto<List<FileContentDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Content = fileContents.ToList()
            };

            return response;
        }
    }
}
