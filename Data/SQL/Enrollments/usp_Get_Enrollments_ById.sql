USE SportGroups;
GO

CREATE PROCEDURE usp_Get_Enrollments_ById
	@userId  INT, 
	@eventId INT
AS 
BEGIN
	SELECT * FROM Enrollments
	WHERE UserId = @userId AND ClubEventId = @eventId;
END;