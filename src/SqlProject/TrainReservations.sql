CREATE TABLE [dbo].[TrainReservations]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[CoachName] VARCHAR(1) NOT NULL,
	[SeatNumber] INT NOT NULL,
	[TrainName] VARCHAR(MAX) NOT NULL,
	[BookingRef] VARCHAR(MAX) NULL
)
