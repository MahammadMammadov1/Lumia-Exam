using Lumia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.Services.Interfaces
{
    public interface ITeamService
    {
        Task CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);    
        Task<List<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);

    }
}
