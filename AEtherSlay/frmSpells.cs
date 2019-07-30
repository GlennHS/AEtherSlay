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

            foreach (string c in Enum.GetValues(typeof(Catalog.CharacterClass)))
            {
                lbxSpellList.ValueMember = "this";
                lbxSpellList.DisplayMember = "name";
                cmbClasses.Items.Add(c);
            }
        }

        private void CmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            validSpells = Catalog.getValidSpells(cmbClasses.SelectedText);
            foreach(Catalog.Spell s in validSpells)
            {
                lbxSpellList.Items.Add(s);
            }
        }
    }
}
