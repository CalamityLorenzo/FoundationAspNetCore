CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Genre] INT NOT NULL DEFAULT 0 , 
    [OriginalPublisher] INT NOT NULL, 
    [YearFirst] INT NOT NULL check([YearFirst]>0),
	CONSTRAINT [FK_BOOKS_Publisher] FOREIGN KEY([OriginalPublisher]) REFERENCES [Publishers]([Id])
)
