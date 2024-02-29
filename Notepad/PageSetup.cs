using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Notepad
{
    public partial class PageSetup : Form
    {
        Brush brush;
        public PageSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (x_txtbx.Text != string.Empty & y_txtbx.Text != string.Empty)
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            else if (x_txtbx.Text == string.Empty | y_txtbx.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Right Value In TextBoxs !\nError Code : 000x00002","Error !",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (colorCombo.SelectedIndex == 0)
            {
                brush = Brushes.Black;
            }
            if (colorCombo.SelectedIndex == 1)
            {
                brush = Brushes.White;
            }
            if (colorCombo.SelectedIndex == 2)
            {
                brush = Brushes.Red;
            }
            if (colorCombo.SelectedIndex == 3)
            {
                brush = Brushes.Blue;
            }
            if (colorCombo.SelectedIndex == 4)
            {
                brush = Brushes.Yellow;
            }
            if (colorCombo.SelectedIndex == 5)
            {
                brush = Brushes.Green;
            }
            notepad notepad = (notepad)Application.OpenForms["notepad"];
            e.Graphics.DrawString(notepad.notepad_txt.Text, notepad.notepad_txt.Font, brush, new Point(Convert.ToInt32(x_txtbx.Text), Convert.ToInt32(y_txtbx.Text)));
           
        }

        private void PageSetup_Load(object sender, EventArgs e)
        {
            // در فرم دوم یا هر جای دیگر مورد نظر
            
            colorCombo.SelectedIndex = 0;
            y_txtbx.Text = "0";
            x_txtbx.Text = "0";

        }

        private void y_txtbx_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void x_txtbx_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
