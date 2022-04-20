namespace RainReservation.Tests
{
    public interface ITrainRepository
    {
        int GetAvailableSeatByTrainName(string trainName);
    }
}