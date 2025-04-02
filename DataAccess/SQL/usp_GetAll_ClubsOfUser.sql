CREATE PROCEDURE usp_GetAll_ClubsOfUser
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT Club FROM ClubMembers
	RIGHT JOIN Clubs 
	ON ClubMembers.clubId = Clubs.clubId
	WHERE userId = @userId;
END;