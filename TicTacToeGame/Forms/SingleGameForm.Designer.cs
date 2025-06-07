namespace TicTacToeGame.Forms
{
    partial class SingleGameForm
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
            cell1_pb = new PictureBox();
            cell2_pb = new PictureBox();
            cell3_pb = new PictureBox();
            cell4_pb = new PictureBox();
            cell5_pb = new PictureBox();
            cell6_pb = new PictureBox();
            cell7_pb = new PictureBox();
            cell8_pb = new PictureBox();
            cell9_pb = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            name1_lbl = new Label();
            name2_lbl = new Label();
            ((System.ComponentModel.ISupportInitialize)secondPlayer_pbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)firstPlayer_pbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell1_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell2_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell3_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell4_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell5_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell6_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell7_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell8_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cell9_pb).BeginInit();
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
            secondPlayer_pbx.Location = new Point(804, 49);
            secondPlayer_pbx.Name = "secondPlayer_pbx";
            secondPlayer_pbx.Size = new Size(100, 100);
            secondPlayer_pbx.TabIndex = 6;
            secondPlayer_pbx.TabStop = false;
            // 
            // firstPlayer_pbx
            // 
            firstPlayer_pbx.Location = new Point(82, 49);
            firstPlayer_pbx.Name = "firstPlayer_pbx";
            firstPlayer_pbx.Size = new Size(100, 100);
            firstPlayer_pbx.TabIndex = 7;
            firstPlayer_pbx.TabStop = false;
            // 
            // cell1_pb
            // 
            cell1_pb.Location = new Point(268, 91);
            cell1_pb.Name = "cell1_pb";
            cell1_pb.Size = new Size(135, 135);
            cell1_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell1_pb.TabIndex = 8;
            cell1_pb.TabStop = false;
            cell1_pb.Click += Cell_Click;
            // 
            // cell2_pb
            // 
            cell2_pb.Location = new Point(430, 91);
            cell2_pb.Name = "cell2_pb";
            cell2_pb.Size = new Size(135, 135);
            cell2_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell2_pb.TabIndex = 9;
            cell2_pb.TabStop = false;
            cell2_pb.Click += Cell_Click;
            // 
            // cell3_pb
            // 
            cell3_pb.Location = new Point(592, 91);
            cell3_pb.Name = "cell3_pb";
            cell3_pb.Size = new Size(135, 135);
            cell3_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell3_pb.TabIndex = 10;
            cell3_pb.TabStop = false;
            cell3_pb.Click += Cell_Click;
            // 
            // cell4_pb
            // 
            cell4_pb.Location = new Point(268, 253);
            cell4_pb.Name = "cell4_pb";
            cell4_pb.Size = new Size(135, 135);
            cell4_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell4_pb.TabIndex = 11;
            cell4_pb.TabStop = false;
            cell4_pb.Click += Cell_Click;
            // 
            // cell5_pb
            // 
            cell5_pb.Location = new Point(430, 253);
            cell5_pb.Name = "cell5_pb";
            cell5_pb.Size = new Size(135, 135);
            cell5_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell5_pb.TabIndex = 12;
            cell5_pb.TabStop = false;
            cell5_pb.Click += Cell_Click;
            // 
            // cell6_pb
            // 
            cell6_pb.Location = new Point(592, 253);
            cell6_pb.Name = "cell6_pb";
            cell6_pb.Size = new Size(135, 135);
            cell6_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell6_pb.TabIndex = 13;
            cell6_pb.TabStop = false;
            cell6_pb.Click += Cell_Click;
            // 
            // cell7_pb
            // 
            cell7_pb.Location = new Point(268, 415);
            cell7_pb.Name = "cell7_pb";
            cell7_pb.Size = new Size(135, 135);
            cell7_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell7_pb.TabIndex = 14;
            cell7_pb.TabStop = false;
            cell7_pb.Click += Cell_Click;
            // 
            // cell8_pb
            // 
            cell8_pb.Location = new Point(430, 415);
            cell8_pb.Name = "cell8_pb";
            cell8_pb.Size = new Size(135, 135);
            cell8_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell8_pb.TabIndex = 15;
            cell8_pb.TabStop = false;
            cell8_pb.Click += Cell_Click;
            // 
            // cell9_pb
            // 
            cell9_pb.Location = new Point(592, 415);
            cell9_pb.Name = "cell9_pb";
            cell9_pb.Size = new Size(135, 135);
            cell9_pb.SizeMode = PictureBoxSizeMode.Zoom;
            cell9_pb.TabIndex = 16;
            cell9_pb.TabStop = false;
            cell9_pb.Click += Cell_Click;
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
            // name1_lbl
            // 
            name1_lbl.AutoSize = true;
            name1_lbl.Font = new Font("Borsok", 18F);
            name1_lbl.ForeColor = Color.FromArgb(231, 106, 137);
            name1_lbl.Location = new Point(82, 232);
            name1_lbl.Name = "name1_lbl";
            name1_lbl.Size = new Size(111, 31);
            name1_lbl.TabIndex = 28;
            name1_lbl.Text = "1 игрок";
            // 
            // name2_lbl
            // 
            name2_lbl.AutoSize = true;
            name2_lbl.Font = new Font("Borsok", 18F);
            name2_lbl.ForeColor = Color.FromArgb(81, 145, 195);
            name2_lbl.Location = new Point(811, 225);
            name2_lbl.Name = "name2_lbl";
            name2_lbl.Size = new Size(113, 31);
            name2_lbl.TabIndex = 26;
            name2_lbl.Text = "2 игрок";
            // 
            // SingleGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 588);
            Controls.Add(name1_lbl);
            Controls.Add(name2_lbl);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cell9_pb);
            Controls.Add(cell8_pb);
            Controls.Add(cell7_pb);
            Controls.Add(cell6_pb);
            Controls.Add(cell5_pb);
            Controls.Add(cell4_pb);
            Controls.Add(cell3_pb);
            Controls.Add(cell2_pb);
            Controls.Add(cell1_pb);
            Controls.Add(firstPlayer_pbx);
            Controls.Add(secondPlayer_pbx);
            Controls.Add(turn_lbl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SingleGameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            ((System.ComponentModel.ISupportInitialize)secondPlayer_pbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)firstPlayer_pbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell1_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell2_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell3_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell4_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell5_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell6_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell7_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell8_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)cell9_pb).EndInit();
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
        private PictureBox cell1_pb;
        private PictureBox cell2_pb;
        private PictureBox cell3_pb;
        private PictureBox cell4_pb;
        private PictureBox cell5_pb;
        private PictureBox cell6_pb;
        private PictureBox cell7_pb;
        private PictureBox cell8_pb;
        private PictureBox cell9_pb;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label name1_lbl;
        private Label name2_lbl;
    }
}