CREATE PROCEDURE [spSaveBooked]

@tripId INT,
@email VARCHAR (50),
@checkin DATETIME,
@checkout DATETIME,
@adults INT,
@bookedHour VARCHAR(50),
@total DECIMAL

AS
BEGIN
    INSERT INTO [dbo].[Booked] ([tripId],[email],[checkin],[checkout],[adults],[bookedHour],[total],[created])
	VALUES (@tripId, @email, @checkin ,@checkout , @adults, @bookedHour , @total, GETDATE() )      

END
GO