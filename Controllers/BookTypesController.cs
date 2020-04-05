using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TDB;
using Microsoft.AspNetCore.Authorization;

namespace TDB.Controllers
{
    [Authorize(Roles = "admin")]
    public class BookTypesController : Controller
    {
        private readonly TitleDBContext _context;

        public BookTypesController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: BookTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookTypes.ToListAsync());
        }

        // GET: BookTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTypes = await _context.BookTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookTypes == null)
            {
                return NotFound();
            }

            return View(bookTypes);
        }

        // GET: BookTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] BookTypes bookTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookTypes);
        }

        // GET: BookTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTypes = await _context.BookTypes.FindAsync(id);
            if (bookTypes == null)
            {
                return NotFound();
            }
            return View(bookTypes);
        }

        // POST: BookTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] BookTypes bookTypes)
        {
            if (id != bookTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTypesExists(bookTypes.Id))
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
            return View(bookTypes);
        }

        // GET: BookTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTypes = await _context.BookTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookTypes == null)
            {
                return NotFound();
            }

            return View(bookTypes);
        }

        // POST: BookTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTypes = await _context.BookTypes.FindAsync(id);
            _context.BookTypes.Remove(bookTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTypesExists(int id)
        {
            return _context.BookTypes.Any(e => e.Id == id);
        }
    }
}
