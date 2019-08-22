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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCastTime = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lbComponents = new System.Windows.Forms.Label();
            this.rtbComponents = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.chkRitual = new System.Windows.Forms.CheckBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.TextBox();
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
            this.lbxSpellList.SelectedIndexChanged += new System.EventHandler(this.LbxSpellList_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(260, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 22);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(190, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(190, 43);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(42, 17);
            this.lblLevel.TabIndex = 5;
            this.lblLevel.Text = "Level";
            // 
            // txtLevel
            // 
            this.txtLevel.Enabled = false;
            this.txtLevel.Location = new System.Drawing.Point(260, 40);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(237, 22);
            this.txtLevel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cast Time";
            // 
            // txtCastTime
            // 
            this.txtCastTime.Enabled = false;
            this.txtCastTime.Location = new System.Drawing.Point(260, 70);
            this.txtCastTime.Name = "txtCastTime";
            this.txtCastTime.Size = new System.Drawing.Size(237, 22);
            this.txtCastTime.TabIndex = 6;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(176, 157);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(62, 17);
            this.lblDuration.TabIndex = 11;
            this.lblDuration.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Enabled = false;
            this.txtDuration.Location = new System.Drawing.Point(253, 154);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(244, 22);
            this.txtDuration.TabIndex = 10;
            // 
            // lbComponents
            // 
            this.lbComponents.AutoSize = true;
            this.lbComponents.Location = new System.Drawing.Point(287, 99);
            this.lbComponents.Name = "lbComponents";
            this.lbComponents.Size = new System.Drawing.Size(87, 17);
            this.lbComponents.TabIndex = 9;
            this.lbComponents.Text = "Components";
            // 
            // rtbComponents
            // 
            this.rtbComponents.Enabled = false;
            this.rtbComponents.Location = new System.Drawing.Point(175, 122);
            this.rtbComponents.Name = "rtbComponents";
            this.rtbComponents.Size = new System.Drawing.Size(322, 23);
            this.rtbComponents.TabIndex = 12;
            this.rtbComponents.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Range";
            // 
            // txtRange
            // 
            this.txtRange.Enabled = false;
            this.txtRange.Location = new System.Drawing.Point(253, 183);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(244, 22);
            this.txtRange.TabIndex = 13;
            // 
            // chkRitual
            // 
            this.chkRitual.AutoSize = true;
            this.chkRitual.Enabled = false;
            this.chkRitual.Location = new System.Drawing.Point(300, 240);
            this.chkRitual.Name = "chkRitual";
            this.chkRitual.Size = new System.Drawing.Size(66, 21);
            this.chkRitual.TabIndex = 15;
            this.chkRitual.Text = "Ritual";
            this.chkRitual.UseVisualStyleBackColor = true;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Enabled = false;
            this.rtbDescription.Location = new System.Drawing.Point(175, 284);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(322, 147);
            this.rtbDescription.TabIndex = 16;
            this.rtbDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "School";
            // 
            // txtSchool
            // 
            this.txtSchool.Enabled = false;
            this.txtSchool.Location = new System.Drawing.Point(253, 212);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(244, 22);
            this.txtSchool.TabIndex = 18;
            // 
            // frmSpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSchool);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.chkRitual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.rtbComponents);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lbComponents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCastTime);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbxSpellList);
            this.Controls.Add(this.cmbClasses);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmSpells";
            this.Text = "frmSpells";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.ListBox lbxSpellList;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCastTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lbComponents;
        private System.Windows.Forms.RichTextBox rtbComponents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.CheckBox chkRitual;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSchool;
    }
}