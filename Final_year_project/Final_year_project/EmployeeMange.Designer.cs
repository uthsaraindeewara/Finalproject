namespace Final_year_project
{
    partial class EmployeeMange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddEmployee = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.EmpName,
            this.StoreID,
            this.Salary,
            this.ContactNo,
            this.Address,
            this.username,
            this.password,
            this.update,
            this.Delete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1308, 382);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AddEmployee
            // 
            this.AddEmployee.BackColor = System.Drawing.Color.Red;
            this.AddEmployee.Location = new System.Drawing.Point(12, 61);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(137, 39);
            this.AddEmployee.TabIndex = 1;
            this.AddEmployee.Text = "Add Employees";
            this.AddEmployee.UseVisualStyleBackColor = false;
            this.AddEmployee.Click += new System.EventHandler(this.AddEmployee_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // EmpName
            // 
            this.EmpName.HeaderText = "Name";
            this.EmpName.MinimumWidth = 6;
            this.EmpName.Name = "EmpName";
            this.EmpName.Width = 125;
            // 
            // StoreID
            // 
            this.StoreID.HeaderText = "StoreID";
            this.StoreID.MinimumWidth = 6;
            this.StoreID.Name = "StoreID";
            this.StoreID.Width = 125;
            // 
            // Salary
            // 
            this.Salary.HeaderText = "Salary";
            this.Salary.MinimumWidth = 6;
            this.Salary.Name = "Salary";
            this.Salary.Width = 125;
            // 
            // ContactNo
            // 
            this.ContactNo.HeaderText = "ContactNo";
            this.ContactNo.MinimumWidth = 6;
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.Width = 125;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.Width = 125;
            // 
            // username
            // 
            this.username.HeaderText = "username";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.Width = 125;
            // 
            // password
            // 
            this.password.HeaderText = "password";
            this.password.MinimumWidth = 6;
            this.password.Name = "password";
            this.password.Width = 125;
            // 
            // update
            // 
            this.update.HeaderText = "update";
            this.update.MinimumWidth = 6;
            this.update.Name = "update";
            this.update.Text = "Update";
            this.update.Width = 125;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.Width = 125;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.IndianRed;
            this.button2.Location = new System.Drawing.Point(20, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Log out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EmployeeMange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 601);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddEmployee);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EmployeeMange";
            this.Text = "EmployeeMange";
            this.Load += new System.EventHandler(this.EmployeeMange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewButtonColumn update;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button button2;
    }
}
