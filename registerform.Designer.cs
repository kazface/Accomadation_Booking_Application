
namespace Projectforstudy
{
    partial class registerform
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
            this.label1 = new System.Windows.Forms.Label();
            this.toploginpanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passshowcheck = new System.Windows.Forms.CheckBox();
            this.exitbutton = new System.Windows.Forms.Button();
            this.loginbutton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loginbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.namelabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.emailbox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.namebox = new System.Windows.Forms.TextBox();
            this.registerbutton = new System.Windows.Forms.Button();
            this.ComboGender = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.toploginpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(255, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toploginpanel
            // 
            this.toploginpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.toploginpanel.Controls.Add(this.label1);
            this.toploginpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toploginpanel.Location = new System.Drawing.Point(0, 0);
            this.toploginpanel.Name = "toploginpanel";
            this.toploginpanel.Size = new System.Drawing.Size(818, 170);
            this.toploginpanel.TabIndex = 14;
            this.toploginpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toploginpanel_MouseDown);
            this.toploginpanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toploginpanel_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(69, 252);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(69, 184);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "username";
            // 
            // passshowcheck
            // 
            this.passshowcheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.passshowcheck.AutoSize = true;
            this.passshowcheck.FlatAppearance.BorderSize = 0;
            this.passshowcheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passshowcheck.Font = new System.Drawing.Font("Gilroy Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passshowcheck.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.passshowcheck.Image = global::Projectforstudy.Properties.Resources.ShowPassword;
            this.passshowcheck.Location = new System.Drawing.Point(347, 279);
            this.passshowcheck.Name = "passshowcheck";
            this.passshowcheck.Size = new System.Drawing.Size(28, 21);
            this.passshowcheck.TabIndex = 23;
            this.passshowcheck.UseVisualStyleBackColor = true;
            this.passshowcheck.CheckedChanged += new System.EventHandler(this.passshowcheck_CheckedChanged);
            // 
            // exitbutton
            // 
            this.exitbutton.BackColor = System.Drawing.Color.White;
            this.exitbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.exitbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.exitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbutton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.exitbutton.Location = new System.Drawing.Point(69, 428);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(306, 40);
            this.exitbutton.TabIndex = 22;
            this.exitbutton.Text = "Exit";
            this.exitbutton.UseVisualStyleBackColor = false;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // loginbutton
            // 
            this.loginbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.loginbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginbutton.FlatAppearance.BorderSize = 0;
            this.loginbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.loginbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbutton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loginbutton.ForeColor = System.Drawing.Color.White;
            this.loginbutton.Location = new System.Drawing.Point(429, 428);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(306, 40);
            this.loginbutton.TabIndex = 21;
            this.loginbutton.Text = "Sign up";
            this.loginbutton.UseVisualStyleBackColor = false;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projectforstudy.Properties.Resources.padlock;
            this.pictureBox2.Location = new System.Drawing.Point(74, 280);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(69, 306);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 1);
            this.panel3.TabIndex = 19;
            // 
            // passwordbox
            // 
            this.passwordbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordbox.Font = new System.Drawing.Font("Gilroy Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordbox.Location = new System.Drawing.Point(104, 273);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.PasswordChar = '●';
            this.passwordbox.Size = new System.Drawing.Size(271, 27);
            this.passwordbox.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projectforstudy.Properties.Resources.user__1_;
            this.pictureBox1.Location = new System.Drawing.Point(74, 212);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(69, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 1);
            this.panel2.TabIndex = 16;
            // 
            // loginbox
            // 
            this.loginbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginbox.Font = new System.Drawing.Font("Gilroy UltraLight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginbox.Location = new System.Drawing.Point(104, 205);
            this.loginbox.Name = "loginbox";
            this.loginbox.Size = new System.Drawing.Size(271, 27);
            this.loginbox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(429, 252);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "email";
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = true;
            this.namelabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.namelabel.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.namelabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.namelabel.Location = new System.Drawing.Point(429, 184);
            this.namelabel.Name = "namelabel";
            this.namelabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.namelabel.Size = new System.Drawing.Size(68, 18);
            this.namelabel.TabIndex = 33;
            this.namelabel.Text = "full name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(429, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 1);
            this.panel1.TabIndex = 31;
            // 
            // emailbox
            // 
            this.emailbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailbox.Font = new System.Drawing.Font("Gilroy Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailbox.Location = new System.Drawing.Point(429, 273);
            this.emailbox.Name = "emailbox";
            this.emailbox.Size = new System.Drawing.Size(306, 27);
            this.emailbox.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(429, 238);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(306, 1);
            this.panel4.TabIndex = 28;
            // 
            // namebox
            // 
            this.namebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.namebox.Font = new System.Drawing.Font("Gilroy UltraLight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.namebox.Location = new System.Drawing.Point(429, 205);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(306, 27);
            this.namebox.TabIndex = 27;
            // 
            // registerbutton
            // 
            this.registerbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerbutton.FlatAppearance.BorderSize = 0;
            this.registerbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerbutton.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.registerbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.registerbutton.Location = new System.Drawing.Point(580, 323);
            this.registerbutton.Name = "registerbutton";
            this.registerbutton.Size = new System.Drawing.Size(155, 22);
            this.registerbutton.TabIndex = 35;
            this.registerbutton.Text = "already have account";
            this.registerbutton.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.registerbutton.UseVisualStyleBackColor = true;
            this.registerbutton.Click += new System.EventHandler(this.registerbutton_Click);
            // 
            // ComboGender
            // 
            this.ComboGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboGender.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ComboGender.FormattingEnabled = true;
            this.ComboGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.ComboGender.Location = new System.Drawing.Point(74, 335);
            this.ComboGender.Name = "ComboGender";
            this.ComboGender.Size = new System.Drawing.Size(301, 36);
            this.ComboGender.TabIndex = 36;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(69, 371);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(306, 1);
            this.panel5.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(74, 318);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 38;
            this.label5.Text = "gender";
            // 
            // registerform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 530);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.ComboGender);
            this.Controls.Add(this.registerbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.namelabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.emailbox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.toploginpanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passshowcheck);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.loginbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "registerform";
            this.Load += new System.EventHandler(this.registerform_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.registerform_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.registerform_MouseMove);
            this.toploginpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel toploginpanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox passshowcheck;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox loginbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label namelabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Button registerbutton;
        private System.Windows.Forms.ComboBox ComboGender;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
    }
}