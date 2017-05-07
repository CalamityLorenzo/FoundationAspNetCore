CREATE TABLE [dbo].[Editions]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [BookId] INT NOT NULL, 
    [AlternativeName] NVARCHAR(100), 
    [DateReleased] DATETIME2 NOT NULL, 
    [CoverThumbUrl] NVARCHAR(255) NOT NULL, 
    [PublisherId] INT NOT NULL, 
	[Isbn] nvarchar(12) not null,
    [DescriptionText] NVARCHAR(MAX) NOT NULL, 
	[IsFirstEdition] BIT DEFAULT 0,
    CONSTRAINT [FK_Editions_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id]),
	CONSTRAINT [FK_Editions_Publisher] FOREIGN KEY ([PublisherId]) REFERENCES [Publishers]([Id])
)

