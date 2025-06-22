using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class passwordchangepanel : Form
    {
        public passwordchangepanel()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void passwordchangepanel_Load(object sender, EventArgs e)
        {
            // Optional initialization logic
        }

        // ✅ Clear all textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtRetypePW.Clear();
            txtUsername.Focus();
        }

        // ✅ Change password logic
        private void btnChangePW_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtPassword.Text.Trim();
            string retypePassword = txtRetypePW.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(retypePassword))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != retypePassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT * FROM employee WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);

                    MySqlDataReader reader = checkCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Close(); // Close reader before updating

                        string updateQuery = "UPDATE employee SET password = @newPassword WHERE username = @username";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@username", username);
                        updateCmd.Parameters.AddWithValue("@newPassword", newPassword);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LOGIN loginForm = new LOGIN();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtRetypePW_TextChanged(object sender, EventArgs e)
        {
            // Optional: Live password match validation
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Optional
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            // Not used in this logic, unless you later want to identify users by ID
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        // ✅ Go back to LOGIN form
        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
        }
    }
}
