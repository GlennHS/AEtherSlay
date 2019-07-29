namespace AEtherSlay
{
    partial class frmCreatureFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreatureFilter));
            this.nudMinCR = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cblSize = new System.Windows.Forms.CheckedListBox();
            this.cblAlignment = new System.Windows.Forms.CheckedListBox();
            this.nudMaxAC = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCR = new System.Windows.Forms.NumericUpDown();
            this.nudMinAC = new System.Windows.Forms.NumericUpDown();
            this.btnGo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAC)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMinCR
            // 
            this.nudMinCR.Location = new System.Drawing.Point(65, 16);
            this.nudMinCR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMinCR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMinCR.Name = "nudMinCR";
            this.nudMinCR.Size = new System.Drawing.Size(67, 22);
            this.nudMinCR.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min CR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max AC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Min AC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Max CR";
            // 
            // cblSize
            // 
            this.cblSize.FormattingEnabled = true;
            this.cblSize.Items.AddRange(new object[] {
            "Tiny",
            "Small",
            "Medium",
            "Large",
            "Huge",
            "Gargantuan"});
            this.cblSize.Location = new System.Drawing.Point(283, 9);
            this.cblSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cblSize.Name = "cblSize";
            this.cblSize.Size = new System.Drawing.Size(107, 72);
            this.cblSize.TabIndex = 9;
            // 
            // cblAlignment
            // 
            this.cblAlignment.FormattingEnabled = true;
            this.cblAlignment.Items.AddRange(new object[] {
            "LG",
            "NG",
            "CG",
            "LN",
            "N",
            "CN",
            "LE",
            "NE",
            "CE"});
            this.cblAlignment.Location = new System.Drawing.Point(399, 9);
            this.cblAlignment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cblAlignment.Name = "cblAlignment";
            this.cblAlignment.Size = new System.Drawing.Size(76, 72);
            this.cblAlignment.TabIndex = 10;
            // 
            // nudMaxAC
            // 
            this.nudMaxAC.Location = new System.Drawing.Point(203, 57);
            this.nudMaxAC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMaxAC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMaxAC.Name = "nudMaxAC";
            this.nudMaxAC.Size = new System.Drawing.Size(67, 22);
            this.nudMaxAC.TabIndex = 11;
            // 
            // nudMaxCR
            // 
            this.nudMaxCR.Location = new System.Drawing.Point(203, 16);
            this.nudMaxCR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMaxCR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMaxCR.Name = "nudMaxCR";
            this.nudMaxCR.Size = new System.Drawing.Size(67, 22);
            this.nudMaxCR.TabIndex = 13;
            // 
            // nudMinAC
            // 
            this.nudMinAC.Location = new System.Drawing.Point(65, 57);
            this.nudMinAC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMinAC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMinAC.Name = "nudMinAC";
            this.nudMinAC.Size = new System.Drawing.Size(67, 22);
            this.nudMinAC.TabIndex = 14;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.Location = new System.Drawing.Point(484, 9);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(109, 79);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmCreatureFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(604, 95);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.nudMinAC);
            this.Controls.Add(this.nudMaxCR);
            this.Controls.Add(this.nudMaxAC);
            this.Controls.Add(this.cblAlignment);
            this.Controls.Add(this.cblSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMinCR);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCreatureFilter";
            this.Text = "frmCreatureFilter";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMinCR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox cblSize;
        private System.Windows.Forms.CheckedListBox cblAlignment;
        private System.Windows.Forms.NumericUpDown nudMaxAC;
        private System.Windows.Forms.NumericUpDown nudMaxCR;
        private System.Windows.Forms.NumericUpDown nudMinAC;
        private System.Windows.Forms.Button btnGo;
    }
}