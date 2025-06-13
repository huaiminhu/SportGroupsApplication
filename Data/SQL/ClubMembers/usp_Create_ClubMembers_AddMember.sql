USE SportGroups;
GO

CREATE PROCEDURE usp_Create_ClubMembers_AddMember
	@userId INT, 
	@clubId INT, 
	@email NVARCHAR(50), 
	@joinTime DATETIME
AS
BEGIN
	INSERT INTO ClubMembers 
	VALUES (@userId, @clubId, @email, @joinTime);
END;