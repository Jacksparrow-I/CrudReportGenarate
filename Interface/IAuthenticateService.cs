using CoreEntityApi.Model.Common;
using CrudReportGenerate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Interface
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);
    }
}
