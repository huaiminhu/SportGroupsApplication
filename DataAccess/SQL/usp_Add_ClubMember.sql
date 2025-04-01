CREATE PROCEDURE usp_Add_ClubMember
	@userId UNIQUEIDENTIFIER, 
	@clubId INT,
	@email NVARCHAR(255), 
	@joinTime DATETIME
AS 
BEGIN
	INSERT INTO ClubMembers
	VALUES (@userId, @clubId, @email, @joinTime);
END;