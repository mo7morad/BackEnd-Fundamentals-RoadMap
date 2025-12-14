using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Login.CustomControls
{
    /// <summary>
    /// A button with rounded corners and modern styling.
    /// </summary>
    public class RoundButton : Button
    {
        private int _borderRadius = 10;
        private Color _borderColor = Color.FromArgb(0, 122, 204);
        private int _borderThickness = 0;

        public RoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(0, 122, 204);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Gets or sets the border radius for rounded corners.
        /// </summary>
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the border thickness.
        /// </summary>
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; this.Invalidate(); }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            
            using (GraphicsPath path = GetRoundedPath(rect, _borderRadius))
            {
                this.Region = new Region(path);
                
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    pevent.Graphics.FillPath(brush, path);
                }
                
                if (_borderThickness > 0)
                {
                    using (Pen pen = new Pen(_borderColor, _borderThickness))
                    {
                        pevent.Graphics.DrawPath(pen, path);
                    }
                }
            }
            
            // Draw text
            TextRenderer.DrawText(
                pevent.Graphics,
                this.Text,
                this.Font,
                rect,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(0, 102, 184);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.FromArgb(0, 122, 204);
        }
    }
}
