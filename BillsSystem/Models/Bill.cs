using System.ComponentModel.DataAnnotations;

namespace BillsSystem.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public string BillNumber { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public string? CreatedByUserId { get; set; }
        public ApplicationUser? CreatedByUser { get; set; }

        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount { get; set; }

        public ICollection<BillItem> BillItems { get; set; } = new List<BillItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
