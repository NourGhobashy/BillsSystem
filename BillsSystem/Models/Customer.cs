using System.ComponentModel.DataAnnotations;

namespace BillsSystem.Models
{
 
    
        public class Customer
        {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [StringLength(14, MinimumLength = 11, ErrorMessage = "Phone number must be between 11 and 14 digits")]
            public string Phone { get; set; }

            [Required]
            [StringLength(200)]
            public string Address { get; set; }

            public ICollection<Bill> Bills { get; set; }
        }
    }
