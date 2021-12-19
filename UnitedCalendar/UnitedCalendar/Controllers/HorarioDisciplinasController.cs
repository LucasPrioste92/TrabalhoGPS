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
    public class HorarioDisciplinasController : Controller
    {
        private readonly UnitedDB _context;

        public HorarioDisciplinasController(UnitedDB context)
        {
            _context = context;
        }

        // GET: HorarioDisciplinas
        public async Task<IActionResult> Index()
        {
            var unitedDB = _context.HorarioDisciplina.Include(h => h.IdDisciplinaNavigation).Include(h => h.IdHorarioNavigation);
            return View(await unitedDB.ToListAsync());
        }

        // GET: HorarioDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioDisciplina = await _context.HorarioDisciplina
                .Include(h => h.IdDisciplinaNavigation)
                .Include(h => h.IdHorarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horarioDisciplina == null)
            {
                return NotFound();
            }

            return View(horarioDisciplina);
        }

        // GET: HorarioDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplina, "Id", "Local");
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id");
            return View();
        }

        // POST: HorarioDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDisciplina,IdHorario,Id")] HorarioDisciplina horarioDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplina, "Id", "Local", horarioDisciplina.IdDisciplina);
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", horarioDisciplina.IdHorario);
            return View(horarioDisciplina);
        }

        // GET: HorarioDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioDisciplina = await _context.HorarioDisciplina.FindAsync(id);
            if (horarioDisciplina == null)
            {
                return NotFound();
            }
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplina, "Id", "Local", horarioDisciplina.IdDisciplina);
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", horarioDisciplina.IdHorario);
            return View(horarioDisciplina);
        }

        // POST: HorarioDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDisciplina,IdHorario,Id")] HorarioDisciplina horarioDisciplina)
        {
            if (id != horarioDisciplina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioDisciplinaExists(horarioDisciplina.Id))
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
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplina, "Id", "Local", horarioDisciplina.IdDisciplina);
            ViewData["IdHorario"] = new SelectList(_context.Horario, "Id", "Id", horarioDisciplina.IdHorario);
            return View(horarioDisciplina);
        }

        // GET: HorarioDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioDisciplina = await _context.HorarioDisciplina
                .Include(h => h.IdDisciplinaNavigation)
                .Include(h => h.IdHorarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horarioDisciplina == null)
            {
                return NotFound();
            }

            return View(horarioDisciplina);
        }

        // POST: HorarioDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horarioDisciplina = await _context.HorarioDisciplina.FindAsync(id);
            _context.HorarioDisciplina.Remove(horarioDisciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioDisciplinaExists(int id)
        {
            return _context.HorarioDisciplina.Any(e => e.Id == id);
        }
    }
}
