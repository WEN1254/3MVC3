using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels.Customer.Output
{
    public class GetCustomerOutput
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string BirthDay { get; set; }
    }
}