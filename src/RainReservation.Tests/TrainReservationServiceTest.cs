using Arolla.WebApis;
using NSubstitute;
using System;
using System.Collections.Generic;
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
        public void Given_train_is_full_then_fail()
        {
            // Arrange
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = "12345";

            _trainRepo.GetAvailableSeatCountByTrainName(trainName)
                .Returns(0);

            // Act
            TrainReservationService sut = GetSut();

            // Assert
            Assert.Throws<Exception>(() =>
                sut.BookSeat(trainName, coachName, seatName));
        }



        #region Reservation details

        [Fact]
        public void Given_The_Train_is_Empty_Then_reservation_has_bookingRef()
        {
            //Arrange
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = "12345";
            var bookingRef = "BookRef01";

            _trainRepo.GetAvailableSeatCountByTrainName(trainName)
            .Returns(4);

            _trainRepo.GetAvaibleSeats(trainName).
                Returns(new List<Seat> {
                    new Seat("A", 1), new Seat("A", 2),
                    new Seat("B", 1), new Seat("B", 2)});

            // Act
            TrainReservationService sut = GetSut();
            var actual = sut.BookSeat(trainName, coachName, seatName);

            // Assert 
            Assert.Equal(bookingRef, actual.BookingRef);
        }

        [Fact]
        public void Given_availableSeats_then_trainName_exists_in_reservation()
        {
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = "12345";
            
            _trainRepo.GetAvailableSeatCountByTrainName(trainName)
               .Returns(4);

            _trainRepo.GetAvaibleSeats(trainName).
                Returns(new List<Seat> {
                    new Seat("A", 1), new Seat("A", 2),
                    new Seat("B", 1), new Seat("B", 2)});

            // Act
            TrainReservationService sut = GetSut();

            Reservation actual = sut.BookSeat(trainName, coachName, seatName);

            Assert.Equal(actual.TrainName, trainName);

        }

        [Fact]
        public void Given_train_is_empty_and_bookSeat_then_book_firstSeat_in_firstCoach()
        {
            var trainName = "SomeTrain";
            var coachName = "SomeCoach";
            var seatName = "12345";
            var bookingRef = "BookRef01";

            _trainRepo.GetAvailableSeatCountByTrainName(trainName)
               .Returns(4);

            _trainRepo.GetAvaibleSeats(trainName).
                Returns(new List<Seat> { 
                    new Seat("A", 1), new Seat("A", 2),
                    new Seat("B", 1), new Seat("B", 2)});

            // Act
            TrainReservationService sut = GetSut();

            Reservation actual = sut.BookSeat(trainName, coachName, seatName);

            // Assert
            Assert.Equal(actual.SeatName, "1A");
        }

        #endregion Reservation details

    }

}
