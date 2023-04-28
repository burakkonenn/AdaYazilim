using Application.Abstractions.Services;
using Application.DTOS.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace TrainReservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        readonly ITrainService _trainService;

        public ReservationController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReservationRequest request)
        {
            var reservationResults = _trainService.GetReservationResults(request);
            return Ok(reservationResults);
        }
    }
}

