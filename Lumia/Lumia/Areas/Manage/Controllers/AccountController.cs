using Lumia.Business.CustomExceptions.Account;
using Lumia.Business.Services.Interfaces;
using Lumia.Business.ViewModel;
using Lumia.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountService accountService,UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel vm)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _accountService.Login(vm);
            }
            catch (InvalidCredentialException ex)
            {
                ModelState.AddModelError(ex.Property,ex.Message);
                return View();
                
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("index","Dashboard");
        }


        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser
            {
                FullName = "Mehemmed Memmedov",
                UserName = "SuperAdmin",
            };

            await _userManager.CreateAsync(user, "Admin123@");
            await _userManager.AddToRoleAsync(user, "SuperAdmin");

            return Ok("Yarandi");
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("Yarandi");
        }


    }
}
