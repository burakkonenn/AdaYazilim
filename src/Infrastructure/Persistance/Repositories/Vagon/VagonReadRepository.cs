using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistance.Context;


namespace Persistance.Repositories
{
    public class VagonReadRepository : ReadRepository<Vagon>, IVagonReadRepository
    {
        public VagonReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
