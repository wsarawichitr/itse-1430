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

            _icharacters = new CharacterRoster();
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

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //AddCharacter(child.Character);
            var character = _icharacters.Add(child.Character);
            UpdateUI();
            
        }

        //private void AddCharacter ( Character character )
        //{
        //    for (var index = 0; index < _characters.Length; ++index)
        //    {
        //        if (_characters[index] == null)
        //        {
        //            _characters[index] = character;
        //            break;
        //        }
        //    }
        //}

        private void UpdateUI ()
        {
            listCharacters.Items.Clear();

            //var characters = GetCharacters();
            //foreach (var character in characters)
            //{
            //    if (character != null)
            //        listCharacters.Items.Add(character);
            //}

            var characters = _icharacters.GetAll();
            listCharacters.Items.AddRange(characters.ToArray());
        }

        private Character[] GetCharacters ()
        {
            return _characters;
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

                //Save edit
                //UpdateCharacter(character, child.Character);

                var error = _icharacters.Update(character.Id, child.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };
                DisplayError(error);
            } while (true);
        }

        private void UpdateCharacter ( Character oldCharacter, Character newCharacter )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == oldCharacter)
                {
                    _characters[index] = newCharacter;
                    break;
                };
            };
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;



            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "Delete"))
                return;

            //DeleteCharacter(character);
            _icharacters.Delete(character.Id);
            UpdateUI();

        }

        //private void DeleteCharacter ( Character character )
        //{
        //    for (var index = 0; index < _characters.Length; ++index)
        //    {
        //        if (_characters[index] == character)
        //        {
        //            _characters[index] = null;
        //            break;
        //        };
        //    };
        //}

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }
        
        private Character[] _characters = new Character[100];
        private readonly ICharacterRoster _icharacters;
    }
}
