USE SportGroupDB;
GO

CREATE TABLE Users (
	UserId INT PRIMARY KEY IDENTITY(1, 1), 
	NickName NVARCHAR(50) UNIQUE NOT NULL, 
	Email NVARCHAR(100) UNIQUE NOT NULL, 
	UserName NVARCHAR(50) UNIQUE NOT NULL, 
	PasswordHash NVARCHAR(60) NOT NULL, 
	UserRole INT NOT NULL, 
	RegisterDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	RefreshToken NVARCHAR(255) NOT NULL, 
	RefreshTokenExpiry DATETIME2(7)
);
GO

CREATE INDEX IX_Users_UserName ON Users(UserName);
GO
CREATE INDEX IX_Users_RefreshToken ON Users(RefreshToken);
GO

CREATE TABLE Clubs (
	ClubId INT PRIMARY KEY IDENTITY(1, 1), 
	ClubName NVARCHAR(100) UNIQUE NOT NULL, 
	Sport INT NOT NULL, 
	Phone NVARCHAR(20) NOT NULL, 
	Email NVARCHAR(100) NOT NULL, 
	ClubDescription NVARCHAR(255) UNIQUE NOT NULL, 
	EstablishedDate DATETIME2(7) DEFAULT SYSDATETIME() 
);
GO

CREATE INDEX IX_Clubs_ClubName ON Clubs(ClubName);
GO
CREATE INDEX IX_Clubs_Sport ON Clubs(Sport);
GO

CREATE TABLE ClubEvents (
	ClubEventId INT PRIMARY KEY IDENTITY(1, 1), 
	EventType INT NOT NULL, 
	Sport INT NOT NULL, 
	EventName NVARCHAR(100) UNIQUE NOT NULL, 
	EventDescription NVARCHAR(255) UNIQUE NOT NULL, 
	EventAddress NVARCHAR(100) NOT NULL, 
	Starting DATETIME2(7), 
	Ending DATETIME2(7), 
	ClubId INT NOT NULL, 
	FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
);
GO

CREATE INDEX IX_ClubEvents_EventName ON ClubEvents(EventName);
GO
CREATE INDEX IX_ClubEvents_ClubId ON ClubEvents(ClubId);
GO
CREATE INDEX IX_ClubEvents_Sport ON ClubEvents(Sport);
GO

CREATE TABLE Articles (
	ArticleId INT PRIMARY KEY IDENTITY(1, 1), 
	Title NVARCHAR(100) NOT NULL, 
	Sport INT NOT NULL, 
	ArticleContent NVARCHAR(MAX) NOT NULL, 
	PostedDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	EditedDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	ClubId INT NOT NULL, 	
	FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
);
GO

CREATE INDEX IX_Articles_Title ON Articles(Title);
GO
CREATE INDEX IX_Articles_ClubId ON Articles(ClubId);
GO
CREATE INDEX IX_Articles_Sport ON Articles(Sport);
GO

CREATE TABLE Medias (
	MediaId INT PRIMARY KEY IDENTITY(1, 1), 
	MediaFileName NVARCHAR(255) NOT NULL, 
	MediaType INT NOT NULL, 
	FileUrl NVARCHAR(255) UNIQUE NOT NULL, 
	AddedDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	ArticleId INT NOT NULL, 
	FOREIGN KEY (ArticleId) REFERENCES Articles(ArticleId)
);
GO

CREATE TABLE ClubMessages (
	ClubMessageId INT PRIMARY KEY IDENTITY(1, 1), 
	Title NVARCHAR(100) UNIQUE NOT NULL, 
	MessageContent NVARCHAR(255) UNIQUE NOT NULL, 
	PostedDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	ClubId INT NOT NULL, 
	FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
);
GO

CREATE INDEX IX_ClubMessages_ClubId ON ClubMessages(ClubId);
GO

CREATE TABLE ClubMembers (
	UserId INT NOT NULL, 
	ClubId INT NOT NULL, 
	JoinedDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	PRIMARY KEY (UserId, ClubId), 
	FOREIGN KEY (UserId) REFERENCES Users(UserId), 
	FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
);
GO

CREATE INDEX IX_ClubMembers_UserId ON ClubMembers(UserId);
GO
CREATE INDEX IX_ClubMembers_ClubId_UserId ON ClubMembers(ClubId, UserId);
GO

CREATE TABLE Enrollments (
	UserId INT NOT NULL, 
	ClubEventId INT NOT NULL, 
	Phone NVARCHAR(20) NOT NULL, 
	EnrolledDate DATETIME2(7) DEFAULT SYSDATETIME(), 
	PRIMARY KEY (UserId, ClubEventId), 
	FOREIGN KEY (UserId) REFERENCES Users(UserId), 
	FOREIGN KEY (ClubEventId) REFERENCES ClubEvents(ClubEventId)
);
GO

CREATE INDEX IX_Enrollments_UserId ON Enrollments(UserId);
GO
CREATE INDEX IX_Enrollments_ClubEventId_UserId ON Enrollments(ClubEventId, UserId);
GO