USE SportGroups;
GO

CREATE PROCEDURE usp_Delete_Enrollments_DeleteEnrollment
	@userId INT, 
	@eventId INT 
AS
BEGIN
	DELETE FROM Enrollments 
	WHERE UserId = @userId AND ClubEventId = @eventId;
END;