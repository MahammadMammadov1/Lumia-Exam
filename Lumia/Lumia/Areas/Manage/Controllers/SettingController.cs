using Lumia.Business.Services.Implementations;
using Lumia.Business.Services.Interfaces;
using Lumia.Core.Models;
using Lumia.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Lumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly ISettingRepository _settingRepository;

        public SettingController(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<IActionResult> Index()
        {
            var teams = await _settingRepository.GetAllAsync();
            return View(teams);
        }

        public async Task<IActionResult> Update(int id)
        {
            var exist = await _settingRepository.GetByIdAsync(x=>x.Id == id);
            if (exist == null) return View("Error");
            return View(exist);
        }

        [HttpPost]
        public   async Task<IActionResult> Update(Setting setting)
        {
            var exist = await _settingRepository.GetByIdAsync(x=>x.Id == setting.Id);
            if (exist == null) return View("Error");

            exist.Value = setting.Value;
            await _settingRepository.CommitAsync();
            

            

            return RedirectToAction("Index");
        }
    }
}
