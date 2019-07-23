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
    public partial class frmCreatureFilter : Form
    {
        public short? minCR, maxCR, minAC, maxAC, minHP, maxHP;

        public List<string> alignments = new List<string>()
                           ,sizes = new List<string>();

        public frmCreatureFilter()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            minCR = (short)nudMinCR.Value;
            maxCR = (short)nudMaxCR.Value;
            minAC = (short)nudMinAC.Value;
            maxAC = (short)nudMaxAC.Value;
            //alignments = cblAlignment.SelectedItems.Cast<List<string>>();
            DialogResult = DialogResult.OK;
        }
    }
}
