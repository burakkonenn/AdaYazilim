using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class TrainWriteRepository : WriteRepository<Train>, ITrainWriteRepository
    {
        public TrainWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
