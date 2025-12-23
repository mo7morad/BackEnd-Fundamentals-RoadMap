using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Login.CustomControls
{
    /// <summary>
    /// A modern ComboBox with flat design, custom dropdown arrow, and focus effects.
    /// </summary>
    public class ModernComboBox : ComboBox
    {
        #region Private Fields

        private Color _borderColor = Color.FromArgb(0, 122, 204);
        private Color _focusBorderColor = Color.FromArgb(0, 102, 184);
        private Color _arrowColor = Color.FromArgb(0, 122, 204);
        private Color _buttonColor = Color.FromArgb(245, 245, 245);
        private int _borderThickness = 2;
        private bool _isFocused = false;

        #endregion

        #region Constructor

        public ModernComboBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Segoe UI", 11F);
            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(33, 33, 33);
            this.ItemHeight = 30;
        }

        #endregion

        #region Properties

        [Category("Modern Appearance")]
        [Description("The color of the border.")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The color of the border when focused.")]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set { _focusBorderColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The color of the dropdown arrow.")]
        public Color ArrowColor
        {
            get => _arrowColor;
            set { _arrowColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The background color of the dropdown button.")]
        public Color ButtonColor
        {
            get => _buttonColor;
            set { _buttonColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("The thickness of the border.")]
        [DefaultValue(2)]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; this.Invalidate(); }
        }

        #endregion

        #region Paint Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Draw background
            using (SolidBrush backgroundBrush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, rect);
            }

            // Draw border
            Color currentBorderColor = _isFocused ? _focusBorderColor : _borderColor;
            using (Pen borderPen = new Pen(currentBorderColor, _borderThickness))
            {
                // Draw only bottom border for modern look
                e.Graphics.DrawLine(borderPen, 0, this.Height - _borderThickness, this.Width, this.Height - _borderThickness);
            }

            // Draw dropdown button area
            Rectangle buttonRect = new Rectangle(this.Width - 30, 0, 30, this.Height);
            using (SolidBrush buttonBrush = new SolidBrush(_buttonColor))
            {
                e.Graphics.FillRectangle(buttonBrush, buttonRect);
            }

            // Draw dropdown arrow
            Point[] arrowPoints = new Point[]
            {
                new Point(this.Width - 22, this.Height / 2 - 3),
                new Point(this.Width - 8, this.Height / 2 - 3),
                new Point(this.Width - 15, this.Height / 2 + 4)
            };
            using (SolidBrush arrowBrush = new SolidBrush(_arrowColor))
            {
                e.Graphics.FillPolygon(arrowBrush, arrowPoints);
            }

            // Draw selected text
            if (this.SelectedItem != null)
            {
                Rectangle textRect = new Rectangle(8, 0, this.Width - 38, this.Height);
                TextRenderer.DrawText(
                    e.Graphics,
                    this.SelectedItem.ToString(),
                    this.Font,
                    textRect,
                    this.ForeColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                );
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Determine colors based on state
            Color backgroundColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Color.FromArgb(232, 240, 254)
                : Color.White;
            Color textColor = Color.FromArgb(33, 33, 33);

            // Draw background
            using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Draw text
            string text = this.Items[e.Index].ToString();
            TextRenderer.DrawText(
                e.Graphics,
                text,
                this.Font,
                new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height),
                textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
        }

        #endregion

        #region Focus Events

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _isFocused = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _isFocused = false;
            this.Invalidate();
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            _isFocused = true;
            this.Invalidate();
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
            if (!this.Focused)
            {
                _isFocused = false;
                this.Invalidate();
            }
        }

        #endregion
    }
}
