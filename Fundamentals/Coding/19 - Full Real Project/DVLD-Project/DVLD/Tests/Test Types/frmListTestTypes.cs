using DVLD.Applications;

using DVLD_Buisness;
using System;
using DVLD.Classes;
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
            this.Size = new Size(900, 600);
            this.MinimumSize = new Size(700, 500);
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        
        private void _ApplyModernTheme()
        {
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style title
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = clsUITheme.TitleColor;
            
            // Style DataGridView
            clsUITheme.StyleDataGridView(dgvTestTypes);
            
            // Style context menu
            clsUITheme.StyleContextMenuStrip(cmsTestTypes);
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _ApplyModernTheme();
            
            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();

            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 120;

            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 200;

            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 400;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;
            dgvTestTypes.Columns[3].DefaultCellStyle.Format = "0.00$";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
           frm.ShowDialog();
            frmListTestTypes_Load(null, null);

        }
    }
}
