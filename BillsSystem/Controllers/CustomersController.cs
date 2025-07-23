using BillsSystem.Models;
using BillsSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillsSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                TempData["Success"] = "Customer added successfully!";
                return RedirectToAction("Create");
            }

           
            return View(customer);
        }

        public IActionResult Details(int customerId)
        {
            var customer = _context.Customers
                .Include(c => c.Bills)
                    .ThenInclude(b => b.BillItems)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

    }

}
