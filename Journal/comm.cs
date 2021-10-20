using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Journal_pro
{
    public static class comm
    {
        public static void myErrorMsg (string errorMsg)
        {
            MessageBox.Show("Error: " + errorMsg);
        }
    }
}
