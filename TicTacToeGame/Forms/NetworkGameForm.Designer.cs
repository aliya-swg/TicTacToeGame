namespace TicTacToeGame.Forms
{
    partial class NetworkGameForm
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
            turn_lbl = new Label();
            secondPlayer_pbx = new PictureBox();
            firstPlayer_pbx = new PictureBox();
            cell00_pb = new PictureBox();
            cell01_pb = new PictureBox();
            cell02_pb = new PictureBox();
            cell10_pb = new PictureBox();
            cell11_pb = new PictureBox();
            cell12_pb = new PictureBox();
            cell20_pb = new PictureBox();
            cell21_pb = new PictureBox();
            cell22_pb = new PictureBox();
            playerTimer_lbl = new Custom_Controls.RoundedButton();
            opponentTimer_lbl = new Custom_Controls.RoundedButton();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)secondPlayer_pbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)firstPlayer_pbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell00_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell01_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell02_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell10_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell11_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell12_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell20_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell21_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell22_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // turn_lbl
            // 
            turn_lbl.AutoSize = true;
            turn_lbl.Font = new Font("Borsok", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            turn_lbl.ForeColor = Color.FromArgb(121, 75, 63);
            turn_lbl.Location = new Point(419, 21);
            turn_lbl.Name = "turn_lbl";
            turn_lbl.Size = new Size(156, 31);
            turn_lbl.TabIndex = 5;
            turn_lbl.Text = "Ожидание";
            // 
            // secondPlayer_pbx
            // 
            secondPlayer_pbx.Image = Properties.Resources.Человечек_для_профиля;
            secondPlayer_pbx.Location = new Point(804, 49);
            secondPlayer_pbx.Name = "secondPlayer_pbx";
            secondPlayer_pbx.Size = new Size(100, 100);
            secondPlayer_pbx.SizeMode = PictureBoxSizeMode.StretchImage;
            secondPlayer_pbx.TabIndex = 6;
            secondPlayer_pbx.TabStop = false;
            // 
            // firstPlayer_pbx
            // 
            firstPlayer_pbx.Image = Properties.Resources.Человечек_для_профиля;
            firstPlayer_pbx.Location = new Point(82, 49);
            firstPlayer_pbx.Name = "firstPlayer_pbx";
            firstPlayer_pbx.Size = new Size(100, 100);
            firstPlayer_pbx.SizeMode = PictureBoxSizeMode.StretchImage;
            firstPlayer_pbx.TabIndex = 7;
            firstPlayer_pbx.TabStop = false;
            // 
            // cell00_pb
            // 
            cell00_pb.Location = new Point(268, 91);
            cell00_pb.Name = "cell00_pb";
            cell00_pb.Size = new Size(135, 135);
            cell00_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell00_pb.TabIndex = 8;
            cell00_pb.TabStop = false;
            cell00_pb.Click += Cell_Click;
            // 
            // cell01_pb
            // 
            cell01_pb.Location = new Point(430, 91);
            cell01_pb.Name = "cell01_pb";
            cell01_pb.Size = new Size(135, 135);
            cell01_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell01_pb.TabIndex = 9;
            cell01_pb.TabStop = false;
            cell01_pb.Click += Cell_Click;
            // 
            // cell02_pb
            // 
            cell02_pb.Location = new Point(592, 91);
            cell02_pb.Name = "cell02_pb";
            cell02_pb.Size = new Size(135, 135);
            cell02_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell02_pb.TabIndex = 10;
            cell02_pb.TabStop = false;
            cell02_pb.Click += Cell_Click;
            // 
            // cell10_pb
            // 
            cell10_pb.Location = new Point(268, 253);
            cell10_pb.Name = "cell10_pb";
            cell10_pb.Size = new Size(135, 135);
            cell10_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell10_pb.TabIndex = 11;
            cell10_pb.TabStop = false;
            cell10_pb.Click += Cell_Click;
            // 
            // cell11_pb
            // 
            cell11_pb.Location = new Point(430, 253);
            cell11_pb.Name = "cell11_pb";
            cell11_pb.Size = new Size(135, 135);
            cell11_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell11_pb.TabIndex = 12;
            cell11_pb.TabStop = false;
            cell11_pb.Click += Cell_Click;
            // 
            // cell12_pb
            // 
            cell12_pb.Location = new Point(592, 253);
            cell12_pb.Name = "cell12_pb";
            cell12_pb.Size = new Size(135, 135);
            cell12_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell12_pb.TabIndex = 13;
            cell12_pb.TabStop = false;
            cell12_pb.Click += Cell_Click;
            // 
            // cell20_pb
            // 
            cell20_pb.Location = new Point(268, 415);
            cell20_pb.Name = "cell20_pb";
            cell20_pb.Size = new Size(135, 135);
            cell20_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell20_pb.TabIndex = 14;
            cell20_pb.TabStop = false;
            cell20_pb.Click += Cell_Click;
            // 
            // cell21_pb
            // 
            cell21_pb.Location = new Point(430, 415);
            cell21_pb.Name = "cell21_pb";
            cell21_pb.Size = new Size(135, 135);
            cell21_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell21_pb.TabIndex = 15;
            cell21_pb.TabStop = false;
            cell21_pb.Click += Cell_Click;
            // 
            // cell22_pb
            // 
            cell22_pb.Location = new Point(592, 415);
            cell22_pb.Name = "cell22_pb";
            cell22_pb.Size = new Size(135, 135);
            cell22_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell22_pb.TabIndex = 16;
            cell22_pb.TabStop = false;
            cell22_pb.Click += Cell_Click;
            // 
            // playerTimer_lbl
            // 
            playerTimer_lbl.BackColor = Color.Transparent;
            playerTimer_lbl.BaseColor = Color.FromArgb(231, 106, 137);
            playerTimer_lbl.CornerRadius = 30;
            playerTimer_lbl.Font = new Font("Borsok", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playerTimer_lbl.ForeColor = Color.White;
            playerTimer_lbl.HoverColor = Color.SlateBlue;
            playerTimer_lbl.Location = new Point(51, 295);
            playerTimer_lbl.Name = "playerTimer_lbl";
            playerTimer_lbl.PressedColor = Color.DarkSlateBlue;
            playerTimer_lbl.Size = new Size(168, 60);
            playerTimer_lbl.TabIndex = 17;
            playerTimer_lbl.Text = "0";
            // 
            // opponentTimer_lbl
            // 
            opponentTimer_lbl.BackColor = Color.Transparent;
            opponentTimer_lbl.BaseColor = Color.FromArgb(81, 145, 195);
            opponentTimer_lbl.CornerRadius = 30;
            opponentTimer_lbl.Font = new Font("Borsok", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            opponentTimer_lbl.ForeColor = Color.White;
            opponentTimer_lbl.HoverColor = Color.SlateBlue;
            opponentTimer_lbl.Location = new Point(773, 295);
            opponentTimer_lbl.Name = "opponentTimer_lbl";
            opponentTimer_lbl.PressedColor = Color.DarkSlateBlue;
            opponentTimer_lbl.Size = new Size(168, 60);
            opponentTimer_lbl.TabIndex = 18;
            opponentTimer_lbl.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox1.Location = new Point(571, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(15, 469);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox2.Location = new Point(409, 86);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(15, 469);
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox3.Location = new Point(263, 232);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(469, 15);
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox4.Location = new Point(263, 394);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(469, 15);
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            // 
            // NetworkGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(opponentTimer_lbl);
            Controls.Add(playerTimer_lbl);
            Controls.Add(cell22_pb);
            Controls.Add(cell21_pb);
            Controls.Add(cell20_pb);
            Controls.Add(cell12_pb);
            Controls.Add(cell11_pb);
            Controls.Add(cell10_pb);
            Controls.Add(cell02_pb);
            Controls.Add(cell01_pb);
            Controls.Add(cell00_pb);
            Controls.Add(firstPlayer_pbx);
            Controls.Add(secondPlayer_pbx);
            Controls.Add(turn_lbl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "NetworkGameForm";
            Text = "Игра";
            ((System.ComponentModel.ISupportInitialize)secondPlayer_pbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)firstPlayer_pbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell00_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell01_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell02_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell10_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell11_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell12_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell20_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell21_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell22_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label turn_lbl;
        private PictureBox secondPlayer_pbx;
        private PictureBox firstPlayer_pbx;
        private PictureBox cell00_pb;
        private PictureBox cell01_pb;
        private PictureBox cell02_pb;
        private PictureBox cell10_pb;
        private PictureBox cell11_pb;
        private PictureBox cell12_pb;
        private PictureBox cell20_pb;
        private PictureBox cell21_pb;
        private PictureBox cell22_pb;
        private Custom_Controls.RoundedButton playerTimer_lbl;
        private Custom_Controls.RoundedButton opponentTimer_lbl;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}