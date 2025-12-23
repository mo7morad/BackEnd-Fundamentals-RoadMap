using DVLD.Applications;
using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtAllTestTypes;

        public frmListTestTypes()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.Size = new Size(900, 500);
            this.MinimumSize = new Size(750, 400);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = clsUITheme.BackgroundLight;
            this.Font = clsUITheme.FontNormal;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title styling
            if (this.Controls.Find("lblTitle", true).Length > 0)
                clsUITheme.ApplyTitleLabelStyle((Label)this.Controls.Find("lblTitle", true)[0]);

            // Button styling
            clsUITheme.ApplyPrimaryButtonStyle(btnClose);

            // Records count labels
            if (this.Controls.Find("label2", true).Length > 0)
            {
                var lbl = (Label)this.Controls.Find("label2", true)[0];
                lbl.Font = clsUITheme.FontHeader;
                lbl.ForeColor = clsUITheme.TextPrimary;
            }
            lblRecordsCount.Font = clsUITheme.FontHeader;
            lblRecordsCount.ForeColor = clsUITheme.PrimaryColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();

            // Apply modern DataGridView styling
            clsUITheme.ApplyDataGridViewStyle(dgvTestTypes);

            if (dgvTestTypes.Columns.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 80;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 180;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 350;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;
                dgvTestTypes.Columns[3].DefaultCellStyle.Format = "0.00$";
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestTypes_Load(null, null);
        }
    }
}
