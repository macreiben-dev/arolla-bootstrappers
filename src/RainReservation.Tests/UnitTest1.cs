using Arolla.WebApis;
using NSubstitute;
using System;
using Xunit;

namespace RainReservation.Tests
{
    public class UnitTest1
    {
        private ITrainRepository _trainRepo;

        public UnitTest1()
        {
            _trainRepo = Substitute.For<ITrainRepository>();
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

        private TrainReservationService GetSut()
        {
            return new TrainReservationService(_trainRepo);
        }

        [Fact]
        void Given_train_is_full_then_fail()
        {
            // Arrange
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = 12345;
            var bookingRef = "BookRef01";

            _trainRepo.GetAvailableSeatByTrainName(trainName)
                .Returns(0);

            // Act
            TrainReservationService sut = GetSut();

            // Assert
            Assert.Throws<Exception>(() =>
                sut.BookSeat(trainName, coachName, seatName));
        }
    }

}
