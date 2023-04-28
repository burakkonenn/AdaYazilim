using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class TrainReadRepository : ReadRepository<Train>, ITrainReadRepository
    {
        readonly ApplicationDbContext _context;
        public TrainReadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Train> GetTrainReservationInformation(string trainName)
        {
            var result = await _context.Train.Where(a => a.Name == trainName).Include(x => x.Vagon).FirstOrDefaultAsync();
           
            return result;
        }
    }
}
