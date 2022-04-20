using System.Linq;
using TrainReservationCore;
using Xunit;

namespace Repositories.DapperSamples.Acceptance.Tests
{
    public class TrainRepositoryTests
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LocalTrainReservation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Fact]
        public void Given_A_TrainName_Then_GetSeat()
        {
            // ARRANGE

            var originalTrainNAme = "Express2000";
            int expectedSeatCount = 4;

            // ACT
            var sut = new TrainRepository();
            //var sut = new TrainRepository(ConnectionString);

            var actual = sut.GetAvaibleSeats(originalTrainNAme);

            // ASSERT
            Assert.Equal(expectedSeatCount, actual.Count());
        }

        [Fact]
        public void Given_A_TrainName_Then_seatCount_is_two_in_first_coach()
        {
            // ARRANGE
            var originalTrainNAme = "Express2000";

            // ACT
            var sut = new TrainRepository();
            //var sut = new TrainRepository(ConnectionString);

            var actual = sut.GetAvaibleSeats(originalTrainNAme).ToList();

            // ASSERT
            var coachSeatCount = actual.Count(c => c.CoachName == "A");

            Assert.Equal(2, coachSeatCount);
        }
    }
}
