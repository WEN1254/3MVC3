using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels.Customer.Output
{
    public class CustomerOrder_OutputModel
    {
        public string OrderEmail { get; set; }
        public string OrderID { get; set; }
        public string RecieverName { get; set; }
        public string ProductName { get; set; }
        public string Colour { get; set; }
        public string  Img{ get; set; }
        public string BuyQuantity { get; set; }
        public string Price { get; set; }
        public string ProductTotal { get; set; }
    }
}