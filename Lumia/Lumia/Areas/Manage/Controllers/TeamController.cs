using Lumia.Business.CustomExceptions.Team;
using Lumia.Business.Services.Interfaces;
using Lumia.Core.Models;
using Lumia.Data.DAL;
using Lumia.PaginatedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Lumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly AppDbContext _appDb;

        public TeamController(ITeamService teamService,AppDbContext appDb)
        {
            _teamService = teamService;
            _appDb = appDb;
        }
        public async Task<IActionResult> Index(int page =1)
        {
            var query = _appDb.Teams.AsQueryable();
            PaginatedList<Team> paginatedList = new PaginatedList<Team>(query.Skip((page - 1) * 2).Take(2).ToList(), page, query.ToList().Count, 2);
            if(page > paginatedList.TotalPageCount)
            {
                paginatedList = new PaginatedList<Team>(query.Skip((page - 1) * 2).Take(2).ToList(), page, query.ToList().Count, 2);
            }
            //var team = await _teamService.GetAllAsync();
            return View(paginatedList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            if (!ModelState.IsValid) return View(team);

            try
            {
                await _teamService.CreateAsync(team);
            }
            catch (ContentTypeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();

            }
            catch (FileLengthException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();

            }
            catch (ImageFileRequiredException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();

            }
            catch (TeamNotFoundException)
            {

                return View("Error");

            }

            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var exist = await _teamService.GetByIdAsync(id);
            if (exist == null) return View("Error");
            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Team team)
        {
            if (!ModelState.IsValid) return View(team);

            try
            {
                await _teamService.UpdateAsync(team);
            }
            catch (ContentTypeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();

            }
            catch (FileLengthException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();

            }
            catch (ImageFileRequiredException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();

            }
            catch (TeamNotFoundException)
            {

                return View("Error");

            }

            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _teamService.GetByIdAsync(id);
            if (exist == null) return View("Error");
            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Team team)
        {
            try
            {
                await _teamService.DeleteAsync(team.Id);
            }
            catch (TeamNotFoundException)
            {

                return View("Error");

            }

            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SoftDelete(int id)
        {
            var exist = await _teamService.GetByIdAsync(id);
            if (exist == null) return View("Error");

            try
            {
                await _teamService.SoftDelete(exist.Id);
            }
            catch (TeamNotFoundException)
            {

                return View("Error");

            }

            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}
