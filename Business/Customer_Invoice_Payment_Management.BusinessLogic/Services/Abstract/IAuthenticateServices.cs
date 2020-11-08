using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IAuthenticateServices
    {
        public Userdata Authenticate(Userdata userModel);
        public List<user> GetLogindetails();
        public int Registration(user UserModel, string UserName);
        public int Editprofile(user UserModel, string UserName, int UserId);
        public user GetEditprofileById(int UserId);
    }
}
