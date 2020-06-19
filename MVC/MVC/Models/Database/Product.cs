namespace MVC.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductSpecifications = new HashSet<ProductSpecification>();
        }

        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int SmallClassificationID { get; set; }

        [StringLength(60)]
        public string LargePageImage { get; set; }

        [StringLength(60)]
        public string DesignDiagramImage { get; set; }

        [Required]
        public string DescriptionTitle { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string Particular { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
    }
}
