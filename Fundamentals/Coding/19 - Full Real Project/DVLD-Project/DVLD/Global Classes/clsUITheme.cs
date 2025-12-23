using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.GlobalClasses
{
    /// <summary>
    /// Modern UI Theme Helper Class for consistent styling across the DVLD application.
    /// Provides centralized color scheme, fonts, and styling methods for a cohesive look.
    /// </summary>
    public static class clsUITheme
    {
        #region Color Palette - Modern Professional Theme
        
        // Primary Colors
        public static readonly Color PrimaryColor = Color.FromArgb(0, 122, 204);          // Modern Blue
        public static readonly Color PrimaryDarkColor = Color.FromArgb(0, 99, 166);       // Darker Blue for hover
        public static readonly Color PrimaryLightColor = Color.FromArgb(51, 153, 255);    // Light Blue accent
        
        // Secondary Colors  
        public static readonly Color SecondaryColor = Color.FromArgb(45, 45, 48);         // Dark Gray (sidebar)
        public static readonly Color SecondaryLightColor = Color.FromArgb(62, 62, 66);    // Lighter Dark Gray
        
        // Accent Colors
        public static readonly Color AccentColor = Color.FromArgb(0, 164, 240);           // Bright Blue accent
        public static readonly Color SuccessColor = Color.FromArgb(76, 175, 80);          // Green for success
        public static readonly Color WarningColor = Color.FromArgb(255, 152, 0);          // Orange for warnings
        public static readonly Color DangerColor = Color.FromArgb(244, 67, 54);           // Red for errors/delete
        public static readonly Color InfoColor = Color.FromArgb(33, 150, 243);            // Blue for info
        
        // Neutral Colors
        public static readonly Color BackgroundColor = Color.FromArgb(250, 250, 252);     // Light background
        public static readonly Color SurfaceColor = Color.White;                           // Card/Panel background
        public static readonly Color BorderColor = Color.FromArgb(224, 224, 224);         // Subtle borders
        public static readonly Color DividerColor = Color.FromArgb(238, 238, 238);        // Dividers
        
        // Text Colors
        public static readonly Color TextPrimaryColor = Color.FromArgb(33, 33, 33);       // Primary text
        public static readonly Color TextSecondaryColor = Color.FromArgb(117, 117, 117);  // Secondary text
        public static readonly Color TextDisabledColor = Color.FromArgb(189, 189, 189);   // Disabled text
        public static readonly Color TextOnPrimaryColor = Color.White;                     // Text on primary color
        
        // Title Colors
        public static readonly Color TitleColor = Color.FromArgb(0, 122, 204);            // Modern blue instead of dark red
        public static readonly Color SubtitleColor = Color.FromArgb(64, 64, 64);          // Subtitle gray
        
        // DataGridView Colors
        public static readonly Color GridHeaderBackColor = Color.FromArgb(0, 122, 204);
        public static readonly Color GridHeaderForeColor = Color.White;
        public static readonly Color GridAlternateRowColor = Color.FromArgb(245, 249, 255);
        public static readonly Color GridSelectionBackColor = Color.FromArgb(187, 222, 251);
        public static readonly Color GridSelectionForeColor = Color.FromArgb(33, 33, 33);
        
        #endregion

        #region Fonts - Modern Typography
        
        public static readonly Font TitleFont = new Font("Segoe UI", 22F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI Semibold", 14F, FontStyle.Regular);
        public static readonly Font HeadingFont = new Font("Segoe UI Semibold", 12F, FontStyle.Regular);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font BodyBoldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font LabelFont = new Font("Segoe UI Semibold", 10F, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 10F, FontStyle.Regular);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font GridFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font GridHeaderFont = new Font("Segoe UI Semibold", 10F, FontStyle.Regular);
        
        #endregion

        #region Dimension Constants
        
        public const int BorderRadius = 8;
        public const int SmallBorderRadius = 4;
        public const int ButtonHeight = 40;
        public const int TextBoxHeight = 36;
        public const int StandardPadding = 16;
        public const int SmallPadding = 8;
        public const int LargePadding = 24;
        
        #endregion

        #region Form Styling Methods
        
        /// <summary>
        /// Apply modern theme to a form
        /// </summary>
        public static void ApplyFormTheme(Form form)
        {
            form.BackColor = SurfaceColor;
            form.Font = BodyFont;
            
            // Apply to all child controls recursively
            ApplyThemeToControls(form.Controls);
        }
        
        /// <summary>
        /// Apply theme to all controls recursively
        /// </summary>
        public static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                ApplyControlTheme(control);
                
                // Recursively apply to child controls
                if (control.Controls.Count > 0)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
        
        /// <summary>
        /// Apply theme based on control type
        /// </summary>
        public static void ApplyControlTheme(Control control)
        {
            switch (control)
            {
                case Button btn:
                    StyleButton(btn);
                    break;
                case TextBox txt:
                    StyleTextBox(txt);
                    break;
                case ComboBox cmb:
                    StyleComboBox(cmb);
                    break;
                case LinkLabel link:
                    StyleLinkLabel(link);
                    break;
                case Label lbl:
                    StyleLabel(lbl);
                    break;
                case DataGridView dgv:
                    StyleDataGridView(dgv);
                    break;
                case GroupBox grp:
                    StyleGroupBox(grp);
                    break;
                case Panel pnl:
                    StylePanel(pnl);
                    break;
                case TabControl tab:
                    StyleTabControl(tab);
                    break;
            }
        }
        
        #endregion

        #region Button Styling
        
        /// <summary>
        /// Style a button with primary theme
        /// </summary>
        public static void StyleButton(Button btn, ButtonStyle style = ButtonStyle.Default)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.Height = ButtonHeight;
            
            switch (style)
            {
                case ButtonStyle.Primary:
                    btn.BackColor = PrimaryColor;
                    btn.ForeColor = TextOnPrimaryColor;
                    btn.FlatAppearance.MouseOverBackColor = PrimaryDarkColor;
                    btn.FlatAppearance.MouseDownBackColor = PrimaryDarkColor;
                    break;
                    
                case ButtonStyle.Success:
                    btn.BackColor = SuccessColor;
                    btn.ForeColor = TextOnPrimaryColor;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 142, 60);
                    break;
                    
                case ButtonStyle.Danger:
                    btn.BackColor = DangerColor;
                    btn.ForeColor = TextOnPrimaryColor;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 47, 47);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(211, 47, 47);
                    break;
                    
                case ButtonStyle.Warning:
                    btn.BackColor = WarningColor;
                    btn.ForeColor = TextOnPrimaryColor;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 124, 0);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 124, 0);
                    break;
                    
                case ButtonStyle.Secondary:
                    btn.BackColor = SurfaceColor;
                    btn.ForeColor = TextPrimaryColor;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = BorderColor;
                    btn.FlatAppearance.MouseOverBackColor = BackgroundColor;
                    btn.FlatAppearance.MouseDownBackColor = DividerColor;
                    break;
                    
                default: // Default style
                    if (btn.Text.ToLower().Contains("save") || btn.Text.ToLower().Contains("add") || 
                        btn.Text.ToLower().Contains("issue") || btn.Text.ToLower().Contains("renew") ||
                        btn.Text.ToLower().Contains("release"))
                    {
                        StyleButton(btn, ButtonStyle.Primary);
                    }
                    else if (btn.Text.ToLower().Contains("close") || btn.Text.ToLower().Contains("cancel"))
                    {
                        StyleButton(btn, ButtonStyle.Secondary);
                    }
                    else if (btn.Text.ToLower().Contains("delete"))
                    {
                        StyleButton(btn, ButtonStyle.Danger);
                    }
                    else
                    {
                        // Generic styling
                        btn.BackColor = SurfaceColor;
                        btn.ForeColor = TextPrimaryColor;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.BorderColor = BorderColor;
                        btn.FlatAppearance.MouseOverBackColor = BackgroundColor;
                    }
                    break;
            }
        }
        
        /// <summary>
        /// Style a primary action button (Save, Submit, etc.)
        /// </summary>
        public static void StylePrimaryButton(Button btn)
        {
            StyleButton(btn, ButtonStyle.Primary);
        }
        
        /// <summary>
        /// Style a secondary/cancel button
        /// </summary>
        public static void StyleSecondaryButton(Button btn)
        {
            StyleButton(btn, ButtonStyle.Secondary);
        }
        
        #endregion

        #region TextBox Styling
        
        public static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = BodyFont;
            txt.BackColor = SurfaceColor;
            txt.ForeColor = TextPrimaryColor;
        }
        
        #endregion

        #region ComboBox Styling
        
        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = BodyFont;
            cmb.BackColor = SurfaceColor;
            cmb.ForeColor = TextPrimaryColor;
        }
        
        #endregion

        #region Label Styling
        
        public static void StyleLabel(Label lbl)
        {
            // Check if it's a title label (large font)
            if (lbl.Font.Size >= 20)
            {
                lbl.Font = TitleFont;
                lbl.ForeColor = TitleColor;
            }
            else if (lbl.Font.Style == FontStyle.Bold && lbl.Font.Size >= 12)
            {
                lbl.Font = HeadingFont;
                lbl.ForeColor = TextPrimaryColor;
            }
            else
            {
                lbl.Font = BodyFont;
                lbl.ForeColor = TextPrimaryColor;
            }
        }
        
        /// <summary>
        /// Style a title label specifically
        /// </summary>
        public static void StyleTitleLabel(Label lbl)
        {
            lbl.Font = TitleFont;
            lbl.ForeColor = TitleColor;
        }
        
        /// <summary>
        /// Style a value/data label
        /// </summary>
        public static void StyleValueLabel(Label lbl)
        {
            lbl.Font = BodyBoldFont;
            lbl.ForeColor = TextPrimaryColor;
        }
        
        #endregion

        #region DataGridView Styling
        
        public static void StyleDataGridView(DataGridView dgv)
        {
            // General settings
            dgv.BackgroundColor = SurfaceColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = DividerColor;
            dgv.Font = GridFont;
            
            // Selection
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            
            // Header styling
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderForeColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = GridHeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // Row styling
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle.BackColor = SurfaceColor;
            dgv.DefaultCellStyle.ForeColor = TextPrimaryColor;
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectionBackColor;
            dgv.DefaultCellStyle.SelectionForeColor = GridSelectionForeColor;
            dgv.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            
            // Alternate row colors
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlternateRowColor;
            
            // Row header styling (if visible)
            dgv.RowHeadersDefaultCellStyle.BackColor = BackgroundColor;
            dgv.RowHeadersDefaultCellStyle.ForeColor = TextSecondaryColor;
            
            // Cell borders
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            
            // Auto-size
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        #endregion

        #region GroupBox Styling
        
        public static void StyleGroupBox(GroupBox grp)
        {
            grp.Font = HeadingFont;
            grp.ForeColor = TextPrimaryColor;
            grp.BackColor = SurfaceColor;
        }
        
        #endregion

        #region Panel Styling
        
        public static void StylePanel(Panel pnl)
        {
            pnl.BackColor = SurfaceColor;
        }
        
        /// <summary>
        /// Style a panel as a card (with shadow effect simulation)
        /// </summary>
        public static void StyleCardPanel(Panel pnl)
        {
            pnl.BackColor = SurfaceColor;
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Padding = new Padding(StandardPadding);
        }
        
        #endregion

        #region TabControl Styling
        
        public static void StyleTabControl(TabControl tab)
        {
            tab.Font = BodyFont;
            
            foreach (TabPage page in tab.TabPages)
            {
                page.BackColor = SurfaceColor;
            }
        }
        
        #endregion

        #region LinkLabel Styling
        
        public static void StyleLinkLabel(LinkLabel link)
        {
            link.Font = BodyFont;
            link.LinkColor = PrimaryColor;
            link.ActiveLinkColor = PrimaryDarkColor;
            link.VisitedLinkColor = PrimaryColor;
            link.LinkBehavior = LinkBehavior.HoverUnderline;
        }
        
        #endregion

        #region ContextMenuStrip Styling
        
        public static void StyleContextMenuStrip(ContextMenuStrip cms)
        {
            cms.Font = BodyFont;
            cms.BackColor = SurfaceColor;
            cms.ForeColor = TextPrimaryColor;
            
            foreach (ToolStripItem item in cms.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    StyleToolStripMenuItem(menuItem);
                }
            }
        }
        
        private static void StyleToolStripMenuItem(ToolStripMenuItem item)
        {
            item.Font = BodyFont;
            item.ForeColor = TextPrimaryColor;
            
            // Recursively style sub-items
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    StyleToolStripMenuItem(subMenuItem);
                }
            }
        }
        
        #endregion

        #region Helper Enums
        
        public enum ButtonStyle
        {
            Default,
            Primary,
            Secondary,
            Success,
            Danger,
            Warning,
            Info
        }
        
        #endregion

        #region Utility Methods
        
        /// <summary>
        /// Create a rounded rectangle path for custom drawing
        /// </summary>
        public static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            
            path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            
            return path;
        }
        
        /// <summary>
        /// Get status color based on status string
        /// </summary>
        public static Color GetStatusColor(string status)
        {
            switch (status?.ToLower())
            {
                case "new":
                case "pending":
                    return InfoColor;
                case "completed":
                case "approved":
                case "active":
                case "passed":
                    return SuccessColor;
                case "cancelled":
                case "rejected":
                case "failed":
                case "detained":
                    return DangerColor;
                case "expired":
                case "warning":
                    return WarningColor;
                default:
                    return TextSecondaryColor;
            }
        }
        
        #endregion
    }
}
