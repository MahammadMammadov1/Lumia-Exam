using Lumia.Business.Services.Interfaces;
using Lumia.Core.Models;

namespace Lumia.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<List<Setting>> GetSettings()
        {
            return await _settingService.GetAllAsync();
        }
    }
}
