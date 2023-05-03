using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViewModel.Data;
using ViewModel.Models;

namespace ViewModel.Controllers
{
    public class AController : Controller
    {
        private readonly ViewModelContext _context;

        public AController(ViewModelContext context)
        {
            _context = context;
        }

        // GET: A
        public async Task<IActionResult> Index()
        {
              return _context.A != null ? 
                          View(await _context.A.ToListAsync()) :
                          Problem("Entity set 'ViewModelContext.A'  is null.");
        }
 
        // GET: AB
        public async Task<IActionResult> AB()
        {
            return _context.A != null ?
                        View(await _context.A.ToListAsync()) :
                        Problem("Entity set 'ViewModelContext.A'  is null.");
        }

        // GET: A/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.A == null)
            {
                return NotFound();
            }

            var a = await _context.A
                .FirstOrDefaultAsync(m => m.Id == id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);
        }

        // GET: A/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: A/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,One,Two,Three")] A a)
        {
            if (ModelState.IsValid)
            {
                _context.Add(a);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(a);
        }

        // GET: A/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.A == null)
            {
                return NotFound();
            }

            var a = await _context.A.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }
            return View(a);
        }

        // POST: A/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,One,Two,Three")] A a)
        {
            if (id != a.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(a);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AExists(a.Id))
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
            return View(a);
        }

        // GET: A/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.A == null)
            {
                return NotFound();
            }

            var a = await _context.A
                .FirstOrDefaultAsync(m => m.Id == id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);
        }

        // POST: A/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.A == null)
            {
                return Problem("Entity set 'ViewModelContext.A'  is null.");
            }
            var a = await _context.A.FindAsync(id);
            if (a != null)
            {
                _context.A.Remove(a);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AExists(int id)
        {
          return (_context.A?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
