CREATE TABLE [dbo].[BookAuthors] (
    [BookId]   INT NOT NULL,
    [AuthorId] INT NOT NULL,
	CONSTRAINT [FK_BookAuthors_Book] FOREIGN KEY([BookId]) REFERENCES [Books]([Id]),
	CONSTRAINT [FK_BookAuthors_Authors] FOREIGN KEY([AuthorId]) REFERENCES [Authors]([Id]), 
    CONSTRAINT [PK_BookAuthors] PRIMARY KEY ([BookId], [AuthorId]),
);

