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
        DateTime selectedDate;

        public Calculate_payroll()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            selectedDate = DateTime.Now;
            LoadEmployeeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel2 homepanel = new Homepanel2();
            homepanel.Show();
            this.Hide();
        }

        private void LoadEmployeeData()
        {
            dataGridView1.Rows.Clear();

            using (MySqlConnection conn = DBConnection.GetConnection())
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

            string monthStart = new DateTime(selectedDate.Year, selectedDate.Month, 1).ToString("yyyy-MM-dd");
            string monthEnd = new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month)).ToString("yyyy-MM-dd");

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        e.employeeID, 
                        e.employeeName, 
                        e.salary,
                        IFNULL(p.bonus, 0) AS bonus, 
                        IFNULL(p.deductions, 0) AS deductions, 
                        p.payDate,
                        (e.salary + IFNULL(p.bonus, 0) - IFNULL(p.deductions, 0)) AS totalPay
                    FROM employee e
                    LEFT JOIN payroll p 
                        ON e.employeeID = p.employeeID 
                        AND p.payDate BETWEEN @start AND @end";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@start", monthStart);
                    cmd.Parameters.AddWithValue("@end", monthEnd);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int employeeID = Convert.ToInt32(reader["employeeID"]);
                            string name = reader["employeeName"].ToString();
                            double salary = Convert.ToDouble(reader["salary"]);
                            double bonus = Convert.ToDouble(reader["bonus"]);
                            double deductions = Convert.ToDouble(reader["deductions"]);

                            string payDateStr;
                            string totalPayStr;

                            if (reader["payDate"] != DBNull.Value)
                            {
                                DateTime payDate = Convert.ToDateTime(reader["payDate"]);
                                payDateStr = payDate.ToShortDateString();
                                double totalPay = Convert.ToDouble(reader["totalPay"]);
                                totalPayStr = totalPay.ToString("0.#");
                            }
                            else
                            {
                                payDateStr = DateTime.Today.ToShortDateString(); // Default today if no payroll
                                totalPayStr = ""; // Leave Total Pay blank
                            }

                            dataGridView1.Rows.Add(
                                employeeID,
                                name,
                                salary.ToString("0.#"),
                                bonus.ToString("0.#"),
                                deductions.ToString("0.#"),
                                payDateStr,
                                "Calculate",
                                totalPayStr
                            );
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["action"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                try
                {
                    int employeeID = int.Parse(row.Cells["employeeID"].Value.ToString());
                    double salary = double.Parse(row.Cells["salary"].Value.ToString());

                    double.TryParse(row.Cells["bonus"].Value?.ToString(), out double bonus);
                    double.TryParse(row.Cells["deductions"].Value?.ToString(), out double deductions);
                    DateTime.TryParse(row.Cells["payDate"].Value?.ToString(), out DateTime payDate);

                    if (payDate == DateTime.MinValue)
                        payDate = DateTime.Today;

                    SavePayroll(employeeID, salary, bonus, deductions, payDate);

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
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                string checkQuery = @"SELECT COUNT(*) FROM payroll 
                          WHERE employeeID = @empID 
                          AND MONTH(payDate) = @month 
                          AND YEAR(payDate) = @year";

                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@empID", employeeID);
                    checkCmd.Parameters.AddWithValue("@month", payDate.Month);
                    checkCmd.Parameters.AddWithValue("@year", payDate.Year);

                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Payroll for this employee in this month already exists.");
                        return;
                    }
                }

                string insertQuery = @"
                    INSERT INTO payroll (employeeID, basicSalary, bonus, deductions, payDate)
                    VALUES (@empID, @salary, @bonus, @deductions, @payDate)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
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

        private void Calculate_payroll_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;
            selectedDate = DateTime.Now;
            dateTimePicker1.Value = selectedDate;
            LoadPayrollData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = dateTimePicker1.Value;
            LoadPayrollData();
        }
    }
}
