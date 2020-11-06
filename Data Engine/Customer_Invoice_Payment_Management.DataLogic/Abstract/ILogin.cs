using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;

namespace Customer_Invoice_Payment_Management.DataLogic.Abstract
{
    public interface ILogin
    {
        public int GetLogin(Registration RegistrationModel, int Id, string UserName);
    }
}
