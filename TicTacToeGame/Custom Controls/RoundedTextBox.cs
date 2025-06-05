using System.Drawing.Drawing2D;
using System.IO;
using Timer = System.Windows.Forms.Timer;

namespace TicTacToeGame.Custom_Controls
{
    public class RoundedTextBox : Control
    {
        private string text = string.Empty;
        private bool isFocused = false;
        private string placeholderText = "Введите текст...";
        private Timer caretTimer;
        private bool drawCaret = false;
        private bool isHovered = false;
        private bool isPressed = false;
        private bool usePasswordChar = false;

        public bool UseSystemPasswordChar
        {
            get => usePasswordChar;
            set
            {
                usePasswordChar = value;
                Invalidate();
            }
        }
        public Color BaseColor { get; set; } = Color.FromArgb(250, 226, 171);

        public RoundedTextBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw|
                ControlStyles.SupportsTransparentBackColor,
                true);

            Width = 200;
            Height = 30;
            Font = new Font("Malgun Gothic", 10);
            ForeColor = Color.Black;
            BackColor = Color.White;

            this.TabStop = true; 

            this.GotFocus += OnGotFocus;
            this.LostFocus += OnLostFocus;
            this.KeyDown += OnKeyDown;
            this.KeyPress += OnKeyPress;
            this.MouseDown += (s, e) => Focus();

            // Таймер для курсора
            caretTimer = new Timer { Interval = 500 };
            caretTimer.Tick += (s, e) =>
            {
                drawCaret = !drawCaret;
                Invalidate();
            };
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            isFocused = true;
            Cursor = Cursors.Default;
            caretTimer.Start();
            Invalidate();
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            isFocused = false;
            caretTimer.Stop();
            drawCaret = false;
            Invalidate();
        }

        public override string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    Invalidate();
                    OnTextChanged(EventArgs.Empty);
                }
            }
        }

        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                Invalidate();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && text.Length > 0)
            {
                text = text.Substring(0, text.Length - 1);
                Invalidate();
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                text += e.KeyChar;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = isFocused? Cursors.Default : Cursors.Hand;
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            isPressed = false;
            Cursor = Cursors.Default;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            int radius = Height / 2;

            using (GraphicsPath path = DrawingHelper.GetRoundedRectangle(rect, radius)) 
            using (Brush backBrush = new SolidBrush(BaseColor))
            using (Pen borderPen = new Pen(BaseColor, 1))
            {
                g.FillPath(backBrush, path);

                g.DrawPath(borderPen, path);
            }

            Rectangle textRect = new Rectangle(24, 0, Width - 24, Height);

            using (StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            })
            {
                if (string.IsNullOrEmpty(text) && !isFocused)
                {
                    using (Brush placeholderBrush = new SolidBrush(SystemColors.GrayText))
                    {
                        e.Graphics.DrawString(placeholderText, Font, placeholderBrush, textRect, format);
                    }
                }
                else
                {
                    string displayText = usePasswordChar ? new string('•', text.Length) : text;
                    e.Graphics.DrawString(displayText, Font, new SolidBrush(ForeColor), textRect, format);
                }
            }

            if (isFocused && drawCaret && !string.IsNullOrEmpty(text))
            {
                Size textSize = TextRenderer.MeasureText(text, Font);
                int x = 13 + textSize.Width;
                int y = (Height - Font.Height) / 2;
                e.Graphics.DrawLine(Pens.Black, x, y, x, y + Font.Height);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                caretTimer?.Stop();
                caretTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    internal static class DrawingHelper
    {
        public static GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}