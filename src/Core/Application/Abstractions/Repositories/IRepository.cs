using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
