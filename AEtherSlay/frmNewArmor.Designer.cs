namespace AEtherSlay
{
    partial class frmNewArmor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewArmor));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numAC = new System.Windows.Forms.NumericUpDown();
            this.numDexLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkStealth = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chkNoLimit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDexLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Armor";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(67, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // numAC
            // 
            this.numAC.Location = new System.Drawing.Point(67, 69);
            this.numAC.Name = "numAC";
            this.numAC.Size = new System.Drawing.Size(33, 20);
            this.numAC.TabIndex = 3;
            // 
            // numDexLimit
            // 
            this.numDexLimit.Location = new System.Drawing.Point(67, 95);
            this.numDexLimit.Name = "numDexLimit";
            this.numDexLimit.Size = new System.Drawing.Size(33, 20);
            this.numDexLimit.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Base AC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dex Limit";
            // 
            // chkStealth
            // 
            this.chkStealth.AutoSize = true;
            this.chkStealth.Location = new System.Drawing.Point(29, 121);
            this.chkStealth.Name = "chkStealth";
            this.chkStealth.Size = new System.Drawing.Size(134, 17);
            this.chkStealth.TabIndex = 8;
            this.chkStealth.Text = "Stealth Disadvantage?";
            this.chkStealth.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.ForeColor = System.Drawing.Color.Black;
            this.btnCreate.Location = new System.Drawing.Point(46, 144);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Add Armor";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chkNoLimit
            // 
            this.chkNoLimit.AccessibleDescription = "chbNoLim";
            this.chkNoLimit.AutoSize = true;
            this.chkNoLimit.Location = new System.Drawing.Point(107, 97);
            this.chkNoLimit.Name = "chkNoLimit";
            this.chkNoLimit.Size = new System.Drawing.Size(64, 17);
            this.chkNoLimit.TabIndex = 10;
            this.chkNoLimit.Text = "No Limit";
            this.chkNoLimit.UseVisualStyleBackColor = true;
            // 
            // frmNewArmor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.chkNoLimit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.chkStealth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numDexLimit);
            this.Controls.Add(this.numAC);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewArmor";
            this.Text = "frmNewArmor";
            ((System.ComponentModel.ISupportInitialize)(this.numAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDexLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numAC;
        private System.Windows.Forms.NumericUpDown numDexLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkStealth;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox chkNoLimit;
    }
}