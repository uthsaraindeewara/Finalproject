using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Final_year_project
{
    public partial class customerpanel : Form
    {
        List<Button> categoryButtons;

        public customerpanel()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void customerpanel_Load(object sender, EventArgs e)
        {
            loadProducts("All");
            categoryButtons = new List<Button> { btnAll, btnFood, btnDrink, btnDesert };
            filterChange(btnAll);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void loadProducts(string category)
        {
            flowProducts.Controls.Clear(); // Clear previous items

            string query = "SELECT * FROM product p INNER JOIN image i ON p.productID = i.productID";

            if (category != "All")
            {
                query += " WHERE p.category = @category";
            }

            try
            {
                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (category != "All")
                            cmd.Parameters.AddWithValue("@category", category);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productId = reader["productID"].ToString();
                                string name = reader["name"].ToString();
                                string description = reader["description"].ToString();
                                decimal price = Convert.ToDecimal(reader["price"]);
                                string formattedPrice = $"Rs. {price:N2}";
                                int quantity = Convert.ToInt32(reader["quantity"]);
                                string categoryValue = reader["category"].ToString();
                                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")
                                                 + reader["path"].ToString().Replace("/", "\\");

                                // Create panel for each product
                                Panel productPanel = new Panel();
                                productPanel.Width = 250;
                                productPanel.Height = 190;
                                productPanel.Margin = new Padding(10);
                                productPanel.BorderStyle = BorderStyle.FixedSingle;

                                // Store product info in Tag
                                productPanel.Tag = new Dictionary<string, object>
                                {
                                    { "productID", productId },
                                    { "name", name },
                                    { "description", description },
                                    { "price", price },
                                    { "quantity", quantity },
                                    { "category", categoryValue },
                                    { "imagePath", imagePath }
                                };

                                // Add click event
                                productPanel.Click += ProductPanel_Click;

                                // Image
                                PictureBox picture = new PictureBox();
                                picture.Size = new Size(100, 100);
                                picture.Location = new Point(10, 10);
                                picture.SizeMode = PictureBoxSizeMode.Zoom;
                                picture.BackColor = Color.White;
                                if (File.Exists(imagePath))
                                {
                                    try
                                    {
                                        using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                        {
                                            picture.Image = Image.FromStream(fs);
                                        }
                                    }
                                    catch
                                    {
                                        // If there's an error loading, use a placeholder or empty image
                                        picture.Image = null;
                                    }
                                }

                                // Name
                                Label lblName = new Label();
                                lblName.Text = name;
                                lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                lblName.Location = new Point(120, 10);
                                lblName.AutoSize = true;

                                // Description
                                Label lblDesc = new Label();
                                lblDesc.Text = description;
                                lblDesc.Font = new Font("Segoe UI", 9);
                                lblDesc.Location = new Point(120, 40);
                                lblDesc.Size = new Size(120, 30);
                                lblDesc.AutoEllipsis = true;

                                Label lblCategory = new Label();
                                lblCategory.Text = categoryValue;
                                lblCategory.Font = new Font("Segoe UI", 8);
                                lblCategory.Location = new Point(120, 70);
                                lblCategory.AutoSize = true;
                                lblCategory.ForeColor = Color.Gray;

                                // Price
                                Label lblPrice = new Label();
                                lblPrice.Text = formattedPrice;
                                lblPrice.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                lblPrice.ForeColor = Color.OrangeRed;
                                lblPrice.Location = new Point(120, 90);
                                lblPrice.AutoSize = true;

                                NumericUpDown numQty = new NumericUpDown();
                                numQty.Value = 1;
                                numQty.Minimum = 1;
                                numQty.Maximum = quantity;
                                numQty.Location = new Point(160, 120);
                                numQty.Width = 40;

                                Button btnAddToCart = new Button();
                                btnAddToCart.Text = "Add";
                                btnAddToCart.Location = new Point(130, 150);
                                btnAddToCart.Width = 100;
                                btnAddToCart.BackColor = Color.Black;
                                btnAddToCart.ForeColor = Color.White;

                                btnAddToCart.Click += (s, e) =>
                                {
                                    AddToCart(productId, name, imagePath, price, (int)numQty.Value);
                                };

                                // Add controls to panel
                                productPanel.Controls.Add(picture);
                                productPanel.Controls.Add(lblName);
                                productPanel.Controls.Add(lblDesc);
                                productPanel.Controls.Add(lblCategory);
                                productPanel.Controls.Add(lblPrice);
                                productPanel.Controls.Add(numQty);
                                productPanel.Controls.Add(btnAddToCart);

                                // Forward child control clicks to the panel
                                foreach (Control ctrl in productPanel.Controls)
                                {
                                    ctrl.Click += (s, ev) => ProductPanel_Click(productPanel, EventArgs.Empty);
                                }

                                // Add to flow layout
                                flowProducts.Controls.Add(productPanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
            finally
            {
                flowProducts.ResumeLayout(); // Resume layout
            }
        }

        private void ProductPanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is Dictionary<string, object> data)
            {
                
            }
        }

        private void filterChange(Button clickedButton)
        {
            foreach (Button btn in categoryButtons)
            {
                btn.BackColor = Color.White;
            }

            clickedButton.BackColor = Color.Black;
        }

        private void AddToCart(string id, string name, string imagePath, decimal price, int qty)
        {
            // Check if already exists
            foreach (Control panel in flowOrder.Controls)
            {
                if (panel is Panel && panel.Tag?.ToString() == id)
                {
                    NumericUpDown qtyBox = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                    if (qtyBox != null)
                    {
                        qtyBox.Value += qty;
                        UpdateCartSummary();
                    }
                    return;
                }
            }

            Panel itemPanel = new Panel { Width = 230, Height = 100, Tag = id, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(5) };

            PictureBox pic = new PictureBox { Size = new Size(60, 60), Location = new Point(10, 10), SizeMode = PictureBoxSizeMode.Zoom };
            if (File.Exists(imagePath))
            {
                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    pic.Image = Image.FromStream(fs);
            }

            Label lblName = new Label { Text = name, Location = new Point(80, 10), Width = 120 };
            NumericUpDown qtyBoxCart = new NumericUpDown { Value = qty, Minimum = 1, Location = new Point(80, 34), Width = 50 };
            Label lblPrice = new Label { Text = $"Rs. {price:N2}", Location = new Point(140, 34), AutoSize = true };
            Button btnRemove = new Button { Text = "Remove", ForeColor = Color.Red, FlatStyle = FlatStyle.Flat, BackColor = Color.Transparent, Font = new Font("Segoe UI", 8, FontStyle.Regular), Size = new Size(70, 25), Location = new Point(140, 60) };

            btnRemove.Click += (senderRemove, eRemove) =>
            {
                flowOrder.Controls.Remove(itemPanel);
                UpdateSummary();
            };

            qtyBoxCart.ValueChanged += (s, e) => UpdateCartSummary();

            itemPanel.Controls.AddRange(new Control[] { pic, lblName, qtyBoxCart, lblPrice, btnRemove });
            flowOrder.Controls.Add(itemPanel);

            UpdateCartSummary();
        }

        private void UpdateCartSummary()
        {
            int totalItems = 0;
            decimal totalPrice = 0;

            foreach (Panel panel in flowOrder.Controls)
            {
                NumericUpDown qtyBox = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                Label priceLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("Rs."));

                if (qtyBox != null && priceLabel != null)
                {
                    int qty = (int)qtyBox.Value;
                    string priceText = priceLabel.Text.Replace("Rs.", "").Trim();
                    decimal pricePerUnit = decimal.Parse(priceText);

                    totalItems += qty;
                    totalPrice += qty * pricePerUnit;
                }
            }

            lblItems.Text = $"{totalItems}";
            lblTotal.Text = $"Rs. {totalPrice:N2}";
        }

        private void UpdateSummary()
        {
            int totalItems = 0;
            decimal totalPrice = 0;

            foreach (Panel panel in flowOrder.Controls)
            {
                NumericUpDown qtyBox = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                Label priceLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("Rs."));

                if (qtyBox != null && priceLabel != null)
                {
                    int qty = (int)qtyBox.Value;
                    string priceText = priceLabel.Text.Replace("Rs.", "").Trim();
                    decimal pricePerUnit = decimal.Parse(priceText);

                    totalItems += qty;
                    totalPrice += qty * pricePerUnit;
                }
            }

            lblItems.Text = $"{totalItems}";
            lblTotal.Text = $"Rs. {totalPrice:N2}";
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            filterChange(btn);
            loadProducts("All");
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            filterChange(btn);
            loadProducts("Food");
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            filterChange(btn);
            loadProducts("Drink");
        }

        private void btnDesert_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            filterChange(btn);
            loadProducts("Desert");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            SearchProducts(searchText);
        }
        
        private void SearchProducts(String search)
        {
            flowProducts.Controls.Clear(); // Clear previous items

            string query = @"SELECT * FROM product p 
                     INNER JOIN image i ON p.productID = i.productID
                     WHERE p.name LIKE @search 
                        OR p.description LIKE @search 
                        OR p.category LIKE @search";

            try
            {
                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{search}%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productId = reader["productID"].ToString();
                                string name = reader["name"].ToString();
                                string description = reader["description"].ToString();
                                decimal price = Convert.ToDecimal(reader["price"]);
                                string formattedPrice = $"Rs. {price:N2}";
                                int quantity = Convert.ToInt32(reader["quantity"]);
                                string categoryValue = reader["category"].ToString();
                                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")
                                                 + reader["path"].ToString().Replace("/", "\\");

                                // Create panel for each product
                                Panel productPanel = new Panel();
                                productPanel.Width = 250;
                                productPanel.Height = 190;
                                productPanel.Margin = new Padding(10);
                                productPanel.BorderStyle = BorderStyle.FixedSingle;

                                // Store product info in Tag
                                productPanel.Tag = new Dictionary<string, object>
                                {
                                    { "productID", productId },
                                    { "name", name },
                                    { "description", description },
                                    { "price", price },
                                    { "quantity", quantity },
                                    { "category", categoryValue },
                                    { "imagePath", imagePath }
                                };

                                // Add click event
                                productPanel.Click += ProductPanel_Click;

                                // Image
                                PictureBox picture = new PictureBox();
                                picture.Size = new Size(100, 100);
                                picture.Location = new Point(10, 10);
                                picture.SizeMode = PictureBoxSizeMode.Zoom;
                                picture.BackColor = Color.White;
                                if (File.Exists(imagePath))
                                {
                                    try
                                    {
                                        using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                        {
                                            picture.Image = Image.FromStream(fs);
                                        }
                                    }
                                    catch
                                    {
                                        // If there's an error loading, use a placeholder or empty image
                                        picture.Image = null;
                                    }
                                }

                                // Name
                                Label lblName = new Label();
                                lblName.Text = name;
                                lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                lblName.Location = new Point(120, 10);
                                lblName.AutoSize = true;

                                // Description
                                Label lblDesc = new Label();
                                lblDesc.Text = description;
                                lblDesc.Font = new Font("Segoe UI", 9);
                                lblDesc.Location = new Point(120, 40);
                                lblDesc.Size = new Size(120, 30);
                                lblDesc.AutoEllipsis = true;

                                Label lblCategory = new Label();
                                lblCategory.Text = categoryValue;
                                lblCategory.Font = new Font("Segoe UI", 8);
                                lblCategory.Location = new Point(120, 70);
                                lblCategory.AutoSize = true;
                                lblCategory.ForeColor = Color.Gray;

                                // Price
                                Label lblPrice = new Label();
                                lblPrice.Text = formattedPrice;
                                lblPrice.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                lblPrice.ForeColor = Color.OrangeRed;
                                lblPrice.Location = new Point(120, 90);
                                lblPrice.AutoSize = true;

                                NumericUpDown numQty = new NumericUpDown();
                                numQty.Value = 1;
                                numQty.Minimum = 1;
                                numQty.Maximum = quantity;
                                numQty.Location = new Point(160, 120);
                                numQty.Width = 40;

                                Button btnAddToCart = new Button();
                                btnAddToCart.Text = "Add";
                                btnAddToCart.Location = new Point(130, 150);
                                btnAddToCart.Width = 100;
                                btnAddToCart.BackColor = Color.Black;
                                btnAddToCart.ForeColor = Color.White;

                                btnAddToCart.Click += (s, e) =>
                                {
                                    AddToCart(productId, name, imagePath, price, (int)numQty.Value);
                                };

                                // Add controls to panel
                                productPanel.Controls.Add(picture);
                                productPanel.Controls.Add(lblName);
                                productPanel.Controls.Add(lblDesc);
                                productPanel.Controls.Add(lblCategory);
                                productPanel.Controls.Add(lblPrice);
                                productPanel.Controls.Add(numQty);
                                productPanel.Controls.Add(btnAddToCart);

                                // Forward child control clicks to the panel
                                foreach (Control ctrl in productPanel.Controls)
                                {
                                    ctrl.Click += (s, ev) => ProductPanel_Click(productPanel, EventArgs.Empty);
                                }

                                // Add to flow layout
                                flowProducts.Controls.Add(productPanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void btnPaceOrder_Click(object sender, EventArgs e)
        {
            if (flowOrder.Controls.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name to place the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();

                    using (MySqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert customer and retrieve auto-generated ID
                            string insertCustomerQuery = "INSERT INTO customer (name) VALUES (@name); SELECT LAST_INSERT_ID();";
                            int customerId;

                            using (MySqlCommand cmdCustomer = new MySqlCommand(insertCustomerQuery, con, transaction))
                            {
                                cmdCustomer.Parameters.AddWithValue("@name", txtName.Text);
                                customerId = Convert.ToInt32(cmdCustomer.ExecuteScalar());
                            }

                            // 2. Insert order and retrieve auto-generated ID
                            decimal totalAmount = decimal.Parse(lblTotal.Text.Replace("Rs.", "").Trim(), CultureInfo.InvariantCulture);
                            string insertOrderQuery = @"INSERT INTO orders (customerID, date, status, amount) 
                                             VALUES (@customerID, @date, @status, @amount);
                                             SELECT LAST_INSERT_ID();";
                            int orderId;

                            using (MySqlCommand cmdOrder = new MySqlCommand(insertOrderQuery, con, transaction))
                            {
                                cmdOrder.Parameters.AddWithValue("@customerID", customerId);
                                cmdOrder.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdOrder.Parameters.AddWithValue("@status", "Pending");
                                cmdOrder.Parameters.AddWithValue("@amount", totalAmount);
                                orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());
                            }

                            // 3. Insert order items
                            foreach (Panel panel in flowOrder.Controls)
                            {
                                if (panel.Tag is string productId)
                                {
                                    NumericUpDown qtyBox = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                                    Label priceLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("Rs."));

                                    if (qtyBox != null && priceLabel != null)
                                    {
                                        int quantity = (int)qtyBox.Value;
                                        decimal price = decimal.Parse(priceLabel.Text.Replace("Rs.", "").Trim(), CultureInfo.InvariantCulture);

                                        string insertItemQuery = @"INSERT INTO orderitem (orderID, productID, quantity, price) 
                                                         VALUES (@orderID, @productID, @quantity, @price)";

                                        using (MySqlCommand cmdItem = new MySqlCommand(insertItemQuery, con, transaction))
                                        {
                                            cmdItem.Parameters.AddWithValue("@orderID", orderId);
                                            cmdItem.Parameters.AddWithValue("@productID", productId);
                                            cmdItem.Parameters.AddWithValue("@quantity", quantity);
                                            cmdItem.Parameters.AddWithValue("@price", price);
                                            cmdItem.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            transaction.Commit();

                            // Clear the cart and reset customer name
                            flowOrder.Controls.Clear();
                            txtName.Clear();
                            UpdateCartSummary();

                            MessageBox.Show($"Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error placing order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
