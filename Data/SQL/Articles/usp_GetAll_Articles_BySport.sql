USE SportGroups;
GO

CREATE PROCEDURE usp_GetAll_Articles_BySport
	@sport INT
AS
BEGIN 
	SELECT a.*, m.* FROM Articles a
	LEFT JOIN Medias m 
	ON m.articleId = a.articleId
	WHERE clubId = (
		SELECT clubId FROM Clubs
		WHERE Sport = @sport
	)ORDER BY EditDate DESC;
END;