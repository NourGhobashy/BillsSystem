using System.ComponentModel.DataAnnotations;

namespace BillsSystem.Models
{
   

    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "COMPANY NAME is Required")]
        [StringLength(100, ErrorMessage = "COMPANY NAME must not exceed 100 characters")]
        public string Name { get; set; }

    }

}
