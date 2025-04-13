CREATE PROCEDURE usp_GetAll_Clubs_OfUser
	@userId INT
AS
BEGIN
	SELECT Club FROM ClubMembers
	RIGHT JOIN Clubs 
	ON ClubMembers.clubId = Clubs.clubId
	WHERE userId = @userId;
END;