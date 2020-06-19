namespace MVC.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SmallClassification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SmallClassificationID { get; set; }

        public int MainClassificationID { get; set; }

        [Required]
        [StringLength(35)]
        public string SmallClassificationName { get; set; }

        public virtual MainClassification MainClassification { get; set; }
    }
}
