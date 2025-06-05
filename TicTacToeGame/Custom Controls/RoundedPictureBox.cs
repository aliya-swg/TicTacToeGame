using System.Drawing.Drawing2D;

namespace TicTacToeGame.Custom_Controls
{
    public class RoundedPictureBox : PictureBox
    {
        private int cornerRadius = 100;

        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                Invalidate();
            }
        }

        public RoundedPictureBox()
        {
            SetStyle(
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer,
               true);

            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image == null)
            {
                base.OnPaint(pe);
                return;
            }

            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = GetRoundedRectangle(rect, cornerRadius))
            {
                g.SetClip(path);

                RectangleF imageRect = new RectangleF(0, 0, Width, Height); 

                g.DrawImage(Image, imageRect);

                g.ResetClip();

                using (Pen pen = new Pen(BackColor, 0))
                {
                    g.DrawPath(pen, path);
                }
            }
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