using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace VideoShare.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        public ManagementController()
        {
        }

        /// <summary>
        /// Returns single Service Keepalive status
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(void), Description = "Returns single Service Keepalive status")]
        [HttpGet("keepalive", Name = "GetKeepAlive")]
        public IActionResult GetKeepAlive()
        {
            return Ok(new
            {
                Status = true,
                TimeStamp = DateTime.Now.ToString()
            });
        }

        /// <summary>
        /// Returns servise version
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(void), Description = "Version number")]
        [HttpGet("version", Name = "GetVersion")]
        public IActionResult GetVersion()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            return Ok(new { Version = fileInfo.ProductVersion });
        }
    }
}
