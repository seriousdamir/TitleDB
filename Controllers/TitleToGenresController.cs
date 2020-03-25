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
    public class TitleToGenresController : Controller
    {
        private readonly TitleDBContext _context;

        public TitleToGenresController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: TitleToGenres
        public async Task<IActionResult> Index()
        {
            var titleDBContext = _context.TitleToGenre.Include(t => t.Genre).Include(t => t.Title);
            return View(await titleDBContext.ToListAsync());
        }

        // GET: TitleToGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titleToGenre = await _context.TitleToGenre
                .Include(t => t.Genre)
                .Include(t => t.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titleToGenre == null)
            {
                return NotFound();
            }

            return View(titleToGenre);
        }

        // GET: TitleToGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            return View();
        }

        // POST: TitleToGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,GenreId,Id")] TitleToGenre titleToGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titleToGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", titleToGenre.GenreId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", titleToGenre.TitleId);
            return View(titleToGenre);
        }

        // GET: TitleToGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titleToGenre = await _context.TitleToGenre.FindAsync(id);
            if (titleToGenre == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", titleToGenre.GenreId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", titleToGenre.TitleId);
            return View(titleToGenre);
        }

        // POST: TitleToGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,GenreId,Id")] TitleToGenre titleToGenre)
        {
            if (id != titleToGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titleToGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleToGenreExists(titleToGenre.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", titleToGenre.GenreId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", titleToGenre.TitleId);
            return View(titleToGenre);
        }

        // GET: TitleToGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titleToGenre = await _context.TitleToGenre
                .Include(t => t.Genre)
                .Include(t => t.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titleToGenre == null)
            {
                return NotFound();
            }

            return View(titleToGenre);
        }

        // POST: TitleToGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titleToGenre = await _context.TitleToGenre.FindAsync(id);
            _context.TitleToGenre.Remove(titleToGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleToGenreExists(int id)
        {
            return _context.TitleToGenre.Any(e => e.Id == id);
        }
    }
}
