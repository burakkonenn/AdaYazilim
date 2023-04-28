using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(T entity);
        Task<T> RemoveAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task<bool> RemoveRangeAsync(List<T> entities);

    }
}
