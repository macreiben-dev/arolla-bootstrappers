using System.Collections.Generic;

namespace TrainReservationCore
{
    public class Reservation
    {
        public string BookingRef { get; internal set; }
        public string TrainName { get; internal set; }
        public string SeatName { get; internal set; }
    }
}