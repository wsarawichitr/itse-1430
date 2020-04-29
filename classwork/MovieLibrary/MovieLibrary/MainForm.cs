using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;    //Language Intergrated Natural Query
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;
using MovieLibrary.Business.Memory;
using MovieLibrary.Winforms;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();

            _movies = new MemoryMovieDatabase();

            #region Playing with objects

            //Full name
            //MovieLibrary.Business.Movie;
            //var movie = new Movie();

            //movie.title = "Jaws";
            //movie.description = movie.title;

            //movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);
            //DisplayConfirmation("Are you sure?", "Start");
            #endregion
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Call extension method as through it is an instance
            //SeedDatabase.SeedIfEmpty(_movies); //Compiles to this
            try
            {
                _movies.SeedIfEmpty();
            } catch (InvalidOperationException)
            {
                DisplayError("Invalid op");
            } catch (ArgumentException)
            {
                DisplayError("Invalid argument");
            } catch (Exception ex)
            {
                DisplayError(ex.Message);
            };

            UpdateUI();
        }

        private bool DisplayConfirmation ( string message, string title )
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        /// <summary>Displays an error message.</summary>
        /// <param name="message">Error to display.</param>
        private void DisplayError ( string message )
        {
            #region Playing with this

            //this represents the current instance
            //var that = this;

            //var Text = "";

            //These are equal
            //var newTitle = this.Text;
            //var newTitle = Text;
            #endregion

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Playing with methods

        void DisplayMovie ( Movie movie )
        {
            if (movie == null)
                return;

            var title = movie.Title;
            movie.Description = "Test";

            movie = new Movie();
        }
        #endregion

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            MovieForm child = new MovieForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the movie
                var movie = _movies.Add(child.Movie);
                if (movie != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError("Add failed");
            } while (true);
        }

        private Movie GetSelectedMovie ()
        {
            //Preferred
            //return listMovies.SelectedItem as Movie;

            //
            // IEnumerable <T> returning LINQ methods are deferred execution
            // All other methods execute immeditately - To?, First?, Last?, Single?
            //

            //SelectedObjectCollection : IEnumerable
            // IEnumerable<T> Cast<T> ( this IEnumberable source )
            // IEnumerable<T> OfType<T> ( this IEnumerable source )
            var selectedItems = listMovies.SelectedItems.OfType<Movie>();

            // T? FirstOrDefault ( this IEnumerable<T> ) :: Returns first item that meets criteria or default for type if none
            // T? LastOrDefault ( this IEnumerable<T> ) :: Returns last item that meets criteria or default for type if none; not always supported

            // T First ( this IEnumerable<T> ) :: Returns first item that meets criteria or blows up
            // T Last ( this IEnumerable<T> ) :: Returns last item that meets criteria or blows up

            // T? SingleOrDefault ( this IEnumerable<T> ) :: Returns the only item that meets criteria or default for type if none, blows up if more than one meets criteria
            // T Single ( this IEnumerable<T> ) :: Returns the only item that meets criteria or blows up
            return selectedItems.FirstOrDefault();
        }

        //private string SortByTitle ( Movie movie ) => movie.Title;
        //private int SortByReleaseYear ( Movie movie ) => movie.ReleaseYear;

        private void UpdateUI ()
        {
            listMovies.Items.Clear();

            //Extention method approach
            //var movies = _movies.GetAll()
            //                    .OrderBy(movie => movie.Title)// IEnumberable<T> OrderBy<T> (this IEnumberable<T> source, Func<T, string> sorter );
            //                    .ThenByDescending(movie => movie.ReleaseYear)
            //                    ;

            //Error handling = try-catch block
            // try
            // { S* } 
            // catch 
            // { S* }
            //
            var movies = Enumerable.Empty<Movie>();
            try
            {
                movies = _movies.GetAll();
                //other things
            } catch (Exception e)
            {
                DisplayError($"Failed to load movies: {e.Message}");
            };

            //LINQ syntx
            //   from movie in IEnumerable<T>
            // [where expression]
            // [orderby property1 [, other properties]
            //   select movie
            movies = from movie in movies
                         where movie.Id > 0
                         orderby movie.Title, movie.ReleaseYear descending
                         select movie;

            // T[] ToArray ( this IEnumerable<T> source ) = returns source as an array
            // List<T> ToList ( this IEnumerable<T> source ) = returns source as an List<T>
            //var temp = new List<Movie>();
            //foreach (var item in _movies)
            //    temp.Add(item);
            //return temp;
            listMovies.Items.AddRange(movies.ToArray()); //Enumerable.ToArray(movies)
            //foreach (var movie in movies)
            //{
            //    listMovies.Items.Add(movie);
            //};
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.Movie = movie;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                // Save the movie
                var error = _movies.Update(movie.Id, child.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };
                DisplayError(error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {movie.Title}?", "Delete"))
                return;

            //TODO: Delete
            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        //private Movie _movie;
        private readonly IMovieDatabase _movies;
    }
}
