USE SportGroups;
GO

CREATE PROCEDURE use_GetAll_ClubEvents_OfUser
	@userId INT
AS
BEGIN
	SELECT * FROM ClubEvents 
	WHERE clubId = (
		SELECT clubId FROM Enrollment 
		WHERE userId = @userId
	);
END;