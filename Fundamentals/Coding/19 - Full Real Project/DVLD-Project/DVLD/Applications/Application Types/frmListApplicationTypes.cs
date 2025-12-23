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

namespace DVLD.Applications
{
    public partial class frmManageApplicationTypes : Form
    {
        private  DataTable _dtAllApplicationTypes;

        public frmManageApplicationTypes()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.Size = new Size(750, 500);
            this.MinimumSize = new Size(650, 400);
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

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();

            // Apply modern DataGridView styling
            clsUITheme.ApplyDataGridViewStyle(dgvApplicationTypes);

            if (dgvApplicationTypes.Columns.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 80;
             
                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 350;
           
                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;
                dgvApplicationTypes.Columns[2].DefaultCellStyle.Format = "0.00$";
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageApplicationTypes_Load(null, null);
        }
    }
}
