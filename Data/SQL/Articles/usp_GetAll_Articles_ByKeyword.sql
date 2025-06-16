USE SportGroups;
GO

CREATE PROCEDURE usp_GetAll_Articles_ByKeyword
	@keyword NVARCHAR(20)
AS
BEGIN
	SELECT a.*, m.* FROM Articles a
	LEFT JOIN Medias m 
	ON m.ArticleId = a.ArticleId
	WHERE Title LIKE '%' + @keyword + '%'
	ORDER BY EditDate DESC;
END;