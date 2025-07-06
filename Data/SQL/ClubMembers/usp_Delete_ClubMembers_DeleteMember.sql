USE SportGroups;
GO

CREATE PROCEDURE usp_Delete_ClubMembers_DeleteMember
	@userId INT, 
	@clubId INT 
AS
BEGIN
	DELETE FROM ClubMembers 
	WHERE UserId = @userId AND ClubId = @clubId;
END;