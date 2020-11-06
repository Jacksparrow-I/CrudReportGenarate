using System;
using System.Collections.Generic;

namespace Customer_Invoice_Payment_Management.DataLogic.DatabaseModel
{
    public partial class Registration
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
