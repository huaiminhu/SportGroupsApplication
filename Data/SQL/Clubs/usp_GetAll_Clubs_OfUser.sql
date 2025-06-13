USE SportGroups;
GO

CREATE PROCEDURE usp_GetAll_Clubs_OfUser
	@userId INT
AS
BEGIN
	SELECT * FROM Clubs
	RIGHT JOIN ClubMembers 
	ON ClubMembers.clubId = Clubs.clubId
	WHERE userId = @userId;
END;