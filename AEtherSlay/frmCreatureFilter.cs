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
        public short? minCR, maxCR, minAC, maxAC;

        public List<string> alignments = new List<string>()
                           ,sizes = new List<string>();

        public frmCreatureFilter()
        {
            InitializeComponent();
            nudMinCR.Value = -1;
            nudMaxCR.Value = -1;
            nudMinAC.Value = -1;
            nudMaxAC.Value = -1;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            minCR = (short)nudMinCR.Value;
            maxCR = (short)nudMaxCR.Value;
            minAC = (short)nudMinAC.Value;
            maxAC = (short)nudMaxAC.Value;
            foreach(string item in cblAlignment.CheckedItems)
            {
                alignments.Add(item);
            }
            if(alignments.Count == 0) { alignments = new List<String>() { "CG", "NG", "LG", "CN", "N", "LN", "CE", "NE", "LE" }; }
            foreach (string item in cblSize.CheckedItems)
            {
                sizes.Add(item);
            }
            if(sizes.Count == 0) { sizes = new List<string>() { "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan" }; }
            DialogResult = DialogResult.OK;
        }
    }
}
