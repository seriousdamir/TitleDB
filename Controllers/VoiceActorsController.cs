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
    public class VoiceActorsController : Controller
    {
        private readonly TitleDBContext _context;

        public VoiceActorsController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: VoiceActors
        public async Task<IActionResult> Index()
        {
            return View(await _context.VoiceActors.ToListAsync());
        }

        // GET: VoiceActors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiceActors = await _context.VoiceActors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiceActors == null)
            {
                return NotFound();
            }

            return View(voiceActors);
        }

        // GET: VoiceActors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VoiceActors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateOfBirth")] VoiceActors voiceActors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voiceActors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voiceActors);
        }

        // GET: VoiceActors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiceActors = await _context.VoiceActors.FindAsync(id);
            if (voiceActors == null)
            {
                return NotFound();
            }
            return View(voiceActors);
        }

        // POST: VoiceActors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfBirth")] VoiceActors voiceActors)
        {
            if (id != voiceActors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voiceActors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoiceActorsExists(voiceActors.Id))
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
            return View(voiceActors);
        }

        // GET: VoiceActors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiceActors = await _context.VoiceActors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiceActors == null)
            {
                return NotFound();
            }

            return View(voiceActors);
        }

        // POST: VoiceActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voiceActors = await _context.VoiceActors.FindAsync(id);
            _context.VoiceActors.Remove(voiceActors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoiceActorsExists(int id)
        {
            return _context.VoiceActors.Any(e => e.Id == id);
        }
    }
}
