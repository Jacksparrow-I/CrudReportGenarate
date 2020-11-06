using System;
using System.Collections.Generic;

namespace Customer_Invoice_Payment_Management.DataLogic.DatabaseModel
{
    public partial class User
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
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
