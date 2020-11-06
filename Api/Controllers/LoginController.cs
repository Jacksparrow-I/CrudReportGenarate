using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Microsoft.AspNetCore.Authorization;

namespace CrudReportGenerate.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _ILogin;
        public LoginController(ILogin LoginRepo)
        {
            _ILogin = LoginRepo;
        }

        [HttpPost("GetLogin")]
        public int GetLogin([FromBody] Registration Registration, int Id, string UserName)
        {
            //**** move this below code to dependency injection ****
            return _ILogin.GetLogin(Registration, Id, UserName);
        }
    }
}