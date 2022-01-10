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
    [Authorize(Roles = "Professor")]
    public class GabinetesController : Controller
    {
        private readonly UnitedCalendarDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public GabinetesController(UnitedCalendarDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // GET: Gabinetes
        public async Task<IActionResult> Index()
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            var model = await _context.Gabinete
                                    .Where(a => a.UserId == userAtual.Id)
                                    .ToListAsync();

            ViewBag.nome = userAtual.Nome;

            return View(model);
        }


        // GET: Gabinetes/Create
        public IActionResult Create()
        {
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View();
        }

        // POST: Gabinetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGabinete,Nome,Descricao,Local,DiaSemana,HoraComeco,HoraTermino,IdHorario,UserId")] Gabinete gabinete)
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            gabinete.UserId = userAtual.Id;

            var horario = await _context.Horario.Where(m => m.UserId == userAtual.Id).FirstAsync();
            gabinete.HorarioIdHorario = horario.IdHorario;
            ModelState.Clear();
            TryValidateModel(gabinete);

            if (ModelState.IsValid)
            {
                _context.Add(gabinete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View(gabinete);
        }

        // GET: Gabinetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            var gabinete = await _context.Gabinete
                                        .Where(a => a.UserId == userAtual.Id)
                                        .FirstAsync(a => a.IdGabinete == id);
            if (gabinete == null)
            {
                return NotFound();
            }

            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View(gabinete);
        }

        // POST: Gabinetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGabinete,Nome,Descricao,Local,DiaSemana,HoraComeco,HoraTermino")] Gabinete gabinete)
        {
            if (id != gabinete.IdGabinete)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            gabinete.UserId = userAtual.Id;

            var horario = await _context.Horario.Where(m => m.UserId == userAtual.Id).FirstAsync();
            gabinete.HorarioIdHorario = horario.IdHorario;
            ModelState.Clear();
            TryValidateModel(gabinete);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gabinete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GabineteExists(gabinete.IdGabinete))
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
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View(gabinete);
        }

        // GET: Gabinetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            var gabinete = await _context.Gabinete
                                        .Where(a => a.UserId == userAtual.Id)
                                        .FirstAsync(a => a.IdGabinete == id);


            if (gabinete == null)
                return NotFound();

            return View(gabinete);
        }

        // POST: Gabinetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            var gabinete = await _context.Gabinete
                                        .Where(a => a.UserId == userAtual.Id)
                                        .FirstAsync(a => a.IdGabinete == id);

            if (gabinete == null)
                return NotFound();


            _context.Gabinete.Remove(gabinete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GabineteExists(int id)
        {
            return _context.Gabinete.Any(e => e.IdGabinete == id);
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
