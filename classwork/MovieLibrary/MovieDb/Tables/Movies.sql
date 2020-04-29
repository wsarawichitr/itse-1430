﻿CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(MAX),
    [Genre] NVARCHAR(100) NULL,
    [ReleaseYear] INT NULL,
    [RunLength] INT NULL,
    [IsClassic] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_Movies_Name] UNIQUE ([Name]), 
    CONSTRAINT [CK_Movies_ReleaseYear] CHECK (ISNULL(ReleaseYear, 0) >= 0), 
    CONSTRAINT [CK_Movies_RunLength] CHECK (ISNULL(RunLength, 0) >= 0), 
    CONSTRAINT [CK_Movies_Name] CHECK (LEN(Name) > 0) 
)
