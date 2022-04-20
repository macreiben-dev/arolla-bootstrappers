using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainReservationCore
{
    public class TrainReservationService
    {
        private readonly ITrainRepository trainRepo;
        private readonly IBookRefRepository bookRefRepo;

        public TrainReservationService(
            ITrainRepository trainRepo, 
            IBookRefRepository bookRefRepo)
        {
            this.trainRepo = trainRepo;
            this.bookRefRepo = bookRefRepo;
        }

        public Reservation BookSeat(string trainName, string coachName, string seatName)
        {
            int availableSeatCount = trainRepo.GetAvailableSeatCountByTrainName(trainName);

            if (IsFull(availableSeatCount))
            {
                throw new Exception();
            }

            IEnumerable<Seat> availableSeats = trainRepo.GetAvaibleSeats(trainName);

            return new Reservation()
            {
                BookingRef = bookRefRepo.NewBookRef(),
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