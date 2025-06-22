namespace Final_year_project
{
    partial class genaratereports
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
            this.btnExpenseReport = new System.Windows.Forms.Button();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.btnProfit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExpenseReport
            // 
            this.btnExpenseReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnExpenseReport.FlatAppearance.BorderSize = 0;
            this.btnExpenseReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExpenseReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnExpenseReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenseReport.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseReport.ForeColor = System.Drawing.Color.White;
            this.btnExpenseReport.Location = new System.Drawing.Point(3, 160);
            this.btnExpenseReport.Name = "btnExpenseReport";
            this.btnExpenseReport.Size = new System.Drawing.Size(203, 83);
            this.btnExpenseReport.TabIndex = 28;
            this.btnExpenseReport.Text = "Expense Report";
            this.btnExpenseReport.UseVisualStyleBackColor = false;
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnSalesReport.FlatAppearance.BorderSize = 0;
            this.btnSalesReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSalesReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesReport.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReport.ForeColor = System.Drawing.Color.White;
            this.btnSalesReport.Location = new System.Drawing.Point(3, 84);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(203, 83);
            this.btnSalesReport.TabIndex = 26;
            this.btnSalesReport.Text = "Sales Report";
            this.btnSalesReport.UseVisualStyleBackColor = false;
            // 
            // btnProfit
            // 
            this.btnProfit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnProfit.FlatAppearance.BorderSize = 0;
            this.btnProfit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnProfit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnProfit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfit.ForeColor = System.Drawing.Color.White;
            this.btnProfit.Location = new System.Drawing.Point(3, 240);
            this.btnProfit.Name = "btnProfit";
            this.btnProfit.Size = new System.Drawing.Size(203, 83);
            this.btnProfit.TabIndex = 29;
            this.btnProfit.Text = "Profit Report";
            this.btnProfit.UseVisualStyleBackColor = false;
            this.btnProfit.Click += new System.EventHandler(this.btnProfit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 27);
            this.label1.TabIndex = 30;
            this.label1.Text = "Financial Reports";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 57;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // genaratereports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProfit);
            this.Controls.Add(this.btnExpenseReport);
            this.Controls.Add(this.btnSalesReport);
            this.Name = "genaratereports";
            this.Load += new System.EventHandler(this.genaratereports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExpenseReport;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button btnProfit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}