using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*'; // Initially hide password
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Optional: Add image click actions here
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Admin login
            if (username == "admin" && password == "123")
            {
                MessageBox.Show("Admin login successful!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Homepanel home = new Homepanel();
                home.Show();
                this.Hide();
                return;
            }

            // Employee login via MySQL
            string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM employee WHERE username = @username AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("Employee login successful!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Homepanel2 home2 = new Homepanel2();
                        home2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Optional: You can add real-time validation here
        }

        // ✅ Clear button: Clears both textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus(); // Optional: focus back on username
        }

        // ✅ Close button: Exits the application
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ✅ Customer link: Opens CustomerPanel
        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            customerpanel customerPanel = new customerpanel();
            customerPanel.Show();
            this.Hide();
        }

        // ✅ Show/Hide Password checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide password
            }
        }

        private void linkLabelFP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            passwordchangepanel passs = new passwordchangepanel();
            passs.Show();
            this.Hide();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}
