CREATE PROCEDURE usp_GetAll_Articles_BySport
	@sport INT
AS
BEGIN 
	SELECT * FROM Articles
	WHERE clubId = (
		SELECT clubId FROM Clubs
		WHERE Sport = @sport
	);
END;