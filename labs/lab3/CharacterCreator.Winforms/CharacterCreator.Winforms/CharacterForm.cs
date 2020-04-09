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
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }
        
        public Character Character { get; set; }
        
        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var character = GetCharacter();

            var errors = ObjectValidator.Validate(character);
            if(errors.Any())
            {
                MessageBox.Show("Errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Character = character;
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
            if (ddlProfessions.Items.Count == 0)
            {
                var professions = Professions.GetAll();
                ddlProfessions.Items.AddRange(professions);
            }
            if (ddlRaces.Items.Count == 0)
            {
                var races = Races.GetAll();
                ddlRaces.Items.AddRange(races);
            }
            
            txtStrength.Text = "50";
            txtIntelligence.Text = "50";
            txtAgility.Text = "50";
            txtConstitution.Text = "50";
            txtCharisma.Text = "50";

            if (Character != null)
            {
                txtName.Text = Character.Name ?? "";

                txtStrength.Text = Character.Attributes[0].ToString();
                txtIntelligence.Text = Character.Attributes[1].ToString();
                txtAgility.Text = Character.Attributes[2].ToString();
                txtConstitution.Text = Character.Attributes[3].ToString();
                txtCharisma.Text = Character.Attributes[4].ToString();

                txtDescription.Text = Character.Description;

                if (Character.Profession != null)
                {
                    //ddlProfessions.SelectedText = Character.Profession.Description;
                    ddlProfessions.SelectedIndex = Character.Profession.Index;
                }
                if (Character.Race != null)
                {
                    //ddlRaces.SelectedText = Character.Race.Description;
                    ddlRaces.SelectedIndex = Character.Race.Index;
                }

                ValidateChildren();
            };
        }

        private Character GetCharacter ()
        {
            var character = new Character();

            character.Name = txtName.Text?.Trim();

            if (ddlProfessions.SelectedItem is Profession profession)
            {
                character.Profession = profession;
                character.Profession.Index = ddlProfessions.SelectedIndex;
            }

            if (ddlRaces.SelectedItem is Race race)
            {
                character.Race = race;
                character.Race.Index = ddlRaces.SelectedIndex;
            }

            character.Attributes[0] = GetAsInt32(txtStrength);
            character.Attributes[1] = GetAsInt32(txtIntelligence);
            character.Attributes[2] = GetAsInt32(txtAgility);
            character.Attributes[3] = GetAsInt32(txtConstitution);
            character.Attributes[4] = GetAsInt32(txtCharisma);

            character.Description = txtDescription.Text.Trim();



            return character;
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

        private void OnValidateProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if ( ddlProfessions.SelectedIndex == -1 )
            {
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateRace ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (ddlRaces.SelectedIndex == -1)
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateAttribute ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 50);
            if (value < 1 || value > 100)
            {
                _errors.SetError(control, "Attributes must be from 1-100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        



        private void CharacterForm_Load ( object sender, EventArgs e )
        {

        }
    }
}
