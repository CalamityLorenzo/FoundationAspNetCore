CREATE TABLE [dbo].[Publishers]
(
	[Id] INT IDENTITY PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [YearStarted] INT NOT NULL, 
    [Bio] NVARCHAR(MAX) NOT NULL
)
