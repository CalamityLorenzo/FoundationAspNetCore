CREATE TABLE [dbo].[Authors]
(
	[Id] INT NOT NULL Identity PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [ThumbnailUrl] NVARCHAR(MAX) NOT NULL, 
    [YearOfBirth] INT not NULL check([YearOfBirth]>0), 
    [YearOfDeath] INT NULL,
	[Bio] NVARCHAR(MAX) NOT NULL, 
)
