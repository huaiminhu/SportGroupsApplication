CREATE PROCEDURE usp_Get_EnrollmentInfo
	@userId  UNIQUEIDENTIFIER, 
	@eventId INT
AS 
BEGIN
	SELECT * FROM Enrollments
	WHERE userId = @userId AND eventId = @eventId;
END;