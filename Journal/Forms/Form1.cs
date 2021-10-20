using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Journal_pro.Forms;

namespace Journal
{
    public partial class Journal : Form
    {
        public Journal()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure that you want to leave? :(", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Close();
            } else
            {
                return;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getTime();
        }

        private void Journal_Load(object sender, EventArgs e)
        {
            try
            {
                //----------Load Login Form ---------------------
                var login = new Login();
                login.ShowDialog();
                //  ------- setting background image -------------
                int si = Journal_pro.Properties.Settings.Default.selected_background_image_index;
                loadBackground(si);
                backgroundComboLoad();
                this.backgroundCombo.SelectedIndex = si;
                // -----------------------------------------------
                getTime();
                getDate();
                this.versionNumLabel.Text = Application.ProductVersion;
                // ------- load Profile Pic ---------------------
                string fn = Application.StartupPath + "\\data\\UserPictures\\1.jpg";
                this.mainProfilePic.Load(fn);
                // ------- Setting last login -------------------
                Journal_pro.Properties.Settings.Default.last_login = DateTime.Now.ToString("dd/MM/yy");
                this.loginLabel.Text = Journal_pro.Properties.Settings.Default.last_login;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void getTime ()
        {
            this.timerLabel.Text = DateTime.Now.ToString("HH:mm");

        }

        public void getDate()
        {
            this.monthLabel.Text = DateTime.Now.ToString("MMMM").Substring(0,4);
            this.dayLabel.Text = DateTime.Now.Day.ToString();
        }
        
        public void loadBackground(int index)
        {
            index += 1;
            string fn;
            fn = Application.StartupPath + $"\\data\\BackgroundImages\\{index}.jpg";
            this.BackgroundImage = Image.FromFile(fn);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void backgroundComboLoad ()
        {
            for(int i =1; i <= 2 ; i++)
            {
                this.backgroundCombo.Items.Add("Image " + i.ToString());
            } 
        }

        private void backgroundCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBackground(this.backgroundCombo.SelectedIndex);
            // saving background Image
            Journal_pro.Properties.Settings.Default.selected_background_image_index = this.backgroundCombo.SelectedIndex;
            Journal_pro.Properties.Settings.Default.Save();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.MdiParent = this;
            about.Show();
         }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var user = new UsersManagement();
            user.MdiParent = this;
            user.Show();
        }

       

        private void lockScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockScreen();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lockScreenButton_Click(object sender, EventArgs e)
        {
            LockScreen();
        }

        public void LockScreen()
        {
            var login = new Login();
            login.ShowDialog();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var newEntry = new NewEntry();
            newEntry.MdiParent = this;
            newEntry.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var search = new Search();
            search.MdiParent = this;
            search.Show();
        }
    }
}
