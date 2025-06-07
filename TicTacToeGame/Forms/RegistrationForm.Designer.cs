namespace TicTacToeGame.Forms
{
    partial class RegistrationForm
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
            registration_lbl = new Label();
            register_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            email_txtb = new TicTacToeGame.Custom_Controls.RoundedTextBox();
            name_txtb = new TicTacToeGame.Custom_Controls.RoundedTextBox();
            secPassword_txtb = new TicTacToeGame.Custom_Controls.RoundedTextBox();
            password_txtb = new TicTacToeGame.Custom_Controls.RoundedTextBox();
            login_btn = new TicTacToeGame.Custom_Controls.TextOnlyButton();
            eyes_pbx = new PictureBox();
            eyes2_pbx = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)eyes_pbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)eyes2_pbx).BeginInit();
            SuspendLayout();
            // 
            // registration_lbl
            // 
            registration_lbl.AutoSize = true;
            registration_lbl.Font = new Font("Borsok", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            registration_lbl.ForeColor = Color.FromArgb(121, 75, 63);
            registration_lbl.Location = new Point(360, 65);
            registration_lbl.Name = "registration_lbl";
            registration_lbl.Size = new Size(268, 45);
            registration_lbl.TabIndex = 21;
            registration_lbl.Text = "Регистрация";
            // 
            // register_btn
            // 
            register_btn.BackColor = Color.White;
            register_btn.BaseColor = Color.FromArgb(231, 106, 137);
            register_btn.CornerRadius = 33;
            register_btn.Font = new Font("Borsok", 16F);
            register_btn.ForeColor = Color.White;
            register_btn.HoverColor = Color.FromArgb(231, 106, 127);
            register_btn.Location = new Point(302, 400);
            register_btn.Name = "register_btn";
            register_btn.PressedColor = Color.DarkSlateBlue;
            register_btn.Size = new Size(384, 67);
            register_btn.TabIndex = 15;
            register_btn.Text = "Зарегистрироваться";
            register_btn.Click += register_btn_Click;
            // 
            // email_txtb
            // 
            email_txtb.BackColor = Color.White;
            email_txtb.BaseColor = Color.FromArgb(250, 226, 171);
            email_txtb.Font = new Font("Malgun Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            email_txtb.ForeColor = Color.Black;
            email_txtb.Location = new Point(88, 165);
            email_txtb.Name = "email_txtb";
            email_txtb.PlaceholderText = "Введите почту...";
            email_txtb.Size = new Size(347, 68);
            email_txtb.TabIndex = 22;
            email_txtb.UseSystemPasswordChar = false;
            // 
            // name_txtb
            // 
            name_txtb.BackColor = Color.White;
            name_txtb.BaseColor = Color.FromArgb(250, 226, 171);
            name_txtb.Font = new Font("Malgun Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_txtb.ForeColor = Color.Black;
            name_txtb.Location = new Point(549, 165);
            name_txtb.Name = "name_txtb";
            name_txtb.PlaceholderText = "Введите логин...";
            name_txtb.Size = new Size(347, 68);
            name_txtb.TabIndex = 23;
            name_txtb.UseSystemPasswordChar = false;
            // 
            // secPassword_txtb
            // 
            secPassword_txtb.BackColor = Color.White;
            secPassword_txtb.BaseColor = Color.FromArgb(250, 226, 171);
            secPassword_txtb.Font = new Font("Malgun Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            secPassword_txtb.ForeColor = Color.Black;
            secPassword_txtb.Location = new Point(549, 280);
            secPassword_txtb.Name = "secPassword_txtb";
            secPassword_txtb.PlaceholderText = "Повторите пароль...";
            secPassword_txtb.Size = new Size(347, 68);
            secPassword_txtb.TabIndex = 24;
            secPassword_txtb.UseSystemPasswordChar = false;
            // 
            // password_txtb
            // 
            password_txtb.BackColor = Color.White;
            password_txtb.BaseColor = Color.FromArgb(250, 226, 171);
            password_txtb.Font = new Font("Malgun Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password_txtb.ForeColor = Color.Black;
            password_txtb.Location = new Point(88, 280);
            password_txtb.Name = "password_txtb";
            password_txtb.PlaceholderText = "Введите пароль...";
            password_txtb.Size = new Size(347, 68);
            password_txtb.TabIndex = 25;
            password_txtb.UseSystemPasswordChar = false;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.Transparent;
            login_btn.Font = new Font("Borsok", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_btn.ForeColor = Color.FromArgb(241, 179, 132);
            login_btn.HoverCursor = Cursors.Hand;
            login_btn.Location = new Point(408, 490);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(172, 40);
            login_btn.TabIndex = 26;
            login_btn.Text = "Авторизация";
            login_btn.Click += login_btn_Click;
            // 
            // eyes_pbx
            // 
            eyes_pbx.BackColor = Color.Transparent;
            eyes_pbx.Image = Properties.Resources.Глаз;
            eyes_pbx.Location = new Point(369, 300);
            eyes_pbx.Name = "eyes_pbx";
            eyes_pbx.Size = new Size(38, 35);
            eyes_pbx.TabIndex = 29;
            eyes_pbx.TabStop = false;
            eyes_pbx.WaitOnLoad = true;
            eyes_pbx.Click += eyes_pbx_Click;
            // 
            // eyes2_pbx
            // 
            eyes2_pbx.BackColor = Color.Transparent;
            eyes2_pbx.Image = Properties.Resources.Глаз;
            eyes2_pbx.Location = new Point(832, 300);
            eyes2_pbx.Name = "eyes2_pbx";
            eyes2_pbx.Size = new Size(38, 35);
            eyes2_pbx.TabIndex = 30;
            eyes2_pbx.TabStop = false;
            eyes2_pbx.WaitOnLoad = true;
            eyes2_pbx.Click += eyes2_pbx_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(eyes2_pbx);
            Controls.Add(eyes_pbx);
            Controls.Add(login_btn);
            Controls.Add(password_txtb);
            Controls.Add(secPassword_txtb);
            Controls.Add(name_txtb);
            Controls.Add(email_txtb);
            Controls.Add(registration_lbl);
            Controls.Add(register_btn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)eyes_pbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)eyes2_pbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label registration_lbl;
        private Custom_Controls.RoundedButton register_btn;
        private Custom_Controls.RoundedTextBox email_txtb;
        private Custom_Controls.RoundedTextBox name_txtb;
        private Custom_Controls.RoundedTextBox secPassword_txtb;
        private Custom_Controls.RoundedTextBox password_txtb;
        private Custom_Controls.TextOnlyButton login_btn;
        private PictureBox eyes_pbx;
        private PictureBox eyes2_pbx;
    }
}