using System.Collections.Generic;

namespace MovieLibrary.Business
{
    public interface IMovieDatabase
    {
        //public interface ISelectableObject
        //{
        //    void Select ();
        //}

        //public interface IResizableObject
        //{
        //    void Resize ( int width, int height );
        //}

        //public struct SelectableResizableObject : IResizableObject, ISelectableObject
        //{
        //    public void Resize ( int width, int height );
        //    public void Select ();
        //}

        //Properties are allowed
        //string Title { get; }

        /// <summary>Adds a new movie.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        /// Error: Movie is invalid
        /// Error: Movie already exists
        Movie Add ( Movie movie );

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The movie to remove.</param>
        /// Error: Id is less than zero.
        void Delete ( int id );

        /// <summary>Gets an existing movie.</summary>
        /// <param name="id">The movie to get.</param>
        /// <returns>The movie, if ay.</returns>
        /// Error: Id is less than zero.
        Movie Get ( int id );

        /// <summary>Gets all movies.</summary>
        /// <returns>The list of movies.</returns>
        IEnumerable<Movie> GetAll ();

        /// <summary>Updates an existing movie.</summary>
        /// <param name="id">The movie to update.</param>
        /// <param name="movie">The movie details.</param>
        /// Error: Movie is invalid
        /// Error: Movie already exists
        /// Error: Movie does not exist.
        /// Error: Id is less than zero.
        string Update ( int id, Movie movie );
    }
}