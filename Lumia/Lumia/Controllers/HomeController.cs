using Lumia.Core.Repository.Interfaces;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lumia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamRepository _teamRepository;

        public HomeController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _teamRepository.GetAllAsync(x=>x.IsDeleted !=true);
            return View(teams);
        }

        
    }
}