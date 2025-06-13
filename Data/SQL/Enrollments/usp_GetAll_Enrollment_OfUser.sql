USE SportGroups;
GO

CREATE PROCEDURE usp_GetAll_Enrollment_OfUser
	@userId INT
AS
BEGIN
	SELECT * FROM Enrollments
	WHERE userId = @userId;
END;