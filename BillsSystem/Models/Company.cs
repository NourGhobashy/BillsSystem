using System.ComponentModel.DataAnnotations;

namespace BillsSystem.MVC.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "COMPANY NAME is Required")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
