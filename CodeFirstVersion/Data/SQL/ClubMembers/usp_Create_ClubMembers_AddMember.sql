USE SportGroups;
GO

CREATE PROCEDURE usp_Create_ClubMembers_AddMember
	@userId INT, 
	@clubId INT,
	@joinTime DATETIME
AS
BEGIN
	INSERT INTO ClubMembers 
	VALUES (@userId, @clubId, @joinTime);
END;