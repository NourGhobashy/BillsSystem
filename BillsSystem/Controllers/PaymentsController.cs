using BillsSystem.Models;
using BillsSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillsSystem.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض كل الدفعات (لاحقًا يمكن تقييده بمستخدم أو فاتورة)
        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments
                .Include(p => p.Bill)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();

            return View(payments);
        }

        // عرض نموذج إضافة دفعة
        public IActionResult Create(int billId)
        {
            var bill = _context.Bills.FirstOrDefault(b => b.Id == billId);
            if (bill == null)
                return NotFound();

            ViewBag.BillId = billId;
            ViewBag.BillNumber = bill.BillNumber;

            return View();
        }

        // تنفيذ إضافة دفعة
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment payment)
        {
            if (!ModelState.IsValid)
                return View(payment);

            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == payment.BillId);
            if (bill == null)
                return NotFound();

            _context.Payments.Add(payment);

            // تحديث القيم في الفاتورة
            bill.AmountPaid += payment.Amount;
            bill.RemainingAmount = bill.NetAmount - bill.AmountPaid;

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Bills", new { id = payment.BillId });
        }
    }
}
