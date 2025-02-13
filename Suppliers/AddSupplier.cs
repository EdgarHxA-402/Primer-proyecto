using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_proyecto.Suppliers
{
    public partial class AddSupplier : Form
    {
        public string CompanyName { get; private set; }
        public string ContactName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string HomePage { get; private set; }


        public AddSupplier()
        {
            InitializeComponent();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyName = textBox1.Text;
            ContactName = textBox2.Text;
            Phone = textBox3.Text;
            Email = textBox4.Text;
            HomePage = textBox5.Text;
            DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
