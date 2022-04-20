using System.Collections.Generic;

namespace RainReservation.Tests
{
    public interface ITrainRepository
    {
        int GetAvailableSeatCountByTrainName(string trainName);
        IEnumerable<Seat> GetAvaibleSeats(string trainName);
    }
}