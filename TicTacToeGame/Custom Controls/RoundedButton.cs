using System.Drawing.Drawing2D;

namespace TicTacToeGame.Custom_Controls
{
    public class RoundedButton : Control
    {
        private bool isHovered = false;
        private bool isPressed = false;

        public Color BaseColor { get; set; } = Color.FromArgb(231, 106, 137);
        public Color HoverColor { get; set; } = Color.FromArgb(167, 65, 88);
        public Color PressedColor { get; set; } = Color.DarkSlateBlue;
        public int CornerRadius { get; set; } = 0;

        public event EventHandler Click;

        public RoundedButton()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            BackColor = Color.Transparent;
            Size = new Size(150, 40);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            ForeColor = Color.White;
            Cursor = Cursors.Hand; 
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Cursor = Cursors.Hand; 
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Click?.Invoke(this, EventArgs.Empty);
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            CornerRadius = Height / 2;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = GetRoundedRectangle(rect, CornerRadius))
            using (Brush backBrush = new SolidBrush(isPressed ? PressedColor : (isHovered ? HoverColor : BaseColor)))
            using (Pen borderPen = new Pen(BaseColor, 1))
            {
                g.FillPath(backBrush, path);

                g.DrawPath(borderPen, path);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                rect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}