using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitedCalendar.Models;

namespace UnitedCalendar.Controllers
{
    public class GabinetesController : Controller
    {
        private readonly UnitedDB _context;

        public GabinetesController(UnitedDB context)
        {
            _context = context;
        }

        // GET: Gabinetes
        public async Task<IActionResult> Index()
        {
            var unitedDB = _context.Gabinete.Include(g => g.IdHorarioNavigation).Include(g => g.IdUserNavigation);
            return View(await unitedDB.ToListAsync());
        }

        // GET: Gabinetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gabinete = await _context.Gabinete
                .Include(g => g.IdHorarioNavigation)
                .Include(g => g.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gabinete == null)
            {
                return NotFound();
            }

            return View(gabinete);
        }

        // GET: Gabinetes/Create
        public IActionResult Create()
        {
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id");
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Gabinetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdHorario,IdUser,HoraTermino,HoraComeco,Local,DiaSemana,Descricao")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gabinete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", gabinete.IdHorario);
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email", gabinete.IdUser);
            return View(gabinete);
        }

        // GET: Gabinetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gabinete = await _context.Gabinete.FindAsync(id);
            if (gabinete == null)
            {
                return NotFound();
            }
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", gabinete.IdHorario);
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email", gabinete.IdUser);
            return View(gabinete);
        }

        // POST: Gabinetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdHorario,IdUser,HoraTermino,HoraComeco,Local,DiaSemana,Descricao")] Gabinete gabinete)
        {
            if (id != gabinete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gabinete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GabineteExists(gabinete.Id))
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
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", gabinete.IdHorario);
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email", gabinete.IdUser);
            return View(gabinete);
        }

        // GET: Gabinetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gabinete = await _context.Gabinete
                .Include(g => g.IdHorarioNavigation)
                .Include(g => g.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gabinete == null)
            {
                return NotFound();
            }

            return View(gabinete);
        }

        // POST: Gabinetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gabinete = await _context.Gabinete.FindAsync(id);
            _context.Gabinete.Remove(gabinete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GabineteExists(int id)
        {
            return _context.Gabinete.Any(e => e.Id == id);
        }
    }
}
