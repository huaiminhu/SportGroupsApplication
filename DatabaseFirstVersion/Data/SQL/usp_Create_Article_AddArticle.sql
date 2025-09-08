USE SportGroupDB;
GO

CREATE PROCEDURE usp_Create_Article_AddArticle
	@Title NVARCHAR(100), 
	@Sport INT, 
	@ArticleContent NVARCHAR(MAX), 
	@PostedDate DATETIME2(7), 
	@EditedDate DATETIME2(7), 
	@ClubId INT, 
	@Medias MEDIATABLE READONLY
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN TRANSACTION;

		INSERT INTO ARTICLES
		VALUES (@Title, @Sport, @ArticleContent, @PostedDate, @EditedDate, @ClubId);

		DECLARE @ArticleId INT = SCOPE_IDENTITY();

		INSERT INTO MEDIAS
		SELECT MediaFileName, MediaType, FileUrl, AddedDate, @ArticleId
		FROM @Medias;

		COMMIT TRANSACTION;

		SELECT @ArticleId AS ArticleId;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		RAISERROR(@ErrorMessage, 16, 1);
	END CATCH
END;