using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Login.CustomControls
{
    /// <summary>
    /// A modern-styled TextBox with customizable appearance.
    /// </summary>
    public class ModernTextBox : TextBox
    {
        private Color _borderColor = Color.FromArgb(0, 122, 204);
        private Color _focusBorderColor = Color.FromArgb(0, 102, 184);
        private int _borderThickness = 2;
        private bool _isFocused = false;

        public ModernTextBox()
        {
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 12F);
            this.ForeColor = Color.FromArgb(64, 64, 64);
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
        /// Gets or sets the border color when focused.
        /// </summary>
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set { _focusBorderColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the border thickness.
        /// </summary>
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; this.Invalidate(); }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _isFocused = true;
            this.BackColor = Color.White;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _isFocused = false;
            this.BackColor = Color.WhiteSmoke;
            this.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            // WM_PAINT
            if (m.Msg == 0x000F)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    Color color = _isFocused ? _focusBorderColor : _borderColor;
                    using (Pen pen = new Pen(color, _borderThickness))
                    {
                        // Draw bottom border only
                        g.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                }
            }
        }
    }
}
