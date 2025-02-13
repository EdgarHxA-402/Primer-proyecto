namespace Primer_proyecto.Suppliers
{
    partial class ActualizeSupplier
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
            Cancelbutton = new Button();
            Addbutton = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // Cancelbutton
            // 
            Cancelbutton.Location = new Point(215, 294);
            Cancelbutton.Name = "Cancelbutton";
            Cancelbutton.Size = new Size(85, 35);
            Cancelbutton.TabIndex = 23;
            Cancelbutton.Text = "Cancel";
            Cancelbutton.UseVisualStyleBackColor = true;
            Cancelbutton.Click += Cancelbutton_Click;
            // 
            // Addbutton
            // 
            Addbutton.Location = new Point(321, 294);
            Addbutton.Name = "Addbutton";
            Addbutton.Size = new Size(85, 35);
            Addbutton.TabIndex = 22;
            Addbutton.Text = "Actualize";
            Addbutton.UseVisualStyleBackColor = true;
            Addbutton.Click += Actualizebutton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 199);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 21;
            label5.Text = "Web Page";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 155);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 20;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 111);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 19;
            label3.Text = "Phone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 67);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 18;
            label2.Text = "Contact";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 23);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 17;
            label1.Text = "Company";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(11, 217);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(288, 23);
            textBox5.TabIndex = 16;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(11, 173);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(288, 23);
            textBox4.TabIndex = 15;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(11, 129);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(288, 23);
            textBox3.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(288, 23);
            textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 23);
            textBox1.TabIndex = 12;
            // 
            // ActualizeSupplier
            // 
            AcceptButton = Addbutton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancelbutton;
            ClientSize = new Size(417, 353);
            Controls.Add(Cancelbutton);
            Controls.Add(Addbutton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ActualizeSupplier";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ActualizeSupplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cancelbutton;
        private Button Addbutton;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}