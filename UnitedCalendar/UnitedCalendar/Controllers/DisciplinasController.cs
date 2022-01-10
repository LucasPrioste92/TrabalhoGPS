using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitedCalendar.Common;
using UnitedCalendar.Data;
using UnitedCalendar.Models;
using UnitedCalendar.ViewModels;

namespace UnitedCalendar.Controllers
{
    [Authorize(Roles = "Admins,Funcionario")]
    public class DisciplinasController : Controller
    {
        private readonly UnitedCalendarDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;

        public DisciplinasController(UnitedCalendarDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.roleManager = roleManager;
        }

        // GET: Disciplinas
        public async Task<IActionResult> Index()
        {
            var unitedCalendarDbContext = _context.Disciplina.Include(d => d.Curso);
            return View(await unitedCalendarDbContext.ToListAsync());
        }

        // GET: Disciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.IdDisciplina == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public IActionResult Create()
        {
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            ViewData["CursoIdCurso"] = new SelectList(_context.Curso, "IdCurso", "Nome");
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDisciplina,Nome,Local,Turma,DiaSemana,HoraComeco,HoraTermino,CursoIdCurso")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            ViewData["CursoIdCurso"] = new SelectList(_context.Curso, "IdCurso", "Nome", disciplina.CursoIdCurso);
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            ViewData["CursoIdCurso"] = new SelectList(_context.Curso, "IdCurso", "Nome", disciplina.CursoIdCurso);
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDisciplina,Nome,Local,Turma,DiaSemana,HoraComeco,HoraTermino,CursoIdCurso")] Disciplina disciplina)
        {
            if (id != disciplina.IdDisciplina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.IdDisciplina))
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
            ViewData["CursoIdCurso"] = new SelectList(_context.Curso, "IdCurso", "Nome", disciplina.CursoIdCurso);
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.IdDisciplina == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            _context.Disciplina.Remove(disciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplina.Any(e => e.IdDisciplina == id);
        }

        private List<DiaSemana> GetDias()
        {
            var tipos = new List<DiaSemana>();
            tipos.Add(new DiaSemana() { Id = Constantes.Domingo, Nome = Constantes.Domingo });
            tipos.Add(new DiaSemana() { Id = Constantes.Segunda, Nome = Constantes.Segunda });
            tipos.Add(new DiaSemana() { Id = Constantes.Terca, Nome = Constantes.Terca });
            tipos.Add(new DiaSemana() { Id = Constantes.Quarta, Nome = Constantes.Quarta });
            tipos.Add(new DiaSemana() { Id = Constantes.Quinta, Nome = Constantes.Quinta });
            tipos.Add(new DiaSemana() { Id = Constantes.Sexta, Nome = Constantes.Sexta });
            tipos.Add(new DiaSemana() { Id = Constantes.Sabado, Nome = Constantes.Sabado });

            return tipos;
        }
    }
}
