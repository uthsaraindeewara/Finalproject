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
    public partial class Homepanel2 : Form
    {
        public Homepanel2()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homepanel2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            genaratereports genaratereports = new genaratereports();
            genaratereports.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           cashier_panel cashier_Panel = new cashier_panel();
            cashier_Panel.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculate_payroll calculate_Payroll = new Calculate_payroll();
            calculate_Payroll.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orderstatus orderstatus = new Orderstatus();
            orderstatus.Show();
            this.Hide();
        }

        private void btnManageStock_Click(object sender, EventArgs e)
        {
            ManageStock manageStock = new ManageStock();
            manageStock.Show();
            this.Hide();
        }

        private void btnManageItems_Click(object sender, EventArgs e)
        {
            Additems additems = new Additems();
            additems.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            profit profit = new profit();
            profit.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Spending spending = new Spending();
            spending.Show();
            this.Hide();
        }
    }
}
