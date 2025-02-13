namespace Primer_proyecto.Categories
{
    partial class ActualizeCategories
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            Actualizebutton = new Button();
            Cancelbutton = new Button();
            Updatebutton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "Category Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 1;
            label2.Text = "Category Description";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 82);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 126);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(198, 147);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 108);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "Picture";
            // 
            // Actualizebutton
            // 
            Actualizebutton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Actualizebutton.Location = new Point(358, 300);
            Actualizebutton.Name = "Actualizebutton";
            Actualizebutton.Size = new Size(83, 29);
            Actualizebutton.TabIndex = 6;
            Actualizebutton.Text = "Actualize";
            Actualizebutton.UseVisualStyleBackColor = true;
            Actualizebutton.Click += Actualizebutton_Click;
            // 
            // Cancelbutton
            // 
            Cancelbutton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Cancelbutton.Location = new Point(246, 300);
            Cancelbutton.Name = "Cancelbutton";
            Cancelbutton.Size = new Size(82, 29);
            Cancelbutton.TabIndex = 7;
            Cancelbutton.Text = "Cancel";
            Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // Updatebutton
            // 
            Updatebutton.Location = new Point(12, 300);
            Updatebutton.Name = "Updatebutton";
            Updatebutton.Size = new Size(78, 29);
            Updatebutton.TabIndex = 8;
            Updatebutton.Text = "Update";
            Updatebutton.UseVisualStyleBackColor = true;
            Updatebutton.Click += Updatebutton_Click_1;
            // 
            // ActualizeCategories
            // 
            AcceptButton = Actualizebutton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancelbutton;
            ClientSize = new Size(453, 347);
            Controls.Add(Updatebutton);
            Controls.Add(Cancelbutton);
            Controls.Add(Actualizebutton);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ActualizeCategories";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ActualizeCategories";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private Label label3;
        private Button Actualizebutton;
        private Button Cancelbutton;
        private Button Updatebutton;
    }
}