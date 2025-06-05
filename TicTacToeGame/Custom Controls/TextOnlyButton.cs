namespace TicTacToeGame.Custom_Controls
{
    public class TextOnlyButton : Control
    {
        private bool isPressed = false;
        private Cursor hoverCursor = Cursors.Hand; 

        public TextOnlyButton()
        {
            SetStyle(
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            BackColor = Color.Transparent;
            ForeColor = Color.White;
            this.Size = new Size(150, 40);
            this.Cursor = Cursors.Hand;
        }

        public event EventHandler Click;

        public Cursor HoverCursor
        {
            get { return hoverCursor; }
            set
            {
                hoverCursor = value;
                if (hoverCursor != null)
                    Cursor = hoverCursor;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = HoverCursor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isPressed = true;
            Click?.Invoke(this, EventArgs.Empty);
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
            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                ClientRectangle,
                isPressed ? ForeColor: ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}