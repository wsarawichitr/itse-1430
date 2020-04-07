﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business.Memory
{

    // Is-a relationship
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {
            //TODO: Clone movie to store
            var item = CloneMovie(movie);
            item.Id = _id++;
            _movies.Add(item);
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //    if (_movies[index] == null)
            //    {
            //        _movies[index] = item;
            //        item.Id = _id++;

            //        return CloneMovie(item);
            //    };
            //};

            return CloneMovie(item);
        }

        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //    if (_movies[index]?.Id == id)
            //    {
            //        _movies[index] = null;
            //        break;
            //    };
            //};
        }

        protected override Movie GetCore ( int id )
        {
            var movie = FindById(id);
            if (movie == null)
                return null;

            return CloneMovie(movie);
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //return _movies;
            //TODO: Clone objects
            //var items = new Movie[_movies.Count];
            //var index = 0;
            //foreach (var movie in _movies)
            //{
            //    items[index++] = CloneMovie(movie);
            //};

            //return items;

            //use an iterator Luke
            foreach (var movie in _movies)
            {
                yield return CloneMovie(movie);
            };
        }

        //private sealed class Enumerator<T>  : IEnumerator<T>
        //{
        //    ...
        //}

        //TODO: Validate
        //TODO: Movie names must be unique
        //TODO: Clone movie to store
        //TODO: Shouldn't need original movie
        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);
            
            //Update
            CopyMovie(existing, movie, false);
        }

        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            CopyMovie(item, movie, true);

            return item;
            //Object initializer syntax
            //return new Movie() {
            //    Id = movie.Id,
            //    Title = movie.Title,
            //    Description = movie.Description,
            //    Genre = new Genre(movie.Genre.Description),
            //    IsClassic = movie.IsClassic,
            //    ReleaseYear = movie.ReleaseYear,
            //    RunLength = movie.RunLength,
            //};
            //item.Id = movie.Id;
            //item.Title = movie.Title;
            //item.Description = movie.Description;
            //item.Genre = movie.Genre;
            //item.IsClassic = movie.IsClassic;
            //item.ReleaseYear = movie.ReleaseYear;
            //item.RunLength = movie.RunLength;

            //return item;
        }

        private void CopyMovie ( Movie target, Movie source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            if (source.Genre != null)
                target.Genre = new Genre(source.Genre.Description);
            else
                target.Genre = null;
            target.IsClassic = source.IsClassic;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
        }

        protected override Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie?.Title, title, true) == 0)
                    return movie;
            };

            return null;
        }

        protected override Movie FindById ( int id )
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            };

            return null;
        }

        //private readonly Movie[] _movies = new Movie[100];
        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
