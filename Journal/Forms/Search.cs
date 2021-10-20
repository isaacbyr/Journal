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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            int last_id = Journal_pro.Properties.Settings.Default.last_memo_id;
            for(int i = 1; i <= last_id; i++)
            {
                this.listEntries.Items.Add("Memo " + i.ToString());
            }
        }

        private void listEntries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            findMemo();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {

                string search = "Memo " + this.searchIdText.Text;

                if (this.listEntries.Items.Contains(search))
                {
                    int listIndex;
                    int.TryParse(this.searchIdText.Text, out listIndex);
                    listIndex -= 1;
                    this.listEntries.SelectedIndex = listIndex;
                    findMemo();
                }
                else
                {
                    MessageBox.Show("Could Not Find Memo");
                    this.searchIdText.ResetText();
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
        }

        public void findMemo ()
        {
            try
            {
                int index = this.listEntries.SelectedIndex + 1;
                string path_text = Application.StartupPath + $"\\documents\\{index}.rtf";
                string title_path = Application.StartupPath + $"\\documents\\title_{index}.txt";
                string date_path = Application.StartupPath + $"\\documents\\date_{index}.txt";

                this.richTextBox1.LoadFile(path_text);
                this.memoIdText.Text = this.listEntries.SelectedIndex.ToString();
                this.titleTextBox.Text = System.IO.File.ReadAllText(title_path);
                this.dateTextBox.Text = System.IO.File.ReadAllText(date_path);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }
    }
}
