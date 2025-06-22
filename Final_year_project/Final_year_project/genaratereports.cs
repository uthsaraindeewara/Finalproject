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
    public partial class genaratereports : Form
    {
        public genaratereports()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnProfit_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();
            homepanel.Show();
            this.Hide();
        }

        private void genaratereports_Load(object sender, EventArgs e)
        {

        }
    }
}
