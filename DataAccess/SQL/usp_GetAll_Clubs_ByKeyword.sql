CREATE PROCEDURE usp_GetAll_Clubs_ByKeyword
	@keyword NVARCHAR(50)
AS
BEGIN
	SELECT * FROM Clubs
	WHERE ClubName LIKE "%@keyword%";
END;