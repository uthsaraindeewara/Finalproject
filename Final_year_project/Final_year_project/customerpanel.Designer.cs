namespace Final_year_project
{
    partial class customerpanel
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnDrink = new System.Windows.Forms.Button();
            this.btnDesert = new System.Windows.Forms.Button();
            this.flowOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnPaceOrder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(946, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 46);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1624, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 24);
            this.label6.TabIndex = 36;
            this.label6.Text = "Current Order ";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(517, 79);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(423, 30);
            this.txtSearch.TabIndex = 33;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Final_year_project.Properties.Resources.th__9_2;
            this.pictureBox7.Location = new System.Drawing.Point(6, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(97, 89);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 31;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remarko Express";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(98, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1768, 41);
            this.panel2.TabIndex = 30;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.Location = new System.Drawing.Point(235, 138);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(1215, 810);
            this.flowProducts.TabIndex = 65;
            this.flowProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.flowProducts_Paint);
            // 
            // panel20
            // 
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.pictureBox22);
            this.panel20.Controls.Add(this.pictureBox23);
            this.panel20.Controls.Add(this.pictureBox24);
            this.panel20.Controls.Add(this.pictureBox25);
            this.panel20.Controls.Add(this.btnAll);
            this.panel20.Controls.Add(this.btnFood);
            this.panel20.Controls.Add(this.btnDrink);
            this.panel20.Controls.Add(this.btnDesert);
            this.panel20.Location = new System.Drawing.Point(23, 138);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(195, 310);
            this.panel20.TabIndex = 64;
            // 
            // pictureBox22
            // 
            this.pictureBox22.Image = global::Final_year_project.Properties.Resources.icons8_cherry_cheesecake_50;
            this.pictureBox22.Location = new System.Drawing.Point(11, 237);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(58, 53);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox22.TabIndex = 7;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBox23
            // 
            this.pictureBox23.Image = global::Final_year_project.Properties.Resources.icons8_champagne_50;
            this.pictureBox23.Location = new System.Drawing.Point(11, 164);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(58, 49);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox23.TabIndex = 6;
            this.pictureBox23.TabStop = false;
            // 
            // pictureBox24
            // 
            this.pictureBox24.Image = global::Final_year_project.Properties.Resources.icons8_hamburger_50;
            this.pictureBox24.Location = new System.Drawing.Point(11, 91);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(58, 47);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox24.TabIndex = 5;
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox25
            // 
            this.pictureBox25.Image = global::Final_year_project.Properties.Resources.icons8_street_food_50;
            this.pictureBox25.Location = new System.Drawing.Point(11, 15);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(58, 50);
            this.pictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox25.TabIndex = 4;
            this.pictureBox25.TabStop = false;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.White;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAll.Location = new System.Drawing.Point(3, 6);
            this.btnAll.Name = "btnAll";
            this.btnAll.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnAll.Size = new System.Drawing.Size(187, 68);
            this.btnAll.TabIndex = 8;
            this.btnAll.Text = "All Items";
            this.btnAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnFood
            // 
            this.btnFood.BackColor = System.Drawing.Color.White;
            this.btnFood.FlatAppearance.BorderSize = 0;
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFood.Location = new System.Drawing.Point(3, 80);
            this.btnFood.Name = "btnFood";
            this.btnFood.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnFood.Size = new System.Drawing.Size(187, 68);
            this.btnFood.TabIndex = 9;
            this.btnFood.Text = "Food";
            this.btnFood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFood.UseVisualStyleBackColor = false;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnDrink
            // 
            this.btnDrink.BackColor = System.Drawing.Color.White;
            this.btnDrink.FlatAppearance.BorderSize = 0;
            this.btnDrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDrink.Location = new System.Drawing.Point(3, 155);
            this.btnDrink.Name = "btnDrink";
            this.btnDrink.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnDrink.Size = new System.Drawing.Size(187, 68);
            this.btnDrink.TabIndex = 10;
            this.btnDrink.Text = "Drinks";
            this.btnDrink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrink.UseVisualStyleBackColor = false;
            this.btnDrink.Click += new System.EventHandler(this.btnDrink_Click);
            // 
            // btnDesert
            // 
            this.btnDesert.BackColor = System.Drawing.Color.White;
            this.btnDesert.FlatAppearance.BorderSize = 0;
            this.btnDesert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDesert.Location = new System.Drawing.Point(3, 229);
            this.btnDesert.Name = "btnDesert";
            this.btnDesert.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnDesert.Size = new System.Drawing.Size(187, 68);
            this.btnDesert.TabIndex = 11;
            this.btnDesert.Text = "Deserts";
            this.btnDesert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesert.UseVisualStyleBackColor = false;
            this.btnDesert.Click += new System.EventHandler(this.btnDesert_Click);
            // 
            // flowOrder
            // 
            this.flowOrder.AutoScroll = true;
            this.flowOrder.Location = new System.Drawing.Point(1476, 138);
            this.flowOrder.Name = "flowOrder";
            this.flowOrder.Size = new System.Drawing.Size(390, 609);
            this.flowOrder.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1471, 759);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 29);
            this.label2.TabIndex = 67;
            this.label2.Text = "Items: ";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(1839, 759);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(27, 29);
            this.lblItems.TabIndex = 68;
            this.lblItems.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1471, 808);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 69;
            this.label3.Text = "Total: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1839, 808);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(27, 29);
            this.lblTotal.TabIndex = 70;
            this.lblTotal.Text = "0";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(1567, 849);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(299, 30);
            this.txtName.TabIndex = 71;
            // 
            // btnPaceOrder
            // 
            this.btnPaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPaceOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaceOrder.Location = new System.Drawing.Point(1700, 900);
            this.btnPaceOrder.Name = "btnPaceOrder";
            this.btnPaceOrder.Size = new System.Drawing.Size(166, 48);
            this.btnPaceOrder.TabIndex = 72;
            this.btnPaceOrder.Text = "Place Order";
            this.btnPaceOrder.UseVisualStyleBackColor = false;
            this.btnPaceOrder.Click += new System.EventHandler(this.btnPaceOrder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1471, 850);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 29);
            this.label4.TabIndex = 73;
            this.label4.Text = "Name: ";
            // 
            // customerpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPaceOrder);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowOrder);
            this.Controls.Add(this.flowProducts);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.panel2);
            this.Name = "customerpanel";
            this.Text = "customerpanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.customerpanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox23;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.PictureBox pictureBox25;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnDrink;
        private System.Windows.Forms.Button btnDesert;
        private System.Windows.Forms.FlowLayoutPanel flowOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnPaceOrder;
        private System.Windows.Forms.Label label4;
    }
}