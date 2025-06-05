namespace TicTacToeGame.Forms
{
    partial class LoginForm
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
            pictureBox1 = new PictureBox();
            login_btn = new Custom_Controls.RoundedButton();
            label1 = new Label();
            login_txtb = new Custom_Controls.RoundedTextBox();
            password_txtb = new Custom_Controls.RoundedTextBox();
            noAcc_btn = new Custom_Controls.TextOnlyButton();
            eyes_pbx = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)eyes_pbx).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Картинка_логина;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(532, 542);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.Transparent;
            login_btn.BaseColor = Color.FromArgb(231, 106, 137);
            login_btn.CornerRadius = 30;
            login_btn.Font = new Font("Borsok", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_btn.ForeColor = Color.White;
            login_btn.HoverColor = Color.FromArgb(231, 106, 127);
            login_btn.Location = new Point(642, 347);
            login_btn.Name = "login_btn";
            login_btn.PressedColor = Color.DarkSlateBlue;
            login_btn.Size = new Size(262, 61);
            login_btn.TabIndex = 22;
            login_btn.Text = "Войти";
            login_btn.Click += login_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Borsok", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(121, 75, 63);
            label1.Location = new Point(611, 50);
            label1.Name = "label1";
            label1.Size = new Size(336, 55);
            label1.TabIndex = 19;
            label1.Text = "Авторизация";
            // 
            // login_txtb
            // 
            login_txtb.BackColor = Color.Transparent;
            login_txtb.BaseColor = Color.FromArgb(250, 226, 171);
            login_txtb.Font = new Font("Malgun Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_txtb.ForeColor = Color.Black;
            login_txtb.Location = new Point(596, 146);
            login_txtb.Name = "login_txtb";
            login_txtb.PlaceholderText = "Введите логин...";
            login_txtb.Size = new Size(359, 68);
            login_txtb.TabIndex = 25;
            login_txtb.UseSystemPasswordChar = false;
            // 
            // password_txtb
            // 
            password_txtb.BackColor = Color.Transparent;
            password_txtb.BaseColor = Color.FromArgb(250, 226, 171);
            password_txtb.Font = new Font("Malgun Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password_txtb.ForeColor = Color.Black;
            password_txtb.Location = new Point(596, 235);
            password_txtb.Name = "password_txtb";
            password_txtb.PlaceholderText = "Введите пароль...";
            password_txtb.Size = new Size(359, 68);
            password_txtb.TabIndex = 26;
            password_txtb.UseSystemPasswordChar = true;
            // 
            // noAcc_btn
            // 
            noAcc_btn.BackColor = Color.Transparent;
            noAcc_btn.Font = new Font("Borsok", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noAcc_btn.ForeColor = Color.FromArgb(241, 179, 132);
            noAcc_btn.HoverCursor = Cursors.Hand;
            noAcc_btn.Location = new Point(656, 426);
            noAcc_btn.Name = "noAcc_btn";
            noAcc_btn.Size = new Size(239, 40);
            noAcc_btn.TabIndex = 27;
            noAcc_btn.Text = "Нет аккаунта";
            noAcc_btn.Click += noAcc_btn_Click;
            // 
            // eyes_pbx
            // 
            eyes_pbx.BackColor = Color.Transparent;
            eyes_pbx.Image = Properties.Resources.Глаз;
            eyes_pbx.Location = new Point(887, 254);
            eyes_pbx.Name = "eyes_pbx";
            eyes_pbx.Size = new Size(38, 35);
            eyes_pbx.TabIndex = 28;
            eyes_pbx.TabStop = false;
            eyes_pbx.Click += eyes_pbx_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(eyes_pbx);
            Controls.Add(noAcc_btn);
            Controls.Add(password_txtb);
            Controls.Add(login_txtb);
            Controls.Add(pictureBox1);
            Controls.Add(login_btn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)eyes_pbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Custom_Controls.RoundedButton login_btn;
        private Label label1;
        private Custom_Controls.RoundedTextBox login_txtb;
        private Custom_Controls.RoundedTextBox password_txtb;
        private Custom_Controls.TextOnlyButton noAcc_btn;
        private PictureBox eyes_pbx;
    }
}