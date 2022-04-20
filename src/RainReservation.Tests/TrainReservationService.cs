using System;
using System.Collections.Generic;
using System.Linq;

namespace RainReservation.Tests
{
    internal class TrainReservationService
    {
        private readonly ITrainRepository trainRepo;

        public TrainReservationService(ITrainRepository trainRepo)
        {
            this.trainRepo = trainRepo;
        }

        internal Reservation BookSeat(string trainName, string coachName, string seatName)
        {
            int availableSeatCount = trainRepo.GetAvailableSeatCountByTrainName(trainName);

            if (IsFull(availableSeatCount))
            {
                throw new Exception();
            }

            IEnumerable<Seat> availableSeats = trainRepo.GetAvaibleSeats(trainName);

            return new Reservation()
            {
                BookingRef = "BookRef01",
                TrainName = trainName,
                SeatName = availableSeats.First().SeatNumber + availableSeats.First().CoachName
            };
        }

        private static bool IsFull(int availableSeat)
        {
            return availableSeat == 0;
        }
    }
}