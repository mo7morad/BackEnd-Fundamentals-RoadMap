using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Login.CustomControls
{
    /// <summary>
    /// A modern panel with rounded corners, shadow effects, and gradient support.
    /// Perfect for creating card-like containers in the UI.
    /// </summary>
    public class ModernPanel : Panel
    {
        #region Private Fields

        private int _borderRadius = 15;
        private Color _borderColor = Color.FromArgb(224, 224, 224);
        private int _borderThickness = 0;
        private bool _showShadow = true;
        private int _shadowDepth = 4;
        private Color _shadowColor = Color.FromArgb(30, 0, 0, 0);
        private bool _useGradient = false;
        private Color _gradientStartColor = Color.White;
        private Color _gradientEndColor = Color.FromArgb(245, 245, 245);
        private float _gradientAngle = 90f;

        #endregion

        #region Constructor

        public ModernPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
            this.Padding = new Padding(15);
        }

        #endregion

        #region Properties

        [Category("Modern Appearance")]
        [Description("The corner radius for rounded edges.")]
        [DefaultValue(15)]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The color of the border.")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The thickness of the border.")]
        [DefaultValue(0)]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("Whether to show a shadow effect.")]
        [DefaultValue(true)]
        public bool ShowShadow
        {
            get => _showShadow;
            set { _showShadow = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The depth of the shadow in pixels.")]
        [DefaultValue(4)]
        public int ShadowDepth
        {
            get => _shadowDepth;
            set { _shadowDepth = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The color of the shadow.")]
        public Color ShadowColor
        {
            get => _shadowColor;
            set { _shadowColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("Whether to use a gradient background.")]
        [DefaultValue(false)]
        public bool UseGradient
        {
            get => _useGradient;
            set { _useGradient = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The start color of the gradient.")]
        public Color GradientStartColor
        {
            get => _gradientStartColor;
            set { _gradientStartColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The end color of the gradient.")]
        public Color GradientEndColor
        {
            get => _gradientEndColor;
            set { _gradientEndColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The angle of the gradient in degrees.")]
        [DefaultValue(90f)]
        public float GradientAngle
        {
            get => _gradientAngle;
            set { _gradientAngle = value; this.Invalidate(); }
        }

        #endregion

        #region Graphics Path Helper

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Ensure we have a valid radius
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

        #endregion

        #region Paint Override

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Calculate rectangles
            int shadowOffset = _showShadow ? _shadowDepth : 0;
            Rectangle panelRect = new Rectangle(0, 0, this.Width - shadowOffset - 1, this.Height - shadowOffset - 1);

            // Draw shadow
            if (_showShadow)
            {
                Rectangle shadowRect = new Rectangle(shadowOffset, shadowOffset, panelRect.Width, panelRect.Height);
                using (GraphicsPath shadowPath = GetRoundedPath(shadowRect, _borderRadius))
                {
                    using (SolidBrush shadowBrush = new SolidBrush(_shadowColor))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }
            }

            // Draw background
            using (GraphicsPath backgroundPath = GetRoundedPath(panelRect, _borderRadius))
            {
                if (_useGradient)
                {
                    using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        panelRect, _gradientStartColor, _gradientEndColor, _gradientAngle))
                    {
                        e.Graphics.FillPath(gradientBrush, backgroundPath);
                    }
                }
                else
                {
                    using (SolidBrush backgroundBrush = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillPath(backgroundBrush, backgroundPath);
                    }
                }

                // Draw border
                if (_borderThickness > 0)
                {
                    using (Pen borderPen = new Pen(_borderColor, _borderThickness))
                    {
                        e.Graphics.DrawPath(borderPen, backgroundPath);
                    }
                }

                // Set the region for the control
                this.Region = new Region(backgroundPath);
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Invalidate();
        }

        #endregion
    }
}
