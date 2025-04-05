CREATE PROCEDURE usp_GetAll_Articles_ByKeyword
	@keyword NVARCHAR(20)
AS
BEGIN
	SELECT * FROM Articles
	WHERE Title LIKE "%@keyword%";
END;