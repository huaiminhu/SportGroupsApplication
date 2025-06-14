USE SportGroups;
GO

CREATE PROCEDURE usp_GetAll_Articles_ByKeyword
	@keyword NVARCHAR(20)
AS
BEGIN
	SELECT * FROM Articles
	WHERE Title LIKE '%' + @keyword + '%'
	ORDER BY EditDate DESC;
END;