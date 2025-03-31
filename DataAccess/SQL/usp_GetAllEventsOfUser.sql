CREATE PROCEDURE use_GetAllEventsOfUser
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM ClubEvents 
	WHERE clubId = (
		SELECT clubId FROM Enrollment 
		WHERE userId = @userId
	);
END;