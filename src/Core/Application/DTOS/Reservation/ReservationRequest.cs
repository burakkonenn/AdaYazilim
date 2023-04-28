

namespace Application.DTOS.Reservation
{
    public class ReservationRequest
    {
        public string TrainName { get; set; }
        public int CountOfReservationRequest { get; set; }
        public bool IsDifferentWagons { get; set; }

    }
}
