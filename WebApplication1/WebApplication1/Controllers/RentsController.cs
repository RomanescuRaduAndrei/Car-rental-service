using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class RentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index()
        {
            return _context.Rents != null ?
                        View(await _context.Rents.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Rents'  is null.");
        }

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rents == null)
            {
                return NotFound();
            }

            return View(rents);
        }

        // GET: Rents/Create
        [Authorize(Roles = "Admin,Client")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Client")]
        public async Task<IActionResult> Create([Bind("Id,RentBegin,RentEnd,PayMethod")] Rents rents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rents);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents.FindAsync(id);
            if (rents == null)
            {
                return NotFound();
            }
            return View(rents);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentBegin,RentEnd,PayMethod")] Rents rents)
        {
            if (id != rents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentsExists(rents.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rents);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rents == null)
            {
                return NotFound();
            }

            return View(rents);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rents'  is null.");
            }
            var rents = await _context.Rents.FindAsync(id);
            if (rents != null)
            {
                _context.Rents.Remove(rents);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentsExists(int id)
        {
            return (_context.Rents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
