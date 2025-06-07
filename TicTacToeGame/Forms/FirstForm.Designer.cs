namespace TicTacToeGame
{
    partial class FirstForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            start_btn = new TicTacToeGame.Custom_Controls.TextOnlyButton();
            SuspendLayout();
            // 
            // start_btn
            // 
            start_btn.BackColor = Color.Transparent;
            start_btn.Font = new Font("Borsok", 32.5F);
            start_btn.ForeColor = Color.FromArgb(121, 75, 63);
            start_btn.HoverCursor = Cursors.Hand;
            start_btn.Location = new Point(426, 355);
            start_btn.Name = "start_btn";
            start_btn.Size = new Size(156, 53);
            start_btn.TabIndex = 0;
            start_btn.Text = "Войти";
            start_btn.Click += start_btn_Click;
            // 
            // FirstForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Фон123;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(999, 588);
            Controls.Add(start_btn);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FirstForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Первая форма";
            ResumeLayout(false);
        }

        #endregion

        private Custom_Controls.TextOnlyButton start_btn;
    }
}
