//William Sarawichitr
//ITSE-1430
//2-26-20
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
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var child = new CharacterForm();
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Save character
            _character = child.Character;
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = _character;
            //if (character == null)
            //    return;

            var child = new CharacterForm();
            child.Character = character;
            child.Text = "Edit Character";
            if (child.ShowDialog(this) != DialogResult.OK)
                return;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private Character _character;
    }
}
