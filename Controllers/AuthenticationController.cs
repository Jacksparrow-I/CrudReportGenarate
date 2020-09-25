using CoreEntityApi.Model.Common;
using CrudReportGenerate.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace CrudReportGenerate.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] User Model)
        {
            var user = _authenticateService.Authenticate(Model.UserName, Model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });

            }
            else
            {
                return Ok(user);
            }
        }
    }
}