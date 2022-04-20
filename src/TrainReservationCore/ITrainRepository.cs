using System.Collections.Generic;

namespace TrainReservationCore
{
    public interface ITrainRepository
    {
        int GetAvailableSeatCountByTrainName(string trainName);
        IEnumerable<Seat> GetAvaibleSeats(string trainName);
    }
}