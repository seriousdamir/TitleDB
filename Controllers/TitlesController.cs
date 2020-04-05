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
    [Authorize(Roles = "admin, user")]
    public class TitlesController : Controller
    {
        private readonly TitleDBContext _context;

        public TitlesController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: Titles
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) return RedirectToAction("Franchaises", "Index");
            ViewBag.FranchaiseId = id;
            ViewBag.FranchaiseName = name;
            var titlesByFranchaise = _context.Title.Where(p => p.FranchaiseId == id).Include(p => p.Franchaise).Include(p => p.Studio);

            return View(await titlesByFranchaise.ToListAsync());
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title
                .Include(t => t.Franchaise)
                .Include(t => t.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            ViewData["FranchaiseId"] = new SelectList(_context.Franchaise, "Id", "Name");
            ViewData["StudioId"] = new SelectList(_context.Studio, "Id", "Name");
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StudioId,StartYear,Ongoing,Mark,FranchaiseId")] Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchaiseId"] = new SelectList(_context.Franchaise, "Id", "Name", title.FranchaiseId);
            ViewData["StudioId"] = new SelectList(_context.Studio, "Id", "Name", title.StudioId);
            return View(title);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            ViewData["FranchaiseId"] = new SelectList(_context.Franchaise, "Id", "Name", title.FranchaiseId);
            ViewData["StudioId"] = new SelectList(_context.Studio, "Id", "Name", title.StudioId);
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StudioId,StartYear,Ongoing,Mark,FranchaiseId")] Title title)
        {
            if (id != title.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.Id))
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
            ViewData["FranchaiseId"] = new SelectList(_context.Franchaise, "Id", "Name", title.FranchaiseId);
            ViewData["StudioId"] = new SelectList(_context.Studio, "Id", "Name", title.StudioId);
            return View(title);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title
                .Include(t => t.Franchaise)
                .Include(t => t.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var title = await _context.Title.FindAsync(id);
            _context.Title.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(int id)
        {
            return _context.Title.Any(e => e.Id == id);
        }
    }
}
