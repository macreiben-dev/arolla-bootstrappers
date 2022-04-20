namespace TrainReservationCore
{
    public class Seat
    {
        private string v1;
        private int v2;

        public Seat(string v1, int v2)
        {
            CoachName = v1;
            SeatNumber = v2;
        }

        public string CoachName { get => v1; set => v1 = value; }
        public int SeatNumber { get => v2; set => v2 = value; }
    }
}