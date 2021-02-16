using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetMania.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }             //Model Categories

        [Required]
        [StringLength(100)]                                            //Maximum Length is 100
        public string CategoryName { get; set; }

        public virtual ICollection<Products> CategoryProducts { get; set; }

    }
}
