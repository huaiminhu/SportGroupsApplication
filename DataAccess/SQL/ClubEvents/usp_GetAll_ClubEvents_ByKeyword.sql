CREATE PROCEDURE usp_GetAll_ClubEvents_ByKeyword
	@keyword NVARCHAR(20)
AS
BEGIN
	SELECT * FROM ClubEvents
	WHERE EventName LIKE "%@keyword%";
END;