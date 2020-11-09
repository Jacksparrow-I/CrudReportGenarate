using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IAuthenticateServices
    {
        public Userdata Authenticate(Userdata Model);
        public List<User> GetLogindetails();
        public int Registration(User UserModel, string UserName);
        public int Editprofile(User UserModel, string UserName, int UserId);
        public User GetEditprofileById(int UserId);
    }
}
