using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Classes
{
    /// <summary>
    /// Custom professional renderer for MenuStrip with dark theme
    /// </summary>
    public class clsMenuRenderer : ToolStripProfessionalRenderer
    {
        // Dark theme colors
        private static readonly Color MenuBackColor = Color.FromArgb(33, 37, 41);
        private static readonly Color MenuItemHoverColor = Color.FromArgb(52, 58, 64);
        private static readonly Color MenuItemSelectedColor = Color.FromArgb(73, 80, 87);
        private static readonly Color DropDownBackColor = Color.FromArgb(43, 47, 51);
        private static readonly Color SeparatorColor = Color.FromArgb(73, 80, 87);
        private static readonly Color BorderColor = Color.FromArgb(52, 58, 64);

        public clsMenuRenderer() : base(new clsMenuColorTable())
        {
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

            if (e.Item.Selected || e.Item.Pressed)
            {
                using (SolidBrush brush = new SolidBrush(e.Item.Pressed ? MenuItemSelectedColor : MenuItemHoverColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(e.ToolStrip is MenuStrip ? MenuBackColor : DropDownBackColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip)
            {
                using (SolidBrush brush = new SolidBrush(MenuBackColor))
                {
                    e.Graphics.FillRectangle(brush, e.AffectedBounds);
                }
            }
            else if (e.ToolStrip is ToolStripDropDownMenu)
            {
                using (SolidBrush brush = new SolidBrush(DropDownBackColor))
                {
                    e.Graphics.FillRectangle(brush, e.AffectedBounds);
                }
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu)
            {
                using (Pen pen = new Pen(BorderColor))
                {
                    Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            int y = e.Item.Height / 2;
            using (Pen pen = new Pen(SeparatorColor))
            {
                e.Graphics.DrawLine(pen, 30, y, e.Item.Width - 4, y);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // Fill the image margin with dark color
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(38, 42, 46)))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
        }
    }

    /// <summary>
    /// Custom color table for the professional renderer
    /// </summary>
    public class clsMenuColorTable : ProfessionalColorTable
    {
        private static readonly Color DarkColor = Color.FromArgb(33, 37, 41);
        private static readonly Color DarkHoverColor = Color.FromArgb(52, 58, 64);
        private static readonly Color DropDownColor = Color.FromArgb(43, 47, 51);

        public override Color MenuBorder => Color.FromArgb(52, 58, 64);
        public override Color MenuItemBorder => Color.FromArgb(52, 58, 64);
        public override Color MenuItemSelected => DarkHoverColor;
        public override Color MenuItemSelectedGradientBegin => DarkHoverColor;
        public override Color MenuItemSelectedGradientEnd => DarkHoverColor;
        public override Color MenuItemPressedGradientBegin => DarkColor;
        public override Color MenuItemPressedGradientEnd => DarkColor;
        public override Color MenuStripGradientBegin => DarkColor;
        public override Color MenuStripGradientEnd => DarkColor;
        public override Color ToolStripDropDownBackground => DropDownColor;
        public override Color ImageMarginGradientBegin => Color.FromArgb(38, 42, 46);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(38, 42, 46);
        public override Color ImageMarginGradientEnd => Color.FromArgb(38, 42, 46);
        public override Color SeparatorDark => Color.FromArgb(73, 80, 87);
        public override Color SeparatorLight => Color.FromArgb(73, 80, 87);
    }
}
