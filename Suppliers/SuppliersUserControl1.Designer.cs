namespace Primer_proyecto
{
    partial class SuppliersUserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            SupplierID = new DataGridViewTextBoxColumn();
            CompanyName = new DataGridViewTextBoxColumn();
            ContactName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            HomePage = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            Deletebutton = new Button();
            Actualizebutton = new Button();
            Addbutton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SupplierID, CompanyName, ContactName, Phone, Email, HomePage });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 85);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(774, 381);
            dataGridView1.TabIndex = 0;
            // 
            // SupplierID
            // 
            SupplierID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            SupplierID.DataPropertyName = "SupplierID";
            SupplierID.HeaderText = "ID";
            SupplierID.Name = "SupplierID";
            SupplierID.ReadOnly = true;
            SupplierID.Width = 43;
            // 
            // CompanyName
            // 
            CompanyName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CompanyName.DataPropertyName = "CompanyName";
            CompanyName.HeaderText = "Company";
            CompanyName.Name = "CompanyName";
            CompanyName.ReadOnly = true;
            CompanyName.Width = 84;
            // 
            // ContactName
            // 
            ContactName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ContactName.DataPropertyName = "ContactName";
            ContactName.HeaderText = "Contact";
            ContactName.Name = "ContactName";
            ContactName.ReadOnly = true;
            ContactName.Width = 74;
            // 
            // Phone
            // 
            Phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Phone.DataPropertyName = "Phone";
            Phone.HeaderText = "Phone";
            Phone.Name = "Phone";
            Phone.ReadOnly = true;
            Phone.Width = 66;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 61;
            // 
            // HomePage
            // 
            HomePage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HomePage.DataPropertyName = "HomePage";
            HomePage.HeaderText = "Web Page";
            HomePage.Name = "HomePage";
            HomePage.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(Deletebutton);
            panel1.Controls.Add(Actualizebutton);
            panel1.Controls.Add(Addbutton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 85);
            panel1.TabIndex = 1;
            // 
            // Deletebutton
            // 
            Deletebutton.Location = new Point(455, 47);
            Deletebutton.Name = "Deletebutton";
            Deletebutton.Size = new Size(75, 23);
            Deletebutton.TabIndex = 2;
            Deletebutton.Text = "Delete";
            Deletebutton.UseVisualStyleBackColor = true;
            Deletebutton.Click += Deletebutton_Click;
            // 
            // Actualizebutton
            // 
            Actualizebutton.Location = new Point(536, 47);
            Actualizebutton.Name = "Actualizebutton";
            Actualizebutton.Size = new Size(75, 23);
            Actualizebutton.TabIndex = 1;
            Actualizebutton.Text = "Actualize";
            Actualizebutton.UseVisualStyleBackColor = true;
            Actualizebutton.Click += Actualizebutton_Click;
            // 
            // Addbutton
            // 
            Addbutton.Location = new Point(617, 47);
            Addbutton.Name = "Addbutton";
            Addbutton.Size = new Size(75, 23);
            Addbutton.TabIndex = 0;
            Addbutton.Text = "Add";
            Addbutton.UseVisualStyleBackColor = true;
            Addbutton.Click += Addbutton_Click;
            // 
            // SuppliersUserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "SuppliersUserControl1";
            Size = new Size(774, 466);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private DataGridViewTextBoxColumn SupplierID;
        private DataGridViewTextBoxColumn CompanyName;
        private DataGridViewTextBoxColumn ContactName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn HomePage;
        private Button Deletebutton;
        private Button Actualizebutton;
        private Button Addbutton;
    }
}
