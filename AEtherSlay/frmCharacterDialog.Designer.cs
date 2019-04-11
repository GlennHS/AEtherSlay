﻿namespace AEtherSlay
{
    partial class frmCharacterDialog
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
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblRace = new System.Windows.Forms.Label();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Ranger",
            "Spellcaster",
            "Melee",
            "Support"});
            this.cmbCategory.Location = new System.Drawing.Point(67, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCategory.Location = new System.Drawing.Point(12, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblClass.Location = new System.Drawing.Point(12, 42);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 3;
            this.lblClass.Text = "Class";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "Barbarian",
            "Bard",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Ranger",
            "Rogue",
            "Sorcerer",
            "Warlock",
            "Wizard"});
            this.cmbClass.Location = new System.Drawing.Point(67, 39);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 21);
            this.cmbClass.TabIndex = 2;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRace.Location = new System.Drawing.Point(12, 69);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(33, 13);
            this.lblRace.TabIndex = 5;
            this.lblRace.Text = "Race";
            // 
            // cmbRace
            // 
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Items.AddRange(new object[] {
            "Tiefling",
            "Human",
            "Half-Elf",
            "Half-Orc",
            "Dragonborn",
            "High Elf",
            "Wood Elf",
            "Mountain Dwarf",
            "Hill Dwarf",
            "Lightfoot Halfling",
            "Stout Halfling",
            "Forest Gnome",
            "Rock Gnome"});
            this.cmbRace.Location = new System.Drawing.Point(67, 66);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(121, 21);
            this.cmbRace.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.Location = new System.Drawing.Point(195, 13);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(86, 74);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmCharacterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(293, 99);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblRace);
            this.Controls.Add(this.cmbRace);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmCharacterDialog";
            this.Text = "frmCharacterDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.Button btnGo;
    }
}