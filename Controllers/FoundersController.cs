using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TDB;

namespace TDB.Controllers
{
    public class FoundersController : Controller
    {
        private readonly TitleDBContext _context;

        public FoundersController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: Founders
        public async Task<IActionResult> Index()
        {
            var titleDBContext = _context.Founder.Include(f => f.Author).Include(f => f.Title);
            return View(await titleDBContext.ToListAsync());
        }

        // GET: Founders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founder
                .Include(f => f.Author)
                .Include(f => f.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // GET: Founders/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            return View();
        }

        // POST: Founders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,AuthorId,Id")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(founder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", founder.AuthorId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", founder.TitleId);
            return View(founder);
        }

        // GET: Founders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founder.FindAsync(id);
            if (founder == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", founder.AuthorId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", founder.TitleId);
            return View(founder);
        }

        // POST: Founders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,AuthorId,Id")] Founder founder)
        {
            if (id != founder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FounderExists(founder.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", founder.AuthorId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", founder.TitleId);
            return View(founder);
        }

        // GET: Founders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founder
                .Include(f => f.Author)
                .Include(f => f.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // POST: Founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var founder = await _context.Founder.FindAsync(id);
            _context.Founder.Remove(founder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FounderExists(int id)
        {
            return _context.Founder.Any(e => e.Id == id);
        }
    }
}
