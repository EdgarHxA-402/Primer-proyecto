namespace Primer_proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadUserControls();
        }

        private void LoadUserControls()
        {
            var productsUserControl = new ProductsUserControl1();
            productsUserControl.Dock = DockStyle.Fill;
            tabPage1.Controls.Clear(); // Clear any existing controls
            tabPage1.Controls.Add(productsUserControl);

            var categoriesUserControl = new CategoriesUserControl1();
            categoriesUserControl.Dock = DockStyle.Fill;
            tabPage2.Controls.Clear(); // Clear any existing controls
            tabPage2.Controls.Add(categoriesUserControl);

            var suppliersUserControl = new SuppliersUserControl1();
            suppliersUserControl.Dock = DockStyle.Fill;
            tabPage3.Controls.Clear(); // Clear any existing controls
            tabPage3.Controls.Add(suppliersUserControl);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
