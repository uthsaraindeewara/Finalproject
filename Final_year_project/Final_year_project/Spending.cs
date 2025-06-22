using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class Spending : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";

        public Spending()
        {
            InitializeComponent();
            LoadSpendingData();
            LoadNextSpendingID();
            dataGridView1.CellClick += dataGridView1_CellClick;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadSpendingData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM spending";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void LoadNextSpendingID()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'final_project' AND TABLE_NAME = 'spending'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                txtSpendingID.Text = result?.ToString() ?? "1";
            }
        }

        private void ClearFields()
        {
            txtSpendingID.Clear();
            txtAmount.Clear();
            txtDescription.Clear();
            cmbType.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO spending (amount, date, description, type) VALUES (@amount, @date, @desc, @type)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@amount", txtAmount.Text.Trim());
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@type", cmbType.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Spending added.");
            LoadSpendingData();
            LoadNextSpendingID();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSpendingID.Text))
            {
                MessageBox.Show("Select a record to update.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE spending SET amount = @amount, date = @date, description = @desc, type = @type WHERE spendingID = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@amount", txtAmount.Text.Trim());
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@type", cmbType.Text);
                cmd.Parameters.AddWithValue("@id", txtSpendingID.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Spending updated.");
            LoadSpendingData();
            LoadNextSpendingID();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadNextSpendingID();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtSpendingID.Text = row.Cells["spendingID"].Value.ToString();
                txtAmount.Text = row.Cells["amount"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(row.Cells["date"].Value);
                txtDescription.Text = row.Cells["description"].Value.ToString();
                cmbType.Text = row.Cells["type"].Value.ToString();
            }
        }

        // Optional: Handle text change events if needed
        private void txtSpendingID_TextChanged(object sender, EventArgs e) { }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtDescription_TextChanged(object sender, EventArgs e) { }
        private void txtAmount_TextChanged(object sender, EventArgs e) { }
        private void dtpDate_ValueChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Spending_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();    
            homepanel.Show();
            this.Hide();
        }
    }
}
