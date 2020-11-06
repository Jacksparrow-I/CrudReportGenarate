using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.DataLogic.Concrete
{
    public class LoginRepository : ILogin
    {
        public int GetLogin(Registration RegistrationModel,int Id, string UserName)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Registration log = new Registration();
                    //Add record
                    {
                        log = dBContext.Registration.SingleOrDefault(asd => asd.UserName == RegistrationModel.UserName && asd.Password == RegistrationModel.Password);
                        if (log != null)
                        {
                            LoginRepository Login = new LoginRepository();
                            return returnVal=1;
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }

    }
}
