using System.ComponentModel.DataAnnotations;

namespace ShopDemo.Core.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Product Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Product price
        /// </summary>
        [Range(typeof(decimal), "0.01", "1000000", ConvertValueInInvariantCulture = true)]
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Product quantity in stock
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
