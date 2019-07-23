namespace AEtherSlay
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnCharacter = new System.Windows.Forms.Button();
            this.btnEncounter = new System.Windows.Forms.Button();
            this.btnCreature = new System.Windows.Forms.Button();
            this.rbOneByOne = new System.Windows.Forms.RadioButton();
            this.rbCumulative = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.txtD100 = new System.Windows.Forms.TextBox();
            this.btnD100 = new System.Windows.Forms.Button();
            this.txtD20 = new System.Windows.Forms.TextBox();
            this.txtD12 = new System.Windows.Forms.TextBox();
            this.txtD10 = new System.Windows.Forms.TextBox();
            this.txtD8 = new System.Windows.Forms.TextBox();
            this.txtD6 = new System.Windows.Forms.TextBox();
            this.btnD20 = new System.Windows.Forms.Button();
            this.btnD12 = new System.Windows.Forms.Button();
            this.btnD10 = new System.Windows.Forms.Button();
            this.btnD8 = new System.Windows.Forms.Button();
            this.btnD6 = new System.Windows.Forms.Button();
            this.txtD4 = new System.Windows.Forms.TextBox();
            this.btnD4 = new System.Windows.Forms.Button();
            this.btnMapGen = new System.Windows.Forms.Button();
            this.btnItemGen = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbCoin = new System.Windows.Forms.PictureBox();
            this.btnBattleTracker = new System.Windows.Forms.Button();
            this.btnEnemySheets = new System.Windows.Forms.Button();
            this.btnCharSheets = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCoin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCharacter
            // 
            this.btnCharacter.BackColor = System.Drawing.Color.Black;
            this.btnCharacter.ForeColor = System.Drawing.Color.White;
            this.btnCharacter.Location = new System.Drawing.Point(14, 134);
            this.btnCharacter.Name = "btnCharacter";
            this.btnCharacter.Size = new System.Drawing.Size(127, 33);
            this.btnCharacter.TabIndex = 0;
            this.btnCharacter.Text = "Character Creation";
            this.btnCharacter.UseVisualStyleBackColor = false;
            this.btnCharacter.Click += new System.EventHandler(this.btnCharacter_Click);
            // 
            // btnEncounter
            // 
            this.btnEncounter.BackColor = System.Drawing.Color.Black;
            this.btnEncounter.ForeColor = System.Drawing.Color.White;
            this.btnEncounter.Location = new System.Drawing.Point(14, 213);
            this.btnEncounter.Name = "btnEncounter";
            this.btnEncounter.Size = new System.Drawing.Size(127, 33);
            this.btnEncounter.TabIndex = 1;
            this.btnEncounter.Text = "Encounter Creation";
            this.btnEncounter.UseVisualStyleBackColor = false;
            // 
            // btnCreature
            // 
            this.btnCreature.BackColor = System.Drawing.Color.Black;
            this.btnCreature.ForeColor = System.Drawing.Color.White;
            this.btnCreature.Location = new System.Drawing.Point(14, 174);
            this.btnCreature.Name = "btnCreature";
            this.btnCreature.Size = new System.Drawing.Size(127, 33);
            this.btnCreature.TabIndex = 2;
            this.btnCreature.Text = "5e Creature Catalog";
            this.btnCreature.UseVisualStyleBackColor = false;
            this.btnCreature.Click += new System.EventHandler(this.BtnCreature_Click);
            // 
            // rbOneByOne
            // 
            this.rbOneByOne.AutoSize = true;
            this.rbOneByOne.BackColor = System.Drawing.Color.Black;
            this.rbOneByOne.Checked = true;
            this.rbOneByOne.ForeColor = System.Drawing.Color.Silver;
            this.rbOneByOne.Location = new System.Drawing.Point(6, 19);
            this.rbOneByOne.Name = "rbOneByOne";
            this.rbOneByOne.Size = new System.Drawing.Size(83, 17);
            this.rbOneByOne.TabIndex = 6;
            this.rbOneByOne.TabStop = true;
            this.rbOneByOne.Text = "One By One";
            this.rbOneByOne.UseVisualStyleBackColor = false;
            this.rbOneByOne.CheckedChanged += new System.EventHandler(this.rbOneByOne_CheckedChanged);
            // 
            // rbCumulative
            // 
            this.rbCumulative.AutoSize = true;
            this.rbCumulative.BackColor = System.Drawing.Color.Black;
            this.rbCumulative.ForeColor = System.Drawing.Color.Silver;
            this.rbCumulative.Location = new System.Drawing.Point(6, 45);
            this.rbCumulative.Name = "rbCumulative";
            this.rbCumulative.Size = new System.Drawing.Size(78, 17);
            this.rbCumulative.TabIndex = 7;
            this.rbCumulative.Text = "All At Once";
            this.rbCumulative.UseVisualStyleBackColor = false;
            this.rbCumulative.CheckedChanged += new System.EventHandler(this.rbCumulative_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.btnRoll);
            this.groupBox1.Controls.Add(this.txtD100);
            this.groupBox1.Controls.Add(this.btnD100);
            this.groupBox1.Controls.Add(this.txtD20);
            this.groupBox1.Controls.Add(this.txtD12);
            this.groupBox1.Controls.Add(this.txtD10);
            this.groupBox1.Controls.Add(this.txtD8);
            this.groupBox1.Controls.Add(this.txtD6);
            this.groupBox1.Controls.Add(this.btnD20);
            this.groupBox1.Controls.Add(this.btnD12);
            this.groupBox1.Controls.Add(this.btnD10);
            this.groupBox1.Controls.Add(this.btnD8);
            this.groupBox1.Controls.Add(this.btnD6);
            this.groupBox1.Controls.Add(this.txtD4);
            this.groupBox1.Controls.Add(this.btnD4);
            this.groupBox1.Controls.Add(this.rbOneByOne);
            this.groupBox1.Controls.Add(this.rbCumulative);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(147, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 352);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dice Roll Style";
            // 
            // btnRoll
            // 
            this.btnRoll.BackColor = System.Drawing.Color.Black;
            this.btnRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnRoll.ForeColor = System.Drawing.Color.White;
            this.btnRoll.Location = new System.Drawing.Point(89, 19);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(82, 43);
            this.btnRoll.TabIndex = 22;
            this.btnRoll.Text = "ROLL";
            this.btnRoll.UseVisualStyleBackColor = false;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // txtD100
            // 
            this.txtD100.Enabled = false;
            this.txtD100.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD100.Location = new System.Drawing.Point(97, 314);
            this.txtD100.Name = "txtD100";
            this.txtD100.Size = new System.Drawing.Size(80, 32);
            this.txtD100.TabIndex = 21;
            this.txtD100.Tag = "RollOutcome";
            // 
            // btnD100
            // 
            this.btnD100.BackColor = System.Drawing.Color.Black;
            this.btnD100.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD100.ForeColor = System.Drawing.Color.White;
            this.btnD100.Location = new System.Drawing.Point(3, 314);
            this.btnD100.Name = "btnD100";
            this.btnD100.Size = new System.Drawing.Size(80, 32);
            this.btnD100.TabIndex = 14;
            this.btnD100.Tag = "RollButton";
            this.btnD100.Text = "D100";
            this.btnD100.UseVisualStyleBackColor = false;
            this.btnD100.Click += new System.EventHandler(this.btnD100_Click);
            // 
            // txtD20
            // 
            this.txtD20.Enabled = false;
            this.txtD20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD20.Location = new System.Drawing.Point(97, 261);
            this.txtD20.Name = "txtD20";
            this.txtD20.Size = new System.Drawing.Size(80, 32);
            this.txtD20.TabIndex = 20;
            this.txtD20.Tag = "RollOutcome";
            // 
            // txtD12
            // 
            this.txtD12.Enabled = false;
            this.txtD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD12.Location = new System.Drawing.Point(97, 223);
            this.txtD12.Name = "txtD12";
            this.txtD12.Size = new System.Drawing.Size(80, 32);
            this.txtD12.TabIndex = 19;
            this.txtD12.Tag = "RollOutcome";
            // 
            // txtD10
            // 
            this.txtD10.Enabled = false;
            this.txtD10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD10.Location = new System.Drawing.Point(97, 185);
            this.txtD10.Name = "txtD10";
            this.txtD10.Size = new System.Drawing.Size(80, 32);
            this.txtD10.TabIndex = 18;
            this.txtD10.Tag = "RollOutcome";
            // 
            // txtD8
            // 
            this.txtD8.Enabled = false;
            this.txtD8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD8.Location = new System.Drawing.Point(97, 147);
            this.txtD8.Name = "txtD8";
            this.txtD8.Size = new System.Drawing.Size(80, 32);
            this.txtD8.TabIndex = 17;
            this.txtD8.Tag = "RollOutcome";
            // 
            // txtD6
            // 
            this.txtD6.Enabled = false;
            this.txtD6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD6.Location = new System.Drawing.Point(97, 109);
            this.txtD6.Name = "txtD6";
            this.txtD6.Size = new System.Drawing.Size(80, 32);
            this.txtD6.TabIndex = 16;
            this.txtD6.Tag = "RollOutcome";
            // 
            // btnD20
            // 
            this.btnD20.BackColor = System.Drawing.Color.Black;
            this.btnD20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD20.ForeColor = System.Drawing.Color.White;
            this.btnD20.Location = new System.Drawing.Point(3, 261);
            this.btnD20.Name = "btnD20";
            this.btnD20.Size = new System.Drawing.Size(80, 32);
            this.btnD20.TabIndex = 13;
            this.btnD20.Tag = "RollButton";
            this.btnD20.Text = "D20";
            this.btnD20.UseVisualStyleBackColor = false;
            this.btnD20.Click += new System.EventHandler(this.btnD20_Click);
            // 
            // btnD12
            // 
            this.btnD12.BackColor = System.Drawing.Color.Black;
            this.btnD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD12.ForeColor = System.Drawing.Color.White;
            this.btnD12.Location = new System.Drawing.Point(3, 223);
            this.btnD12.Name = "btnD12";
            this.btnD12.Size = new System.Drawing.Size(80, 32);
            this.btnD12.TabIndex = 12;
            this.btnD12.Tag = "RollButton";
            this.btnD12.Text = "D12";
            this.btnD12.UseVisualStyleBackColor = false;
            this.btnD12.Click += new System.EventHandler(this.btnD12_Click);
            // 
            // btnD10
            // 
            this.btnD10.BackColor = System.Drawing.Color.Black;
            this.btnD10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD10.ForeColor = System.Drawing.Color.White;
            this.btnD10.Location = new System.Drawing.Point(3, 185);
            this.btnD10.Name = "btnD10";
            this.btnD10.Size = new System.Drawing.Size(80, 32);
            this.btnD10.TabIndex = 11;
            this.btnD10.Tag = "RollButton";
            this.btnD10.Text = "D10";
            this.btnD10.UseVisualStyleBackColor = false;
            this.btnD10.Click += new System.EventHandler(this.btnD10_Click);
            // 
            // btnD8
            // 
            this.btnD8.BackColor = System.Drawing.Color.Black;
            this.btnD8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD8.ForeColor = System.Drawing.Color.White;
            this.btnD8.Location = new System.Drawing.Point(3, 147);
            this.btnD8.Name = "btnD8";
            this.btnD8.Size = new System.Drawing.Size(80, 32);
            this.btnD8.TabIndex = 10;
            this.btnD8.Tag = "RollButton";
            this.btnD8.Text = "D8";
            this.btnD8.UseVisualStyleBackColor = false;
            this.btnD8.Click += new System.EventHandler(this.btnD8_Click);
            // 
            // btnD6
            // 
            this.btnD6.BackColor = System.Drawing.Color.Black;
            this.btnD6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD6.ForeColor = System.Drawing.Color.White;
            this.btnD6.Location = new System.Drawing.Point(3, 109);
            this.btnD6.Name = "btnD6";
            this.btnD6.Size = new System.Drawing.Size(80, 32);
            this.btnD6.TabIndex = 9;
            this.btnD6.Tag = "RollButton";
            this.btnD6.Text = "D6";
            this.btnD6.UseVisualStyleBackColor = false;
            this.btnD6.Click += new System.EventHandler(this.btnD6_Click);
            // 
            // txtD4
            // 
            this.txtD4.Enabled = false;
            this.txtD4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.txtD4.Location = new System.Drawing.Point(97, 71);
            this.txtD4.Name = "txtD4";
            this.txtD4.Size = new System.Drawing.Size(80, 32);
            this.txtD4.TabIndex = 15;
            this.txtD4.Tag = "RollOutcome";
            // 
            // btnD4
            // 
            this.btnD4.BackColor = System.Drawing.Color.Black;
            this.btnD4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.btnD4.ForeColor = System.Drawing.Color.White;
            this.btnD4.Location = new System.Drawing.Point(3, 71);
            this.btnD4.Name = "btnD4";
            this.btnD4.Size = new System.Drawing.Size(80, 32);
            this.btnD4.TabIndex = 8;
            this.btnD4.Tag = "RollButton";
            this.btnD4.Text = "D4";
            this.btnD4.UseVisualStyleBackColor = false;
            this.btnD4.Click += new System.EventHandler(this.btnD4_Click);
            // 
            // btnMapGen
            // 
            this.btnMapGen.BackColor = System.Drawing.Color.Black;
            this.btnMapGen.ForeColor = System.Drawing.Color.White;
            this.btnMapGen.Location = new System.Drawing.Point(14, 251);
            this.btnMapGen.Name = "btnMapGen";
            this.btnMapGen.Size = new System.Drawing.Size(127, 33);
            this.btnMapGen.TabIndex = 3;
            this.btnMapGen.Text = "Map Generator";
            this.btnMapGen.UseVisualStyleBackColor = false;
            // 
            // btnItemGen
            // 
            this.btnItemGen.BackColor = System.Drawing.Color.Black;
            this.btnItemGen.ForeColor = System.Drawing.Color.White;
            this.btnItemGen.Location = new System.Drawing.Point(14, 290);
            this.btnItemGen.Name = "btnItemGen";
            this.btnItemGen.Size = new System.Drawing.Size(127, 33);
            this.btnItemGen.TabIndex = 4;
            this.btnItemGen.Text = "Item Generator";
            this.btnItemGen.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Aqua;
            this.lblTitle.Location = new System.Drawing.Point(17, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(313, 58);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Welcome, Traveller.\r\n               How May I Help?";
            // 
            // pbCoin
            // 
            this.pbCoin.Location = new System.Drawing.Point(35, 48);
            this.pbCoin.Name = "pbCoin";
            this.pbCoin.Size = new System.Drawing.Size(80, 80);
            this.pbCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCoin.TabIndex = 10;
            this.pbCoin.TabStop = false;
            this.pbCoin.Click += new System.EventHandler(this.pbCoin_Click);
            // 
            // btnBattleTracker
            // 
            this.btnBattleTracker.BackColor = System.Drawing.Color.Black;
            this.btnBattleTracker.ForeColor = System.Drawing.Color.White;
            this.btnBattleTracker.Location = new System.Drawing.Point(14, 328);
            this.btnBattleTracker.Name = "btnBattleTracker";
            this.btnBattleTracker.Size = new System.Drawing.Size(127, 33);
            this.btnBattleTracker.TabIndex = 13;
            this.btnBattleTracker.Text = "Battle Tracker";
            this.btnBattleTracker.UseVisualStyleBackColor = false;
            // 
            // btnEnemySheets
            // 
            this.btnEnemySheets.BackColor = System.Drawing.Color.Black;
            this.btnEnemySheets.ForeColor = System.Drawing.Color.White;
            this.btnEnemySheets.Location = new System.Drawing.Point(14, 406);
            this.btnEnemySheets.Name = "btnEnemySheets";
            this.btnEnemySheets.Size = new System.Drawing.Size(127, 33);
            this.btnEnemySheets.TabIndex = 12;
            this.btnEnemySheets.Text = "Enemy Sheets";
            this.btnEnemySheets.UseVisualStyleBackColor = false;
            // 
            // btnCharSheets
            // 
            this.btnCharSheets.BackColor = System.Drawing.Color.Black;
            this.btnCharSheets.ForeColor = System.Drawing.Color.White;
            this.btnCharSheets.Location = new System.Drawing.Point(14, 367);
            this.btnCharSheets.Name = "btnCharSheets";
            this.btnCharSheets.Size = new System.Drawing.Size(127, 33);
            this.btnCharSheets.TabIndex = 11;
            this.btnCharSheets.Text = "Character Sheets";
            this.btnCharSheets.UseVisualStyleBackColor = false;
            this.btnCharSheets.Click += new System.EventHandler(this.BtnCharSheets_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(341, 448);
            this.Controls.Add(this.btnBattleTracker);
            this.Controls.Add(this.btnEnemySheets);
            this.Controls.Add(this.btnCharSheets);
            this.Controls.Add(this.pbCoin);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnItemGen);
            this.Controls.Add(this.btnMapGen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreature);
            this.Controls.Add(this.btnEncounter);
            this.Controls.Add(this.btnCharacter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "ÆtherSlay: The DM\'s Best Friend";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCoin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCharacter;
        private System.Windows.Forms.Button btnEncounter;
        private System.Windows.Forms.Button btnCreature;
        private System.Windows.Forms.RadioButton rbOneByOne;
        private System.Windows.Forms.RadioButton rbCumulative;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtD4;
        private System.Windows.Forms.Button btnD4;
        private System.Windows.Forms.Button btnMapGen;
        private System.Windows.Forms.TextBox txtD100;
        private System.Windows.Forms.Button btnD100;
        private System.Windows.Forms.TextBox txtD20;
        private System.Windows.Forms.TextBox txtD12;
        private System.Windows.Forms.TextBox txtD10;
        private System.Windows.Forms.TextBox txtD8;
        private System.Windows.Forms.TextBox txtD6;
        private System.Windows.Forms.Button btnD20;
        private System.Windows.Forms.Button btnD12;
        private System.Windows.Forms.Button btnD10;
        private System.Windows.Forms.Button btnD8;
        private System.Windows.Forms.Button btnD6;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnItemGen;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbCoin;
        private System.Windows.Forms.Button btnBattleTracker;
        private System.Windows.Forms.Button btnEnemySheets;
        private System.Windows.Forms.Button btnCharSheets;
    }
}

