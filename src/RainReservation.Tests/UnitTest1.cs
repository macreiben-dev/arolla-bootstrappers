using Arolla.WebApis;
using System;
using Xunit;

namespace RainReservation.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Given_The_Train_is_Empty_Then_I_Book_A_Seat()
        {
            //Arrange
            var trainName = "SomeTrain";
            var coachName ="SomeCoach" ;
            var seatName = 12345;
            var bookingRef = "BookRef01";

            // Act
            TrainReservationService sut = new TrainReservationService();
            var actual = sut.BookSeat(trainName, coachName, seatName);

            // Assert 
            Assert.Equal(bookingRef,actual);
        }
    }
}
