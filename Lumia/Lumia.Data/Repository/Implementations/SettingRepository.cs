using Lumia.Core.Models;
using Lumia.Core.Repository.Interfaces;
using Lumia.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Data.Repository.Implementations
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
