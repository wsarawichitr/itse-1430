using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{

    // Is-a relationship
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return null;

            //.NET Validation
            var errors = ObjectValidator.Validate(movie);
            if (errors.Any())
            //if (!Validator.TryValidateObject(movie, new ValidationContext(movie), errors, true))
            //if (!movie.Validate(out var error))
                return null;

            //TODO: Movie names must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                return null;

            return AddCore(movie);
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id<=0)
                return;

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            //TODO: Error
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        public IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty<Movie>();

        protected abstract IEnumerable<Movie> GetAllCore ();

        //private sealed class Enumerator<T>  : IEnumerator<T>
        //{
        //    ...
        //}

        //TODO: Validate
        //TODO: Movie names must be unique
        //TODO: Clone movie to store
        //TODO: Shouldn't need original movie

        public string Update ( int id, Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return "Movie is null";

            var errors = ObjectValidator.Validate(movie);
            if (errors.Any())
                //if (!movie.Validate(out var error))
                return "Error";

            if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "Movie not found";

            // Movie names must be unique
            var sameName = FindByTitle(movie.Title);
            if (sameName != null && sameName.Id != id)
                return "Movie must be unique";

            UpdateCore(id, movie);

            return null;
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );

        protected abstract Movie FindById ( int id );
        
    }
}
