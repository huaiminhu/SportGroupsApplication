CREATE PROCEDURE usp_Get_Enrollments_ById
	@userId  UNIQUEIDENTIFIER, 
	@eventId INT
AS 
BEGIN
	SELECT * FROM Enrollments
	WHERE userId = @userId AND eventId = @eventId;
END;