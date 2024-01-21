using Lumia.Business.CustomExceptions.Setting;
using Lumia.Business.Services.Interfaces;
using Lumia.Core.Models;
using Lumia.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<List<Setting>> GetAllAsync()
        {
            return await _settingRepository.GetAllAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return  await _settingRepository.GetByIdAsync(x=>x.Id == id);

        }

        public async Task UpdateAsync(Setting setting)
        {
            var exist = await _settingRepository.GetByIdAsync(x=>x.Id == setting.Id);
            if (exist == null) throw new SettingNotFoundException();

            exist.Value = setting.Value;
            exist.CreatedDate = setting.CreatedDate;
            exist.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _settingRepository.CommitAsync();
        }
    }
}
