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

            if(availableSeat == 0)
            {
                throw new Exception();
            }

            return "BookRef01";
        }
    }
}