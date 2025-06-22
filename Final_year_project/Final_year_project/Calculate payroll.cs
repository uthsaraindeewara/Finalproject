using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class Calculate_payroll : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";
        private bool isAfterCalculation = false;

        public Calculate_payroll()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupInitialGrid();
            LoadEmployeeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();
            homepanel.Show();
            this.Hide();
        }

        private void SetupInitialGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("employeeID", "Employee ID");
            dataGridView1.Columns["employeeID"].ReadOnly = true;

            dataGridView1.Columns.Add("employeeName", "Employee Name");
            dataGridView1.Columns["employeeName"].ReadOnly = true;

            dataGridView1.Columns.Add("salary", "Basic Salary");
            dataGridView1.Columns["salary"].ReadOnly = true;

            dataGridView1.Columns.Add("bonus", "Bonus");
            dataGridView1.Columns.Add("deductions", "Deductions");
            dataGridView1.Columns.Add("payDate", "Pay Date");

            DataGridViewButtonColumn calcButton = new DataGridViewButtonColumn();
            calcButton.Name = "calculateButton";
            calcButton.HeaderText = "Calculate";
            calcButton.Text = "Calculate";
            calcButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(calcButton);
        }

        private void SetupCalculatedGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("payrollID", "Payroll ID");
            dataGridView1.Columns["payrollID"].ReadOnly = true;

            dataGridView1.Columns.Add("employeeName", "Employee Name");
            dataGridView1.Columns["employeeName"].ReadOnly = true;

            dataGridView1.Columns.Add("salary", "Basic Salary");
            dataGridView1.Columns["salary"].ReadOnly = true;

            dataGridView1.Columns.Add("deductions", "Deductions");
            dataGridView1.Columns["deductions"].ReadOnly = true;

            dataGridView1.Columns.Add("bonus", "Bonus");
            dataGridView1.Columns["bonus"].ReadOnly = true;

            dataGridView1.Columns.Add("payDate", "Pay Date");
            dataGridView1.Columns["payDate"].ReadOnly = true;

            dataGridView1.Columns.Add("finalAmount", "Final Payroll Amount");
            dataGridView1.Columns["finalAmount"].ReadOnly = true;
        }

        private void LoadEmployeeData()
        {
            dataGridView1.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT employeeID, employeeName, salary 
                    FROM employee 
                    WHERE employeeID NOT IN (SELECT employeeID FROM payroll)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["employeeID"].ToString(),
                            reader["employeeName"].ToString(),
                            reader["salary"].ToString(),
                            "", // bonus
                            "", // deductions
                            DateTime.Now.ToShortDateString(), // pay date
                            "Calculate"
                        );
                    }
                }
            }
        }

        private void LoadPayrollData()
        {
            dataGridView1.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.payrollID,
                        e.employeeName,
                        p.basicSalary,
                        p.deductions,
                        p.bonus,
                        p.payDate,
                        (p.basicSalary + p.bonus - p.deductions) AS finalAmount
                    FROM payroll p
                    INNER JOIN employee e ON e.employeeID = p.employeeID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["payrollID"].ToString(),
                            reader["employeeName"].ToString(),
                            Convert.ToDouble(reader["basicSalary"]).ToString("F2"),
                            Convert.ToDouble(reader["deductions"]).ToString("F2"),
                            Convert.ToDouble(reader["bonus"]).ToString("F2"),
                            Convert.ToDateTime(reader["payDate"]).ToShortDateString(),
                            Convert.ToDouble(reader["finalAmount"]).ToString("F2")
                        );
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isAfterCalculation &&
                e.ColumnIndex == dataGridView1.Columns["calculateButton"].Index &&
                e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                try
                {
                    int employeeID = int.Parse(row.Cells["employeeID"].Value.ToString());
                    double salary = double.Parse(row.Cells["salary"].Value.ToString());

                    double bonus = 0;
                    double deductions = 0;
                    DateTime payDate = DateTime.Now;

                    double.TryParse(row.Cells["bonus"].Value?.ToString(), out bonus);
                    double.TryParse(row.Cells["deductions"].Value?.ToString(), out deductions);
                    DateTime.TryParse(row.Cells["payDate"].Value?.ToString(), out payDate);

                    SavePayroll(employeeID, salary, bonus, deductions, payDate);

                    // Switch to result view
                    isAfterCalculation = true;
                    SetupCalculatedGrid();
                    LoadPayrollData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void SavePayroll(int employeeID, double salary, double bonus, double deductions, DateTime payDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM payroll WHERE employeeID = @empID";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@empID", employeeID);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    string query;
                    if (count > 0)
                    {
                        query = @"UPDATE payroll 
                                  SET basicSalary = @salary, bonus = @bonus, deductions = @deductions, payDate = @payDate 
                                  WHERE employeeID = @empID";
                    }
                    else
                    {
                        query = @"INSERT INTO payroll (employeeID, basicSalary, bonus, deductions, payDate) 
                                  VALUES (@empID, @salary, @bonus, @deductions, @payDate)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empID", employeeID);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        cmd.Parameters.AddWithValue("@bonus", bonus);
                        cmd.Parameters.AddWithValue("@deductions", deductions);
                        cmd.Parameters.AddWithValue("@payDate", payDate);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
