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
    public class VoiceActingsController : Controller
    {
        private readonly TitleDBContext _context;

        public VoiceActingsController(TitleDBContext context)
        {
            _context = context;
        }

        // GET: VoiceActings
        public async Task<IActionResult> Index()
        {
            var titleDBContext = _context.VoiceActing.Include(v => v.Actor).Include(v => v.Title);
            return View(await titleDBContext.ToListAsync());
        }

        // GET: VoiceActings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiceActing = await _context.VoiceActing
                .Include(v => v.Actor)
                .Include(v => v.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiceActing == null)
            {
                return NotFound();
            }

            return View(voiceActing);
        }

        // GET: VoiceActings/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.VoiceActors, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            return View();
        }

        // POST: VoiceActings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,ActorId,Id")] VoiceActing voiceActing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voiceActing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.VoiceActors, "Id", "Name", voiceActing.ActorId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", voiceActing.TitleId);
            return View(voiceActing);
        }

        // GET: VoiceActings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiceActing = await _context.VoiceActing.FindAsync(id);
            if (voiceActing == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.VoiceActors, "Id", "Name", voiceActing.ActorId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", voiceActing.TitleId);
            return View(voiceActing);
        }

        // POST: VoiceActings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,ActorId,Id")] VoiceActing voiceActing)
        {
            if (id != voiceActing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voiceActing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoiceActingExists(voiceActing.Id))
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
            ViewData["ActorId"] = new SelectList(_context.VoiceActors, "Id", "Name", voiceActing.ActorId);
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name", voiceActing.TitleId);
            return View(voiceActing);
        }

        // GET: VoiceActings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiceActing = await _context.VoiceActing
                .Include(v => v.Actor)
                .Include(v => v.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiceActing == null)
            {
                return NotFound();
            }

            return View(voiceActing);
        }

        // POST: VoiceActings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voiceActing = await _context.VoiceActing.FindAsync(id);
            _context.VoiceActing.Remove(voiceActing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoiceActingExists(int id)
        {
            return _context.VoiceActing.Any(e => e.Id == id);
        }
    }
}
