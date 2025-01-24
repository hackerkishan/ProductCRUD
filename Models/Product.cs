using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCRUD.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is mandatory")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Quantity is mandatory")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is mandatory")]
        public float Price { get; set; }
    }
}
