using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillsSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [StringLength(250)]
        public string? Notes { get; set; }
    }
}
