--
-- Updates an existing movie.
--
-- PARAMS:
--    id - The ID of the existing movie.
--    name - The name of the movie. Must be unique and cannot be empty.
--    releaseYear - The release year. If specified must be >= 0.
--    runLength - The run length. If specified must be >= 0.
--    description - Specifies the description of the movie.
--    genre - The optional genre.
--    isClassic - Determines if this is a classic movie.
--
-- RETURNS: None.
--
CREATE PROCEDURE [dbo].[UpdateMovie]
    @id INT,
	@name NVARCHAR(255),
    @description NVARCHAR(MAX) = NULL,
    @genre NVARCHAR(10) = NULL,    
    @releaseYear INT = NULL,
    @runLength INT = NULL,
    @isClassic BIT = NULL
AS BEGIN
    SET NOCOUNT ON;

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))

    -- Validate
	IF LEN(@name) = 0
        THROW 51000, 'Name cannot be empty.', 1
    
    IF ISNULL(@releaseYear, 0) < 0
        THROW 51001, 'ReleaseYear must be >= 0.', 1
    IF ISNULL(@runLength, 0) < 0
        THROW 51002, 'RunLength must be >= 0.', 1
    
    IF NOT EXISTS (SELECT * FROM Movies WHERE Id = @id)
        THROW 51002, 'Movie not found.', 1

    IF EXISTS (SELECT * FROM Movies WHERE Name = @name AND Id <> @id)
        THROW 51003, 'Movie with same name already exists.', 1

    -- Update
    SET @description = LTRIM(RTRIM(ISNULL(@description, '')))
    IF LEN(@description) = 0 
        SET @description = NULL

    SET @genre = LTRIM(RTRIM(ISNULL(@genre, '')))
    IF LEN(@genre) = 0 
        SET @genre = NULL

    UPDATE Movies
    SET
        Name = @name, 
        Description = @description, 
        Genre = @genre, 
        ReleaseYear = @releaseYear, 
        RunLength = @runLength, 
        IsClassic = @isClassic
    WHERE Id = @id
END