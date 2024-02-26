using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public partial class notepad : Form
    {
        public SaveFileDialog file = new SaveFileDialog();
        public String Filename;
        public String SaveFileFilter = "|*.txt||*.cfg||*.inf||*.ini";
        public String OpenFileFilter = "|*.txt||*.cfg||*.inf||*.ini||*.pdf";
        public String FileLoc;
        public notepad()
        {
            InitializeComponent();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (notepad_txt.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Do You Want To Save This File ?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = SaveFileFilter;
                    file.Title = "Save Text File";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        FileLoc = file.FileName;
                        File.WriteAllText(file.FileName, notepad_txt.Text);
                        notepad notepad = (notepad)Application.OpenForms["notepad"];
                        notepad.Text = "StreamTech Notepad " + "- " + FileLoc;
                    }
                }
                else if (result == DialogResult.No)
                {
                    notepad_txt.Clear();
                }
            }


        }//تابع ساخت فایل جدید
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notepad_txt.Text == string.Empty)
            {
                Environment.Exit(0);
            }
            else if (notepad_txt.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Do You Want To Save This File ?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = SaveFileFilter;
                    file.Title = "Save Text File";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        FileLoc = file.FileName;
                        File.WriteAllText(file.FileName, notepad_txt.Text);
                        notepad notepad = (notepad)Application.OpenForms["notepad"];
                        notepad.Text = "StreamTech Notepad " + "- " + FileLoc;
                    }
                    Environment.Exit(0);
                }
                else if (result == DialogResult.No)
                {
                    Environment.Exit(0);
                }

            }

        }//تابع خروج از برنامه
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open Text File";
            openFile.Filter = OpenFileFilter;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileLoc = openFile.FileName;
                notepad_txt.Text = File.ReadAllText(openFile.FileName);
                notepad notepad = (notepad)Application.OpenForms["notepad"];
                notepad.Text = "StreamTech Notepad " + "- " + FileLoc;
            }
        }//تابع باز کردن فایل
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.Title = "Save Text File";
            if (notepad_txt.Text != string.Empty)
            {
                file.Filter = SaveFileFilter;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    FileLoc = file.FileName;
                    File.WriteAllText(file.FileName, notepad_txt.Text);
                    notepad notepad = (notepad)Application.OpenForms["notepad"];
                    notepad.Text = "StreamTech Notepad " + "- " + FileLoc;
                }
            }
            else
            {
                MessageBox.Show("This Page Is Empty!\nError code : 000x00001", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//تابع زخیره فایل
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Undo();
        }//تابع اندو
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Clear();
        }//تابع دیلیت
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Cut();
        }//تابع کات
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Copy();
        }//تابع کپی
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Paste();
        }//تابع پیست
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Redo();
        }//تابع ریدو
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                notepad_txt.SelectionFont = fontDialog.Font;
            }

        }//تابع فونت
        private void changeBackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog backColorDialog = new ColorDialog();
            if (backColorDialog.ShowDialog() == DialogResult.OK)
            {
                notepad_txt.BackColor = backColorDialog.Color;
            }
        }//تابع تغییر رنگ پشت
        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog foreColorDialog = new ColorDialog();
            if (foreColorDialog.ShowDialog() == DialogResult.OK)
            {
                notepad_txt.ForeColor = foreColorDialog.Color;
            }
        }//تابع تغییر رنگ رو
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                notepad_txt.SelectionColor = colorDialog.Color;
            }
        }//تابع تغییر رنگ انتخاب شده
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notepad_txt.Text == string.Empty)
            {
                MessageBox.Show("This Page Is Empty!\nError code : 000x00001", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (notepad_txt.Text != string.Empty)
            {
                PageSetup pagesetup = new PageSetup();
                pagesetup.ShowDialog();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.Filter = SaveFileFilter;
            file.Title = "Save Text File";
            if (notepad_txt.Text == string.Empty)
            {
                MessageBox.Show("This Page Is Empty!\nError code : 000x00001", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (notepad_txt.Text != string.Empty)
            {
                if (file.FileName == string.Empty)
                {
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        FileLoc = file.FileName;
                        File.WriteAllText(file.FileName, notepad_txt.Text);
                        notepad notepad = (notepad)Application.OpenForms["notepad"];
                        notepad.Text = "StreamTech Notepad" + " " + FileLoc;
                    }
                }
                else if (file.FileName != string.Empty)
                {
                    FileLoc = file.FileName;
                    File.WriteAllText(file.FileName, notepad_txt.Text);
                    notepad notepad = (notepad)Application.OpenForms["notepad"];
                    notepad.Text = "StreamTech Notepad" + " " + FileLoc;
                }
            }
        }

        private void currentTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.Text += DateTime.Now;
        }

        private void fontAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                notepad_txt.Font = fontDialog.Font;
            }
        }

        //private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (notepad_txt.Text == string.Empty)
        //    {

        //        Application.Restart();
        //    }
        //    else if (notepad_txt.Text != string.Empty)
        //    {
        //        DialogResult result = MessageBox.Show("Do You Want To Save This File ?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //        if (result == DialogResult.Yes)
        //        {
        //            SaveFileDialog file = new SaveFileDialog();
        //            file.Filter = SaveFileFilter;
        //            file.Title = "Save Text File";
        //            if (file.ShowDialog() == DialogResult.OK)
        //            {
        //                FileLoc = file.FileName;
        //                File.WriteAllText(file.FileName, notepad_txt.Text);
        //                notepad notepad = (notepad)Application.OpenForms["notepad"];
        //                notepad.Text = "StreamTech Notepad " + "- " + FileLoc;
        //            }
        //            Application.Restart();
        //        }
        //        else if (result == DialogResult.No)
        //        {
        //            Application.Restart();
        //        }
        //    }

        //}


        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_txt.SelectAll();
        }



        private void notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notepad_txt.Text == string.Empty)
            {
                Environment.Exit(0);
            }
            else if (notepad_txt.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Do You Want To Save This File ?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = SaveFileFilter;
                    file.Title = "Save Text File";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        FileLoc = file.FileName;
                        File.WriteAllText(file.FileName, notepad_txt.Text);
                        notepad notepad = (notepad)Application.OpenForms["notepad"];
                        notepad.Text = "StreamTech Notepad " + "- " + FileLoc;
                    }
                    Environment.Exit(0);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    Environment.Exit(0);
                }

            }
        }

        private void notepad_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

