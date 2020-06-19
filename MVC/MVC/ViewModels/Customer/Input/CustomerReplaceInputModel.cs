using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels.Customer.Input
{
    public class CustomerReplaceInputModel
    {
        public string ReplaceEmail { get; set; }
        public string ReplaceCustomerName { get; set; }
        public string ReplaceBirthDay { get; set; }
        public string ReplacePhone { get; set; }
        public string ReplacePassword { get; set; }
    }
}