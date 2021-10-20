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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.headerLabel.Text = Application.CompanyName;
            this.productName.Text = Application.ProductName;
            this.version.Text = Application.ProductVersion;
            this.website.Text = Journal_pro.Properties.Settings.Default.company_website;
            this.developer.Text = Journal_pro.Properties.Settings.Default.developer;
        }

        
    }
}
