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
        
        private void OnSave ( object sender, EventArgs e )
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



            if (Character != null)
            {
                txtName.Text = Character.Name ?? "";

                txtStrength.Text = Character.Attribute[0].ToString();
                txtIntelligence.Text = Character.Attribute[1].ToString();
                txtAgility.Text = Character.Attribute[2].ToString();
                txtConstitution.Text = Character.Attribute[3].ToString();
                txtCharisma.Text = Character.Attribute[4].ToString();

                txtDescription.Text = Character.Description;

                if (Character.Profession != null)
                    ddlProfessions.SelectedText = Character.Profession.Description;
                if (Character.Race != null)
                    ddlRaces.SelectedText = Character.Race.Description;

                ValidateChildren();
            };
        }

        private Character GetCharacter ()
        {
            var character = new Character();

            character.Name = txtName.Text?.Trim();

            if (ddlProfessions.SelectedItem is Profession profession)
                character.Profession = profession;

            if (ddlRaces.SelectedItem is Race race)
                character.Race = race;

            character.Attribute[0] = GetAsInt32(txtStrength);
            character.Attribute[1] = GetAsInt32(txtIntelligence);
            character.Attribute[2] = GetAsInt32(txtAgility);
            character.Attribute[3] = GetAsInt32(txtConstitution);
            character.Attribute[4] = GetAsInt32(txtCharisma);

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
    }
}
