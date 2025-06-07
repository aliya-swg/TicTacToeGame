namespace TicTacToeGame.Forms
{
    partial class PreGameForm
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
            pictureBox2 = new PictureBox();
            acc_btn = new TicTacToeGame.Custom_Controls.TextOnlyButton();
            playNetwork_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            playSingle_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            stars_lbl = new Label();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox1.Location = new Point(140, 108);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(278, 271);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox2.Location = new Point(561, 108);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(278, 271);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // acc_btn
            // 
            acc_btn.BackColor = Color.Transparent;
            acc_btn.Font = new Font("Borsok", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            acc_btn.ForeColor = Color.FromArgb(121, 75, 63);
            acc_btn.HoverCursor = Cursors.Hand;
            acc_btn.Location = new Point(36, 21);
            acc_btn.Name = "acc_btn";
            acc_btn.Size = new Size(150, 40);
            acc_btn.TabIndex = 2;
            acc_btn.Text = "Аккаунт";
            acc_btn.Click += acc_btn_Click;
            // 
            // playNetwork_btn
            // 
            playNetwork_btn.BackColor = Color.White;
            playNetwork_btn.BaseColor = Color.FromArgb(231, 106, 137);
            playNetwork_btn.CornerRadius = 30;
            playNetwork_btn.Font = new Font("Borsok", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playNetwork_btn.ForeColor = Color.White;
            playNetwork_btn.HoverColor = Color.FromArgb(231, 106, 127);
            playNetwork_btn.Location = new Point(140, 436);
            playNetwork_btn.Name = "playNetwork_btn";
            playNetwork_btn.PressedColor = Color.DarkSlateBlue;
            playNetwork_btn.Size = new Size(278, 61);
            playNetwork_btn.TabIndex = 3;
            playNetwork_btn.Text = "Игра по сети";
            playNetwork_btn.Click += playNetwork_btn_Click;
            // 
            // playSingle_btn
            // 
            playSingle_btn.BackColor = Color.White;
            playSingle_btn.BaseColor = Color.FromArgb(231, 106, 137);
            playSingle_btn.CornerRadius = 30;
            playSingle_btn.Font = new Font("Borsok", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playSingle_btn.ForeColor = Color.White;
            playSingle_btn.HoverColor = Color.FromArgb(231, 106, 127);
            playSingle_btn.Location = new Point(561, 436);
            playSingle_btn.Name = "playSingle_btn";
            playSingle_btn.PressedColor = Color.DarkSlateBlue;
            playSingle_btn.Size = new Size(278, 61);
            playSingle_btn.TabIndex = 4;
            playSingle_btn.Text = "Игра с одного устр-ва";
            playSingle_btn.Click += play_btn_Click;
            // 
            // stars_lbl
            // 
            stars_lbl.AutoSize = true;
            stars_lbl.Font = new Font("Borsok", 20F);
            stars_lbl.ForeColor = Color.FromArgb(121, 75, 63);
            stars_lbl.Location = new Point(870, 32);
            stars_lbl.Name = "stars_lbl";
            stars_lbl.Size = new Size(31, 36);
            stars_lbl.TabIndex = 5;
            stars_lbl.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Звездочка;
            pictureBox3.Location = new Point(817, 21);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(55, 50);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // PreGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(pictureBox3);
            Controls.Add(stars_lbl);
            Controls.Add(playSingle_btn);
            Controls.Add(playNetwork_btn);
            Controls.Add(acc_btn);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PreGameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Custom_Controls.TextOnlyButton acc_btn;
        private Custom_Controls.RoundedButton playNetwork_btn;
        private Custom_Controls.RoundedButton playSingle_btn;
        private Label stars_lbl;
        private PictureBox pictureBox3;
    }
}