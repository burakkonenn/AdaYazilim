using Application.Abstractions.Wrappers;
using Application.DTOS.Reservation;


namespace Application.Abstractions.Services
{
    public interface ITrainService
    {
        Task<ServiceResponse<List<ReservationResults>>> GetReservationResults(ReservationRequest request);
    }
}
