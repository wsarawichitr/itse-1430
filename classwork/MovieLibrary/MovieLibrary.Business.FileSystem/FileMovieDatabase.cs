using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business.FileSystem
{
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase ( string filename )
        {
            if (_filename == null)
                throw new ArgumentNullException(nameof(filename)); //"filename"
            if (String.IsNullOrEmpty(_filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            _filename = filename;
            
        }

        protected override Movie AddCore ( Movie movie )
        {
            throw new NotImplementedException();
        }

        protected override void DeleteCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override Movie FindById ( int id )
        {
            throw new NotImplementedException();
        }

        protected override Movie FindByTitle ( string title )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            throw new NotImplementedException();
        }

        protected override Movie GetCore ( int id )
        {
            throw new NotImplementedException();
        }

        //protected override IEnumerable<Movie> GetAllCore ()
        //{
        //    return Enumerable.Empty
        //}

        protected override void UpdateCore ( int id, Movie movie )
        {
            throw new NotImplementedException();
        }

        private readonly string _filename;
    }
}
