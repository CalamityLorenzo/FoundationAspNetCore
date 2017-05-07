CREATE TABLE [dbo].[EditionFiles]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
	[Edition] INt NOT NULL,
    [FileUrl] NVARCHAR(MAX) NOT NULL, 
    [FileType] NCHAR(25) NOT NULL, /* is it a Cover image, is it a copy of the text, translation etc */
    [FileFormat] NVARCHAR(50) NOT NULL, /* html, txt,docx etc */
	[Title] NVARCHAR(255) NOT NULL,
	CONSTRAINT [FK_EditionFs_Editions] FOREIGN KEY([Edition]) REFERENCES  [Editions]([Id])
)
