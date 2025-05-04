using Bathra.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Bathra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiInfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ApiInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<ApiResponse<object>> GetApiInfo()
        {
            var apiInfo = new
            {
                Name = "Bathra API",
                Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0",
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
                Timestamp = DateTime.UtcNow
            };

            return Ok(ApiResponse<object>.SuccessResponse(apiInfo, "API is running"));
        }

        [HttpGet("ping")]
        public ActionResult<ApiResponse<object>> Ping()
        {
            return Ok(ApiResponse<object>.SuccessResponse(
                new { timestamp = DateTime.UtcNow },
                "API is responsive"));
        }
    }
} 