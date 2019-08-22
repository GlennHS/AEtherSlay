using System;
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
    public partial class frmSpells : Form
    {
        public List<Catalog.Spell> validSpells;
        public frmSpells()
        {
            InitializeComponent();

            foreach (string c in Enum.GetNames(typeof(Catalog.CharacterClass)))
            {
                cmbClasses.Items.Add(c);
            }
        }

        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxSpellList.Items.Clear();
            validSpells = Catalog.getValidSpellsByClass(cmbClasses.Text);
            validSpells.Sort((a, b) => a.level.CompareTo(b.level));
            foreach (Catalog.Spell s in validSpells)
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
    }
}
