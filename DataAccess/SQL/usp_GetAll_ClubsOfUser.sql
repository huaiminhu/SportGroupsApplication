CREATE PROCEDURE usp_GetAll_ClubsOfUser
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT Club FROM Clubs
	LEFT JOIN ClubMembers 
	ON Clubs.clubId = ClubMembers.clubId
	WHERE userId = @userId;
END;