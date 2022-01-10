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
    [Authorize(Roles = "Estudante,Professor")]
    public class AtividadeExtrasController : Controller
    {
        private readonly UnitedCalendarDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AtividadeExtrasController(UnitedCalendarDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // GET: AtividadeExtras
        public async Task<IActionResult> Index()
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            var model = await _context.AtividadeExtra
                                    .Where(a => a.UserId == userAtual.Id)
                                    .ToListAsync();

            ViewBag.nome = userAtual.Nome;

            return View(model);
        }


        // GET: AtividadeExtras/Create
        public IActionResult Create()
        {
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View();
        }

        // POST: AtividadeExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtividadeExtra,Nome,DiaSemana,HoraComeco,HoraTermino")] AtividadeExtra atividadeExtra)
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            atividadeExtra.UserId = userAtual.Id;

            var horario = await _context.Horario.Where(m => m.UserId == userAtual.Id).FirstAsync();
            atividadeExtra.HorarioIdHorario = horario.IdHorario;
            ModelState.Clear();
            TryValidateModel(atividadeExtra);

            if (ModelState.IsValid)
            {
                _context.Add(atividadeExtra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View(atividadeExtra);
        }

        // GET: AtividadeExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            var atividadeExtra = await _context.AtividadeExtra  
                                        .Where(a => a.UserId == userAtual.Id)
                                        .FirstAsync(a => a.IdAtividadeExtra==id);
            if (atividadeExtra == null)
            {
                return NotFound();
            }

            ViewBag.DiaSemana = new SelectList(GetDias(), "Id", "Nome");
            return View(atividadeExtra);
        }

        // POST: AtividadeExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtividadeExtra,Nome,DiaSemana,HoraComeco,HoraTermino")] AtividadeExtra atividadeExtra)
        {
            if (id != atividadeExtra.IdAtividadeExtra)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            atividadeExtra.UserId = userAtual.Id;

            var horario = await _context.Horario.Where(m => m.UserId == userAtual.Id).FirstAsync();
            atividadeExtra.HorarioIdHorario = horario.IdHorario;
            ModelState.Clear();
            TryValidateModel(atividadeExtra);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividadeExtra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExtraExists(atividadeExtra.IdAtividadeExtra))
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
            return View(atividadeExtra);
        }

        // GET: AtividadeExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            var atividadeExtra = await _context.AtividadeExtra
                                        .Where(a => a.UserId == userAtual.Id)
                                        .FirstAsync(a => a.IdAtividadeExtra == id);

           
            if (atividadeExtra == null)
                return NotFound();


            return View(atividadeExtra);
        }

        // POST: AtividadeExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            var atividadeExtra = await _context.AtividadeExtra
                                        .Where(a => a.UserId == userAtual.Id)
                                        .FirstAsync(a => a.IdAtividadeExtra == id);

            if (atividadeExtra == null)
                return NotFound();

            _context.AtividadeExtra.Remove(atividadeExtra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExtraExists(int id)
        {
            return _context.AtividadeExtra.Any(e => e.IdAtividadeExtra == id);
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
