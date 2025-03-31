CREATE PROCEDURE usp_GetAllEventsBySport
	@Sport INT 
AS 
BEGIN
	SELECT * FROM ClubEvents 
	WHERE ClubId = (
		SELECT ClubId FROM Clubs
		WHERE Sport = @Sport
	);
END;