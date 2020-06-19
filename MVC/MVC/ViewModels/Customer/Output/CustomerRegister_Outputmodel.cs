using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels.Customer.Output
{
    public class CustomerRegister_Outputmodel
    {
        public string RegisterEmail { get; set; }
        public string RegisterPassword { get; set; }
        public string RegisterCustomerName { get; set; }
        public string RegisterBirthday { get; set; }
        public string RegisterPhone { get; set; }
    }
}