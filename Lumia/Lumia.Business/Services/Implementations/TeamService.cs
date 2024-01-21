using Lumia.Business.CustomExceptions.Team;
using Lumia.Business.Services.Interfaces;
using Lumia.Core.Models;
using Lumia.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ITeamRepository _teamRepository;

        public TeamService(IWebHostEnvironment env,ITeamRepository teamRepository)
        {
            _env = env;
            _teamRepository = teamRepository;
        }
        public async Task CreateAsync(Team team)
        {
            if(team.FormFile != null)
            {
                if(team.FormFile.Length > 2097162)
                {
                    throw new FileLengthException("FormFile","File must be less than 2 mb");
                }
                if (team.FormFile.ContentType != "image/png" && team.FormFile.ContentType != "image/jpeg")
                {
                    throw new FileLengthException("FormFile","File must be png or jpeg");

                }

                team.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath,"Uploads/Teams", team.FormFile);
            }
            else
            {
                throw new ImageFileRequiredException("FormFile", "File is required!!");
            }

            team.CreatedDate = DateTime.UtcNow.AddHours(4);
            team.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _teamRepository.CreateAsync(team);
            await _teamRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await _teamRepository.GetByIdAsync(x => x.Id == id);
            if (exist == null) throw new TeamNotFoundException();

            string oldPath = Path.Combine(_env.WebRootPath, "Uploads/Teams", exist.ImageUrl);
            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }

            _teamRepository.Delete(exist);
            await _teamRepository.CommitAsync();


        }

        public Task<List<Team>> GetAllAsync()
        {
            return _teamRepository.GetAllAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(x=>x.Id == id);
        }

        public async Task SoftDelete(int id)
        {
            var exist = await _teamRepository.GetByIdAsync(x => x.Id == id);
            if (exist == null) throw new TeamNotFoundException();

            exist.IsDeleted = !exist.IsDeleted;
            await _teamRepository.CommitAsync();

        }

        public async Task UpdateAsync(Team team)
        {
            var exist = await _teamRepository.GetByIdAsync(x=>x.Id == team.Id);
            if (exist == null) throw new TeamNotFoundException();
            

            if (team.FormFile != null)
            {
                if (team.FormFile.Length > 2097162)
                {
                    throw new FileLengthException("FormFile", "File must be less than 2 mb");
                }
                if (team.FormFile.ContentType != "image/png" && team.FormFile.ContentType != "image/jpeg")
                {
                    throw new FileLengthException("FormFile", "File must be png or jpeg");

                }

                string oldPath = Path.Combine(_env.WebRootPath, "Uploads/Teams", exist.ImageUrl);
                if(File.Exists(oldPath))
                {
                    File.Delete(oldPath);   
                }

                exist.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath, "Uploads/Teams", team.FormFile);
            }

            exist.Profession  = team.Profession;
            exist.Fullname = team.Fullname;
            exist.InstagramUrl = team.InstagramUrl;
            exist.CreatedDate = team.CreatedDate;
            exist.IsDeleted = team.IsDeleted;
            exist.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _teamRepository.CommitAsync();
        }
    }
}
