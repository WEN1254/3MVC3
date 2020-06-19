namespace MVC.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainClassification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainClassification()
        {
            SmallClassifications = new HashSet<SmallClassification>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MainClassificationID { get; set; }

        [Required]
        [StringLength(30)]
        public string MainClassificationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SmallClassification> SmallClassifications { get; set; }
    }
}
