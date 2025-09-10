USE SportGroupDB;
GO

CREATE PROCEDURE usp_GetArticleWithCondition
	@ClubId INT = NULL, 
	@Sport INT = NULL, 
	@Keyword NVARCHAR(50) = NULL
AS
BEGIN
	SELECT a.*, m.MediaId, m.MediaFileName, m.MediaType, m.FileUrl, m.AddedDate FROM Articles a
	LEFT JOIN Medias m
	ON a.ArticleId = m.ArticleId
	WHERE (a.ClubId = @ClubId OR @ClubId IS NOT NULL)
	AND (a.Sport = @Sport OR @Sport IS NOT NULL)
	AND (a.Title LIKE '%' + @Keyword + '%' OR @Keyword IS NOT NULL)
	GROUP BY a.ArticleId
	ORDER BY a.EditedDate DESC;
END;