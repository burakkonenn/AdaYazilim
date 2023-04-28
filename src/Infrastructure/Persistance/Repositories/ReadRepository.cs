using Application.Abstractions.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); 

        public virtual IQueryable<T> GetAll(bool tracking = true)
        {
            if(!tracking)
                return Table.AsNoTracking();
            else
                return Table.AsQueryable();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            if (!tracking)
                return Table.Where(expression).AsNoTracking();
            else
                return Table.Where(expression).AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
