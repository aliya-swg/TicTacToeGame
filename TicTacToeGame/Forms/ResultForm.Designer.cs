namespace TicTacToeGame.Forms
{
    partial class ResultForm
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
            label1 = new Label();
            back_btn = new TicTacToeGame.Custom_Controls.RoundedButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // turn_lbl
            // 
            turn_lbl.AutoSize = true;
            turn_lbl.Font = new Font("Borsok", 25F);
            turn_lbl.ForeColor = Color.FromArgb(121, 75, 63);
            turn_lbl.Location = new Point(369, 71);
            turn_lbl.Name = "turn_lbl";
            turn_lbl.Size = new Size(218, 44);
            turn_lbl.TabIndex = 6;
            turn_lbl.Text = "Ожидание";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Borsok", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(181, 115, 98);
            label1.Location = new Point(319, 149);
            label1.Name = "label1";
            label1.Size = new Size(129, 31);
            label1.TabIndex = 7;
            label1.Text = "Событие";
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.White;
            back_btn.BaseColor = Color.FromArgb(231, 106, 137);
            back_btn.CornerRadius = 33;
            back_btn.Font = new Font("Borsok", 16F);
            back_btn.ForeColor = Color.White;
            back_btn.HoverColor = Color.SlateBlue;
            back_btn.Location = new Point(286, 428);
            back_btn.Name = "back_btn";
            back_btn.PressedColor = Color.DarkSlateBlue;
            back_btn.Size = new Size(384, 67);
            back_btn.TabIndex = 16;
            back_btn.Text = "В главное меню";
            back_btn.Click += back_btn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(217, 217, 217);
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(319, 203);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(321, 190);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(pictureBox1);
            Controls.Add(back_btn);
            Controls.Add(label1);
            Controls.Add(turn_lbl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ResultForm";
            Text = "Результаты";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label turn_lbl;
        private Label label1;
        private Custom_Controls.RoundedButton back_btn;
        private PictureBox pictureBox1;
    }
}