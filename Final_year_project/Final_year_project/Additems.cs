using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class Additems : Form
    {
        private string selectedImagePath = null;
        private string selectedImageExtension = null;
        List<Button> categoryButtons;

        public Additems()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Additems_Load(object sender, EventArgs e)
        {
            loadData();
            loadProducts("All");
            categoryButtons = new List<Button> { btnAll, btnFood, btnDrink, btnDesert };
            filterChange(btnAll);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
            string.IsNullOrWhiteSpace(txtName.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text) ||
            cmbCategory.SelectedIndex == -1 ||
            pictureBox1.Image == null ||
            nucPrice.Value <= 0 ||
            nucQuantity.Value < 0 ||
            string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Please fill in all fields and select an image.");
                return;
            }

            string productId = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string category = cmbCategory.SelectedItem.ToString();
            decimal price = nucPrice.Value;
            int quantity = (int)nucQuantity.Value;

            string folderName = "product-images";
            string fileName = $"product-{productId}{selectedImageExtension}";
            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(projectFolder, @"..\.."));
            string targetFolder = Path.Combine(projectRoot, folderName);
            string destinationPath = Path.Combine(targetFolder, fileName);
            string relativePath = Path.Combine(folderName, fileName).Replace("\\", "/");

            try
            {
                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();

                    // Insert into product table
                    string insertProduct = "INSERT INTO product(name, description, price, quantity, category) " +
                                           "VALUES (@name, @description, @price, @quantity, @category)";
                    using (MySqlCommand cmd = new MySqlCommand(insertProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@category", category);

                        cmd.ExecuteNonQuery();
                    }

                    // Save image to folder
                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);

                    File.Copy(selectedImagePath, destinationPath, true); // Overwrite if exists

                    // Insert image record
                    string insertImage = "INSERT INTO image(productID, path, name) VALUES (@productID, @path, @name)";
                    using (MySqlCommand cmd = new MySqlCommand(insertImage, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        cmd.Parameters.AddWithValue("@path", relativePath);
                        cmd.Parameters.AddWithValue("@name", fileName);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product and image saved successfully!");

                    txtId.Clear();  // We'll reload the next ID separately
                    txtName.Clear();
                    txtDescription.Clear();
                    cmbCategory.SelectedIndex = -1;
                    nucPrice.Value = 0;
                    nucQuantity.Value = 0;

                    // Dispose image and clear
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    // Reset selected image tracking
                    selectedImagePath = null;
                    selectedImageExtension = null;

                    loadData();
                    loadProducts("All");
                    filterChange(btnAll);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();
            homepanel.Show();
            this.Hide();
        }

        private void loadData()
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MAX(productId) FROM product";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    int nextId = 1; // default if table is empty

                    if (result != DBNull.Value && result != null)
                    {
                        nextId = Convert.ToInt32(result) + 1;
                    }

                    txtId.Text = nextId.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    selectedImageExtension = Path.GetExtension(selectedImagePath);

                    // Dispose old image
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    // Preview new image
                    byte[] imageBytes = File.ReadAllBytes(selectedImagePath);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = new Bitmap(ms);
                    }
                }
            }
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
                                productPanel.Height = 130;
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
                                lblDesc.Size = new Size(120, 50);
                                lblDesc.AutoEllipsis = true;

                                // Price
                                Label lblPrice = new Label();
                                lblPrice.Text = formattedPrice;
                                lblPrice.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                lblPrice.ForeColor = Color.OrangeRed;
                                lblPrice.Location = new Point(120, 90);
                                lblPrice.AutoSize = true;

                                // Add controls to panel
                                productPanel.Controls.Add(picture);
                                productPanel.Controls.Add(lblName);
                                productPanel.Controls.Add(lblDesc);
                                productPanel.Controls.Add(lblPrice);

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
                txtId.Text = data["productID"].ToString();
                txtName.Text = data["name"].ToString();
                txtDescription.Text = data["description"].ToString();
                nucPrice.Value = Convert.ToDecimal(data["price"]);
                nucQuantity.Value = Convert.ToInt32(data["quantity"]);
                cmbCategory.SelectedItem = data["category"].ToString();

                selectedImagePath = data["imagePath"].ToString();
                selectedImageExtension = Path.GetExtension(selectedImagePath);

                // Load image
                if (File.Exists(selectedImagePath))
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    byte[] imageBytes = File.ReadAllBytes(selectedImagePath);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = new Bitmap(ms);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                cmbCategory.SelectedIndex == -1 ||
                pictureBox1.Image == null ||
                nucPrice.Value <= 0 ||
                nucQuantity.Value < 0)
            {
                MessageBox.Show("Please fill in all fields and select an image.");
                return;
            }

            string productId = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string category = cmbCategory.SelectedItem.ToString();
            decimal price = nucPrice.Value;
            int quantity = (int)nucQuantity.Value;

            string folderName = "product-images";
            string fileName = $"product-{productId}{selectedImageExtension}";
            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(projectFolder, @"..\.."));
            string targetFolder = Path.Combine(projectRoot, folderName);
            string destinationPath = Path.Combine(targetFolder, fileName);
            string relativePath = Path.Combine(folderName, fileName).Replace("\\", "/");

            try
            {
                // First, copy the image to a temporary location
                string tempImagePath = Path.Combine(Path.GetTempPath(), fileName);
                File.Copy(selectedImagePath, tempImagePath, true);

                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();

                    // Update product table
                    string updateProduct = @"UPDATE product SET 
                                name = @name,
                                description = @description,
                                price = @price,
                                quantity = @quantity,
                                category = @category
                            WHERE productID = @productID";
                    using (MySqlCommand cmd = new MySqlCommand(updateProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@category", category);

                        cmd.ExecuteNonQuery();
                    }

                    // Clear the PictureBox and ensure resources are released
                    if (pictureBox1.Image != null)
                    {
                        var oldImage = pictureBox1.Image;
                        pictureBox1.Image = null;
                        oldImage.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }

                    // Ensure directory exists
                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);

                    // Delete the old file if it exists
                    if (File.Exists(destinationPath))
                    {
                        File.Delete(destinationPath);
                    }

                    // Copy from temp location to destination
                    File.Copy(tempImagePath, destinationPath);

                    // Update image table
                    string updateImage = @"UPDATE image SET 
                                path = @path,
                                name = @name 
                           WHERE productID = @productID";
                    using (MySqlCommand cmd = new MySqlCommand(updateImage, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        cmd.Parameters.AddWithValue("@path", relativePath);
                        cmd.Parameters.AddWithValue("@name", fileName);

                        cmd.ExecuteNonQuery();
                    }

                    // Clean up temp file
                    try
                    {
                        File.Delete(tempImagePath);
                    }
                    catch { /* Ignore temp file deletion errors */ }

                    // Reload the image
                    if (File.Exists(destinationPath))
                    {
                        using (var fs = new FileStream(destinationPath, FileMode.Open, FileAccess.Read))
                        {
                            pictureBox1.Image = Image.FromStream(fs);
                        }
                    }

                    MessageBox.Show("Product updated successfully!");

                    txtId.Clear();
                    txtName.Clear();
                    txtDescription.Clear();
                    cmbCategory.SelectedIndex = -1;
                    nucPrice.Value = 0;
                    nucQuantity.Value = 0;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    selectedImagePath = null;
                    selectedImageExtension = null;

                    loadData();
                    loadProducts("All");
                    filterChange(btnAll);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            string productId = txtId.Text.Trim();

            try
            {
                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();

                    // Get the image path first
                    string imagePath = null;
                    string getImageQuery = "SELECT path FROM image WHERE productID = @productID";
                    using (MySqlCommand cmd = new MySqlCommand(getImageQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        object resultPath = cmd.ExecuteScalar();
                        if (resultPath != null && resultPath != DBNull.Value)
                        {
                            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..", resultPath.ToString().Replace("/", "\\"));
                            imagePath = Path.GetFullPath(fullPath);
                        }
                    }

                    // First delete the image record to satisfy foreign key constraint
                    string deleteImage = "DELETE FROM image WHERE productID = @productID";
                    using (MySqlCommand cmd = new MySqlCommand(deleteImage, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        cmd.ExecuteNonQuery();
                    }

                    // Then delete the product record
                    string deleteProduct = "DELETE FROM product WHERE productID = @productID";
                    using (MySqlCommand cmd = new MySqlCommand(deleteProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productId);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete the image file from disk if exists
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        try
                        {
                            File.Delete(imagePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning: Could not delete image file: " + ex.Message);
                        }
                    }

                    MessageBox.Show("Product deleted successfully!");

                    // Clear form
                    txtId.Clear();
                    txtName.Clear();
                    txtDescription.Clear();
                    cmbCategory.SelectedIndex = -1;
                    nucPrice.Value = 0;
                    nucQuantity.Value = 0;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    selectedImagePath = null;
                    selectedImageExtension = null;

                    loadData();
                    loadProducts("All");
                    filterChange(btnAll);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
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

        private void filterChange(Button clickedButton)
        {
            foreach (Button btn in categoryButtons)
            {
                btn.BackColor = Color.White;
            }

            clickedButton.BackColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

       
    }


}
