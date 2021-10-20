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
    public partial class UsersManagement : Form
    {
        public UsersManagement()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
             try
            {
                Journal_pro.Properties.Settings.Default.User_name = this.userNameTextBox.Text;
                Journal_pro.Properties.Settings.Default.user_password = this.passwordText.Text;


                if (string.IsNullOrEmpty(this.userNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter a valid User Name", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ------------Save User Picture----------
                string dest = Application.StartupPath + "//data//UserPictures//1.jpg";
                string fn;
                fn = this.openFileDialog1.FileName;
                System.IO.File.Copy(fn, dest, true);
                // ---------------------------------------


                if (this.passwordText.Text == this.passwordConfText.Text)
                {

                    Journal_pro.Properties.Settings.Default.Save();
                    MessageBox.Show("Saved!", "Saved Data");
                }
                else
                {
                    MessageBox.Show("Passwords must match", "Passwords aren't matching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.passwordText.ResetText();
                    this.passwordConfText.ResetText();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

            
        }

        private void UsersManagement_Load(object sender, EventArgs e)
        {
            try
            {
                this.userNameTextBox.Text = Journal_pro.Properties.Settings.Default.User_name;
                this.passwordText.Text = Journal_pro.Properties.Settings.Default.user_password;
                this.passwordConfText.Text = Journal_pro.Properties.Settings.Default.user_password;

                // --------- Loading Image -------- 
                string dest = Application.StartupPath + "//data//UserPictures//1.jpg";
                this.profilePic.Load(dest);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.passwordText.PasswordChar == '*')
            {
                this.passwordText.PasswordChar = '\0';
                this.passwordConfText.PasswordChar = '\0';
                this.showPasswordButton.Text = "Hide Passwords";
            } else
            {
                this.passwordText.PasswordChar = '*';
                this.passwordConfText.PasswordChar = '*';
                this.showPasswordButton.Text = "Show Passwords";
            }
            
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            string fn;
            fn = this.openFileDialog1.FileName;
            this.profilePic.Load(fn);
            
        }
    }
}
