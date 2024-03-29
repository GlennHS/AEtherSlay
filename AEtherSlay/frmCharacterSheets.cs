﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEtherSlay
{
    public partial class frmCharacterSheets : Form
    {
        TextBox[] coreStatBoxes;
        TextBox[] statModifierBoxes;
        Boolean editModeEnabled = false;
        Catalog.PlayerCharacter selectedCharacter;
        List<Catalog.Weapon> storedWeapons = new List<Catalog.Weapon>();
        Catalog.Armor storedArmor;

        public frmCharacterSheets()
        {
            InitializeComponent();

            coreStatBoxes = new TextBox[] { txtStr, txtCon, txtDex, txtInt, txtWis, txtCha };
            statModifierBoxes = new TextBox[] { txtStrMod, txtConMod, txtDexMod, txtIntMod, txtWisMod, txtChaMod };
        }

        private void FrmCharacterSheets_Load(object sender, EventArgs e)
        {
            bindCharComboBox(cbCharName);
        }

        private void bindCharComboBox(ComboBox combobox)
        {
            List<Catalog.PlayerCharacter> charSheets = Program.storage.retrieveAllCharacterSheets();
            foreach (Catalog.PlayerCharacter character in charSheets)
            {
                ComboboxItem cmbItem = new ComboboxItem();
                cmbItem.Text = character.name;
                cmbItem.Value = character;

                combobox.Items.Add(cmbItem);
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void CbCharName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedCharacterItem = (ComboboxItem)(cbCharName.SelectedItem);
            selectedCharacter = (Catalog.PlayerCharacter)selectedCharacterItem.Value;

            storedWeapons = new List<Catalog.Weapon>();
            storedArmor = null;

            Int16 i = 0;

            #region Calculate Core Modifiers
            foreach (TextBox box in statModifierBoxes)
            {
                box.Text = selectedCharacter.statMods[i].ToString();
                i++;
            }
            #endregion

            i = 0;
            foreach (TextBox box in coreStatBoxes)
            {
                box.Text = selectedCharacter.stats[i].ToString();
                i++;
            }

            txtRace.Text = selectedCharacter.raceName;
            txtClass.Text = selectedCharacter.className;
            txtProf.Text = "2";
            txtSpeed.Text = selectedCharacter.speed.ToString();
            txtAC.Text = selectedCharacter.ac.ToString();
            lblAlignment.Text = selectedCharacter.alignment;
            txtInit.Text = txtDexMod.Text;
            txtHP.Text = (selectedCharacter.hitDiceSides + selectedCharacter.statMods[1]).ToString();
            if(selectedCharacter.armor != null)
            {
                storedArmor = selectedCharacter.armor;
                txtArmor.Text = storedArmor.name;
            } else {
                txtArmor.Text = "";
            }
            chbShield.Checked = selectedCharacter.hasShield;
            lbWeapons.Items.Clear();
            if (selectedCharacter.weapons != null)
            {
                foreach (Catalog.Weapon weap in selectedCharacter.weapons) {
                    storedWeapons.Add(weap);
                    lbWeapons.Items.Add($"{weap.quantity} x {weap.name}");
                }
            } else {
                lbWeapons.Items.Clear();
            }
            txtName.Text = selectedCharacter.name;
            rtbNotes.Text = selectedCharacter.notes;

            rtbProficiencies.Text = "PROFICIENCIES\n\n";
            try
            {
                foreach (String prof in selectedCharacter.proficiencies) { rtbProficiencies.Text += prof + "\n"; }
            }
            catch { }

            rtbTraits.Text = "TRAITS\n\n";
            try
            {
                foreach (String trait in selectedCharacter.traits) { rtbTraits.Text += trait + "\n"; }
            }
            catch { }

            rtbLanguages.Text = "LANGUAGES\n\n";
            try
            {
                foreach (String language in selectedCharacter.languages) { rtbLanguages.Text += language + "\n"; }
            }
            catch { }

            rtbEquipment.Text = "EQUIPMENT\n\n";
            try
            {
                foreach (String equip in selectedCharacter.equipment) { rtbEquipment.Text += equip + "\n"; }
            }
            catch { }
        }

        private void lbWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(storedWeapons[lbWeapons.SelectedIndex].getDmgString());
        }

        private void btnEnableEdit_Click(object sender, EventArgs e)
        {
            if(editModeEnabled)
            {
                saveCharacter();
                editModeEnabled          = false;
                btnEnableEdit.Text       = "Enable Editing";
                btnAddArmor.Enabled      = false;
                txtStr.Enabled           = false;
                txtStrMod.Enabled        = false;
                txtCon.Enabled           = false;
                txtConMod.Enabled        = false;
                txtDex.Enabled           = false;
                txtDexMod.Enabled        = false;
                btnAddWeapon.Enabled     = false;
                txtInt.Enabled           = false;
                txtIntMod.Enabled        = false;
                txtWis.Enabled           = false;
                txtWisMod.Enabled        = false;
                txtCha.Enabled           = false;
                txtChaMod.Enabled        = false;
                txtRace.Enabled          = false;
                txtClass.Enabled         = false;
                txtAC.Enabled            = false;
                txtSpeed.Enabled         = false;
                rtbProficiencies.Enabled = false;
                rtbLanguages.Enabled     = false;
                rtbEquipment.Enabled     = false;
                rtbTraits.Enabled        = false;
                rtbNotes.Enabled         = false;
                chbShield.Enabled        = false;
            } else
            {
                editModeEnabled          = true;
                btnEnableEdit.Text       = "Save Character";
                btnAddArmor.Enabled      = true;
                txtStr.Enabled           = true;
                txtStrMod.Enabled        = true;
                txtCon.Enabled           = true;
                txtConMod.Enabled        = true;
                txtDex.Enabled           = true;
                txtDexMod.Enabled        = true;
                btnAddWeapon.Enabled     = true;
                txtInt.Enabled           = true;
                txtIntMod.Enabled        = true;
                txtWis.Enabled           = true;
                txtWisMod.Enabled        = true;
                txtCha.Enabled           = true;
                txtChaMod.Enabled        = true;
                txtRace.Enabled          = true;
                txtClass.Enabled         = true;
                txtAC.Enabled            = true;
                txtSpeed.Enabled         = true;
                rtbProficiencies.Enabled = true;
                rtbLanguages.Enabled     = true;
                rtbEquipment.Enabled     = true;
                rtbTraits.Enabled        = true;
                rtbNotes.Enabled         = true;
                chbShield.Enabled        = true;
            }
        }

        private void saveCharacter()
        {
            String newName  = txtName.Text;
            String newRace  = txtRace.Text;
            String newClass = txtClass.Text;
            String newHP    = txtHP.Text;
            String newProf  = txtProf.Text;
            String newSpeed = txtSpeed.Text;
            String newInit  = txtInit.Text;
            short[] newStats = new short[] { short.Parse(txtStr.Text), short.Parse(txtCon.Text), short.Parse(txtDex.Text), short.Parse(txtInt.Text), short.Parse(txtWis.Text), short.Parse(txtCha.Text) };
            short[] newStatMods = new short[] { short.Parse(txtStrMod.Text), short.Parse(txtConMod.Text), short.Parse(txtDexMod.Text), short.Parse(txtIntMod.Text), short.Parse(txtWisMod.Text), short.Parse(txtChaMod.Text) };
            Catalog.Armor  newArmor = storedArmor;
            List<Catalog.Weapon> newWeapons = storedWeapons;
        }

        private void btnAddArmor_Click(object sender, EventArgs e)
        {
            if (selectedCharacter != null)
            {
                var frmArmor = new frmNewArmor();
                frmArmor.ShowDialog();
                if (frmArmor.DialogResult == DialogResult.OK)
                {
                    storedArmor = frmArmor.createdArmor;
                }
                frmArmor.Dispose();
            }
        }

        //private void lbWeapons_MouseHover(object sender, EventArgs e)
        //{
        //    Point point = lbWeapons.PointToClient(Cursor.Position);
        //    int index = lbWeapons.IndexFromPoint(point);
        //    if (index < 0) return;
        //    // Sketchy Stack Overflow job
        //    try
        //    {
        //        ToolTip ttWeap = new ToolTip();
        //        Catalog.Weapon hoveredWeap = Program.catalog.findWeapon((String)lbWeapons.Items[index]);
        //        ttWeap.BackColor = Color.White;
        //        ttWeap.ForeColor = Color.Black;
        //        ttWeap.Show($"This weapon is called {hoveredWeap.name}", this);
        //    } catch
        //    {
        //        Console.WriteLine("Why did you ever think that was a good idea");
        //    }
        //}
    }
}
