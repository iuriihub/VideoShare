using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VideoShare.Infrastructure.Interfaces;

namespace VideoShare.Controllers
{
    [Route("api/v1/video-share")]
    [ApiController]
    public class VideoShareController : ControllerBase
    {
        private readonly IVideoShareService _videoShareService;

        public VideoShareController(IVideoShareService videoShareService)
        {
            _videoShareService = videoShareService ?? throw new ArgumentNullException(nameof(videoShareService));
        }

        /// <summary>
        /// Returls list of files
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(void), Description = "Returls list of files")]
        [HttpGet("video-resources", Name = "GetVideoResources")]
        public async Task<IActionResult> GetVideoResources()
        {
            var response = await _videoShareService.GetVideoResources();

            if (response.Content != null)
            {
                return Ok(response.Content);
            }

            return StatusCode((int)response.StatusCode, response.HttpContent);
        }
    }
}
