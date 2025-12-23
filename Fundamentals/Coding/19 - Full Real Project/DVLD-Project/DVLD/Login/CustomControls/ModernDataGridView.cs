using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Login.CustomControls
{
    /// <summary>
    /// A modern DataGridView with consistent styling, hover effects, and smooth appearance.
    /// </summary>
    public class ModernDataGridView : DataGridView
    {
        #region Private Fields

        private Color _headerBackColor = Color.FromArgb(245, 245, 245);
        private Color _headerForeColor = Color.FromArgb(33, 33, 33);
        private Color _alternateRowColor = Color.FromArgb(250, 250, 252);
        private Color _selectionBackColor = Color.FromArgb(232, 240, 254);
        private Color _selectionForeColor = Color.FromArgb(33, 33, 33);
        private Color _hoverBackColor = Color.FromArgb(232, 240, 254);
        private Color _gridLineColor = Color.FromArgb(230, 230, 230);
        private int _rowHeight = 40;
        private int _headerHeight = 45;

        #endregion

        #region Constructor

        public ModernDataGridView()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint, true);

            ApplyModernStyle();
        }

        #endregion

        #region Properties

        [Category("Modern Appearance")]
        [Description("The background color of the header row.")]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set { _headerBackColor = value; ApplyHeaderStyle(); }
        }

        [Category("Modern Appearance")]
        [Description("The text color of the header row.")]
        public Color HeaderForeColor
        {
            get => _headerForeColor;
            set { _headerForeColor = value; ApplyHeaderStyle(); }
        }

        [Category("Modern Appearance")]
        [Description("The background color of alternating rows.")]
        public Color AlternateRowColor
        {
            get => _alternateRowColor;
            set { _alternateRowColor = value; ApplyRowStyle(); }
        }

        [Category("Modern Appearance")]
        [Description("The background color of selected rows.")]
        public Color SelectionBackColor
        {
            get => _selectionBackColor;
            set { _selectionBackColor = value; ApplyRowStyle(); }
        }

        [Category("Modern Appearance")]
        [Description("The text color of selected rows.")]
        public Color SelectionForeColor
        {
            get => _selectionForeColor;
            set { _selectionForeColor = value; ApplyRowStyle(); }
        }

        [Category("Modern Appearance")]
        [Description("The background color when hovering over a row.")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set { _hoverBackColor = value; }
        }

        [Category("Modern Appearance")]
        [Description("The color of the grid lines.")]
        public Color GridLineColor
        {
            get => _gridLineColor;
            set { _gridLineColor = value; this.GridColor = value; }
        }

        [Category("Modern Appearance")]
        [Description("The height of each row.")]
        [DefaultValue(40)]
        public int RowHeight
        {
            get => _rowHeight;
            set { _rowHeight = value; this.RowTemplate.Height = value; }
        }

        [Category("Modern Appearance")]
        [Description("The height of the header row.")]
        [DefaultValue(45)]
        public int HeaderRowHeight
        {
            get => _headerHeight;
            set
            {
                _headerHeight = value;
                this.ColumnHeadersHeight = value;
            }
        }

        #endregion

        #region Style Application

        private void ApplyModernStyle()
        {
            // Basic settings
            this.BorderStyle = BorderStyle.None;
            this.BackgroundColor = Color.White;
            this.GridColor = _gridLineColor;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.EnableHeadersVisualStyles = false;
            this.RowHeadersVisible = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.ReadOnly = true;

            // Font
            this.Font = new Font("Segoe UI", 11F);

            ApplyHeaderStyle();
            ApplyRowStyle();

            // Set row height
            this.RowTemplate.Height = _rowHeight;
        }

        private void ApplyHeaderStyle()
        {
            // Header style
            this.ColumnHeadersDefaultCellStyle.BackColor = _headerBackColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = _headerForeColor;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = _headerBackColor;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = _headerForeColor;
            this.ColumnHeadersHeight = _headerHeight;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

        private void ApplyRowStyle()
        {
            // Default cell style
            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            this.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            this.DefaultCellStyle.SelectionBackColor = _selectionBackColor;
            this.DefaultCellStyle.SelectionForeColor = _selectionForeColor;
            this.DefaultCellStyle.Padding = new Padding(10, 6, 10, 6);

            // Alternating row style
            this.AlternatingRowsDefaultCellStyle.BackColor = _alternateRowColor;
            this.AlternatingRowsDefaultCellStyle.SelectionBackColor = _selectionBackColor;
            this.AlternatingRowsDefaultCellStyle.SelectionForeColor = _selectionForeColor;
        }

        #endregion

        #region Hover Effect

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            if (e.RowIndex >= 0 && e.RowIndex < this.Rows.Count)
            {
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor = _hoverBackColor;
            }
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            if (e.RowIndex >= 0 && e.RowIndex < this.Rows.Count)
            {
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : _alternateRowColor;
            }
        }

        #endregion

        #region Paint Override for Smooth Scrolling

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw a subtle bottom border
            using (Pen borderPen = new Pen(Color.FromArgb(224, 224, 224), 1))
            {
                e.Graphics.DrawLine(borderPen, 0, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        #endregion
    }
}
