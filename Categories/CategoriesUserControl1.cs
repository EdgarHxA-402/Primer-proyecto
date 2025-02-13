using Microsoft.Data.SqlClient;
using Primer_proyecto.Categories;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Primer_proyecto
{
    public partial class CategoriesUserControl1 : UserControl
    {
        public CategoriesUserControl1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            Load += CategoriesUserControl1_Load;
        }

        private void CategoriesUserControl1_Load(object? sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categoryDao = new CategoryDao();
            dataGridView1.DataSource = categoryDao.GetCategories();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var addCategoryForm = new AddCategories();

            if (addCategoryForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var categoryDao = new CategoryDao();

                    bool isAdded = categoryDao.AddCategory(new Category
                    {
                        CategoryName = addCategoryForm.CategoryName,
                        Description = addCategoryForm.Description,
                        Picture = addCategoryForm.Picture
                    });

                    if (isAdded)
                    {
                        MessageBox.Show("Category created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = categoryDao.GetCategories();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var category = new Category
                {
                    CategoryID = (int)selectedRow.Cells["CategoryID"].Value,
                    CategoryName = (string)selectedRow.Cells["CategoryName"].Value,
                    Description = (string)selectedRow.Cells["Description"].Value,
                    Picture = (byte[])selectedRow.Cells["Picture"].Value
                };

                var updateForm = new ActualizeCategories(category.CategoryName, category.Description, category.Picture);

                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var categoryDao = new CategoryDao();
                        bool isUpdated = categoryDao.ActualizeCategory(new Category
                        {
                            CategoryID = category.CategoryID,
                            CategoryName = updateForm.CategoryName,
                            Description = updateForm.Description,
                            Picture = updateForm.Picture
                        });

                        if (isUpdated)
                        {
                            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = categoryDao.GetCategories();
                        }
                        else
                        {
                            MessageBox.Show("Failed to actualize category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int categoryID = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value); // Corrección aquí

                var result = MessageBox.Show("Are you sure you want to delete this Category?", "Confirm Deletion",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var categoryDao = new CategoryDao();
                    bool isDeleted = categoryDao.DeleteCategory(categoryID); // Corrección aquí

                    if (isDeleted)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = categoryDao.GetCategories();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete this category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Picture { get; set; } = Array.Empty<byte>(); // (3) Picture inicializado correctamente para evitar null
    }

    public class CategoryDao
    {

        public bool DeleteCategory(int categoryID)
        {
            using var connection = new SqlConnection(Program.GetConnectionString());
            using var command = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @CategoryID", connection);

            command.Parameters.AddWithValue("@CategoryID", categoryID);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }


        public bool ActualizeCategory(Category category)
        {
            using var connection = new SqlConnection(Program.GetConnectionString());
            using var command = new SqlCommand(@"
        UPDATE Categories 
        SET CategoryName = @CategoryName, 
            Description = @Description, 
            Picture = @Picture
        WHERE CategoryID = @CategoryID", connection);

            command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@Picture", category.Picture ?? Array.Empty<byte>());

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public IEnumerable<Category> GetCategories()
        {
            string connectionString = Program.GetConnectionString();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("SELECT CategoryID, CategoryName, Description, Picture FROM Categories", connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            var listOfCategories = new List<Category>();
            while (reader.Read())
            {
                var category = new Category
                {
                    CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                    Picture = reader.IsDBNull(reader.GetOrdinal("Picture")) ? Array.Empty<byte>() : (byte[])reader["Picture"]
                };
                listOfCategories.Add(category);
            }
            return listOfCategories;
        }

        public bool AddCategory(Category category)
        {
            using var connection = new SqlConnection(Program.GetConnectionString());
            using var command = new SqlCommand(@"
                        INSERT INTO Categories (CategoryName, Description, Picture) 
                        VALUES (@CategoryName, @Description, @Picture)", connection);

            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@Picture", category.Picture ?? Array.Empty<byte>()); // (3) Evita problemas con null

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
