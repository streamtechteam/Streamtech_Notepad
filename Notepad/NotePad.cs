using System;
using System.IO;
using System.Linq;
using System.Text;
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
        public Encoding Encoding;
        
        public notepad()
        {
            InitializeComponent();
            
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // دریافت TabPage فعال
            TabPage selectedTabPage = tabControl1.SelectedTab;

            // بررسی اینکه آیا TabPage فعال دارای یک RichTextBox است یا خیر
            RichTextBox richTextBox = selectedTabPage.Controls.OfType<RichTextBox>().FirstOrDefault();

            // اضافه کردن رویداد TextChanged به RichTextBox
            richTextBox.TextChanged += RichTextBox_TextChanged;
            richTextBox.SelectionChanged += RichTextBox_TextChanged;

        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            // دریافت موقعیت موس در RichTextBox
            int index = GetActiveEditor().SelectionStart;
            int line = GetActiveEditor().GetLineFromCharIndex(index);
            int column = index - GetActiveEditor().GetFirstCharIndexOfCurrentLine() + 1;
            int Char = GetActiveEditor().Text.Length;

            // نمایش سطر و ستون
            toolStripStatusLabel1.Text = "Line: " + (line + 1).ToString() + ", Column: " + column.ToString() + ", Characters: " + Char.ToString();
        }

        private RichTextBox GetActiveEditor()
        {

            TabPage currentPage = tabControl1.SelectedTab;
            if (currentPage.Controls.Count > 0 && currentPage.Controls[0] is RichTextBox)
            {
                return (RichTextBox)currentPage.Controls[0];
            }
            else
            {
                // اگر TabPage شامل یک RichTextBox نبود، یک RichTextBox جدید ایجاد کنید و به آن اضافه کنید
                RichTextBox newRichTextBox = new RichTextBox();
                newRichTextBox.Dock = DockStyle.Fill;
                currentPage.Controls.Add(newRichTextBox);
                return newRichTextBox;
            }


        }
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad notepad = new notepad();
            TabPage tp = new TabPage("New Document");
            RichTextBox rtb = new RichTextBox();
            rtb = notepad.notepad_txt;
            rtb.Dock = DockStyle.Fill;
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);



        }//تابع ساخت فایل جدید
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encode();
            if (GetActiveEditor().Text == string.Empty)
            {
                Environment.Exit(0);
            }
            else if (GetActiveEditor().Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Do You Want To Save This File ?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = SaveFileFilter;
                    file.Title = "Save Text File";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(file.FileName, GetActiveEditor().Text,Encoding);
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
                GetActiveEditor().Text = File.ReadAllText(openFile.FileName);
                notepad notepad = (notepad)Application.OpenForms["notepad"];
                notepad.Text = "StreamTech NotePad  " + "- " + FileLoc;
                string fileName = Path.GetFileName(openFile.FileName);
                tabControl1.SelectedTab.Text = fileName;
            }
        }//تابع باز کردن فایل
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encode();
            file.Title = "Save Text File";
            if (GetActiveEditor().Text != string.Empty)
            {
                file.Filter = SaveFileFilter;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    FileLoc = file.FileName;
                    File.WriteAllText(file.FileName, GetActiveEditor().Text,Encoding);
                    notepad notepad = (notepad)Application.OpenForms["notepad"];
                    notepad.Text = "StreamTech NotePad  " + "- " + FileLoc;
                    string fileName = Path.GetFileName(file.FileName);
                    tabControl1.SelectedTab.Text = fileName;
                    GetActiveEditor().Tag = "true";

                }
            }
            else
            {
                MessageBox.Show("This Page Is Empty!\nError code : 000x00001", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//تابع زخیره فایل
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().Undo();
        }//تابع اندو
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().Clear();
        }//تابع دیلیت
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().Cut();
        }//تابع کات
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().Copy();
        }//تابع کپی
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().Paste();
        }//تابع پیست
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().Redo();
        }//تابع ریدو
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = GetActiveEditor().Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                GetActiveEditor().SelectionFont = fontDialog.Font;
            }

        }//تابع فونت
        private void changeBackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog backColorDialog = new ColorDialog();
            if (backColorDialog.ShowDialog() == DialogResult.OK)
            {
                GetActiveEditor().BackColor = backColorDialog.Color;
            }
        }//تابع تغییر رنگ پشت
        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog foreColorDialog = new ColorDialog();
            if (foreColorDialog.ShowDialog() == DialogResult.OK)
            {
                GetActiveEditor().ForeColor = foreColorDialog.Color;
            }
        }//تابع تغییر رنگ رو
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                GetActiveEditor().SelectionColor = colorDialog.Color;
            }
        }//تابع تغییر رنگ انتخاب شده
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetActiveEditor().Text == string.Empty)
            {
                MessageBox.Show("This Page Is Empty!\nError code : 000x00001", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetActiveEditor().Text != string.Empty)
            {
                PageSetup pagesetup = new PageSetup();
                pagesetup.ShowDialog();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encode();
            file.Filter = SaveFileFilter;
            file.Title = "Save Text File";
            if (GetActiveEditor().Text == string.Empty)
            {
                MessageBox.Show("This Page Is Empty!\nError code : 000x00001", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetActiveEditor().Text != string.Empty)
            {
                if (GetActiveEditor().Tag == null)
                {

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        FileLoc = file.FileName;
                        File.WriteAllText(file.FileName, GetActiveEditor().Text,Encoding);
                        notepad notepad = (notepad)Application.OpenForms["notepad"];
                        notepad.Text = "StreamTech NotePad " + "- " + FileLoc;
                        string fileName = Path.GetFileName(file.FileName);
                        tabControl1.SelectedTab.Text = fileName;
                        GetActiveEditor().Tag = "true";
                    }
                }
                else if (GetActiveEditor().Tag != null)
                {
                    File.WriteAllText(file.FileName, GetActiveEditor().Text,Encoding);
                }
            }
        }

        private void currentTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().SelectedText += DateTime.Now;
        }

        private void fontAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = GetActiveEditor().Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                GetActiveEditor().Font = fontDialog.Font;
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveEditor().SelectAll();
        }



        private void notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            encode();
            if (GetActiveEditor().Text == string.Empty)
            {
                Environment.Exit(0);
            }
            else if (GetActiveEditor().Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Do You Want To Save This File ?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = SaveFileFilter;
                    file.Title = "Save Text File";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(file.FileName, GetActiveEditor().Text,Encoding);
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
        private void notepad_Load(object sender, EventArgs e)
        {
            encode_Combobox.SelectedIndex = 0;
        }

        private void notepad_txt_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            // دریافت TabPage فعال
            TabPage selectedTabPage = (sender as TabPage);

            // بررسی اینکه آیا TabPage فعال دارای یک RichTextBox است یا خیر
            RichTextBox richTextBox = selectedTabPage.Controls.OfType<RichTextBox>().FirstOrDefault();
            if (richTextBox != null)
            {
                // اضافه کردن رویداد TextChanged به RichTextBox
                richTextBox.TextChanged += RichTextBox_TextChanged;
                richTextBox.SelectionChanged += RichTextBox_TextChanged;
            }
        }
        private void encode()
        {
            if(encode_Combobox.SelectedIndex == 0)
            {
                Encoding = Encoding.ASCII;
            }
            if (encode_Combobox.SelectedIndex == 1)
            {
                Encoding = Encoding.BigEndianUnicode;
            }
            if (encode_Combobox.SelectedIndex == 2)
            {
                Encoding = Encoding.Unicode;
            }
            if (encode_Combobox.SelectedIndex == 3)
            {
                Encoding = Encoding.UTF8;
            }
            if(encode_Combobox.SelectedIndex == 4)
            {
                Encoding = Encoding.UTF7;
            }
            if(encode_Combobox.SelectedIndex == 5)
            {
                Encoding = Encoding.UTF32;
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl1.SelectedTab;
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.Remove(tabPage);
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad notepad = new notepad();
            notepad.Show();
        }
    }
}


