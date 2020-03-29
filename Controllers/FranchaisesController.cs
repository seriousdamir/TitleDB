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
    [Authorize(Roles="admin, user")]
    public class FranchaisesController : Controller
    {
        private readonly TitleDBContext _context;

        public FranchaisesController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: Franchaises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Franchaise.ToListAsync());
        }

        // GET: Franchaises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchaise = await _context.Franchaise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (franchaise == null)
            {
                return NotFound();
            }

            //return View(franchaise);
            return RedirectToAction("Index", "Titles", new { id = franchaise.Id, name = franchaise.Name });
        }

        // GET: Franchaises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchaises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Franchaise franchaise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchaise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchaise);
        }

        // GET: Franchaises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchaise = await _context.Franchaise.FindAsync(id);
            if (franchaise == null)
            {
                return NotFound();
            }
            return View(franchaise);
        }

        // POST: Franchaises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Franchaise franchaise)
        {
            if (id != franchaise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchaise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchaiseExists(franchaise.Id))
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
            return View(franchaise);
        }

        // GET: Franchaises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchaise = await _context.Franchaise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (franchaise == null)
            {
                return NotFound();
            }

            return View(franchaise);
        }

        // POST: Franchaises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var franchaise = await _context.Franchaise.FindAsync(id);
            _context.Franchaise.Remove(franchaise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchaiseExists(int id)
        {
            return _context.Franchaise.Any(e => e.Id == id);
        }
    }
}
