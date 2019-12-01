using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [ApiController]
    [Route("")]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<InfoController> _logger;

        public InfoController(ILogger<InfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public InfoModel GetInfo()
        {
            return new InfoModel { AppEnvironment = GetEnvironmentVariable("APPENVIRONMENT"), AppHost = GetEnvironmentVariable("APPHOST") };
        }

        private string GetEnvironmentVariable(string name)
        {
            _logger.LogInformation($"Getting environment variable '{name}'.");
            return Environment.GetEnvironmentVariable(name.ToLower()) ?? Environment.GetEnvironmentVariable(name.ToUpper());
        }
    }
}
