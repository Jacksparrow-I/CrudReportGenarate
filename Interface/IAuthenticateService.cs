using CrudReportGenerate.Model.Common;
using CrudReportGenerate.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Interface
{
    public interface IAuthenticateService
    {
        public Userdata Authenticate(Userdata Model);
        public List<User> GetLogindetails();
        public int Registration(Userdata UserModel, string UserName);
        public int Editprofile(Userdata UserModel, string UserName, int UserId);
    }
}
