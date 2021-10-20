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

namespace Journal_pro.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            if (this.passwordText.PasswordChar == '*')
            {
                this.passwordText.PasswordChar = '\0';
                this.showPasswordButton.Text = "Hide Passwords";
            }
            else
            {
                this.passwordText.PasswordChar = '*';
             
                this.showPasswordButton.Text = "Show Passwords";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
             try
            {
                if (string.IsNullOrEmpty(this.userNameTextBox.Text))
                {
                    MessageBox.Show("Must Enter Valid Username", "Invalid UserName");
                    return;
                }

                if (this.userNameTextBox.Text != Journal_pro.Properties.Settings.Default.User_name && this.passwordText.Text != Journal_pro.Properties.Settings.Default.user_password)
                {
                    MessageBox.Show("Incorrect Password or Username", "Invalid Entry");
                    return;
                }
                if (this.userNameTextBox.Text == Journal_pro.Properties.Settings.Default.User_name && this.passwordText.Text == Journal_pro.Properties.Settings.Default.user_password)
                {
                    string fn = Application.StartupPath + "\\data\\UserPictures\\1.jpg";
                    this.profilePic.Load(fn);
                    MessageBox.Show("Succesfully logged in");
                    this.Close();
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
