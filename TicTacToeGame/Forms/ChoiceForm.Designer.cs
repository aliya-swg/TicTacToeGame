namespace TicTacToeGame.Forms
{
    partial class ChoiceForm
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
            host_btn = new Custom_Controls.RoundedButton();
            client_btn = new Custom_Controls.RoundedButton();
            SuspendLayout();
            // 
            // host_btn
            // 
            host_btn.BackColor = Color.Transparent;
            host_btn.BaseColor = Color.FromArgb(231, 106, 137);
            host_btn.CornerRadius = 41;
            host_btn.Font = new Font("Borsok", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            host_btn.ForeColor = Color.White;
            host_btn.HoverColor = Color.FromArgb(167, 65, 88);
            host_btn.Location = new Point(46, 82);
            host_btn.Name = "host_btn";
            host_btn.PressedColor = Color.DarkSlateBlue;
            host_btn.Size = new Size(172, 83);
            host_btn.TabIndex = 0;
            host_btn.Text = "Хост";
            host_btn.Click += host_btn_Click;
            // 
            // client_btn
            // 
            client_btn.BackColor = Color.Transparent;
            client_btn.BaseColor = Color.FromArgb(231, 106, 137);
            client_btn.CornerRadius = 41;
            client_btn.Font = new Font("Borsok", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            client_btn.ForeColor = Color.White;
            client_btn.HoverColor = Color.FromArgb(165, 67, 88);
            client_btn.Location = new Point(287, 82);
            client_btn.Name = "client_btn";
            client_btn.PressedColor = Color.DarkSlateBlue;
            client_btn.Size = new Size(172, 83);
            client_btn.TabIndex = 1;
            client_btn.Text = "Клиент";
            client_btn.Click += client_btn_Click;
            // 
            // ChoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 263);
            Controls.Add(client_btn);
            Controls.Add(host_btn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ChoiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор режима";
            ResumeLayout(false);
        }

        #endregion

        private Custom_Controls.RoundedButton host_btn;
        private Custom_Controls.RoundedButton client_btn;
    }
}