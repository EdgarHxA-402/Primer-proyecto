using System;
using System.Windows.Forms;

namespace Primer_proyecto
{
    public partial class AddProduct : Form
    {
        public Product Product { get; set; }

        public AddProduct(Product product = null)
        {
            InitializeComponent();
            Load += AddProduct_Load;

            Product = product ?? new Product();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            var productDao = new ProductDao();

            comboBox1.DataSource = productDao.GetCategories();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";

            comboBox2.DataSource = productDao.GetSuppliers();
            comboBox2.DisplayMember = "CompanyName";
            comboBox2.ValueMember = "SupplierID";

            if (Product.ProductID > 0)
            {
                textBox1.Text = Product.ProductName;
                textBox2.Text = Product.UnitPrice.ToString();
                comboBox1.SelectedValue = Product.CategoryID;
                comboBox2.SelectedValue = Product.SupplierID;
            }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                comboBox1.SelectedValue == null ||
                comboBox2.SelectedValue == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox2.Text, out decimal price))
            {
                MessageBox.Show("Invalid price format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product.ProductName = textBox1.Text;
            Product.UnitPrice = price;
            Product.CategoryID = (int)comboBox1.SelectedValue;
            Product.SupplierID = (int)comboBox2.SelectedValue;

            DialogResult = DialogResult.OK;
        }
    }
}
