using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class AuthenticateServices : IAuthenticateServices
    {
        private readonly IAuthenticate _Authenticate;
        public AuthenticateServices( IAuthenticate Authenticate)
        {
            _Authenticate = Authenticate;
        }

        public Userdata Login(Userdata Model)
        {
            return _Authenticate.Login(Model);
        }

        public int Editprofile(User UserModel, string UserName, int UserId)
        {
            return _Authenticate.Editprofile(UserModel, UserName, UserId);
        }

        public User GetEditprofileById(int UserId)
        {
            return _Authenticate.GetEditprofileById(UserId);
        }

        public List<User> GetLogindetails()
        {
            return _Authenticate.GetLogindetails();
        }
 
        public int Registration(User UserModel, string UserName)
        {
            return _Authenticate.Registration(UserModel, UserName);
        }
    }
}


