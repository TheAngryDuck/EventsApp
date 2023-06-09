using EventAppDataLayer.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private IConfiguration _configuration;

        public ValidationController(IConfiguration configuration) { 
            _configuration = configuration;
        }

        // POST api/<ValidationController>/5
        [HttpPost]
        public ActionResult Validate([FromBody] ValidationDto dto)
        {
            var correctEmail = _configuration.GetSection("LoginData").GetSection("email").Value;
            var correctPassword = _configuration.GetSection("LoginData").GetSection("password").Value;
            if (dto.Email.Equals(correctEmail) && (dto.Password.Equals(correctPassword)))
            {
                return Ok();
            }
            return Unauthorized();
            
        }
    }
}
