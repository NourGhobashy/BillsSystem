using System.ComponentModel.DataAnnotations;

namespace BillsSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

      
        public ICollection<BillItem>? BillItems { get; set; }
    }
}
