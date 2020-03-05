using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class SeedDatabase
    {
        public IMovieDatabase SeedIfEmpty ( IMovieDatabase database )
        {
            if (database.GetAll().Length == 0)
            {
                database.Add(new Movie() { Title = "Jaws", RunLength = 210, ReleaseYear = 1977 });
                database.Add(new Movie() { Title = "Jaws 2", RunLength = 220, ReleaseYear = 1979 });
                database.Add(new Movie() { Title = "Dune", RunLength = 260, ReleaseYear = 1985 });
            };

            return database;
        }
    }
}
