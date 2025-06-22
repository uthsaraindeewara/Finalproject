using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_year_project
{
    public partial class reportforadmin : Form
    {
        public reportforadmin()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel homepanel = new Homepanel();
            homepanel.Show();
            this.Hide();
        }

        private void reportforadmin_Load(object sender, EventArgs e)
        {

        }
    }
}
