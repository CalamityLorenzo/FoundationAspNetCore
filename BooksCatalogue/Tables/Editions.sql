CREATE TABLE [dbo].[Editions]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [BookId] INT NOT NULL, 
    [FileType] NCHAR(8) NOT NULL, 
    [Year] INT NOT NULL, 
    [CoverImgUrl] NVARCHAR(MAX) NOT NULL, 
    [Publisher] INT NOT NULL, 
    [Blurb] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Editions_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id]),
	CONSTRAINT [FK_Editions_Publisher] FOREIGN KEY ([Publisher]) REFERENCES [Publishers]([Id])
)
