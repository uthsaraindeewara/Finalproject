// ManageStock.cs with corrected `supplier Name` handling and product quantity update
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class ManageStock : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";

        public ManageStock()
        {
            InitializeComponent();
            LoadProductTable();
            LoadNextStockId();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadNextStockId()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'final_project' AND TABLE_NAME = 'stock'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                txtStockID.Text = result?.ToString() ?? "1";
            }
        }

        private void LoadProductTable()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT productID, name, description, price, quantity, category, type FROM product";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxname.Text) || string.IsNullOrWhiteSpace(textboxproductid.Text))
            {
                MessageBox.Show("Please enter Product ID and Supplier Name.");
                return;
            }

            if (!int.TryParse(textboxproductid.Text.Trim(), out int productId))
            {
                MessageBox.Show("Product ID must be a valid number.");
                return;
            }

            int quantity = int.Parse(txtQuantity.Text);
            double cost = double.Parse(txtCost.Text);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string insertQuery = "INSERT INTO stock (productID, quantity, cost, `supplier Name`) VALUES (@productID, @quantity, @cost, @supplierName)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@productID", productId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.Parameters.AddWithValue("@supplierName", textBoxname.Text.Trim());
                cmd.ExecuteNonQuery();

                // Update product quantity
                string updateProductQty = "UPDATE product SET quantity = quantity + @quantity WHERE productID = @productID";
                MySqlCommand updateCmd = new MySqlCommand(updateProductQty, conn);
                updateCmd.Parameters.AddWithValue("@quantity", quantity);
                updateCmd.Parameters.AddWithValue("@productID", productId);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Stock added successfully.");
                ClearFields();
                LoadNextStockId();
                LoadProductTable();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStockID.Text) || string.IsNullOrWhiteSpace(textboxproductid.Text))
            {
                MessageBox.Show("Please enter Stock ID and Product ID to update.");
                return;
            }

            if (!int.TryParse(textboxproductid.Text.Trim(), out int productId))
            {
                MessageBox.Show("Product ID must be a valid number.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE stock SET productID = @productID, quantity = @quantity, cost = @cost, `supplier Name` = @supplierName WHERE stockID = @stockID";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@productID", productId);
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@cost", txtCost.Text);
                cmd.Parameters.AddWithValue("@supplierName", textBoxname.Text.Trim());
                cmd.Parameters.AddWithValue("@stockID", txtStockID.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Stock updated successfully.");
                ClearFields();
                LoadNextStockId();
                LoadProductTable();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStockID.Text))
            {
                MessageBox.Show("Please enter Stock ID to delete.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM stock WHERE stockID = @stockID";
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@stockID", txtStockID.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Stock deleted successfully.");
                ClearFields();
                LoadNextStockId();
                LoadProductTable();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadNextStockId();
        }

        private void ClearFields()
        {
            txtStockID.Clear();
            txtCost.Clear();
            txtQuantity.Clear();
            textBoxname.Clear();
            textboxproductid.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();
            homepanel.Show();
            this.Hide();
        }

        private void ManageStock_Load(object sender, EventArgs e)
        {

        }
    }
}
