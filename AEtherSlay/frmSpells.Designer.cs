namespace AEtherSlay
{
    partial class frmSpells
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
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.lbxSpellList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmbClasses
            // 
            this.cmbClasses.FormattingEnabled = true;
            this.cmbClasses.Location = new System.Drawing.Point(13, 13);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(155, 24);
            this.cmbClasses.TabIndex = 0;
            this.cmbClasses.SelectedIndexChanged += new System.EventHandler(this.CmbClasses_SelectedIndexChanged);
            // 
            // lbxSpellList
            // 
            this.lbxSpellList.FormattingEnabled = true;
            this.lbxSpellList.ItemHeight = 16;
            this.lbxSpellList.Location = new System.Drawing.Point(13, 43);
            this.lbxSpellList.Name = "lbxSpellList";
            this.lbxSpellList.Size = new System.Drawing.Size(155, 388);
            this.lbxSpellList.TabIndex = 1;
            // 
            // frmSpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(444, 450);
            this.Controls.Add(this.lbxSpellList);
            this.Controls.Add(this.cmbClasses);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmSpells";
            this.Text = "frmSpells";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.ListBox lbxSpellList;
    }
}