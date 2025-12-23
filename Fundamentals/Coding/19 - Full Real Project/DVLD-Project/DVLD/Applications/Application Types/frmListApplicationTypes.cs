using DVLD.GlobalClasses;
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            // Apply modern UI theme
            _ApplyModernTheme();
            
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();

            dgvApplicationTypes.Columns[0].HeaderText = "ID";
            dgvApplicationTypes.Columns[0].Width = 110;
         
            dgvApplicationTypes.Columns[1].HeaderText = "Title";
            dgvApplicationTypes.Columns[1].Width = 400;
       
            dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            dgvApplicationTypes.Columns[2].Width = 100;
            dgvApplicationTypes.Columns[2].DefaultCellStyle.Format = "0.00$";

           
        }
        
        private void _ApplyModernTheme()
        {
            // Apply theme to form
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style title
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = clsUITheme.TitleColor;
            
            // Style labels
            label2.Font = clsUITheme.LabelFont;
            label2.ForeColor = clsUITheme.TextSecondaryColor;
            lblRecordsCount.Font = clsUITheme.BodyBoldFont;
            lblRecordsCount.ForeColor = clsUITheme.TextPrimaryColor;
            
            // Style DataGridView
            clsUITheme.StyleDataGridView(dgvApplicationTypes);
            
            // Style button
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
            
            // Style context menu
            clsUITheme.StyleContextMenuStrip(cmsApplicationTypes);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageApplicationTypes_Load(null, null);

        }
    }
}
