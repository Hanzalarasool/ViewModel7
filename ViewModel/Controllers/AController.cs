using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViewModel.Data;
using ViewModel.Models;
using ViewModel.Models.View;

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
        //public async Task<IActionResult> AB()
        //{
        //    return _context.A != null ?
        //                View(await _context.A.ToListAsync()) :
        //                Problem("Entity set 'ViewModelContext.A'  is null.");
        //}

        //GET: AB
        public IActionResult AB()
        {
            //var ab = _context.C.Select(c => new AB()
            //{

            //    A = c.A,
            //    B = c.B,

            //}).ToList();
            var ab2 = new List<AB>();
            //query A and B table, 
            var Alist = _context.A.ToList();
            var Blist = _context.B.ToList();
            //use foreach statement to filter data. And Add A and B to the ab list.
            foreach (var item in Alist)
            {
                var newab = new AB()
                {
                    A = item
                };
                //add the new item into the list.
                ab2.Add(newab);
            }
            foreach (var item in Blist)
            {
                var newab = new AB()
                {
                    B = item
                };
                //add the new item into the list.
                ab2.Add(newab);
            }
            return View(ab2); // return the list to the view page.

        }
        public IActionResult AB2()
        {
            //define a variable to store the return data.
            var ab2 = new List<ABViewModel>();
            //query A and B table,
            var Alist = _context.A.ToList();
            var Blist = _context.B.ToList();
            //use foreach statement to filter data. And Add A and B to the ab list.
            foreach (var item in Alist)
            {
                var newab = new ABViewModel()
                {
                    One = item.One,
                    Three = item.Three,
                    Two = item.Two
                };
                //add the new item into the list.
                ab2.Add(newab);
            }
            foreach (var item in Blist)
            {
                var newab = new ABViewModel()
                {
                    One = item.One,
                    Three = item.Three,
                    Two = item.Two
                };
                //add the new item into the list.
                ab2.Add(newab);
            }


            return View(ab2); // return the list to the view page.
        }
        public IActionResult AB5()
        {
           
            //query A and B table,
            var Alist = _context.A.Include(c=>c.B).ToList(); //  A list includes B values if there is any
          


            return View(Alist); // return the list to the view page.
        }

        ////GET: AB
        //public IActionResult AB2()
        //{
        //    //define a variable to store the return data.
        //    var ab2 = new List<AB>();
        //    //query A and B table, 
        //    var Alist = _context.A.ToList();
        //    var Blist = _context.B.ToList();
        //    //use foreach statement to filter data. And Add A and B to the ab list.
        //    foreach (var item in Alist)
        //    {
        //        var newab = new AB()
        //        {
        //            A = item
        //        };
        //        //add the new item into the list.
        //        ab2.Add(newab);
        //    }
        //    return View(ab2); // return the list to the view page.
        //}

        //GET: AB
        //public IActionResult AB2()
        //{
        //    //define a variable to store the return data.
        //    var ab2 = new List<AB>();
        //    //query A and B table, 
        //    var Alist = _context.A.ToList();
        //    var Blist = _context.B.ToList();
        //    //use foreach statement to filter data. And Add A and B to the ab list.
        //    foreach (var item in Alist)
        //    {
        //        var newab = new AB()
        //        {
        //            A = item
        //          //B = item                    2nd change: did not work
        //        };
        //        //add the new item into the list.
        //        ab2.Add(newab);
        //    }

        //    //foreach (var item in Blist)         1st change: did not work
        //    //{
        //    //    var newab = new AB()
        //    //    {
        //    //        B = item
        //    //    };
        //    //    //add the new item into the list.
        //    //    ab2.Add(newab);
        //    //}



        //    return View(ab2); // return the list to the view page.
        //}



        //GET: AB3
        //public IActionResult AB3()
        //{
        //    //define a variable to store the return data.
        //    var ab2 = new List<AB>();
        //    //query A and B table, 
        //    var Alist = _context.A.ToList();
        //    var Blist = _context.B.ToList();
        //    var ABList = Alist.Select(a => new AB
        //    {
        //        A = a,
        //        B = Blist.FirstOrDefault(b => b.???? = a.????)
        //    }).ToList();

        //    //use foreach statement to filter data. And Add A and B to the ab list.
        //    foreach (var item in Alist)
        //    {
        //        var newab = new AB()
        //        {
        //            A = item
        //        };
        //        //add the new item into the list.
        //        ab2.Add(newab);
        //    }
        //    return View(ab2); // return the list to the view page.
        //}

        //GET: AB3a                                     original - Bruce 1
        //var Alist = _dbContext.A.ToList();
        //var Blist = _dbContext.B.ToList();
        //var ABList = Alist.Select(a => new AB
        //{
        //    A = a,
        //    B = Blist.FirstOrDefault(b => b.???? = a.????)
        //}).ToList();


        //GET: AB3b (Join)                                original - Bruce 2
        //public IActionResult AB4()
        //var ABList = _context.A.Join(_context.B,
        //   a => a.????,
        //   b => b.????,
        //   (a, b) => new AB
        //   {
        //       A = a,
        //       B = b
        //   }).ToList();


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
