using Arolla.WebApis;
using NSubstitute;
using System;
using Xunit;

namespace RainReservation.Tests
{
    public class TrainReservationServiceTest
    {
        private ITrainRepository _trainRepo;

        public TrainReservationServiceTest()
        {
            _trainRepo = Substitute.For<ITrainRepository>();
        }

        private TrainReservationService GetSut()
        {
            return new TrainReservationService(_trainRepo);
        }

        [Fact]
        public void Given_The_Train_is_Empty_Then_I_Book_A_Seat()
        {
            //Arrange
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = 12345;
            var bookingRef = "BookRef01";

            _trainRepo.GetAvailableSeatByTrainName(trainName)
                .Returns(10);

            // Act
            TrainReservationService sut = GetSut();
            var actual = sut.BookSeat(trainName, coachName, seatName);

            // Assert 
            Assert.Equal(bookingRef, actual);
        }

        [Fact]
        public void Given_train_is_full_then_fail()
        {
            // Arrange
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = 12345;
            
            _trainRepo.GetAvailableSeatByTrainName(trainName)
                .Returns(0);

            // Act
            TrainReservationService sut = GetSut();

            // Assert
            Assert.Throws<Exception>(() =>
                sut.BookSeat(trainName, coachName, seatName));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Given_availableSeats_then_I_can_book(int avaiableSeats)
        {
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = 12345;
            var bookingRef = "BookRef01";

            _trainRepo.GetAvailableSeatByTrainName(trainName)
                .Returns(avaiableSeats);
            
            // Act
            TrainReservationService sut = GetSut();

            var actual = sut.BookSeat(trainName, coachName, seatName);

            // Assert
            Assert.Equal(bookingRef, actual);
        }
    }

}
