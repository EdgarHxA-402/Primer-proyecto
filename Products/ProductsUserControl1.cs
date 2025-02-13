using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Primer_proyecto
{
    public partial class ProductsUserControl1 : UserControl
    {
        public ProductsUserControl1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            Load += ProductsUserControl1_Load;
        }

        private void ProductsUserControl1_Load(object? sender, EventArgs e)
        {
            var productDao = new ProductDao();
            dataGridView1.DataSource = productDao
                .GetProducts();
            var categories = productDao.GetCategories();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProduct();

            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var productDao = new ProductDao();
                    bool isAdded = productDao.AddProduct(addProductForm.Product);

                    if (isAdded)
                    {
                        MessageBox.Show("Product created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = productDao.GetProducts();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                var productID = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                var productName = selectedRow.Cells["ProductName"].Value.ToString();
                var unitPrice = Convert.ToDecimal(selectedRow.Cells["UnitPrice"].Value);
                var categoryID = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);
                var supplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);

                var updateForm = new ActualizeProduct(productID, productName, unitPrice, categoryID, supplierID);

                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                   
                    var productDao = new ProductDao();
                    dataGridView1.DataSource = productDao.GetProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int productID = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var productDao = new ProductDao();
                    bool isDeleted = productDao.DeleteProduct(productID);

                    if (isDeleted)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = productDao.GetProducts();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }



    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }

    public class ProductDao
    {
        public IEnumerable<Product> GetProducts()
        {
            string connectionString = Program.GetConnectionString();

            var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("SELECT ProductID, ProductName, UnitPrice, CategoryID, SupplierID FROM Products", connection);

            connection.Open();
            var reader = command.ExecuteReader();

            var listOfProducts = new List<Product>();
            while (reader.Read())
            {
                var product = new Product
                {
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    UnitPrice = reader.IsDBNull(reader.GetOrdinal("UnitPrice")) ? 0 : Convert.ToDecimal(reader["UnitPrice"]),
                    CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                    SupplierID = reader.IsDBNull(reader.GetOrdinal("SupplierID")) ? 0 : reader.GetInt32(reader.GetOrdinal("SupplierID"))
                };

                listOfProducts.Add(product);
            }
            return listOfProducts;

        }

        public bool DeleteProduct(int productID)
        {
            using var connection = new SqlConnection(Program.GetConnectionString());
            using var command = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", connection);

            command.Parameters.AddWithValue("@ProductID", productID);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }


        public bool UpdateProduct(Product product)
        {
            using var connection = new SqlConnection(Program.GetConnectionString());
            using var command = new SqlCommand(@"
        UPDATE Products 
        SET ProductName = @ProductName, 
            UnitPrice = @UnitPrice, 
            CategoryID = @CategoryID, 
            SupplierID = @SupplierID
        WHERE ProductID = @ProductID", connection);

            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
            command.Parameters.AddWithValue("@ProductID", product.ProductID);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }


        private string connectionString = Program.GetConnectionString();

        public DataTable GetCategories()
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories", connection);
            var adapter = new SqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetSuppliers()
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("SELECT SupplierID, CompanyName FROM Suppliers", connection);
            var adapter = new SqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        public bool AddProduct(Product product)
        {
            string connectionString = Program.GetConnectionString();
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(@"INSERT INTO Products (ProductName, UnitPrice, CategoryID, SupplierID) 
                                         VALUES (@ProductName, @UnitPrice, @CategoryID, @SupplierID)", connection);

            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            command.Parameters.AddWithValue("@SupplierID", product.SupplierID);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }


    }
}

