using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Journal_pro.Forms
{
    public partial class NewEntry : Form
    {
        public NewEntry()
        {
            InitializeComponent();
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowDialog();
            this.richTextBox1.SelectionFont = this.fontDialog1.Font;
        }

        private void fontColorButton_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.richTextBox1.SelectionColor = this.colorDialog1.Color;
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.richTextBox1.SelectionBackColor = this.colorDialog1.Color;
        }

        private void alignLeftButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alignCenterButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void alignRightButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void incIndentButton_Click(object sender, EventArgs e)
        {
            int indent = this.richTextBox1.SelectionIndent;
            indent = indent +  10;
            this.richTextBox1.SelectionIndent = indent;

        }

        private void decIndentButton_Click(object sender, EventArgs e)
        {
            int indent = this.richTextBox1.SelectionIndent;
            indent = indent - 10;
            this.richTextBox1.SelectionIndent = indent;

        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Redo();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            this.saveButton.Enabled = true;
            this.dateTextBox.ResetText();
            this.titleTextBox.ResetText();
            this.richTextBox1.ResetText();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox1.Enabled = false;
                this.saveButton.Enabled = false;
                // ---- Saving Text File --------------------------
                string fn;
                string fn_title;
                string fn_date;

                int last_id = Journal_pro.Properties.Settings.Default.last_memo_id;
                last_id = last_id + 1;

                fn = Application.StartupPath + $"\\documents\\{last_id.ToString()}.rtf";
                fn_title = Application.StartupPath + $"\\documents\\title_{last_id.ToString()}.txt";
                fn_date = Application.StartupPath + $"\\documents\\date_{last_id.ToString()}.txt";

                System.IO.File.WriteAllText(fn_title, this.titleTextBox.Text);
                System.IO.File.WriteAllText(fn_date, this.dateTextBox.Text);

                this.richTextBox1.SaveFile(fn);
                MessageBox.Show("Successfully saved");
                Journal_pro.Properties.Settings.Default.last_memo_id += 1;
                Journal_pro.Properties.Settings.Default.Save();
                // -------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void NewEntry_Load(object sender, EventArgs e)
        {
            this.saveButton.Enabled = false;
            string memo_id = Journal_pro.Properties.Settings.Default.last_memo_id.ToString();
            this.memoIdText.Text = memo_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Journal_pro.Properties.Settings.Default.last_memo_id = 0;
            Journal_pro.Properties.Settings.Default.Save();
        }
    }
}
