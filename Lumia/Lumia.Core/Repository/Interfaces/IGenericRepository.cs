using Lumia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Core.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        public DbSet<TEntity> Table { get; }

        Task<int> CommitAsync();
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
    }
}
