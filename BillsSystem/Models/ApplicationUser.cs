using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BillsSystem.Models
{
    public class ApplicationUser : IdentityUser

    {

        public ICollection<Bill> Bills { get; set; } = new List<Bill>();


    }
}
