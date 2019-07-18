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
    public partial class frmMain : Form
    {
        Random   rand = new Random();
        bool  allAtOnceRollStyle = false;
        short[]  diceQuantityArray = new short[7];
        Object[] btnOuts = new TextBox[7];
        bool  coinInUse = false;
        Image    imgHeads = Image.FromFile("../Images/DnDCoinH.png");
        Image    imgTails = Image.FromFile("../Images/DnDCoinT.png");

        public frmMain()
        {
            InitializeComponent();
            btnOuts = new object[] { txtD4, txtD6, txtD8, txtD10, txtD12, txtD20, txtD100 };
            foreach (TextBox box in btnOuts)
            {
                box.Enabled = false;
                box.Text = "0";
            }
            lblVersion.Text = "Version Number: " + Program.version;
            pbCoin.Image = Image.FromFile("../Images/DnDCoinH.png");
        }

        private void btnD4_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD4.Text = (Convert.ToInt16(txtD4.Text) + 1).ToString();
            }
            else
            {
                txtD4.Text = rand.Next(1, 5).ToString();
            }
        }

        private void btnD6_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD6.Text = (Convert.ToInt16(txtD6.Text) + 1).ToString();
            }
            else
            {
                txtD6.Text = rand.Next(1, 7).ToString();
            }
        }

        private void btnD8_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD8.Text = (Convert.ToInt16(txtD8.Text) + 1).ToString();
            }
            else
            {
                txtD8.Text = rand.Next(1, 9).ToString();
            }
        }

        private void btnD10_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD10.Text = (Convert.ToInt16(txtD10.Text) + 1).ToString();
            }
            else
            {
                txtD10.Text = rand.Next(1, 11).ToString();
            }
        }

        private void btnD12_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD12.Text = (Convert.ToInt16(txtD12.Text) + 1).ToString();
            }
            else
            {
                txtD12.Text = rand.Next(1, 13).ToString();
            }
        }

        private void btnD20_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD20.Text = (Convert.ToInt16(txtD20.Text) + 1).ToString();
            }
            else
            {
                txtD20.Text = rand.Next(1, 21).ToString();
            }
        }

        private void btnD100_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                txtD100.Text = (Convert.ToInt16(txtD100.Text) + 1).ToString();
            }
            else
            {
                txtD100.Text = rand.Next(1, 101).ToString();
            }
        }

        private void rbCumulative_CheckedChanged(object sender, EventArgs e)
        {
            allAtOnceRollStyle = true;
            foreach (TextBox box in btnOuts)
            {
                box.Enabled = true;
                box.Text = "0";
            }
        }

        private void rbOneByOne_CheckedChanged(object sender, EventArgs e)
        {
            allAtOnceRollStyle = false;
            foreach (TextBox box in btnOuts)
            {
                box.Enabled = false;
                box.Text = "0";
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (allAtOnceRollStyle)
            {
                String  outString = "Your Rolls Were As Follows:\n";
                Int16[] diceSides = new short[] { 4, 6, 8, 10, 12, 20, 100 };
                Int16   rolled = 0;
                Int16   total = 0;
                Int16   i = 0;

                foreach (TextBox box in btnOuts)
                {
                    diceQuantityArray[i] = Convert.ToInt16(box.Text);
                    i++;
                }
                for (i = 0; i < 7; i++)
                {
                    for (Int16 numDice = 0; numDice < diceQuantityArray[i]; numDice++)
                    {
                        rolled = Convert.ToInt16(rand.Next(1, diceSides[i] + 1));
                        total += rolled;
                        outString += "\n 1d" + diceSides[i].ToString() + ": " + rolled.ToString();
                    }
                }
                outString += "\nTotal Rolled: " + total.ToString();
                MessageBox.Show(outString);
                // CLEAR TEXT BOXES ON ALL AT ONCE ROLL //
                //**************************************//
                //foreach (TextBox box in btnOuts)
                //{
                //    box.Text = "0";
                //}
            }
        }

        private void pbCoin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String result = "Coin Flip Failed.\nPlease contact the developer at glenniumhs@gmail.com";
            if(!coinInUse) {
                coinInUse = true;

                for (Int16 i = 0; i < 5; i++)
                {
                    if (rand.Next(1, 3) == 2)
                    {
                        pbCoin.Image = imgHeads;
                        result = "Heads!";
                    }
                    else
                    {
                        pbCoin.Image = imgTails;
                        result = "Tails!";
                    }
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                }
                coinInUse = false;
                Cursor.Current = Cursors.Default;
                MessageBox.Show(result);
            }
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            Form charDialog = new frmCharacterDialog();
            charDialog.Show();
        }

        private void BtnCreature_Click(object sender, EventArgs e)
        {
            Form creatureFrm = new frmCreatureCreation();
            creatureFrm.Show();
        }

        private void BtnCharSheets_Click(object sender, EventArgs e)
        {
            Form charSheetsfrm = new frmCharacterSheets();
            charSheetsfrm.Show();
        }
    }
}
