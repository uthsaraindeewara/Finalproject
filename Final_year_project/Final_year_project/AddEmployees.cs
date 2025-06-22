using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using K4os.Hash.xxHash;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using TheArtOfDev.HtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Final_year_project
{
    public partial class AddEmployees : Form
    {
        int employeeId = 0;
        string position = "";
        
        // Constructor called when the form is created to add a new employee
        public AddEmployees()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            setNextId();
        }

        public AddEmployees(int employeeId)
        {
            InitializeComponent();

            this.employeeId = employeeId;
            changeToUpdate();
            getPosition();
            loadEmployeeDetails();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();

                    string query = @"INSERT INTO employee (employeeID, employeeName, storeID, salary, contactNo, address, username, password)
                     VALUES (@employeeID, @employeeName, @storeID, @salary, @contactNo, @address, @username, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@employeeID", txtId.Text);
                        cmd.Parameters.AddWithValue("@employeeName", txtName.Text);
                        cmd.Parameters.AddWithValue("@storeID", cmbStore.Text);
                        cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                        cmd.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show("Failed to add employee.");
                            return;
                        }
                    }

                    if (cmbPosition.Text == "Manager")
                    {
                        query = @"INSERT INTO manager (managerID, email, role, qualifications)
                        VALUES (@managerID, @email, @role, @qualifications)";

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@managerID", txtId.Text);
                            cmd.Parameters.AddWithValue("@email", txtManagerEmail.Text);
                            cmd.Parameters.AddWithValue("@role", cmbManagerRole.Text);
                            cmd.Parameters.AddWithValue("@qualifications", txtManagerQualification.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Manager added successfully!");
                            else
                                MessageBox.Show("Failed to add manager.");
                        }
                    }
                    else if (cmbPosition.Text == "Accountant")
                    {
                        query = @"INSERT INTO accountant (accountantID, email, qualifications)
                        VALUES (@accountantID, @email, @qualifications)";

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@accountantID", txtId.Text);
                            cmd.Parameters.AddWithValue("@email", txtAccountantEmail.Text);
                            cmd.Parameters.AddWithValue("@qualifications", txtAccountantQualification.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Accountant added successfully!");
                            else
                                MessageBox.Show("Failed to add accountant.");
                        }
                    }
                    else if (cmbPosition.Text == "Waiter")
                    {
                        query = @"INSERT INTO waiter (waiterID, shiftTime, experience) 
                        VALUES (@waiterID, @shiftTime, @experience)";

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@waiterID", txtId.Text);
                            cmd.Parameters.AddWithValue("@shiftTime", dtpWaiterShiftTime.Value);
                            cmd.Parameters.AddWithValue("@experience", txtWaiterExperience);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                                MessageBox.Show("Waiter added successfully!");
                            else
                                MessageBox.Show("Failed to add waiter.");
                        }

                    }
                    else if (cmbPosition.Text == "Cashier")
                    {
                        query = @"INSERT INTO cashier (cashierID, experience) 
                        VALUES (@cashierID, @experience)";

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@cashierID", txtId.Text);
                            cmd.Parameters.AddWithValue("@experience", txtCashierExperience);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                                MessageBox.Show("Cashier added successfully!");
                            else
                                MessageBox.Show("Failed to add cashier.");
                        }
                    }

                    clearFields();
                    setNextId();
                }
            }
        }


        private bool ValidateInputs()
        {
            // Check if all text fields are not empty
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter an address.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                MessageBox.Show("Please enter a contact number.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                MessageBox.Show("Please enter a salary.");
                return false;
            }

            // Check if a store is selected
            if (string.IsNullOrWhiteSpace(cmbStore.Text))
            {
                MessageBox.Show("Please select a store.");
                return false;
            }

            // Validate txtContactNo contains exactly 10 digits
            if (txtContactNo.Text.Length != 10 || !long.TryParse(txtContactNo.Text, out _))
            {
                MessageBox.Show("Contact number must contain exactly 10 digits.");
                return false;
            }

            // Validate txtSalary is an integer
            if (!int.TryParse(txtSalary.Text, out _))
            {
                MessageBox.Show("Salary must be a valid number.");
                return false;
            }

            if (string.IsNullOrEmpty(cmbPosition.Text))
            {
                MessageBox.Show("Please select a position.");
                return false;
            }

            if (cmbPosition.Text == "Manager")
            {
                if (string.IsNullOrEmpty(cmbManagerRole.Text))
                {
                    MessageBox.Show("Please select a manager role");
                    return false;
                }
                if (string.IsNullOrEmpty(txtManagerEmail.Text))
                {
                    MessageBox.Show("Please enter manager email");
                    return false;
                }
            }
            else if (cmbPosition.Text == "Accountant")
            {
                if (string.IsNullOrEmpty(txtAccountantEmail.Text))
                {
                    MessageBox.Show("Please enter accountant email");
                    return false;
                }
            }
            else if (cmbPosition.Text == "Waiter")
            {
                if (string.IsNullOrEmpty(dtpWaiterShiftTime.Value.ToString()))
                {
                    MessageBox.Show("Please enter waiter shift time");
                    return false;
                }
            }

            return true;
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPosition.Text == "Manager")
            {
                pnlManagerDetails.Visible = true;
                pnlAccountantDetails.Visible = false;
                pnlWaiterDetails.Visible = false;
                pnlCashierDetails.Visible = false;
            }
            else if (cmbPosition.Text == "Accountant")
            {
                pnlManagerDetails.Visible = false;
                pnlAccountantDetails.Visible = true;
                pnlWaiterDetails.Visible = false;
                pnlCashierDetails.Visible = false;
            }
            else if (cmbPosition.Text == "Waiter")
            {
                pnlManagerDetails.Visible = false;
                pnlAccountantDetails.Visible = false;
                pnlWaiterDetails.Visible = true;
                pnlCashierDetails.Visible = false;
            }
            else if (cmbPosition.Text == "Cashier")
            {
                pnlManagerDetails.Visible = false;
                pnlAccountantDetails.Visible = false;
                pnlWaiterDetails.Visible = false;
                pnlCashierDetails.Visible = true;
            }
        }

        private void clearFields()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            cmbStore.Text = "";
            txtSalary.Text = "";
            cmbPosition.Text = "";
            cmbManagerRole.Text = "";
            txtManagerEmail.Text = "";
            txtManagerQualification.Text = "";
            txtAccountantEmail.Text = "";
            txtAccountantQualification.Text = "";
            dtpWaiterShiftTime.Value = DateTime.Now;
            txtWaiterExperience.Text = "";
            txtCashierExperience.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void getPosition()
        {
            string query = @"SELECT 
                                managerID, 'Manager' AS position 
                             FROM manager 
                             WHERE managerID = @employeeId 
                             UNION 
                             SELECT accountantID, 'Accountant' AS position 
                             FROM accountant 
                             WHERE accountantID = @employeeId 
                             UNION 
                             SELECT waiterID, 'Waiter' AS position 
                             FROM  waiter
                             WHERE waiterID = @employeeId 
                             UNION 
                             SELECT cashierID, 'Cashier' AS position 
                             FROM cashier 
                             WHERE cashierID = @employeeId";

            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand com = new MySqlCommand(query, connection);

                    com.Parameters.AddWithValue("@employeeId", employeeId);
                    MySqlDataReader dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        position = dr.GetString("position");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string query = @"UPDATE employee SET 
                        employeeName = @employeeName,
                        storeID = @storeID,
                        salary = @salary,
                        contactNo = @contactNo,
                        address = @address,
                        username = @username,
                        password = @password
                    WHERE employeeID = @employeeID";

                using (MySqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@employeeID", txtId.Text);
                        cmd.Parameters.AddWithValue("@employeeName", txtName.Text);
                        cmd.Parameters.AddWithValue("@storeID", cmbStore.Text);
                        cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                        cmd.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        cmd.ExecuteNonQuery();
                    }

                    if (position == "Manager")
                    {
                        query = @"UPDATE manager SET 
                        email = @email,
                        role = @role,
                        qualifications = @qualifications
                        WHERE managerID = @managerID";

                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@managerID", txtId.Text);
                                cmd.Parameters.AddWithValue("@email", txtManagerEmail.Text);
                                cmd.Parameters.AddWithValue("@role", cmbManagerRole.Text);
                                cmd.Parameters.AddWithValue("@qualifications", txtManagerQualification.Text);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Manager updated successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating manager: " + ex.Message);
                        }
                    }
                    else if (position == "Accountant")
                    {
                        query = @"UPDATE accountant SET 
                        email = @email,
                        qualifications = @qualifications
                        WHERE accountantID = @accountantID";

                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@accountantID", txtId.Text);
                                cmd.Parameters.AddWithValue("@email", txtAccountantEmail.Text);
                                cmd.Parameters.AddWithValue("@qualifications", txtAccountantQualification.Text);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Accountant updated successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating accountant: " + ex.Message);
                        }
                    }
                    else if (position == "Waiter")
                    {
                        query = @"UPDATE waiter SET 
                        shiftTime = @shiftTime,
                        experience = @experience
                        WHERE waiterID = @waiterID";

                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@waiterID", txtId.Text);
                                cmd.Parameters.AddWithValue("@shiftTime", dtpWaiterShiftTime.Value);
                                cmd.Parameters.AddWithValue("@experience", txtWaiterExperience);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Waiter updated successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating waiter: " + ex.Message);
                        }
                    }
                    else if (position == "Cashier")
                    {
                        query = @"UPDATE cashier SET 
                        experience = @experience
                        WHERE cashierID = @id";

                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@cashierID", txtId.Text);
                                cmd.Parameters.AddWithValue("@experience", txtCashierExperience);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Cashier updated successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating cashier: " + ex.Message);
                        }
                    }
                }

                this.Dispose();
            }
        }

        private void loadEmployeeDetails()
        {
            using (MySqlConnection con = DBConnection.GetConnection())
            {
                con.Open();

                // Fetch common employee data
                string query = "SELECT * FROM employee WHERE employeeID = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtId.Text = reader["employeeID"].ToString();
                            txtName.Text = reader["employeeName"].ToString();
                            txtContactNo.Text = reader["contactNo"].ToString();
                            txtAddress.Text = reader["address"].ToString();
                            cmbStore.Text = reader["storeID"].ToString();
                            txtSalary.Text = reader["salary"].ToString();
                            txtUsername.Text = reader["username"].ToString();
                            txtPassword.Text = reader["password"].ToString();

                            cmbPosition.SelectedItem = position;
                            cmbPosition.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.");
                            return;
                        }
                    }
                }

                if (position == "Manager")
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT email, role, qualifications FROM manager WHERE managerID = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtManagerEmail.Text = dr["email"].ToString();
                                cmbManagerRole.SelectedItem = dr["role"].ToString();
                                txtManagerQualification.Text = dr["qualifications"].ToString();
                            }
                        }
                    }
                }
                else if (position == "Accountant")
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT email, qualifications FROM accountant WHERE accountantID = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtAccountantEmail.Text = dr["email"].ToString();
                                txtAccountantQualification.Text = dr["qualifications"].ToString();
                            }
                        }
                    }
                }
                else if (position == "Waiter")
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT shiftTime, experience FROM waiter WHERE waiterID = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                dtpWaiterShiftTime.Value = Convert.ToDateTime(dr["shiftTime"]);
                                txtWaiterExperience.Text = dr["experience"].ToString();
                            }
                        }
                    }
                }
                else if (position == "Cashier")
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT cashRegisterID, experience FROM cashier WHERE cashierID = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtCashierExperience.Text = dr["experience"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void changeToUpdate()
        {
            Text = "Update Employee";
            btnAdd.Text = "Update";
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnUpdate_Click;
        }

        private void setNextId()
        {
            using (MySqlConnection con = DBConnection.GetConnection())
            {
                con.Open();

                string query = "SELECT MAX(employeeID) AS employeeID FROM employee";

                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    MySqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        if (dr.GetValue(0).ToString() == "")
                        {
                            txtId.Text = "1";
                        }
                        else
                        {
                            txtId.Text = (Convert.ToInt32(dr.GetValue(0)) + 1).ToString();
                        }
                    }
                    else
                    {
                        txtId.Text = "1";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeMange employeeMange = new EmployeeMange();
            this.Hide();
            employeeMange.Show();
        }

        private void AddEmployees_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; // Show password
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;  // Hide password
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
