namespace TicTacToeGame.Forms
{
    partial class ProfileForm
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
            userPicture_pbx = new TicTacToeGame.Custom_Controls.RoundedPictureBox();
            name_lbl = new Label();
            stars_lbl = new Label();
            starCount_lbl = new Label();
            back_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            userPicture_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            userLogin_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            userPassword_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            exitAcc_btn = new TicTacToeGame.Custom_Controls.TextOnlyButton();
            ((System.ComponentModel.ISupportInitialize)userPicture_pbx).BeginInit();
            SuspendLayout();
            // 
            // userPicture_pbx
            // 
            userPicture_pbx.BackColor = Color.Transparent;
            userPicture_pbx.CornerRadius = 10;
            userPicture_pbx.Image = Properties.Resources.Человечек_для_профиля;
            userPicture_pbx.Location = new Point(55, 64);
            userPicture_pbx.Name = "userPicture_pbx";
            userPicture_pbx.Size = new Size(280, 280);
            userPicture_pbx.SizeMode = PictureBoxSizeMode.StretchImage;
            userPicture_pbx.TabIndex = 0;
            userPicture_pbx.TabStop = false;
            // 
            // name_lbl
            // 
            name_lbl.AutoSize = true;
            name_lbl.Font = new Font("Borsok", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_lbl.ForeColor = Color.FromArgb(121, 75, 63);
            name_lbl.Location = new Point(380, 72);
            name_lbl.Name = "name_lbl";
            name_lbl.Size = new Size(378, 45);
            name_lbl.TabIndex = 22;
            name_lbl.Text = "Имя пользователя";
            // 
            // stars_lbl
            // 
            stars_lbl.AutoSize = true;
            stars_lbl.Font = new Font("Malgun Gothic", 20.25F, FontStyle.Bold);
            stars_lbl.ForeColor = Color.FromArgb(181, 115, 98);
            stars_lbl.Location = new Point(380, 127);
            stars_lbl.Name = "stars_lbl";
            stars_lbl.Size = new Size(326, 37);
            stars_lbl.TabIndex = 23;
            stars_lbl.Text = "Количество звёздочек:";
            // 
            // starCount_lbl
            // 
            starCount_lbl.AutoSize = true;
            starCount_lbl.Font = new Font("Malgun Gothic", 20.25F, FontStyle.Bold);
            starCount_lbl.ForeColor = Color.FromArgb(181, 115, 98);
            starCount_lbl.Location = new Point(695, 127);
            starCount_lbl.Name = "starCount_lbl";
            starCount_lbl.Size = new Size(33, 37);
            starCount_lbl.TabIndex = 24;
            starCount_lbl.Text = "0";
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.Transparent;
            back_btn.BackgroundImage = Properties.Resources.Стрелка2;
            back_btn.BackgroundImageLayout = ImageLayout.Zoom;
            back_btn.BaseColor = Color.Transparent;
            back_btn.CornerRadius = 40;
            back_btn.Font = new Font("Segoe UI", 12F);
            back_btn.ForeColor = Color.White;
            back_btn.HoverColor = Color.SlateBlue;
            back_btn.Location = new Point(832, 84);
            back_btn.Name = "back_btn";
            back_btn.PressedColor = Color.DarkSlateBlue;
            back_btn.Size = new Size(80, 80);
            back_btn.TabIndex = 25;
            back_btn.Click += back_btn_Click;
            // 
            // userPicture_btn
            // 
            userPicture_btn.BackColor = Color.White;
            userPicture_btn.BaseColor = Color.FromArgb(231, 106, 137);
            userPicture_btn.CornerRadius = 31;
            userPicture_btn.Font = new Font("Borsok", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userPicture_btn.ForeColor = Color.White;
            userPicture_btn.HoverColor = Color.FromArgb(165, 67, 88);
            userPicture_btn.Location = new Point(55, 404);
            userPicture_btn.Name = "userPicture_btn";
            userPicture_btn.PressedColor = Color.DarkSlateBlue;
            userPicture_btn.Size = new Size(280, 63);
            userPicture_btn.TabIndex = 26;
            userPicture_btn.Text = "Сменить аватарку";
            // 
            // userLogin_btn
            // 
            userLogin_btn.BackColor = Color.White;
            userLogin_btn.BaseColor = Color.FromArgb(181, 115, 98);
            userLogin_btn.CornerRadius = 31;
            userLogin_btn.Font = new Font("Borsok", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userLogin_btn.ForeColor = Color.White;
            userLogin_btn.HoverColor = Color.FromArgb(136, 99, 89);
            userLogin_btn.Location = new Point(360, 404);
            userLogin_btn.Name = "userLogin_btn";
            userLogin_btn.PressedColor = Color.DarkSlateBlue;
            userLogin_btn.Size = new Size(280, 63);
            userLogin_btn.TabIndex = 27;
            userLogin_btn.Text = "Сменить логин";
            userLogin_btn.Click += userLogin_btn_Click;
            // 
            // userPassword_btn
            // 
            userPassword_btn.BackColor = Color.White;
            userPassword_btn.BaseColor = Color.FromArgb(146, 149, 208);
            userPassword_btn.CornerRadius = 31;
            userPassword_btn.Font = new Font("Borsok", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userPassword_btn.ForeColor = Color.White;
            userPassword_btn.HoverColor = Color.SlateBlue;
            userPassword_btn.Location = new Point(663, 404);
            userPassword_btn.Name = "userPassword_btn";
            userPassword_btn.PressedColor = Color.DarkSlateBlue;
            userPassword_btn.Size = new Size(280, 63);
            userPassword_btn.TabIndex = 28;
            userPassword_btn.Text = "Сменить пароль";
            userPassword_btn.Click += userPassword_btn_Click;
            // 
            // exitAcc_btn
            // 
            exitAcc_btn.BackColor = Color.Transparent;
            exitAcc_btn.Font = new Font("Borsok", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitAcc_btn.ForeColor = Color.FromArgb(231, 106, 137);
            exitAcc_btn.HoverCursor = Cursors.Hand;
            exitAcc_btn.Location = new Point(339, 507);
            exitAcc_btn.Name = "exitAcc_btn";
            exitAcc_btn.Size = new Size(318, 40);
            exitAcc_btn.TabIndex = 29;
            exitAcc_btn.Text = "Выйти из аккаунта";
            exitAcc_btn.Click += exitAcc_btn_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(exitAcc_btn);
            Controls.Add(userPassword_btn);
            Controls.Add(userLogin_btn);
            Controls.Add(userPicture_btn);
            Controls.Add(back_btn);
            Controls.Add(starCount_lbl);
            Controls.Add(stars_lbl);
            Controls.Add(name_lbl);
            Controls.Add(userPicture_pbx);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Профиль";
            ((System.ComponentModel.ISupportInitialize)userPicture_pbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Custom_Controls.RoundedPictureBox userPicture_pbx;
        private Label name_lbl;
        private Label stars_lbl;
        private Label starCount_lbl;
        private Custom_Controls.RoundedButton back_btn;
        private Custom_Controls.RoundedButton userPicture_btn;
        private Custom_Controls.RoundedButton userLogin_btn;
        private Custom_Controls.RoundedButton userPassword_btn;
        private Custom_Controls.TextOnlyButton exitAcc_btn;
    }
}