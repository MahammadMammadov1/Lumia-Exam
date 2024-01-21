using Lumia.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions dbContext) : base(dbContext)
        {
            
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
