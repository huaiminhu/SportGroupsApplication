USE SportGroupDB;
GO

CREATE TYPE MEDIATABLE AS TABLE
(
	MediaFileName NVARCHAR(255), 
	MediaType INT, 
	FileUrl NVARCHAR(255), 
	AddedDate DATETIME2(7)
);
GO