namespace MVC.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int ProductSpecificationID { get; set; }

        public int? BuyQuantity { get; set; }

        public decimal? Price { get; set; }

        public DateTime? Date { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

        public virtual ProductSpecification ProductSpecification { get; set; }
    }
}
