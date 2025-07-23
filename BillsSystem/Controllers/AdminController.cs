using BillsSystem.Models.ViewModels;
using BillsSystem.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Dashboard()
    {
        var bills = _context.Bills.ToList();

        var model = new DashboardViewModel
        {
            CustomerCount = _context.Customers.Count(),
            BillCount = bills.Count,
            TotalAmount = bills.Sum(b => b.Total),
            NetAmount = bills.Sum(b => b.NetAmount),
            RemainingAmount = bills.Sum(b => b.RemainingAmount),
            UnpaidBillsCount = bills.Count(b => b.RemainingAmount > 0),
            PaidBillsCount = bills.Count(b => b.RemainingAmount <= 0)
        };

        return View(model);
    }
}
