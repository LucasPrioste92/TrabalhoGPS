using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitedCalendar.Data;
using UnitedCalendar.Models;

namespace UnitedCalendar.Controllers
{
    [Authorize(Roles ="Admins,Funcionario")]
    public class CursosController : Controller
    {
        private readonly UnitedCalendarDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;

        public CursosController(UnitedCalendarDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.roleManager = roleManager;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var model = await _context.Curso.ToListAsync();
            foreach (var curso in model)
            {
                curso.Faculdade = _context.Faculdade
                                    .Where(f => f.IdFaculdade == curso.FaculdadeIdFaculdade)
                                    .FirstOrDefault();
            }
               
            return View(model);
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (curso == null)
            {
                return NotFound();
            }
            curso.Faculdade = _context.Faculdade
                                    .Where(f => f.IdFaculdade == curso.FaculdadeIdFaculdade)
                                    .FirstOrDefault();

            return View(curso);
        }

        // GET: Cursos/Create
        public async Task<IActionResult> Create()
        {
            var faculdades = await _context.Faculdade.ToListAsync();
            ViewData["FaculdadeID"] = new SelectList(faculdades, "IdFaculdade", "Nome");

            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurso,Nome,FaculdadeIdFaculdade")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            curso.Faculdade = _context.Faculdade
                                    .Where(f => f.IdFaculdade == curso.FaculdadeIdFaculdade)
                                    .FirstOrDefault();

            var faculdades = await _context.Faculdade.ToListAsync();
            ViewData["FaculdadeID"] = new SelectList(faculdades, "IdFaculdade", "Nome");

            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCurso,Nome,FaculdadeIdFaculdade")] Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.IdCurso))
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
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (curso == null)
            {
                return NotFound();
            }
            curso.Faculdade = _context.Faculdade
                                    .Where(f => f.IdFaculdade == curso.FaculdadeIdFaculdade)
                                    .FirstOrDefault();

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.IdCurso == id);
        }
    }
}
