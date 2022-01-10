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
using UnitedCalendar.ViewModels;

namespace UnitedCalendar.Controllers
{
    [Authorize(Roles = "Professor,Estudante")]
    public class HorariosController : Controller
    {
        private readonly UnitedCalendarDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public HorariosController(UnitedCalendarDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            var horarioExiste = _context.Horario
                            .Where(u => u.UserId == userAtual.Id)
                            .Any();

            if (!horarioExiste) //O horario do utilizador ainda nao foi criado
            {
                Horario horario = new Horario();
                horario.UserId = userAtual.Id;
                horario.Publico = false;

                _context.Horario.Add(horario);
                _context.SaveChanges();
            }

            var model = new HorarioGestaoViewModel();
            

            model.Horario = await _context.Horario
                            .Where(u => u.UserId == userAtual.Id)
                            .FirstAsync();


            model.User = userAtual;
            if (userAtual.CursoIdCurso != null)
            {
                var cursoGet = await _context.Curso
                                .Where(u => u.IdCurso == userAtual.CursoIdCurso)
                                .FirstOrDefaultAsync();
                model.User.Curso = cursoGet;
            }


            var horarioDisciplina = await _context.HorarioDisciplina
                                            .Where(m => m.HorarioId == model.Horario.IdHorario)
                                            .ToListAsync();

            foreach (var discId in horarioDisciplina)
            {
                var disc = await _context.Disciplina
                                    .Where(t => t.IdDisciplina == discId.DisciplinaId)
                                    .FirstAsync();

                model.Disciplinas.Add(disc);
            }

            model.AtividadeExtras = await _context.AtividadeExtra
                                            .Where(m => m.HorarioIdHorario == model.Horario.IdHorario)
                                            .ToListAsync();

            model.Gabinetes = await _context.Gabinete
                                            .Where(m => m.HorarioIdHorario == model.Horario.IdHorario)
                                            .ToListAsync();



            return View(model);
        }


        public async Task<IActionResult> GerirDisciplinas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            var horarioExiste = _context.Horario
                            .Where(u => u.UserId == userAtual.Id)
                            .Any();

            if (!horarioExiste)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                            .Where(u => u.UserId == userAtual.Id)
                            .FirstAsync();


            ViewBag.idUser = userAtual.Id;
            ViewBag.idHorario = horario.IdHorario;

            var model = new List<AdicionarDisciplinaViewModel>();
            
            var disciplinas = await _context.Disciplina
                                            .Where(d => d.CursoIdCurso == userAtual.CursoIdCurso)
                                            .ToListAsync(); //obter Lista dos tipos de teste disponiveis

            foreach (var disc in disciplinas)
            {
                var discAdd = new AdicionarDisciplinaViewModel()
                {
                    Disc = disc
                };

                if (await DiscIsSelectedAsync(disc.IdDisciplina, horario.IdHorario))
                    discAdd.IsSelected = true;
                else
                    discAdd.IsSelected = false;

                model.Add(discAdd);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GerirDisciplinas(List<AdicionarDisciplinaViewModel> model, int id)
        {
            Horario horario;

            var user = await userManager.GetUserAsync(User); //obter o utilizador atual logado
            //O utilizador logado é um Gestor, só pode ver editar os seus laboratorios
            horario = await _context.Horario
                .Where(m => m.UserId == user.Id)
                .FirstOrDefaultAsync(m => m.IdHorario == id);

            if (horario == null)
                return NotFound();

            HorarioDisciplina horarioDisciplina = new HorarioDisciplina();

            for (int i = 0; i < model.Count; i++)
            {
                if (model[i].IsSelected && !(await DiscIsSelectedAsync(model[i].Disc.IdDisciplina, id))) //Adcionar a selecao
                {
                    horarioDisciplina.Id = 0; //Vai ser incrementado automaticamente
                    horarioDisciplina.HorarioId = id;
                    horarioDisciplina.DisciplinaId = model[i].Disc.IdDisciplina;
                    var resultado = await _context.HorarioDisciplina.AddAsync(horarioDisciplina);
                    await resultado.Context.SaveChangesAsync();
                }
                else if (!model[i].IsSelected && (await DiscIsSelectedAsync(model[i].Disc.IdDisciplina, id)))
                { //Remover a selecao
                    horarioDisciplina = await _context.HorarioDisciplina
                                    .Where(m => m.DisciplinaId == model[i].Disc.IdDisciplina && m.HorarioId == id)
                                    .FirstAsync();

                    _context.HorarioDisciplina.Remove(horarioDisciplina);
                }
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> HorarioVisibilidade(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            var horarioExiste = _context.Horario
                            .Where(u => u.UserId == userAtual.Id)
                            .Any();

            if (!horarioExiste)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                            .Where(u => u.UserId == userAtual.Id)
                            .FirstAsync();

            if(horario.Publico)
                horario.Publico = false;
            else
                horario.Publico = true;

            _context.Horario.Update(horario);
            await _context.SaveChangesAsync();
            

            return RedirectToAction("Index");
        }


        // GET: Horarios/Edit/5
        public async Task<IActionResult> AdicionarCurso(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            if (userAtual.Id != id)
                return NotFound();


            ViewBag.idUser = userAtual.Id;

            var idFaculdade = await _context.Faculdade
                                        .Where(f => f.Nome == userAtual.Escola)
                                        .FirstOrDefaultAsync();

            var model = new AddCursoViewModel();

            ViewData["CursoIdCurso"] = new SelectList(_context.Curso
                                            .Where(c => c.FaculdadeIdFaculdade == idFaculdade.IdFaculdade)
                                            .ToList(), "IdCurso", "Nome", model.idCurso);
            return View(model);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarCurso(AddCursoViewModel model,string id)
        {
            var userAtual = await userManager.GetUserAsync(User); //obter o utilizador atual logado

            if (id != userAtual.Id)
            {
                return NotFound();
            }

            userAtual.CursoIdCurso = model.idCurso;
            await userManager.UpdateAsync(userAtual);



            return RedirectToAction("Index");
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.IdHorario == id);
        }

        private async Task<bool> DiscIsSelectedAsync(int IdDisc, int IdHorario)
        {
            var resultado = await _context.HorarioDisciplina
                                    .Where(t => t.DisciplinaId == IdDisc && t.HorarioId == IdHorario)
                                    .AnyAsync();

            if (resultado)
                return true;

            return false;
        }
    }
}
