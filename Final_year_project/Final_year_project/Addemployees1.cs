using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_year_project
{
    public partial class Addemployees1 : Form
    {
        public Addemployees1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Addemployees_Load(object sender, EventArgs e)
        {

        }

        private void BTNUP_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepanel homepanel = new Homepanel();
            homepanel.Show();
            this.Hide();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.pnlCashierDetails = new System.Windows.Forms.Panel();
            this.txtCashierExperience = new System.Windows.Forms.TextBox();
            this.txtCashierCashRegisterNo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlSalesAssociateDetails = new System.Windows.Forms.Panel();
            this.txtSalesAssociateExperience = new System.Windows.Forms.TextBox();
            this.cmbSalesAssociateType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlAccountantDetails = new System.Windows.Forms.Panel();
            this.txtAccountantQualification = new System.Windows.Forms.TextBox();
            this.txtAccountantEmail = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlManagerDetails = new System.Windows.Forms.Panel();
            this.txtManagerQualification = new System.Windows.Forms.TextBox();
            this.txtManagerEmail = new System.Windows.Forms.TextBox();
            this.cmbManagerRole = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.pnlCashierDetails.SuspendLayout();
            this.pnlSalesAssociateDetails.SuspendLayout();
            this.pnlAccountantDetails.SuspendLayout();
            this.pnlManagerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCashierDetails
            // 
            this.pnlCashierDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlCashierDetails.Controls.Add(this.txtCashierExperience);
            this.pnlCashierDetails.Controls.Add(this.txtCashierCashRegisterNo);
            this.pnlCashierDetails.Controls.Add(this.label18);
            this.pnlCashierDetails.Controls.Add(this.label21);
            this.pnlCashierDetails.Controls.Add(this.label23);
            this.pnlCashierDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlCashierDetails.Name = "pnlCashierDetails";
            this.pnlCashierDetails.Size = new System.Drawing.Size(526, 381);
            this.pnlCashierDetails.TabIndex = 53;
            this.pnlCashierDetails.Visible = false;
            // 
            // txtCashierExperience
            // 
            this.txtCashierExperience.Location = new System.Drawing.Point(185, 197);
            this.txtCashierExperience.Multiline = true;
            this.txtCashierExperience.Name = "txtCashierExperience";
            this.txtCashierExperience.Size = new System.Drawing.Size(304, 152);
            this.txtCashierExperience.TabIndex = 25;
            // 
            // txtCashierCashRegisterNo
            // 
            this.txtCashierCashRegisterNo.Location = new System.Drawing.Point(185, 89);
            this.txtCashierCashRegisterNo.Name = "txtCashierCashRegisterNo";
            this.txtCashierCashRegisterNo.Size = new System.Drawing.Size(299, 22);
            this.txtCashierCashRegisterNo.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 16);
            this.label18.TabIndex = 27;
            this.label18.Text = "Experience";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 16);
            this.label21.TabIndex = 26;
            this.label21.Text = "Cash Register No";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(180, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 16);
            this.label23.TabIndex = 25;
            this.label23.Text = "Cashier Details";
            // 
            // pnlSalesAssociateDetails
            // 
            this.pnlSalesAssociateDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlSalesAssociateDetails.Controls.Add(this.txtSalesAssociateExperience);
            this.pnlSalesAssociateDetails.Controls.Add(this.pnlCashierDetails);
            this.pnlSalesAssociateDetails.Controls.Add(this.cmbSalesAssociateType);
            this.pnlSalesAssociateDetails.Controls.Add(this.label16);
            this.pnlSalesAssociateDetails.Controls.Add(this.label19);
            this.pnlSalesAssociateDetails.Controls.Add(this.label20);
            this.pnlSalesAssociateDetails.Location = new System.Drawing.Point(760, 36);
            this.pnlSalesAssociateDetails.Name = "pnlSalesAssociateDetails";
            this.pnlSalesAssociateDetails.Size = new System.Drawing.Size(526, 385);
            this.pnlSalesAssociateDetails.TabIndex = 51;
            this.pnlSalesAssociateDetails.Visible = false;
            // 
            // txtSalesAssociateExperience
            // 
            this.txtSalesAssociateExperience.Location = new System.Drawing.Point(165, 182);
            this.txtSalesAssociateExperience.Multiline = true;
            this.txtSalesAssociateExperience.Name = "txtSalesAssociateExperience";
            this.txtSalesAssociateExperience.Size = new System.Drawing.Size(339, 161);
            this.txtSalesAssociateExperience.TabIndex = 25;
            // 
            // cmbSalesAssociateType
            // 
            this.cmbSalesAssociateType.FormattingEnabled = true;
            this.cmbSalesAssociateType.Items.AddRange(new object[] {
            "Senior",
            "Training",
            "Temporary"});
            this.cmbSalesAssociateType.Location = new System.Drawing.Point(165, 86);
            this.cmbSalesAssociateType.Name = "cmbSalesAssociateType";
            this.cmbSalesAssociateType.Size = new System.Drawing.Size(226, 24);
            this.cmbSalesAssociateType.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 185);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 16);
            this.label16.TabIndex = 27;
            this.label16.Text = "Experience";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(34, 86);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 16);
            this.label19.TabIndex = 25;
            this.label19.Text = "Type";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(157, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(150, 16);
            this.label20.TabIndex = 25;
            this.label20.Text = "Sales Associate Details";
            // 
            // pnlAccountantDetails
            // 
            this.pnlAccountantDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAccountantDetails.Controls.Add(this.txtAccountantQualification);
            this.pnlAccountantDetails.Controls.Add(this.txtAccountantEmail);
            this.pnlAccountantDetails.Controls.Add(this.label14);
            this.pnlAccountantDetails.Controls.Add(this.label15);
            this.pnlAccountantDetails.Controls.Add(this.label17);
            this.pnlAccountantDetails.Location = new System.Drawing.Point(760, 36);
            this.pnlAccountantDetails.Name = "pnlAccountantDetails";
            this.pnlAccountantDetails.Size = new System.Drawing.Size(526, 381);
            this.pnlAccountantDetails.TabIndex = 52;
            this.pnlAccountantDetails.Visible = false;
            // 
            // txtAccountantQualification
            // 
            this.txtAccountantQualification.Location = new System.Drawing.Point(165, 188);
            this.txtAccountantQualification.Multiline = true;
            this.txtAccountantQualification.Name = "txtAccountantQualification";
            this.txtAccountantQualification.Size = new System.Drawing.Size(339, 161);
            this.txtAccountantQualification.TabIndex = 25;
            // 
            // txtAccountantEmail
            // 
            this.txtAccountantEmail.Location = new System.Drawing.Point(165, 81);
            this.txtAccountantEmail.Name = "txtAccountantEmail";
            this.txtAccountantEmail.Size = new System.Drawing.Size(339, 22);
            this.txtAccountantEmail.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 27;
            this.label14.Text = "Qualification";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 16);
            this.label15.TabIndex = 26;
            this.label15.Text = "Email";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(180, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 16);
            this.label17.TabIndex = 25;
            this.label17.Text = "Accountant Details";
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "Manager",
            "Accountant",
            "Sales Associate",
            "Cashier"});
            this.cmbPosition.Location = new System.Drawing.Point(143, 498);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(226, 24);
            this.cmbPosition.TabIndex = 49;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 501);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 48;
            this.label9.Text = "Position";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(545, 586);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 54);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(196, 586);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(146, 54);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbStore
            // 
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Items.AddRange(new object[] {
            "Palawaththa",
            "Welisara"});
            this.cmbStore.Location = new System.Drawing.Point(143, 384);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(226, 24);
            this.cmbStore.TabIndex = 45;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(258, 324);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(74, 20);
            this.rbFemale.TabIndex = 44;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(143, 324);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(58, 20);
            this.rbMale.TabIndex = 43;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDob.Location = new System.Drawing.Point(143, 144);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(170, 22);
            this.dtpDob.TabIndex = 42;
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(143, 441);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(170, 22);
            this.txtSalary.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 444);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 40;
            this.label8.Text = "Salary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 39;
            this.label7.Text = "Store";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Gender";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(143, 266);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(226, 22);
            this.txtContactNo.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Contact No";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(143, 207);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(548, 22);
            this.txtAddress.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "DOB";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(143, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(548, 22);
            this.txtName.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Name";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(143, 36);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(144, 22);
            this.txtId.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "ID";
            // 
            // pnlManagerDetails
            // 
            this.pnlManagerDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlManagerDetails.Controls.Add(this.txtManagerQualification);
            this.pnlManagerDetails.Controls.Add(this.txtManagerEmail);
            this.pnlManagerDetails.Controls.Add(this.cmbManagerRole);
            this.pnlManagerDetails.Controls.Add(this.label13);
            this.pnlManagerDetails.Controls.Add(this.label12);
            this.pnlManagerDetails.Controls.Add(this.label11);
            this.pnlManagerDetails.Controls.Add(this.label10);
            this.pnlManagerDetails.Location = new System.Drawing.Point(760, 36);
            this.pnlManagerDetails.Name = "pnlManagerDetails";
            this.pnlManagerDetails.Size = new System.Drawing.Size(526, 495);
            this.pnlManagerDetails.TabIndex = 50;
            this.pnlManagerDetails.Visible = false;
            // 
            // txtManagerQualification
            // 
            this.txtManagerQualification.Location = new System.Drawing.Point(165, 245);
            this.txtManagerQualification.Multiline = true;
            this.txtManagerQualification.Name = "txtManagerQualification";
            this.txtManagerQualification.Size = new System.Drawing.Size(339, 161);
            this.txtManagerQualification.TabIndex = 25;
            // 
            // txtManagerEmail
            // 
            this.txtManagerEmail.Location = new System.Drawing.Point(165, 169);
            this.txtManagerEmail.Name = "txtManagerEmail";
            this.txtManagerEmail.Size = new System.Drawing.Size(339, 22);
            this.txtManagerEmail.TabIndex = 25;
            // 
            // cmbManagerRole
            // 
            this.cmbManagerRole.FormattingEnabled = true;
            this.cmbManagerRole.Items.AddRange(new object[] {
            "General Manager",
            "HR Manager",
            "Store Manager"});
            this.cmbManagerRole.Location = new System.Drawing.Point(165, 86);
            this.cmbManagerRole.Name = "cmbManagerRole";
            this.cmbManagerRole.Size = new System.Drawing.Size(226, 24);
            this.cmbManagerRole.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Qualification";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Email";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Role";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Manager Details";
            // 
            // update
            // 
            this.update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.Location = new System.Drawing.Point(376, 586);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(146, 54);
            this.update.TabIndex = 54;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = true;
            // 
            // Addemployees1
            // 
            this.ClientSize = new System.Drawing.Size(1431, 863);
            this.Controls.Add(this.update);
            this.Controls.Add(this.pnlSalesAssociateDetails);
            this.Controls.Add(this.pnlAccountantDetails);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlManagerDetails);
            this.Name = "Addemployees1";
            this.Load += new System.EventHandler(this.Addemployees_Load_2);
            this.pnlCashierDetails.ResumeLayout(false);
            this.pnlCashierDetails.PerformLayout();
            this.pnlSalesAssociateDetails.ResumeLayout(false);
            this.pnlSalesAssociateDetails.PerformLayout();
            this.pnlAccountantDetails.ResumeLayout(false);
            this.pnlAccountantDetails.PerformLayout();
            this.pnlManagerDetails.ResumeLayout(false);
            this.pnlManagerDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private void Addemployees_Load_1(object sender, EventArgs e)
        {

        }

        private Panel pnlCashierDetails;
        private TextBox txtCashierExperience;
        private TextBox txtCashierCashRegisterNo;
        private Label label18;
        private Label label21;
        private Label label23;
        private Panel pnlSalesAssociateDetails;
        private TextBox txtSalesAssociateExperience;
        private ComboBox cmbSalesAssociateType;
        private Label label16;
        private Label label19;
        private Label label20;
        private Panel pnlAccountantDetails;
        private TextBox txtAccountantQualification;
        private TextBox txtAccountantEmail;
        private Label label14;
        private Label label15;
        private Label label17;
        private ComboBox cmbPosition;
        private Label label9;
        private Button btnCancel;
        private Button btnAdd;
        private ComboBox cmbStore;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private DateTimePicker dtpDob;
        private TextBox txtSalary;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtContactNo;
        private Label label5;
        private TextBox txtAddress;
        private Label label4;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Panel pnlManagerDetails;
        private TextBox txtManagerQualification;
        private TextBox txtManagerEmail;
        private ComboBox cmbManagerRole;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Homepanel Homepanel = new Homepanel();
            Homepanel.Show();
            this.Hide();
        }

        private Button update;

        private void Addemployees_Load_2(object sender, EventArgs e)
        {

        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPosition.Text == "Manager")
            {
                pnlManagerDetails.Visible = true;
                pnlAccountantDetails.Visible = false;
                pnlSalesAssociateDetails.Visible = false;
                pnlCashierDetails.Visible = false;
            }
            else if (cmbPosition.Text == "Accountant")
            {
                pnlManagerDetails.Visible = false;
                pnlAccountantDetails.Visible = true;
                pnlSalesAssociateDetails.Visible = false;
                pnlCashierDetails.Visible = false;
            }
            else if (cmbPosition.Text == "Sales Associate")
            {
                pnlManagerDetails.Visible = false;
                pnlAccountantDetails.Visible = false;
                pnlSalesAssociateDetails.Visible = true;
                pnlCashierDetails.Visible = false;
            }
            else if (cmbPosition.Text == "Cashier")
            {
                pnlManagerDetails.Visible = false;
                pnlAccountantDetails.Visible = false;
                pnlSalesAssociateDetails.Visible = false;
                pnlCashierDetails.Visible = true;
            }
        }
    }
}
