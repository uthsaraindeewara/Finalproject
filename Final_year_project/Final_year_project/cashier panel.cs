using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class cashier_panel : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";
        private DataTable productTable;
        private decimal totalBeforeDiscount = 0;

        public cashier_panel()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cashier_panel_Load(object sender, EventArgs e)
        {
            LoadProductData();
            LoadLatestOrderItems(); // ✅ Load and calculate total of latest customer order
        }

        private void LoadProductData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT 
                                    productID AS Productid,
                                    name AS ProductName,
                                    description AS Description,
                                    price AS Productprice,
                                    quantity AS ProductQuantity,
                                    category 
                                 FROM product 
                                 ORDER BY name ASC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                productTable = new DataTable();
                adapter.Fill(productTable);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = productTable;
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (productTable != null)
            {
                productTable.DefaultView.RowFilter = $"ProductName LIKE '%{txtNameSearch.Text}%'";
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to add.");
                return;
            }

            var selectedRow = dataGridView2.SelectedRows[0];
            string id = selectedRow.Cells["Productid"].Value.ToString();
            string name = selectedRow.Cells["ProductName"].Value.ToString();
            decimal unitPrice = Convert.ToDecimal(selectedRow.Cells["Productprice"].Value);
            int availableQty = Convert.ToInt32(selectedRow.Cells["ProductQuantity"].Value);
            int selectedQty = (int)nucQuantity.Value;

            if (selectedQty <= 0 || selectedQty > availableQty)
            {
                MessageBox.Show("Invalid quantity selected.");
                return;
            }

            decimal totalPrice = unitPrice * selectedQty;

            dataGridView1.Rows.Add(id, name, selectedQty, unitPrice.ToString("0.00"), totalPrice.ToString("0.00"));
            totalBeforeDiscount += totalPrice;
            txtTotal.Text = totalBeforeDiscount.ToString("0.00");
            nucQuantity.Value = 1;
        }

        private void btnNetTotal_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTotal.Text, out decimal total)) return;
            if (!decimal.TryParse(textdiscount.Text, out decimal discountPercentage)) discountPercentage = 0;
            if (!decimal.TryParse(txtCash.Text, out decimal cash)) cash = 0;

            decimal discountAmount = total * discountPercentage / 100;
            decimal netTotal = total - discountAmount;
            decimal change = cash - netTotal;

            txtNetTotal.Text = netTotal.ToString("0.00");
            txtChange.Text = change.ToString("0.00");

            SaveOrderToDatabase(netTotal, discountAmount);
        }

        private void SaveOrderToDatabase(decimal netTotal, decimal discountAmount)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertOrderQuery = "INSERT INTO orders (customerID, date, status, amount) VALUES (@customerID, @date, @status, @amount); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd = new MySqlCommand(insertOrderQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@customerID", 1); // Replace with actual customerID
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", "Completed");
                    cmd.Parameters.AddWithValue("@amount", netTotal);
                    int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                    if (discountAmount > 0)
                    {
                        string insertDiscount = "INSERT INTO discount (billID, amount) VALUES (@billID, @amount)";
                        cmd = new MySqlCommand(insertDiscount, conn, transaction);
                        cmd.Parameters.AddWithValue("@billID", orderId);
                        cmd.Parameters.AddWithValue("@amount", discountAmount);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["ID"].Value == null) continue;

                        string insertItem = "INSERT INTO orderitem (orderID, productID, quantity, price) VALUES (@orderID, @productID, @quantity, @price)";
                        cmd = new MySqlCommand(insertItem, conn, transaction);
                        cmd.Parameters.AddWithValue("@orderID", orderId);
                        cmd.Parameters.AddWithValue("@productID", row.Cells["ID"].Value);
                        cmd.Parameters.AddWithValue("@quantity", row.Cells["Quantity"].Value);
                        cmd.Parameters.AddWithValue("@price", row.Cells["Price"].Value);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Order saved successfully.");

                    LoadLatestOrderItems(); // ✅ Refresh view with saved order
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving order: " + ex.Message);
                }
            }
        }

        private void LoadLatestOrderItems()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string getLastOrderQuery = "SELECT MAX(orderID) FROM orders";
                MySqlCommand cmd = new MySqlCommand(getLastOrderQuery, conn);
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value) return;

                int latestOrderId = Convert.ToInt32(result);

                string itemQuery = @"
                    SELECT 
                        oi.productID,
                        p.name,
                        oi.quantity,
                        oi.price,
                        (oi.quantity * oi.price) AS total
                    FROM orderitem oi
                    JOIN product p ON p.productID = oi.productID
                    WHERE oi.orderID = @orderID";

                cmd = new MySqlCommand(itemQuery, conn);
                cmd.Parameters.AddWithValue("@orderID", latestOrderId);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.Rows.Clear();
                    totalBeforeDiscount = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        decimal rowTotal = Convert.ToDecimal(row["total"]);
                        totalBeforeDiscount += rowTotal;

                        dataGridView1.Rows.Add(
                            row["productID"].ToString(),
                            row["name"].ToString(),
                            row["quantity"].ToString(),
                            Convert.ToDecimal(row["price"]).ToString("0.00"),
                            rowTotal.ToString("0.00")
                        );
                    }

                    txtTotal.Text = totalBeforeDiscount.ToString("0.00");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional for future use
        }
    }
}
