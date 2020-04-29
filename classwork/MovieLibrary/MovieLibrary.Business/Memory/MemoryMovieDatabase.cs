using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            throw new Exception("Failed");

            //Filtering
            var items = _movies.Where(m => true);

            //Transforms
            return _movies.Select(m => CloneMovie(m));

            //items.Any() => true if any elements meet a condition
            //items.All() => true for all elements
            //new[] { 1, 2 }.Join()(new[] { 3, 4, });
            //items.Max(i => i.Id); .Min(); .Sum()

            //Debug.WriteLine("Starting GetAllCore");

            ////use an iterator Luke
            //foreach (var movie in _movies)
            //{
            //    Debug.WriteLine($"Returning {movie.Id}");
            //    yield return CloneMovie(movie);
            //    Debug.WriteLine($"Returned {movie.Id}");
            //};
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

        private IEnumerable<Movie> Query ( string title, int releaseYear )
        {
            var query = from movie in _movies
                        select movie;

            if (!String.IsNullOrEmpty(title))
                query = query.Where(m => String.Compare(m.Title, title, true) == 0);

            if (releaseYear > 0)
                query = query.Where(m => m.ReleaseYear >= releaseYear);

            return query.ToList();
        }
        protected override Movie FindByTitle ( string title ) => (from movie in _movies
                                                                  where String.Compare(movie.Title, title, true) == 0
                                                                  select movie).FirstOrDefault();
            // 1. Expression body       => _movies.FirstOrDefault(m => String.Compare(m?.Title, title, true) == 0);
            // 2. Long way
        //{
        //    foreach (var movie in _movies)
        //    {
        //        if (String.Compare(movie?.Title, title, true) == 0)
        //            return movie;
        //    };

        //    return null;
        //}

        //private bool _SJDFLKJNOE ( Movie movie ) { return movie.Id == id; }

        //Lambda syntax ::= parameters => body
        // 0 parameters () => ?    Func<?>
        // 1 parameter, 1 return type ::=    x => E   ,   _ => E            Func<T, ?>
        // 2+ parameters  (x,y) => ?                                        Func<S, T, ?>
        // no return type => {}                                             Action<>
        // Multiple statment expressions => { S* }
        //       x => { Console.WriteLine(x); var y = x; return x; }
        //
        // General rules around lambdas
        //   1.\ No ref or out parameters
        //   2. Closure
        protected override Movie FindById ( int id ) => _movies.FirstOrDefault(m => m.Id == id);
        //{
        //    _movies.FirstOrDefault(m => m.Id == id);
        //    //var temp = new DummyType()  { Id = id };
        //    //_movies.FirstOrDefault(temp._SHJHDJ);

        //    foreach (var movie in _movies)
        //    {
        //        if (movie.Id == id)
        //            return movie;
        //    };

        //    return null;
        //}

        //private readonly Movie[] _movies = new Movie[100];
        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
