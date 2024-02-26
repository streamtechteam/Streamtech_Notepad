namespace Notepad
{
    partial class PageSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.print_btn = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.y_txtbx = new System.Windows.Forms.MaskedTextBox();
            this.x_txtbx = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distance From Zero Point :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "X :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // colorCombo
            // 
            this.colorCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorCombo.FormattingEnabled = true;
            this.colorCombo.Items.AddRange(new object[] {
            "Black",
            "White",
            "Red",
            "Blue",
            "Yellow",
            "Green"});
            this.colorCombo.Location = new System.Drawing.Point(52, 89);
            this.colorCombo.Name = "colorCombo";
            this.colorCombo.Size = new System.Drawing.Size(121, 24);
            this.colorCombo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Color :";
            // 
            // print_btn
            // 
            this.print_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print_btn.Location = new System.Drawing.Point(204, 82);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(229, 35);
            this.print_btn.TabIndex = 5;
            this.print_btn.Text = "Print";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // y_txtbx
            // 
            this.y_txtbx.Location = new System.Drawing.Point(274, 30);
            this.y_txtbx.Mask = "0000";
            this.y_txtbx.Name = "y_txtbx";
            this.y_txtbx.Size = new System.Drawing.Size(100, 22);
            this.y_txtbx.TabIndex = 6;
            this.y_txtbx.ValidatingType = typeof(int);
            this.y_txtbx.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.y_txtbx_MaskInputRejected);
            // 
            // x_txtbx
            // 
            this.x_txtbx.Location = new System.Drawing.Point(92, 30);
            this.x_txtbx.Mask = "0000";
            this.x_txtbx.Name = "x_txtbx";
            this.x_txtbx.Size = new System.Drawing.Size(100, 22);
            this.x_txtbx.TabIndex = 6;
            this.x_txtbx.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.x_txtbx_MaskInputRejected);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(49, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Note : You Should Set X/Y According Image Size (A4,A3,...)\r\n";
            // 
            // PageSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 123);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.x_txtbx);
            this.Controls.Add(this.y_txtbx);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colorCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PageSetup";
            this.ShowIcon = false;
            this.Text = "Page Setup";
            this.Load += new System.EventHandler(this.PageSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox colorCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.MaskedTextBox y_txtbx;
        private System.Windows.Forms.MaskedTextBox x_txtbx;
        private System.Windows.Forms.Label label5;
    }
}