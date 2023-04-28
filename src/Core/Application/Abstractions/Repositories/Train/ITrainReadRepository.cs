using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface ITrainReadRepository:IReadRepository<Train>
    {
        Task<Train> GetTrainReservationInformation(string trainName);
    }
}
