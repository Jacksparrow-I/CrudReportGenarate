using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;

namespace CrudReportGenerate.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateServices _authenticateService;
        public AuthenticationController(IAuthenticateServices authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpGet("GetLogindetails")]
        public List<User> GetLogindetails()
        {
            return _authenticateService.GetLogindetails();
        }

        [HttpPost("Registration")]
        public int Registration([FromBody] User UserModel, string UserName)
        {
            return _authenticateService.Registration(UserModel, UserName);
        }

        [HttpPost("Editprofile/{UserID}")]
        public int Editprofile([FromBody] User UserModel, string UserName, int UserId)
        {
            return _authenticateService.Editprofile(UserModel, UserName, UserId);
        }

        [HttpGet("GetEditprofileById/{UserId}")]
        public User GetEditprofileById(int UserId)
        {
            return _authenticateService.GetEditprofileById(UserId);
        }

        [HttpPost]//Login
        public IActionResult Post([FromBody] Userdata Model)
        {
            var user = _authenticateService.Login(Model);

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