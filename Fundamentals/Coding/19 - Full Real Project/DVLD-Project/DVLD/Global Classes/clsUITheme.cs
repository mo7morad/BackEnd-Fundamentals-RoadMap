using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD.Classes
{
    /// <summary>
    /// Centralized UI theme class providing consistent styling across the application.
    /// Modern flat design with accent colors and smooth visual effects.
    /// </summary>
    public static class clsUITheme
    {
        #region Color Palette

        // Primary Colors
        public static readonly Color PrimaryColor = Color.FromArgb(0, 122, 204);      // Blue
        public static readonly Color PrimaryDark = Color.FromArgb(0, 102, 184);       // Darker Blue
        public static readonly Color PrimaryLight = Color.FromArgb(100, 181, 246);    // Light Blue

        // Secondary Colors
        public static readonly Color SecondaryColor = Color.FromArgb(45, 45, 48);     // Dark Gray
        public static readonly Color SecondaryDark = Color.FromArgb(30, 30, 33);      // Darker Gray
        public static readonly Color SecondaryLight = Color.FromArgb(62, 62, 66);     // Light Gray

        // Accent Colors
        public static readonly Color AccentGreen = Color.FromArgb(76, 175, 80);       // Success Green
        public static readonly Color AccentRed = Color.FromArgb(244, 67, 54);         // Error Red
        public static readonly Color AccentOrange = Color.FromArgb(255, 152, 0);      // Warning Orange
        public static readonly Color AccentPurple = Color.FromArgb(156, 39, 176);     // Info Purple

        // Background Colors
        public static readonly Color BackgroundLight = Color.FromArgb(250, 250, 250);  // Main Background
        public static readonly Color BackgroundWhite = Color.White;
        public static readonly Color BackgroundCard = Color.White;
        public static readonly Color BackgroundHover = Color.FromArgb(232, 240, 254);  // Subtle Blue Hover

        // Text Colors
        public static readonly Color TextPrimary = Color.FromArgb(33, 33, 33);         // Dark text
        public static readonly Color TextSecondary = Color.FromArgb(117, 117, 117);    // Gray text
        public static readonly Color TextLight = Color.White;
        public static readonly Color TextAccent = Color.FromArgb(0, 122, 204);         // Blue text

        // Border Colors
        public static readonly Color BorderLight = Color.FromArgb(224, 224, 224);
        public static readonly Color BorderMedium = Color.FromArgb(189, 189, 189);
        public static readonly Color BorderDark = Color.FromArgb(158, 158, 158);

        // DataGridView Colors
        public static readonly Color GridHeaderBackground = Color.FromArgb(245, 245, 245);
        public static readonly Color GridAlternateRow = Color.FromArgb(250, 250, 252);
        public static readonly Color GridSelectionBackground = Color.FromArgb(232, 240, 254);
        public static readonly Color GridGridLines = Color.FromArgb(230, 230, 230);

        #endregion

        #region Fonts

        public static readonly Font FontTitle = new Font("Segoe UI", 22F, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font FontHeader = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font FontNormal = new Font("Segoe UI", 11F);
        public static readonly Font FontSmall = new Font("Segoe UI", 10F);
        public static readonly Font FontButton = new Font("Segoe UI", 11F, FontStyle.Bold);

        #endregion

        #region Native Methods for Rounded Corners

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public static void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }

        #endregion

        #region Form Styling

        /// <summary>
        /// Applies modern styling to a form.
        /// </summary>
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = BackgroundLight;
            form.Font = FontNormal;
        }

        /// <summary>
        /// Applies modern styling to a dialog form with rounded corners.
        /// </summary>
        public static void ApplyDialogStyle(Form form, int cornerRadius = 15)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = BackgroundWhite;
            form.Font = FontNormal;
            ApplyRoundedCorners(form, cornerRadius);
        }

        #endregion

        #region Button Styling

        /// <summary>
        /// Applies primary button styling (filled with primary color).
        /// </summary>
        public static void ApplyPrimaryButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = PrimaryColor;
            button.ForeColor = TextLight;
            button.Font = FontButton;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.MouseOverBackColor = PrimaryDark;
            button.FlatAppearance.MouseDownBackColor = SecondaryDark;

            // Apply rounded corners
            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, 8, 8));

            button.MouseEnter += (s, e) => button.BackColor = PrimaryDark;
            button.MouseLeave += (s, e) => button.BackColor = PrimaryColor;
        }

        /// <summary>
        /// Applies secondary button styling (outlined).
        /// </summary>
        public static void ApplySecondaryButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = PrimaryColor;
            button.BackColor = BackgroundWhite;
            button.ForeColor = PrimaryColor;
            button.Font = FontButton;
            button.Cursor = Cursors.Hand;

            button.MouseEnter += (s, e) =>
            {
                button.BackColor = BackgroundHover;
            };
            button.MouseLeave += (s, e) =>
            {
                button.BackColor = BackgroundWhite;
            };
        }

        /// <summary>
        /// Applies danger button styling (red color for delete/cancel actions).
        /// </summary>
        public static void ApplyDangerButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = AccentRed;
            button.ForeColor = TextLight;
            button.Font = FontButton;
            button.Cursor = Cursors.Hand;

            button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(211, 47, 47);
            button.MouseLeave += (s, e) => button.BackColor = AccentRed;
        }

        /// <summary>
        /// Applies success button styling (green color).
        /// </summary>
        public static void ApplySuccessButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = AccentGreen;
            button.ForeColor = TextLight;
            button.Font = FontButton;
            button.Cursor = Cursors.Hand;

            button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(56, 142, 60);
            button.MouseLeave += (s, e) => button.BackColor = AccentGreen;
        }

        #endregion

        #region TextBox Styling

        /// <summary>
        /// Applies modern styling to a textbox with underline effect.
        /// </summary>
        public static void ApplyTextBoxStyle(TextBox textBox, Panel underlinePanel = null)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = BackgroundLight;
            textBox.Font = FontNormal;
            textBox.ForeColor = TextPrimary;

            if (underlinePanel != null)
            {
                underlinePanel.BackColor = PrimaryColor;
                underlinePanel.Height = 2;
            }

            textBox.Enter += (s, e) =>
            {
                textBox.BackColor = BackgroundWhite;
                if (underlinePanel != null) underlinePanel.BackColor = PrimaryDark;
            };
            textBox.Leave += (s, e) =>
            {
                textBox.BackColor = BackgroundLight;
                if (underlinePanel != null) underlinePanel.BackColor = PrimaryColor;
            };
        }

        #endregion

        #region DataGridView Styling

        /// <summary>
        /// Applies comprehensive modern styling to a DataGridView.
        /// </summary>
        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            // Basic settings
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = BackgroundWhite;
            dgv.GridColor = GridGridLines;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            // Don't use Fill mode - let columns keep their specified widths
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.ScrollBars = ScrollBars.Both;

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackground;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBackground;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row style
            dgv.DefaultCellStyle.BackColor = BackgroundWhite;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectionBackground;
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
            dgv.RowTemplate.Height = 35;

            // Alternating row style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlternateRow;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectionBackground;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TextPrimary;

            // Hover effect - remove previous handlers to avoid stacking
            dgv.CellMouseEnter -= DataGridView_CellMouseEnter;
            dgv.CellMouseLeave -= DataGridView_CellMouseLeave;
            dgv.CellMouseEnter += DataGridView_CellMouseEnter;
            dgv.CellMouseLeave += DataGridView_CellMouseLeave;
        }

        private static void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null && e.RowIndex >= 0)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = BackgroundHover;
            }
        }

        private static void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null && e.RowIndex >= 0)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? BackgroundWhite : GridAlternateRow;
            }
        }

        #endregion

        #region ComboBox Styling

        /// <summary>
        /// Applies modern styling to a ComboBox.
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = BackgroundLight;
            comboBox.ForeColor = TextPrimary;
            comboBox.Font = FontNormal;
        }

        #endregion

        #region Label Styling

        /// <summary>
        /// Applies title label styling.
        /// </summary>
        public static void ApplyTitleLabelStyle(Label label)
        {
            label.Font = FontTitle;
            label.ForeColor = PrimaryColor;
        }

        /// <summary>
        /// Applies subtitle label styling.
        /// </summary>
        public static void ApplySubtitleLabelStyle(Label label)
        {
            label.Font = FontSubtitle;
            label.ForeColor = TextPrimary;
        }

        /// <summary>
        /// Applies header label styling.
        /// </summary>
        public static void ApplyHeaderLabelStyle(Label label)
        {
            label.Font = FontHeader;
            label.ForeColor = TextPrimary;
        }

        #endregion

        #region Panel Styling

        /// <summary>
        /// Applies card panel styling with subtle shadow effect.
        /// </summary>
        public static void ApplyCardPanelStyle(Panel panel, int cornerRadius = 10)
        {
            panel.BackColor = BackgroundCard;
            panel.Padding = new Padding(15);
            ApplyRoundedCorners(panel, cornerRadius);
        }

        /// <summary>
        /// Creates a shadow panel to place behind a card for depth effect.
        /// </summary>
        public static Panel CreateShadowPanel(Panel mainPanel, int offset = 4)
        {
            Panel shadowPanel = new Panel
            {
                Location = new Point(mainPanel.Left + offset, mainPanel.Top + offset),
                Size = mainPanel.Size,
                BackColor = Color.FromArgb(30, 0, 0, 0)
            };
            ApplyRoundedCorners(shadowPanel, 10);
            return shadowPanel;
        }

        #endregion

        #region GroupBox Styling

        /// <summary>
        /// Applies modern styling to a GroupBox.
        /// </summary>
        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            groupBox.Font = FontHeader;
            groupBox.ForeColor = PrimaryColor;
            groupBox.BackColor = BackgroundWhite;
        }

        #endregion

        #region TabControl Styling

        /// <summary>
        /// Applies modern styling to a TabControl.
        /// </summary>
        public static void ApplyTabControlStyle(TabControl tabControl)
        {
            tabControl.Font = FontNormal;
            tabControl.Padding = new Point(15, 8);

            foreach (TabPage tab in tabControl.TabPages)
            {
                tab.BackColor = BackgroundWhite;
                tab.Padding = new Padding(10);
            }
        }

        #endregion

        #region MenuStrip Styling

        /// <summary>
        /// Applies modern styling to a MenuStrip.
        /// </summary>
        public static void ApplyMenuStripStyle(MenuStrip menuStrip)
        {
            menuStrip.BackColor = SecondaryColor;
            menuStrip.ForeColor = TextLight;
            menuStrip.Font = FontNormal;
            menuStrip.Padding = new Padding(8, 4, 0, 4);

            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                ApplyMenuItemStyle(item);
            }
        }

        private static void ApplyMenuItemStyle(ToolStripMenuItem menuItem)
        {
            menuItem.ForeColor = TextLight;
            menuItem.BackColor = SecondaryColor;
            menuItem.Padding = new Padding(12, 6, 12, 6);

            menuItem.MouseEnter += (s, e) => menuItem.BackColor = SecondaryLight;
            menuItem.MouseLeave += (s, e) => menuItem.BackColor = SecondaryColor;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    subMenuItem.ForeColor = TextPrimary;
                    subMenuItem.BackColor = BackgroundWhite;
                    subMenuItem.Padding = new Padding(10, 6, 10, 6);
                    ApplyMenuItemStyle(subMenuItem);
                }
            }
        }

        #endregion

        #region ContextMenuStrip Styling

        /// <summary>
        /// Applies modern styling to a ContextMenuStrip.
        /// </summary>
        public static void ApplyContextMenuStyle(ContextMenuStrip contextMenu)
        {
            contextMenu.BackColor = BackgroundWhite;
            contextMenu.ForeColor = TextPrimary;
            contextMenu.Font = FontNormal;
            contextMenu.Padding = new Padding(0, 4, 0, 4);
            contextMenu.ShowImageMargin = true;

            foreach (ToolStripItem item in contextMenu.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = BackgroundWhite;
                    menuItem.ForeColor = TextPrimary;
                    menuItem.Padding = new Padding(8, 6, 8, 6);
                }
            }
        }

        #endregion

        #region LinkLabel Styling

        /// <summary>
        /// Applies modern styling to a LinkLabel.
        /// </summary>
        public static void ApplyLinkLabelStyle(LinkLabel linkLabel)
        {
            linkLabel.LinkColor = PrimaryColor;
            linkLabel.ActiveLinkColor = PrimaryDark;
            linkLabel.VisitedLinkColor = PrimaryColor;
            linkLabel.Font = FontNormal;
        }

        #endregion

        #region CheckBox Styling

        /// <summary>
        /// Applies modern styling to a CheckBox.
        /// </summary>
        public static void ApplyCheckBoxStyle(CheckBox checkBox)
        {
            checkBox.ForeColor = TextPrimary;
            checkBox.Font = FontNormal;
        }

        #endregion

        #region PictureBox Styling

        /// <summary>
        /// Applies circular styling to a PictureBox (for profile images).
        /// </summary>
        public static void ApplyCircularPictureBoxStyle(PictureBox pictureBox)
        {
            int radius = Math.Min(pictureBox.Width, pictureBox.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, radius, radius);
            pictureBox.Region = new Region(path);
        }

        /// <summary>
        /// Applies rounded rectangle styling to a PictureBox.
        /// </summary>
        public static void ApplyRoundedPictureBoxStyle(PictureBox pictureBox, int cornerRadius = 10)
        {
            ApplyRoundedCorners(pictureBox, cornerRadius);
        }

        #endregion

        #region Graphics Helpers

        /// <summary>
        /// Creates a rounded rectangle GraphicsPath.
        /// </summary>
        public static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
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

        /// <summary>
        /// Creates a linear gradient brush for backgrounds.
        /// </summary>
        public static LinearGradientBrush CreateGradientBrush(Rectangle rect, Color startColor, Color endColor, float angle = 90f)
        {
            return new LinearGradientBrush(rect, startColor, endColor, angle);
        }

        /// <summary>
        /// Draws a subtle shadow around a control.
        /// </summary>
        public static void DrawShadow(Graphics g, Rectangle rect, int shadowOffset = 4, int shadowAlpha = 30)
        {
            using (var shadowBrush = new SolidBrush(Color.FromArgb(shadowAlpha, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, new Rectangle(rect.X + shadowOffset, rect.Y + shadowOffset, rect.Width, rect.Height));
            }
        }

        #endregion
    }
}
