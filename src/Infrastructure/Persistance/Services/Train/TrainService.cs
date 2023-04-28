using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Abstractions.Wrappers;
using Application.DTOS.Reservation;
using Application.DTOS.Vagon;


namespace Persistance.Services.Train
{
    public class TrainService : ITrainService
    {
        readonly ITrainReadRepository _trainReadRepository;
        public TrainService(ITrainReadRepository trainReadRepository)
        {
            _trainReadRepository = trainReadRepository;
        }

        public async Task<ServiceResponse<List<ReservationResults>>> GetReservationResults(ReservationRequest request)
        {
            var response = new ServiceResponse<List<ReservationResults>>();
            var train = _trainReadRepository.GetTrainReservationInformation(request.TrainName).Result;

            var availableVagon = train.Vagon.Select(trainCar => new VagonDto
            {
                TrainName = trainCar.Train.Name,
                VagonName = trainCar.Name,
                EmptyOfSeats = (int)(trainCar.Capacity * 0.7) - trainCar.FullSeats,

            }).ToList();

            var TotalavailableSeats = availableVagon.Sum(trainCar => trainCar.EmptyOfSeats);
            var TotalAvailableTrainCarCount = availableVagon.Count();


            if (request.CountOfReservationRequest > TotalavailableSeats)
            {
                return new ServiceResponse<List<ReservationResults>>
                {
                    IsReservationRequestSuccees = false,
                    Message = "Tüm vagonlar doludur.",
                };
            }
            else
            {
                if (request.IsDifferentWagons)
                {
                    var passengerCount = request.CountOfReservationRequest;
                    var seatDetails = new List<ReservationResults>();

                    for (int i = 0; i < availableVagon.Count && passengerCount > 0; i++)
                    {
                        var vagonSeat = availableVagon[i];
                        if (vagonSeat.EmptyOfSeats >= passengerCount)
                        {
                            seatDetails.Add(new ReservationResults
                            {
                                VagonName = vagonSeat.VagonName,
                                CountOfPeople = passengerCount,
                            });
                            passengerCount = 0;
                        }
                        else
                        {
                            int remainingSeats = vagonSeat.EmptyOfSeats;

                            seatDetails.Add(new ReservationResults
                            {
                                VagonName = vagonSeat.VagonName,
                                CountOfPeople = vagonSeat.EmptyOfSeats,
                            });
                            passengerCount -= remainingSeats;
                        }
                    }

                    return new ServiceResponse<List<ReservationResults>>
                    {
                        Data = seatDetails,
                        IsReservationRequestSuccees = true,
                        Message = "Uygun vagonlara tüm kişiler eklenmiştir.",
                    };
                }

                else
                {
                    var matchingVagon = availableVagon.FirstOrDefault(v => v.EmptyOfSeats >= request.CountOfReservationRequest);
                    if (matchingVagon != null)
                    {
                        var seatDetails = new List<ReservationResults>
                        {
                            new ReservationResults
                            {
                                VagonName = matchingVagon.VagonName,
                                CountOfPeople = request.CountOfReservationRequest
                            }
                        };
                        return new ServiceResponse<List<ReservationResults>>
                        {
                            Data = seatDetails,
                            IsReservationRequestSuccees = true,
                            Message = "Tüm kişiler aynı vagona yerleştirildi.",
                        };
                    }
                    else
                    {
                        return new ServiceResponse<List<ReservationResults>>
                        {
                            IsReservationRequestSuccees = true,
                            Message = "Aynı vagonda yeterli sayıda boş koltuk bulunmamaktadır.",
                        };
                    }
                }
            }
        }
    }
}
