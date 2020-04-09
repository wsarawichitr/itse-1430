//William Sarawichitr
//ITSE-1430
//4-6-20
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

            _characters = new MemoryCharacterRoster();
        }

        private bool DisplayConfirmation ( string message, string title )
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var child = new CharacterForm();

            
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                var character = _characters.Add(child.Character);
                if (character == null)
                {
                    DisplayError("Character with the same name already exists");
                } 
                else
                {
                    UpdateUI();
                    return;
                }
                
            } while (true);

        }

        private void UpdateUI ()
        {
            listCharacters.Items.Clear();

            //var characters = GetCharacters();
            //foreach (var character in characters)
            //{
            //    if (character != null)
            //        listCharacters.Items.Add(character);
            //}

            var characters = _characters.GetAll();
            listCharacters.Items.AddRange(characters.ToArray());
        }
        
        private Character GetSelectedCharacter ()
        {
            return listCharacters.SelectedItem as Character;
        }
        

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var child = new CharacterForm();
            child.Character = character;
            child.Text = "Edit Character";

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Update(character.Id, child.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };
                DisplayError(error);
            } while (true);
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;



            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "Delete"))
                return;
            
            _characters.Delete(character.Id);
            UpdateUI();

        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }
        
        private readonly ICharacterRoster _characters;
    }
}
