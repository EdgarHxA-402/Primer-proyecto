using Microsoft.Data.SqlClient;
using Primer_proyecto.Suppliers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Primer_proyecto
{
    public partial class SuppliersUserControl1 : UserControl
    {
        public SuppliersUserControl1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            Load += SuppliersUserControl1_Load;
        }

        private void SuppliersUserControl1_Load(object? sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            var suppliersDao = new SuppliersDao();
            dataGridView1.DataSource = suppliersDao.GetSuppliers();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            var addSupplier = new AddSupplier();

            if (addSupplier.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var suppliersDao = new SuppliersDao();
                    bool isAdded = suppliersDao.AddSupplier(new Supplier
                    {
                        CompanyName = addSupplier.CompanyName,
                        ContactName = addSupplier.ContactName,
                        Phone = addSupplier.Phone,
                        Email = addSupplier.Email,
                        HomePage = addSupplier.HomePage
                    });
                    if (isAdded)
                    {
                        MessageBox.Show("Supplier created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSuppliers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create Supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while creating the Supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Actualizebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var supplier = new Supplier
                {
                    SupplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value),
                    CompanyName = selectedRow.Cells["CompanyName"].Value.ToString(),
                    ContactName = selectedRow.Cells["ContactName"].Value.ToString(),
                    Phone = selectedRow.Cells["Phone"].Value.ToString(),
                    Email = selectedRow.Cells["Email"].Value.ToString(),
                    HomePage = selectedRow.Cells["HomePage"].Value.ToString()
                };

                var actualizeSupplier = new ActualizeSupplier(supplier.CompanyName, supplier.ContactName, supplier.Phone, supplier.Email, supplier.HomePage);

                if (actualizeSupplier.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var suppliersDao = new SuppliersDao();
                        bool isUpdated = suppliersDao.ActualizeSupplier(new Supplier
                        {
                            SupplierID = supplier.SupplierID,
                            CompanyName = actualizeSupplier.CompanyName,
                            ContactName = actualizeSupplier.ContactName,
                            Phone = actualizeSupplier.Phone,
                            Email = actualizeSupplier.Email,
                            HomePage = actualizeSupplier.HomePage
                        });
                        if (isUpdated)
                        {
                            MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSuppliers();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update Supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating the Supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a Supplier to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int supplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this Supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var suppliersDao = new SuppliersDao();
                        bool isDeleted = suppliersDao.DeleteSupplier(supplierID);
                        if (isDeleted)
                        {
                            MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSuppliers();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete Supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the Supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public class Supplier
        {
            public int SupplierID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string HomePage { get; set; }
        }

        public class SuppliersDao
        {
            public bool DeleteSupplier(int supplierID)
            {
                using var connection = new SqlConnection(Program.GetConnectionString());
                using var command = new SqlCommand("DELETE FROM Suppliers WHERE SupplierID = @SupplierID", connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }

            public bool ActualizeSupplier(Supplier supplier)
            {
                using var connection = new SqlConnection(Program.GetConnectionString());
                using var command = new SqlCommand("UPDATE Suppliers " +
                    "SET CompanyName = @CompanyName, ContactName = @ContactName, Phone = @Phone, Email = @Email, HomePage = @HomePage " +
                    "WHERE SupplierID = @SupplierID", connection);

                command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                command.Parameters.AddWithValue("@Phone", supplier.Phone);
                command.Parameters.AddWithValue("@Email", supplier.Email);
                command.Parameters.AddWithValue("@HomePage", supplier.HomePage);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }

            public bool AddSupplier(Supplier supplier)
            {
                string connectionString = Program.GetConnectionString();
                using var connection = new SqlConnection(connectionString);
                using var command = new SqlCommand("INSERT INTO Suppliers (CompanyName, ContactName, Phone, Email, HomePage) VALUES (@CompanyName, @ContactName, @Phone, @Email, @HomePage)", connection);
                command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                command.Parameters.AddWithValue("@Phone", supplier.Phone);
                command.Parameters.AddWithValue("@Email", supplier.Email);
                command.Parameters.AddWithValue("@HomePage", supplier.HomePage);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }

            public IEnumerable<Supplier> GetSuppliers()
            {
                string connectionString = Program.GetConnectionString();

                using var connection = new SqlConnection(connectionString);
                using var command = new SqlCommand("SELECT SupplierID, CompanyName, ContactName, Phone, Email, HomePage FROM Suppliers", connection);

                connection.Open();
                using var reader = command.ExecuteReader();

                var listOfSuppliers = new List<Supplier>();
                while (reader.Read())
                {
                    var supplier = new Supplier
                    {
                        SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                        CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                        ContactName = reader.IsDBNull(reader.GetOrdinal("ContactName")) ? "" : reader.GetString(reader.GetOrdinal("ContactName")),
                        Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? "" : reader.GetString(reader.GetOrdinal("Phone")),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                        HomePage = reader.IsDBNull(reader.GetOrdinal("HomePage")) ? "" : reader.GetString(reader.GetOrdinal("HomePage"))
                    };

                    listOfSuppliers.Add(supplier);
                }
                return listOfSuppliers;
            }
        }
    }
}
