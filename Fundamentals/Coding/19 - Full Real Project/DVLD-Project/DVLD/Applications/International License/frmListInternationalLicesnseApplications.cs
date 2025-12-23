using DVLD.Licenses.International_License;
using DVLD.Licenses.International_Licenses;
using DVLD.People;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.International_License
{
    public partial class frmListInternationalLicesnseApplications : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListInternationalLicesnseApplications_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilterBy.SelectedIndex= 0;

            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
                   lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;

            }
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            //refresh
            frmListInternationalLicesnseApplications_Load(null,null);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
          

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }


          
            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
           
            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow numbers only becasue all fiters are numbers.
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
