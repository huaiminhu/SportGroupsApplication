CREATE PROCEDURE usp_Create_Enrollments_AddEnrollment
	@userId     UNIQUEIDENTIFIER, 
	@eventId    INT, 
	@phone      NVARCHAR(12), 
	@enrollDate DATETIME
AS 
BEGIN 
	INSERT INTO Enrollments
	VALUES (@userId, @eventId, @phone, @enrollDate);
END;