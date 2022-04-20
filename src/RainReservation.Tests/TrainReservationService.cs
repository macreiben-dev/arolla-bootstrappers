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

        internal object BookSeat(string trainName, string coachName, int seatName)
        {
            int availableSeat = trainRepo.GetAvailableSeatByTrainName(trainName);

            if (IsFull(availableSeat))
            {
                throw new Exception();
            }

            return "BookRef01";
        }

        private static bool IsFull(int availableSeat)
        {
            return availableSeat == 0;
        }
    }
}