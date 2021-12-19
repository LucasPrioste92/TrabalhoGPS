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
    public class AtividadeExtrasController : Controller
    {
        private readonly UnitedDB _context;

        public AtividadeExtrasController(UnitedDB context)
        {
            _context = context;
        }

        // GET: AtividadeExtras
        public async Task<IActionResult> Index()
        {
            var unitedDB = _context.AtividadeExtra.Include(a => a.IdHorarioNavigation).Include(a => a.IdUserNavigation);
            return View(await unitedDB.ToListAsync());
        }

        // GET: AtividadeExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadeExtra = await _context.AtividadeExtra
                .Include(a => a.IdHorarioNavigation)
                .Include(a => a.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atividadeExtra == null)
            {
                return NotFound();
            }

            return View(atividadeExtra);
        }

        // GET: AtividadeExtras/Create
        public IActionResult Create()
        {
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id");
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: AtividadeExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,IdHorario,Nome,HoraCom,HoraFim,DiaSemana")] AtividadeExtra atividadeExtra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividadeExtra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", atividadeExtra.IdHorario);
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email", atividadeExtra.IdUser);
            return View(atividadeExtra);
        }

        // GET: AtividadeExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadeExtra = await _context.AtividadeExtra.FindAsync(id);
            if (atividadeExtra == null)
            {
                return NotFound();
            }
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", atividadeExtra.IdHorario);
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email", atividadeExtra.IdUser);
            return View(atividadeExtra);
        }

        // POST: AtividadeExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,IdHorario,Nome,HoraCom,HoraFim,DiaSemana")] AtividadeExtra atividadeExtra)
        {
            if (id != atividadeExtra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividadeExtra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExtraExists(atividadeExtra.Id))
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
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", atividadeExtra.IdHorario);
            ViewData["IdUser"] = new SelectList(_context.User, "Id", "Email", atividadeExtra.IdUser);
            return View(atividadeExtra);
        }

        // GET: AtividadeExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadeExtra = await _context.AtividadeExtra
                .Include(a => a.IdHorarioNavigation)
                .Include(a => a.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atividadeExtra == null)
            {
                return NotFound();
            }

            return View(atividadeExtra);
        }

        // POST: AtividadeExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atividadeExtra = await _context.AtividadeExtra.FindAsync(id);
            _context.AtividadeExtra.Remove(atividadeExtra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExtraExists(int id)
        {
            return _context.AtividadeExtra.Any(e => e.Id == id);
        }
    }
}
