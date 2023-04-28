using Application.Abstractions.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return null;
                else
                    entity.CreatedDate = DateTime.Now;
                    await Table.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            if (entities.Count == 0)
                return false;
            else
                await Table.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            if (entity == null)
                return null;
            else
                Table.Remove(entity);
            return entity;
        
        }

        public async Task<T> RemoveAsync(int id)
        {
            var entity = await Table.FindAsync(id);

            if (entity == null)
                return null;
            else
                Table.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
        }

        public Task<bool> RemoveRangeAsync(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                return null;
            else
            {
                entity.UpdatedDate = DateTime.UtcNow;
                Table.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
        }
    }
}
