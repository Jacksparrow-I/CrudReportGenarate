using CrudReportGenerate.Model.Common;
using CrudReportGenerate.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CrudReportGenerate.Model.Entity;

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

        [HttpGet("GetLogindetails")]
        public List<User> GetLogindetails()
        {
            return _authenticateService.GetLogindetails();
        }

        [HttpPost("Registration")]
        public int Registration([FromBody] Userdata UserModel, string UserName)
        {
            return _authenticateService.Registration(UserModel, UserName);
        }



        [HttpPost]//Login
        public IActionResult Post([FromBody] Userdata Model)
        {
            var user = _authenticateService.Authenticate(Model);

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