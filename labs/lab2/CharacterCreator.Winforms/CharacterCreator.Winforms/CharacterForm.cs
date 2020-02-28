using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        private void CharacterForm_Load ( object sender, EventArgs e )
        {

        }

        public Character Character { get; set; }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnOK ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Populate comboboxes
            var professions = Professions.GetAll();
            ddlProfessions.Items.AddRange(professions);
            var races = Races.GetAll();
            ddlRaces.Items.AddRange(races);



            //if (Movie != null)
            //{
            //    txtTitle.Text = Movie.Title;
            //    txtDescription.Text = Movie.Description;
            //    txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            //    txtRunLength.Text = Movie.RunLength.ToString();
            //    chkIsClassic.Checked = Movie.IsClassic;

            //    if (Movie.Genre != null)
            //        ddlGenres.SelectedText = Movie.Genre.Description;

            //    ValidateChildren();
            //};
        }
    }
}
