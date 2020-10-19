using CrudReportGenerate.Interface;
using CrudReportGenerate.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Repository
{
    public class LoginRepo : ILogin
    {
        public int GetLogin(Model.Entity.Registration RegistrationModel,int Id, string UserName)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Entity.Registration log = new Model.Entity.Registration();
                    //Add record
                    {
                        log = dBContext.Registration.SingleOrDefault(asd => asd.UserName == RegistrationModel.UserName && asd.Password == RegistrationModel.Password);
                        if (log != null)
                        {
                            LoginRepo Login = new LoginRepo();
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
