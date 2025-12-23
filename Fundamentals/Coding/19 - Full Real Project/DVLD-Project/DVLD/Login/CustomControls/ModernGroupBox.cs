using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Login.CustomControls
{
    /// <summary>
    /// A modern GroupBox with customizable header, rounded corners, and accent colors.
    /// </summary>
    public class ModernGroupBox : GroupBox
    {
        #region Private Fields

        private Color _headerColor = Color.FromArgb(0, 122, 204);
        private Color _headerTextColor = Color.White;
        private Color _borderColor = Color.FromArgb(224, 224, 224);
        private int _borderRadius = 10;
        private int _headerHeight = 35;
        private bool _showHeaderBackground = true;

        #endregion

        #region Constructor

        public ModernGroupBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw, true);

            this.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.BackColor = Color.White;
            this.Padding = new Padding(10, 40, 10, 10);
        }

        #endregion

        #region Properties

        [Category("Modern Appearance")]
        [Description("The background color of the header.")]
        public Color HeaderColor
        {
            get => _headerColor;
            set { _headerColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The text color of the header.")]
        public Color HeaderTextColor
        {
            get => _headerTextColor;
            set { _headerTextColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The color of the border.")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The corner radius for rounded edges.")]
        [DefaultValue(10)]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The height of the header area.")]
        [DefaultValue(35)]
        public int HeaderHeight
        {
            get => _headerHeight;
            set { _headerHeight = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("Whether to show a colored header background.")]
        [DefaultValue(true)]
        public bool ShowHeaderBackground
        {
            get => _showHeaderBackground;
            set { _showHeaderBackground = value; this.Invalidate(); }
        }

        #endregion

        #region Graphics Path Helpers

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;
            if (diameter < 2) diameter = 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private GraphicsPath GetHeaderPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Top left corner
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Top right corner
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Right edge down
            path.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom);
            // Bottom edge (straight)
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
            // Left edge up
            path.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + radius);
            path.CloseFigure();

            return path;
        }

        #endregion

        #region Paint Override

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Draw the main border/background
            using (GraphicsPath mainPath = GetRoundedPath(bounds, _borderRadius))
            {
                // Fill background
                using (SolidBrush backgroundBrush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(backgroundBrush, mainPath);
                }

                // Draw border
                using (Pen borderPen = new Pen(_borderColor, 1))
                {
                    e.Graphics.DrawPath(borderPen, mainPath);
                }
            }

            // Draw header
            if (_showHeaderBackground)
            {
                Rectangle headerRect = new Rectangle(0, 0, this.Width - 1, _headerHeight);
                using (GraphicsPath headerPath = GetHeaderPath(headerRect, _borderRadius))
                {
                    using (SolidBrush headerBrush = new SolidBrush(_headerColor))
                    {
                        e.Graphics.FillPath(headerBrush, headerPath);
                    }
                }

                // Draw header text
                TextRenderer.DrawText(
                    e.Graphics,
                    this.Text,
                    this.Font,
                    new Rectangle(15, 0, this.Width - 30, _headerHeight),
                    _headerTextColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                );
            }
            else
            {
                // Draw text with accent underline
                Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
                
                TextRenderer.DrawText(
                    e.Graphics,
                    this.Text,
                    this.Font,
                    new Point(15, 8),
                    _headerColor
                );

                // Draw accent underline
                using (Pen accentPen = new Pen(_headerColor, 2))
                {
                    e.Graphics.DrawLine(accentPen, 15, 8 + textSize.Height + 2, 15 + textSize.Width, 8 + textSize.Height + 2);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        #endregion
    }
}
