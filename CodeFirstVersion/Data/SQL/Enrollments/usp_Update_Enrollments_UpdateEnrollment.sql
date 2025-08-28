USE SportGroups;
GO

CREATE PROCEDURE usp_Update_Enrollments_UpdateEnrollment
	@userId INT, 
	@eventId INT, 
	@phone NVARCHAR(12)
AS
BEGIN
	UPDATE Enrollments
	SET Phone = @phone
	WHERE UserId = @userId AND ClubEventId = @eventId;
END;