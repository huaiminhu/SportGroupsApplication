USE SportGroupDB;
GO

CREATE PROCEDURE usp_GetNumberOfEventOfClubs
AS
BEGIN
	SELECT c.ClubName, COUNT(ce.ClubId) NumberOfClubs FROM Clubs c
	LEFT JOIN ClubEvents ce
	ON c.ClubId = ce.ClubId
	GROUP BY ce.ClubId
	HAVING COUNT(ce.ClubId) > 0
	ORDER BY NumberOfClubs DESC;
END;