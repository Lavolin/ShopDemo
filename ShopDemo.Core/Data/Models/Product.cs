using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShopDemo.Core.Data.Models
{
    [Comment("Product to sell")]
    public class Product
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Product name")]
        public string Name { get; set; }

        [Required]
        [Comment("Product price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Product quantity")]
        public int Quantity { get; set; }

    }
}
