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
                    //Model.Common.Registration Login = new Model.Common.Registration();
                    //Add record
                    {
                        //log = dBContext.Registration.SingleOrDefault(asd => asd.Id == Id && asd.UserName == UserName);
                        //if (log != null)
                        //{
                        //    LoginRepo Login = new LoginRepo();
                        //    //Login.Id = log.Id;
                        //    //Login.UserName = log.UserName;
                        //    return returnVal = 1;
                        //}
                        log = dBContext.Registration.SingleOrDefault(asd => asd.UserName == RegistrationModel.UserName && asd.Password == RegistrationModel.Password);
                        if (log != null)
                        {
                            LoginRepo Login = new LoginRepo();
                            //Login.Id = log.Id;
                            //Login.UserName = log.UserName;
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

        //public List<Model.Common.Registration> GetiLogin()
        //{
        //    List<Models.Common.Department> Items = new List<Models.Common.Department>();

        //    {
        //        using (var dBContext = new workentityContext())
        //        {
        //            Model.Entity.Registration log = new Model.Entity.Registration();
        //            Model.Common.Registration emp;
        //            foreach (var it in dBContext.Registration)
        //            {
        //                log = dBContext.Registration.SingleOrDefault(asd => asd.Id == Id && asd.UserName == UserName);
        //                if (log != null)
        //                {
        //                    LoginRepo Login = new LoginRepo();
        //                    //Login.Id = log.Id;
        //                    //Login.UserName = log.UserName;
        //                }
        //            
        //          }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return Items;
        //}

    }
}
