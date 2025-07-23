using System.ComponentModel.DataAnnotations;

namespace BillsSystem.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}
