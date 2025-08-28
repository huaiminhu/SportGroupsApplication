USE SportGroups;
GO

CREATE PROCEDURE usp_GetAll_ClubMembers_ClubsOfUser
	@userId INT
AS
BEGIN
	SELECT c.ClubId, ClubName, Sport, Phone, c.Email, Description, establishedDate FROM Clubs c
	RIGHT JOIN ClubMembers 
	ON ClubMembers.clubId = c.clubId
	WHERE UserId = @userId;
END;