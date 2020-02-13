using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie
    {
        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _title;

        /// <summary>Gets or sets the run length in minutes.</summary>
        public int RunLength
        {
            get { return _runLength; }
            set { _runLength = value; }
        }
        private int _runLength;

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _description;

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }
        private int _releaseYear = 1900;

        /// <summary>Determines if this is a classic movie.</summary>
        public bool isClassic
        {
            get { return _isClassic; }
            set { _isClassic = value; }
        }
        private bool _isClassic;
    }
}
