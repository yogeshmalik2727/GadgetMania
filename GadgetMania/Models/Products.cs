using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetMania.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }          //Product Id

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } // NAme of Product

        [Required]
        [StringLength(50)]
        public string Price { get; set; }

        public string ProductDescription { get; set; }            // Description of Product

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }
        
        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        [InverseProperty("CategoryProducts")]
        public virtual Category Categories { get; set; }             
        /// </summary>

        [Required]
        //For suppliers
        public int SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        [InverseProperty("SuppliersProducts")]
        public virtual Suppliers Suppliers { get; set; }

        
        public virtual ICollection<SupplierReview> SupplierReview { get; set; }

        [NotMapped]
        public SingleFileUploads File { get; set; }
    }

    public class SingleFileUploads
    { 
      //  To upload file
    /// </summary>
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
