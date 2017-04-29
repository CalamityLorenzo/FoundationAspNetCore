CREATE TABLE [dbo].[Editions]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [BookId] INT NOT NULL, 
    [AlternativeName] NVARCHAR(100) NOT NULL, 
    [DateReleased] DATETIME2 NOT NULL, 
    [CoverThumbUrl] NVARCHAR(255) NOT NULL, 
    [Publisher] INT NOT NULL, 
    [DescriptionTest] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Editions_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id]),
	CONSTRAINT [FK_Editions_Publisher] FOREIGN KEY ([Publisher]) REFERENCES [Publishers]([Id])
)
