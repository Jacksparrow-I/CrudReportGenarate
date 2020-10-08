using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Model.Common
{
    public class Userdata
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Usertype { get; set; }
        public string Region { get; set; }
        public string Token { get; set; }
    }
}
