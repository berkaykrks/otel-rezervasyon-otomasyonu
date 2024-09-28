namespace Otel_Rezervasyon_Sistemi
{
    partial class Form14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            panel2 = new Panel();
            button12 = new Button();
            label2 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            hotelName_1 = new Label();
            button3 = new Button();
            fiyat_1 = new Label();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.RoyalBlue;
            panel2.Controls.Add(button12);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(878, 37);
            panel2.TabIndex = 7;
            panel2.MouseDown += panel1_MouseDown;
            // 
            // button12
            // 
            button12.BackgroundImage = (Image)resources.GetObject("button12.BackgroundImage");
            button12.BackgroundImageLayout = ImageLayout.Zoom;
            button12.Dock = DockStyle.Right;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Location = new Point(822, 0);
            button12.Name = "button12";
            button12.Size = new Size(28, 37);
            button12.TabIndex = 5;
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 4;
            label2.Text = "Karakuşlar Hotel";
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(850, 0);
            button1.Name = "button1";
            button1.Size = new Size(28, 37);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(878, 349);
            panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(hotelName_1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(fiyat_1);
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(854, 340);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rezervasyon";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            numericUpDown1.Location = new Point(702, 146);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(105, 33);
            numericUpDown1.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(686, 95);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 30;
            label5.Text = "ID'sini giriniz";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(651, 45);
            label4.Name = "label4";
            label4.Size = new Size(196, 25);
            label4.TabIndex = 29;
            label4.Text = "İptal Etmek İstediğiniz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(658, 70);
            label3.Name = "label3";
            label3.Size = new Size(180, 25);
            label3.TabIndex = 28;
            label3.Text = "Rezervasyonunuzun";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(628, 249);
            dataGridView1.TabIndex = 27;
            // 
            // hotelName_1
            // 
            hotelName_1.AutoSize = true;
            hotelName_1.BackColor = SystemColors.Control;
            hotelName_1.Font = new Font("Cambria", 30.25F, FontStyle.Bold);
            hotelName_1.ForeColor = Color.DeepSkyBlue;
            hotelName_1.Location = new Point(56, 46);
            hotelName_1.Name = "hotelName_1";
            hotelName_1.Size = new Size(0, 48);
            hotelName_1.TabIndex = 24;
            hotelName_1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderSize = 5;
            button3.Font = new Font("Cambria", 14.22F);
            button3.Location = new Point(676, 207);
            button3.Name = "button3";
            button3.Size = new Size(162, 53);
            button3.TabIndex = 11;
            button3.Text = "Rezervasyonu \r\nSil";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // fiyat_1
            // 
            fiyat_1.AutoSize = true;
            fiyat_1.BackColor = SystemColors.Control;
            fiyat_1.Font = new Font("Cambria", 31.75F);
            fiyat_1.Location = new Point(220, 115);
            fiyat_1.Name = "fiyat_1";
            fiyat_1.Size = new Size(0, 51);
            fiyat_1.TabIndex = 26;
            fiyat_1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 20.25F, FontStyle.Bold);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 0;
            // 
            // Form14
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 386);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form14";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form14";
            Load += Form14_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button button12;
        private Label label2;
        private Button button1;
        private Panel panel1;
        private Label label1;
        private Button button3;
        private Label hotelName_1;
        private GroupBox groupBox1;
        private Label fiyat_1;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label4;
        private Label label3;
        private NumericUpDown numericUpDown1;
    }
}