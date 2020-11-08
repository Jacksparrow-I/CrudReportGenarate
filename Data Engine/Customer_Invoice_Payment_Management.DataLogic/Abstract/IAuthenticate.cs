using Customer_Invoice_Payment_Management.Model.Common;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.DataLogic.Abstract
{
    public interface IAuthenticate
    {
        public Userdata Authenticate(Userdata Model);
        public List<User> GetLogindetails();
        public int Registration(User UserModel, string UserName);
        public int Editprofile(User UserModel, string UserName, int UserId);
        public User GetEditprofileById(int UserId);

    }
}
