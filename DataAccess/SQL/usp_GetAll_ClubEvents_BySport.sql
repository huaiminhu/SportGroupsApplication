CREATE PROCEDURE usp_GetAll_ClubEvents_BySport
	@Sport INT 
AS 
BEGIN
	SELECT * FROM ClubEvents 
	WHERE ClubId = (
		SELECT ClubId FROM Clubs
		WHERE Sport = @Sport
	);
END;