﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;

namespace MovieLibrary.Winforms
{
    public partial class MovieForm : Form
    {
        #region Constructors

        public MovieForm ()
        {
            InitializeComponent();
        }

        //Call the more specific constructor first - constructor chaining
        public MovieForm ( Movie movie ) : this(movie != null ? "Edit" : "Add", movie)
        {
            //InitializeComponent();
            //Movie = movie;

            //Text = movie != null ? "Edit" : "Add";
        }

        public MovieForm ( string title, Movie movie ) : this()
        {
            Text = title;
            Movie = movie;
        }

        //private void Initialize ( string title, Movie movie )
        //{
        //    InitializeComponent();
        //    Text = title;
        //    Movie = movie;
        //}
        #endregion

        public Movie Movie { get; set; }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Event Handlers

        private void OnOK ( object sender, EventArgs e )
        {
            // Validation and error reporting
            var movie = GetMovie();
            if (!movie.Validate(out var error))
            {
                DisplayError(error);
                return;
            };

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                txtTitle.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                txtRunLength.Text = Movie.RunLength.ToString();
                chkIsClassic.Checked = Movie.IsClassic;
            }
        }

        private Movie GetMovie ()
        {
            var movie = new Movie();

            //Null conditional
            movie.Title = txtTitle.Text?.Trim();
            movie.RunLength = GetAsInt32(txtRunLength);
            movie.ReleaseYear = GetAsInt32(txtReleaseYear);
            movie.Description = txtDescription.Text.Trim();
            movie.IsClassic = chkIsClassic.Checked;

            return movie;
        }

        /// <summary>Displays an error message.</summary>
        /// <param name="message"></param>
        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetAsInt32 ( Control control )
        {
            return GetAsInt32(control, 0);
        }

        private int GetAsInt32 ( Control control, int emptyValue )
        {
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }
    }  
}
