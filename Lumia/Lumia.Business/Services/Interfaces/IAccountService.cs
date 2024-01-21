using Lumia.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Login(AdminLoginViewModel vm);
    }
}
