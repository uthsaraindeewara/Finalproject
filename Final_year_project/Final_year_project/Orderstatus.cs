using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class Orderstatus : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";

        public Orderstatus()
        {
            InitializeComponent();
            this.Load += Orderstatus_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Orderstatus_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            dataGridView1.Columns.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        o.orderID AS ID,
                        c.name AS CusName,
                        o.date AS Date,
                        o.amount AS Amount,
                        o.status AS Status
                    FROM orders o
                    JOIN customer c ON o.customerID = c.customerID";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            // Add "Action" button column
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Action";
            btnColumn.HeaderText = "Action";
            btnColumn.Text = "Change ";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnColumn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Columns[e.ColumnIndex].Name != "Action")
                return;

            int orderId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            string currentStatus = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            string newStatus = currentStatus == "Pending" ? "Delivered" : "Pending";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE orders SET status = @status WHERE orderID = @orderID";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@orderID", orderId);
                cmd.ExecuteNonQuery();
            }

            // Refresh data after update
            LoadOrderData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();
            homepanel.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Not needed but avoid removal in designer
        }
    }
}
