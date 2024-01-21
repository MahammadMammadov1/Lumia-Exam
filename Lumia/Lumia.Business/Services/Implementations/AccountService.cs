using Lumia.Business.CustomExceptions.Account;
using Lumia.Business.Services.Interfaces;
using Lumia.Business.ViewModel;
using Lumia.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser > userManager ,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(AdminLoginViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null) throw new InvalidCredentialException("","invalid username or password");

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);
            if (!result.Succeeded) throw new InvalidCredentialException("", "invalid username or password");
        }
    }
}
