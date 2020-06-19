namespace MVC.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductSpecification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductSpecification()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductSpecificationID { get; set; }

        public int ProductID { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(30)]
        public string Colour { get; set; }

        [StringLength(60)]
        public string Image { get; set; }

        [StringLength(60)]
        public string ColourImg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Product Product { get; set; }
    }
}
