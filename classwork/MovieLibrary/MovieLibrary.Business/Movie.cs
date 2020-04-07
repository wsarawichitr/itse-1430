using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie : IValidatableObject
    {
        //public int Id
        //{
        //    get { return _id; }
        //    private set { _id = value; }
        //}
        //private int _id;
        public int Id { get; set; }

        public Genre Genre { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            //Never return null from a string prperty, always return empty string
            //get { return _title ?? ""; }
            get => _title ?? "";    // Expression body

            //Use null conditional operator if instance value can be null
            //set { _title = value?.Trim(); }
            set => _title = value?.Trim();  //Expression body
        }

        /// <summary>Gets or sets the run length in minutes.</summary>
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;
        public int RunLength { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            //1. Remove curlies
            //2. Put arrow after get
            //3. Remove return
            //get { return _description ?? ""; }
            get => _description ?? "";

            //set { _description = value?.Trim(); }
            set => _description = value?.Trim();
        }

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        public int ReleaseYear { get; set; }

        /// <summary>Determines if this is a classic movie.</summary>
        public bool IsClassic { get; set; }

        //Expression body for calculated properties
        // 1. Remove all curlies
        // 2. Remove return
        // 3. Arrow after property followed by expression
        //Calculated property, no setter
        public bool IsBlackAndWhite => ReleaseYear <= 1930;
        //{
        //    //get { return ReleaseYear <= 1930; }
        //    get => ReleaseYear <= 1930;
        //}
        //public bool IsBlackAndWhite = ReleaseYear <= 1930;
        //public List<string> SomeValue => new List<string>();
        //public List<string> SomeValue
        //{
        //    get { return new List<string(); }
        //}

        // Expression body
        // 1. Remove curlies
        // 2. Put in arrow after member
        // 3. Remove return
        // 4. Semicolon on end
        public override string ToString () => Title;
        //{
        //    return Title;
        //}

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //Title is required
            //if (txtTitle.Text?.Trim() == "")
            if (String.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Title is required.", new[] { nameof(Title) });
                //error = "Title is required.";
            };

            //Run length >= 0
            if (RunLength < 0)
            {
                yield return new ValidationResult("Run length must be >= 0.", new[] { nameof(RunLength) });
                //error = "Run length must be >= 0.";
            }


            //Release year >= 1900
            if (ReleaseYear < 1900)
            {
                yield return new ValidationResult("Release year must be >= 1900.", new[] { nameof(ReleaseYear) });
                //error = "Release year must be >= 1900.";
            };

            //error = null;
            //return true;
        }
        
        private string _title;
        private string _description;
    }
}
