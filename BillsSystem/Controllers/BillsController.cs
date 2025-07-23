using BillsSystem.Models;
using BillsSystem.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class BillsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public BillsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public IActionResult Index(int? customerId)
    {
        var userId = _userManager.GetUserId(User);
        var isAdmin = User.IsInRole("Admin");

        var bills = _context.Bills
            .Include(b => b.Customer)
            .AsQueryable();

        if (!isAdmin)
            bills = bills.Where(b => b.CreatedByUserId == userId);

        if (customerId.HasValue)
            bills = bills.Where(b => b.CustomerId == customerId.Value);

        ViewBag.Customers = new SelectList(_context.Customers.ToList(), "Id", "Name");
        ViewBag.SelectedCustomerId = customerId;

        return View(bills.ToList());
    }



    public IActionResult Create()
    {
        ViewBag.Customers = _context.Customers.ToList();
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Bill bill)
    {
        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
            bill.CreatedByUserId = userId;

            _context.Add(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", bill.CustomerId);
        return View(bill);
    }


    public IActionResult Details(int id)
    {
        var bill = _context.Bills
            .Include(b => b.Customer)
            .Include(b => b.BillItems)
            .ThenInclude(i => i.Product)
            .Include(b => b.Payments)
            .FirstOrDefault(b => b.Id == id);

        if (bill == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);
        if (bill.CreatedByUserId != userId && !User.IsInRole("Admin"))
            return NotFound();
        ViewBag.Products = _context.Products.ToList();

        return View(bill);
    }


    public IActionResult Edit(int id)
    {
        var bill = _context.Bills.Find(id);
        if (bill == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);
        if (bill.CreatedByUserId != userId && !User.IsInRole("Admin"))
            return NotFound();

        ViewBag.Customers = _context.Customers.ToList();
        return View(bill);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Bill bill)
    {
        if (id != bill.Id)
            return NotFound();

        var existingBill = _context.Bills.AsNoTracking().FirstOrDefault(b => b.Id == id);
        if (existingBill == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);
        if (existingBill.CreatedByUserId != userId && !User.IsInRole("Admin"))
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(bill);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Customers = _context.Customers.ToList();
        return View(bill);
    }


    public IActionResult Delete(int id)
    {
        var bill = _context.Bills
            .Include(b => b.Customer)
            .FirstOrDefault(b => b.Id == id);

        if (bill == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);
        if (bill.CreatedByUserId != userId && !User.IsInRole("Admin"))
            return NotFound();

        return View(bill);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var bill = _context.Bills.FirstOrDefault(b => b.Id == id);
        if (bill == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);
        if (bill.CreatedByUserId != userId && !User.IsInRole("Admin"))
            return NotFound();

        _context.Bills.Remove(bill);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(int BillId, string ItemName, int Quantity, decimal UnitPrice, int? ProductId)
    {
        var bill = await _context.Bills
            .Include(b => b.BillItems)
            .FirstOrDefaultAsync(b => b.Id == BillId);

        if (bill == null)
            return NotFound();

        var item = new BillItem
        {
            BillId = BillId,
            ItemName = ItemName,
            Quantity = Quantity,
            UnitPrice = UnitPrice,
            ProductId = ProductId
        };

        _context.BillItems.Add(item);

        bill.Total = bill.BillItems.Sum(i => i.Total) + item.Total;
        bill.NetAmount = bill.Total - bill.Discount;
        bill.RemainingAmount = bill.NetAmount - bill.AmountPaid;

        await _context.SaveChangesAsync();

        return Json(new
        {
            id = item.Id,
            itemName = item.ItemName,
            quantity = item.Quantity,
            unitPrice = item.UnitPrice,
            total = item.Total,
            billId = bill.Id,
            billTotal = bill.Total,
            netAmount = bill.NetAmount,
            remaining = bill.RemainingAmount
        });
    }




    [HttpPost]
    public async Task<IActionResult> DeleteItem(int id, int billId)
    {
        var bill = await _context.Bills
            .Include(b => b.BillItems)
            .FirstOrDefaultAsync(b => b.Id == billId);

        if (bill == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);
        if (bill.CreatedByUserId != userId && !User.IsInRole("Admin"))
            return Unauthorized();

        var item = bill.BillItems.FirstOrDefault(i => i.Id == id);
        if (item == null)
            return NotFound();

        _context.BillItems.Remove(item);

        bill.Total = bill.BillItems.Where(i => i.Id != id).Sum(i => i.Total);
        bill.NetAmount = bill.Total - bill.Discount;
        bill.RemainingAmount = bill.NetAmount - bill.AmountPaid;

        await _context.SaveChangesAsync();

        return Json(new
        {
            billTotal = bill.Total,
            netAmount = bill.NetAmount,
            remaining = bill.RemainingAmount
        });
    }
    public IActionResult CustomerBills(int customerId)
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
