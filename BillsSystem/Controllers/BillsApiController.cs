using BillsSystem.Models;
using BillsSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillsSystem.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bills = _context.Bills
                .Include(b => b.Customer)
                .Include(b => b.CreatedByUser)
                .Select(b => new
                {
                    b.Id,
                    b.BillNumber,
                    b.Date,
                    CustomerName = b.Customer != null ? b.Customer.Name : "غير محدد",
                    CreatedBy = b.CreatedByUser != null ? b.CreatedByUser.UserName : "غير معروف",
                    b.Total,
                    b.Discount,
                    b.NetAmount,
                    b.AmountPaid,
                    b.RemainingAmount
                })
                .ToList();

            return Ok(bills);
        }

    }
}