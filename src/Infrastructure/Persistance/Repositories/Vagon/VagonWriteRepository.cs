using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistance.Context;


namespace Persistance.Repositories
{
    public class VagonWriteRepository : WriteRepository<Vagon>, IVagonWriteRepository
    {
        public VagonWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
