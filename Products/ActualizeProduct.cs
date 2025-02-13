using System;
using System.Data;
using System.Windows.Forms;

namespace Primer_proyecto
{
    public partial class ActualizeProduct : Form
    {
        private readonly ProductDao productDao = new ProductDao();
        public int ProductID { get; private set; }

        public ActualizeProduct(int productID, string productName, decimal unitPrice, int categoryID, int supplierID)
        {
            InitializeComponent();
            ProductID = productID;

            LoadCategories();
            LoadSuppliers();

            textBox1.Text = productName;
            textBox2.Text = unitPrice.ToString();
            comboBox1.SelectedValue = categoryID;
            comboBox2.SelectedValue = supplierID;
        }

        private void LoadCategories()
        {
            DataTable categories = productDao.GetCategories();
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "CategoryName"; 
            comboBox1.ValueMember = "CategoryID"; 
        }

        private void LoadSuppliers()
        {
            DataTable suppliers = productDao.GetSuppliers();
            comboBox2.DataSource = suppliers;
            comboBox2.DisplayMember = "CompanyName";
            comboBox2.ValueMember = "SupplierID";
        }


        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
    string.IsNullOrWhiteSpace(textBox2.Text) ||
    comboBox2.SelectedValue == null ||
    comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox2.Text, out decimal unitPrice))
            {
                MessageBox.Show("Invalid price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var product = new Product
            {
                ProductID = ProductID,
                ProductName = textBox1.Text,
                UnitPrice = unitPrice,
                CategoryID = Convert.ToInt32(comboBox1.SelectedValue),
                SupplierID = Convert.ToInt32(comboBox2.SelectedValue)
            };

            bool isUpdated = productDao.UpdateProduct(product);

            if (isUpdated)
            {
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
