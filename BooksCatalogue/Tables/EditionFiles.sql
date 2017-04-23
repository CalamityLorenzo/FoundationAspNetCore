CREATE TABLE [dbo].[EditionFiles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[Edition] INt NOT NULL,
    [FileUrl] NVARCHAR(MAX) NOT NULL, 
    [FileNameExt] NCHAR(10) NOT NULL, 
    [FileFormat] NVARCHAR(50) NOT NULL,
	CONSTRAINT [FK_EditionFs_Editions] FOREIGN KEY([Edition]) REFERENCES  [Editions]([Id])
)
