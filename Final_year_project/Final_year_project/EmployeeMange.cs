using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public partial class EmployeeMange : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=final_project;";

        public EmployeeMange()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void EmployeeMange_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT employeeID, employeeName, storeID, salary, contactNo, address, username, password FROM employee";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["employeeID"],
                        row["employeeName"],
                        row["storeID"],
                        row["salary"],
                        row["contactNo"],
                        row["address"],
                        row["username"],
                        row["password"],
                        "Update",
                        "Delete"
                    );
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get employee ID from grid
            int employeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

            // Handle Update
            if (dataGridView1.Columns[e.ColumnIndex].Name == "update")
            {
                AddEmployees addForm = new AddEmployees(employeeID); // pass ID as int
                addForm.Show();
                this.Hide();
            }

            // Handle Delete
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM employee WHERE employeeID = @employeeID";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Employee deleted successfully.");
                    LoadEmployeeData(); // refresh
                }
            }
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployees addForm = new AddEmployees(); // open empty form for new add
            addForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Homepanel homepanel = new Homepanel();
            homepanel.Show();
            this.Hide();
        }
    }
}
