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
            CharacterForm character = new CharacterForm();
            if (character.ShowDialog(this) != DialogResult.OK)
                return;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        
    }
}
