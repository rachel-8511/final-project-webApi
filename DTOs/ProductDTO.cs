using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "name must be less than 30 characters long")]
        public string ProductName { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Description must be less than 100 characters long")]
        public string Description { get; set; } = null!;
        [Required, MaxLength(50, ErrorMessage = "imageURL must be less than 50 characters long")]
        public string ImageUrl { get; set; } = null!;

        
    }
}
