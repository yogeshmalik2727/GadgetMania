using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace GadgetMania.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContact { get; set; }
        public string ContactPerson { get; set; }

        public virtual ICollection<Products> SuppliersProducts { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }

    }
    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
