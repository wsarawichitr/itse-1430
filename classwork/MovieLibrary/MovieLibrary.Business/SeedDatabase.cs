using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public static class SeedDatabase
    {
        //Extention method - are static methods of classes that appear as instance members on the applied type
        // Rules:
        //   1. Must be a static method
        //   2. Owning type must be static
        //   3. The first parameter must be proceeded with keyword 'this'
        //   4. Should behave just like instance member
        //   5. Do not add frivalous methods to core types
        public static IMovieDatabase SeedIfEmpty ( this IMovieDatabase database )
        {
            if (!database.GetAll().Any())
            {
                //Collection Initializer - works with anything with an Add method
                var demo = new Movie() { Title = "Dune", RunLength = 260, ReleaseYear = 1985 };
                var items = new [] {
                    new Movie() { Title = "Jaws", RunLength = 210, ReleaseYear = 1977 },
                    new Movie() { Title = "Jaws 2", RunLength = 220, ReleaseYear = 1979 },
                    demo,
                };

                //var movie = new Movie();
                //movie.title = "Jaws";
                //movie.RunLength = 210;
                foreach (var item in items)
                    database.Add(item);
            };

            return database;
        }
    }
}
