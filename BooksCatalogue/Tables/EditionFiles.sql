CREATE TABLE [dbo].[EditionFiles]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
	[Edition] INt NOT NULL,
	[Title] NVARCHAR(255) NOT NULL,
    [Url] NVARCHAR(MAX) NOT NULL, 
    [Type] NCHAR(25) NOT NULL, /* is it a Cover image, is it a copy of the text, translation etc, video, audio reading */
    [Format] NVARCHAR(50) NOT NULL, /* html, txt,docx etc */
	CONSTRAINT [FK_EditionFs_Editions] FOREIGN KEY([Edition]) REFERENCES  [Editions]([Id])
)
