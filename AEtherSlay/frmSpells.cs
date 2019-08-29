using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AEtherSlay
{
    public partial class frmSpells : Form
    {
        public frmSpells()
        {
            InitializeComponent();

            foreach (string c in Enum.GetNames(typeof(Catalog.CharacterClass)))
            {
                cmbClasses.Items.Add(c);
                cmbFilterClass.Items.Add(c);
            }
            foreach (string s in Enum.GetNames(typeof(Catalog.SpellSchools)))
            {
                cmbFilterSchool.Items.Add(s);
            }
            for(int i = 0; i < 9; i++) { cblFilterLevel.Items.Add(i + 1); }
        }

        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxSpellList.Items.Clear();
            updateSpellLBX(Catalog.getValidSpellsByClass(cmbClasses.Text));
        }

        private void updateSpellLBX(List<Catalog.Spell> sList)
        {
            sList.Sort((a, b) => a.level.CompareTo(b.level));
            foreach (Catalog.Spell s in sList)
            {
                lbxSpellList.Items.Add(s.name);
            }
        }

        private void LbxSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Catalog.Spell selectedSpell = Program.catalog.getSpellByName(lbxSpellList.Text);
            txtCastTime.Text = selectedSpell.casting_time;
            txtDuration.Text = selectedSpell.duration;
            txtLevel.Text = selectedSpell.level.ToString();
            txtName.Text = selectedSpell.name;
            txtRange.Text = selectedSpell.range;
            rtbComponents.Text = selectedSpell.components;
            chkRitual.Checked = selectedSpell.ritual;
            rtbDescription.Text = selectedSpell.description;
            txtSchool.Text = selectedSpell.school;
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            List<Catalog.Spell> validSpells = new List<Catalog.Spell>();
            List<short> validLevels = new List<short>();
            lbxSpellList.Items.Clear();
            foreach (int lvl in cblFilterLevel.SelectedItems)
            {
                validLevels.Add((short)lvl);
            }
            foreach (Catalog.Spell s in Program.storage.spellList)
            {
                bool valid = true;
                Regex matchMaterialComponent = new Regex("M\\s\\(");
                Regex matchSomaticComponent = new Regex("S,?\\W");
                Regex matchVerbalComponent = new Regex("V,?\\W");
                if (chkFilterComponentM.Checked && !(matchMaterialComponent.IsMatch(s.components))) { valid = false; }
                if (chkFilterComponentS.Checked && !(matchSomaticComponent.IsMatch(s.components))) { valid = false; }
                if (chkFilterComponentV.Checked && !(matchVerbalComponent.IsMatch(s.components))) { valid = false; }
                if (txtFilterName.Text != "" && !s.name.Contains(txtFilterName.Text)) { valid = false; }
                if (chkFilterRitual.Checked && (s.ritual != true)) { valid = false; }
                if(validLevels.Count != 0)
                {
                    if(!validLevels.Contains(s.level)) { valid = false; }
                }

                if (valid) { validSpells.Add(s); }
            }
            updateSpellLBX(validSpells);
        }
    }
}
