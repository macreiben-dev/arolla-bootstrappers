using System;

namespace RainReservation.Tests
{
    internal class TrainReservationService
    {
        private readonly ITrainRepository trainRepo;

        public TrainReservationService(ITrainRepository trainRepo)
        {
            this.trainRepo = trainRepo;
        }

        internal Reservation BookSeat(string trainName, string coachName, int seatName)
        {
            int availableSeat = trainRepo.GetAvailableSeatByTrainName(trainName);

            if (IsFull(availableSeat))
            {
                throw new Exception();
            }

            return new Reservation() { BookingRef= "BookRef01",
                TrainName=trainName,
                SeatName=seatName
            };
        }

        private static bool IsFull(int availableSeat)
        {
            return availableSeat == 0;
        }
    }
}