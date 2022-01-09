using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitedCalendar.Data;
using UnitedCalendar.Models;

namespace UnitedCalendar.Controllers
{
    public class FaculdadesController : Controller
    {
        private readonly UnitedCalendarDbContext _context;

        public FaculdadesController(UnitedCalendarDbContext context)
        {
            _context = context;
        }

        // GET: Faculdades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faculdade.ToListAsync());
        }

        // GET: Faculdades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdade
                .FirstOrDefaultAsync(m => m.IdFaculdade == id);
            if (faculdade == null)
            {
                return NotFound();
            }

            return View(faculdade);
        }

        // GET: Faculdades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculdades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFaculdade,Nome")] Faculdade faculdade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculdade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculdade);
        }

        // GET: Faculdades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdade.FindAsync(id);
            if (faculdade == null)
            {
                return NotFound();
            }
            return View(faculdade);
        }

        // POST: Faculdades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFaculdade,Nome")] Faculdade faculdade)
        {
            if (id != faculdade.IdFaculdade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculdade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaculdadeExists(faculdade.IdFaculdade))
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
            return View(faculdade);
        }

        // GET: Faculdades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdade
                .FirstOrDefaultAsync(m => m.IdFaculdade == id);
            if (faculdade == null)
            {
                return NotFound();
            }

            return View(faculdade);
        }

        // POST: Faculdades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faculdade = await _context.Faculdade.FindAsync(id);
            _context.Faculdade.Remove(faculdade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaculdadeExists(int id)
        {
            return _context.Faculdade.Any(e => e.IdFaculdade == id);
        }
    }
}
