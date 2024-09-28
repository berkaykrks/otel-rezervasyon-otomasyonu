namespace Otel_Rezervasyon_Sistemi
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            pictureBox2 = new PictureBox();
            linkLabel2 = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            verifycode_textbox = new TextBox();
            send_button = new Button();
            label2 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            verify_button = new Button();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            email_textbox = new TextBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(17, 192);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(138, 282);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(142, 15);
            linkLabel2.TabIndex = 8;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Already have an account?";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.Location = new Point(84, 15);
            label4.Name = "label4";
            label4.Size = new Size(250, 32);
            label4.TabIndex = 6;
            label4.Text = "Reset Your Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(48, 173);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 5;
            label3.Text = "Verify Code";
            // 
            // verifycode_textbox
            // 
            verifycode_textbox.BackColor = SystemColors.Window;
            verifycode_textbox.Location = new Point(48, 196);
            verifycode_textbox.Name = "verifycode_textbox";
            verifycode_textbox.Size = new Size(327, 23);
            verifycode_textbox.TabIndex = 4;
            // 
            // send_button
            // 
            send_button.FlatStyle = FlatStyle.Flat;
            send_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            send_button.ForeColor = Color.White;
            send_button.Location = new Point(122, 115);
            send_button.Name = "send_button";
            send_button.Size = new Size(158, 40);
            send_button.TabIndex = 1;
            send_button.Text = "Send";
            send_button.UseVisualStyleBackColor = true;
            send_button.Click += send_button_Click;
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
            button1.Location = new Point(945, 0);
            button1.Name = "button1";
            button1.Size = new Size(28, 37);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.RoyalBlue;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(verify_button);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(email_textbox);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(linkLabel2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(verifycode_textbox);
            panel2.Controls.Add(send_button);
            panel2.Location = new Point(520, 127);
            panel2.Name = "panel2";
            panel2.Size = new Size(422, 329);
            panel2.TabIndex = 10;
            // 
            // verify_button
            // 
            verify_button.FlatStyle = FlatStyle.Flat;
            verify_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            verify_button.ForeColor = Color.White;
            verify_button.Location = new Point(122, 225);
            verify_button.Name = "verify_button";
            verify_button.Size = new Size(158, 40);
            verify_button.TabIndex = 15;
            verify_button.Text = "Verify";
            verify_button.UseVisualStyleBackColor = true;
            verify_button.Click += verify_button_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(155, 306);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(103, 15);
            linkLabel1.TabIndex = 14;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Create an account";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(26, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(57, 63);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 12;
            label1.Text = "E-Mail";
            // 
            // email_textbox
            // 
            email_textbox.BackColor = SystemColors.Window;
            email_textbox.Location = new Point(57, 86);
            email_textbox.Name = "email_textbox";
            email_textbox.Size = new Size(327, 23);
            email_textbox.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(973, 37);
            panel1.TabIndex = 8;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 29);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(973, 530);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(973, 557);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox8;
        private Label label9;
        private TextBox surname_textbox;
        private PictureBox pictureBox7;
        private Label label8;
        private TextBox name_textbox;
        private PictureBox pictureBox6;
        private Label label7;
        private TextBox confirmPassword_textbox;
        private ComboBox comboBox1;
        private PictureBox pictureBox5;
        private Label label6;
        private TextBox password_textbox;
        private PictureBox pictureBox4;
        private Label label5;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel2;
        private Label label4;
        private Label label3;
        private TextBox verifycode_textbox;
        private Button send_button;
        private TextBox username_textbox;
        private Label label2;
        private Button button1;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox email_textbox;
        private LinkLabel linkLabel1;
        private Button verify_button;
    }
}