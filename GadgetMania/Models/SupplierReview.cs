using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetMania.Models
{
    public class SupplierReview
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string ReviewText { get; set; }

        [Required]
        public int SupplierID { get; set; }

        public Products Products { get; set; }

        public DateTime ReviewDate { get; set; }

    }
}
