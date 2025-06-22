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
    public partial class Homepanel : Form
    {
        public Homepanel()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Homepanel_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            EmployeeMange addemployees = new EmployeeMange();
            addemployees.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void btnManageStock_Click(object sender, EventArgs e)
        {

        }

        private void btnManageItems_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportforadmin genaratereports = new reportforadmin();
            genaratereports.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Homepanel2  homepanel2 = new Homepanel2();
            homepanel2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEmployees addemployees = new AddEmployees(3);
            addemployees.Show();
            this.Hide();
        }
    }
}
