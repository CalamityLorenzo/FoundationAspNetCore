

CREATE TABLE [dbo].[EditionFiles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[Edition] INt NOT NULL,
    [FileUrl] NVARCHAR(MAX) NOT NULL, 
    [FileType] NCHAR(10) NOT NULL, /* is it a Cover image, is it a copy of the text, translation etc */
    [FileFormat] NVARCHAR(50) NOT NULL, /* html, txt,docx etc */
	CONSTRAINT [FK_EditionFs_Editions] FOREIGN KEY([Edition]) REFERENCES  [Editions]([Id])
)
