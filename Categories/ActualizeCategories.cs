using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_proyecto.Categories
{
    public partial class ActualizeCategories : Form
    {
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public byte[] Picture { get; private set; }

        public ActualizeCategories(string categoryName, string description, byte[] picture)
        {
            InitializeComponent();

            textBox1.Text = categoryName;
            textBox2.Text = description;
            Picture = picture;

            if (picture != null)
            {
                using (var ms = new MemoryStream(picture))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }
        private void Actualizebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || Picture == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CategoryName = textBox1.Text;
            Description = textBox2.Text;
            DialogResult = DialogResult.OK;

        }

        private void Updatebutton_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                Picture = File.ReadAllBytes(openFileDialog.FileName);
            }

        }
    }
}
