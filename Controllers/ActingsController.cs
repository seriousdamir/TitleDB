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
    public class ActingsController : Controller
    {
        private readonly TitleDBContext _context;

        public ActingsController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: Actings
        public async Task<IActionResult> Index()
        {
            var titleDBContext = _context.Acting.Include(a => a.Character).Include(a => a.Title);
            return View(await titleDBContext.ToListAsync());
        }

        // GET: Actings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acting = await _context.Acting
                .Include(a => a.Character)
                .Include(a => a.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acting == null)
            {
                return NotFound();
            }

            return View(acting);
        }

        // GET: Actings/Create
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            return View();
        }

        // POST: Actings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,CharacterId,Id")] Acting acting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Name", acting.CharacterId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", acting.TitleId);
            return View(acting);
        }

        // GET: Actings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acting = await _context.Acting.FindAsync(id);
            if (acting == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Name", acting.CharacterId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", acting.TitleId);
            return View(acting);
        }

        // POST: Actings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,CharacterId,Id")] Acting acting)
        {
            if (id != acting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActingExists(acting.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Name", acting.CharacterId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", acting.TitleId);
            return View(acting);
        }

        // GET: Actings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acting = await _context.Acting
                .Include(a => a.Character)
                .Include(a => a.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acting == null)
            {
                return NotFound();
            }

            return View(acting);
        }

        // POST: Actings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acting = await _context.Acting.FindAsync(id);
            _context.Acting.Remove(acting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActingExists(int id)
        {
            return _context.Acting.Any(e => e.Id == id);
        }
    }
}
