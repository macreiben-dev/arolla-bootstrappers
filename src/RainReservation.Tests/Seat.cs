namespace RainReservation.Tests
{
    public class Seat
    {
        private string v1;
        private int v2;

        public Seat(string v1, int v2)
        {
            this.CoachName = v1;
            this.SeatNumber = v2;
        }

        public string CoachName { get => v1; set => v1 = value; }
        public int SeatNumber { get => v2; set => v2 = value; }
    }
}