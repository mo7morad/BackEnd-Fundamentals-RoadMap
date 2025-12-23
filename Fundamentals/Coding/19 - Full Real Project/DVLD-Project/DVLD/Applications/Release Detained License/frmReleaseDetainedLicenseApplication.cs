using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD.Licenses.Controls;
using DVLD.Licenses.International_License;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.Rlease_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _SelectedLicenseID = -1;
        private float _applicationFees = 0f;
        private float _fineFees = 0f;
        private float _totalFees = 0f;

        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            ApplyModernStyle();
            _SelectedLicenseID = LicenseID;
       
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.BackColor = clsUITheme.BackgroundLight;
            this.Font = clsUITheme.FontNormal;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title styling
            if (this.Controls.Find("lblTitle", true).Length > 0)
                clsUITheme.ApplyTitleLabelStyle((Label)this.Controls.Find("lblTitle", true)[0]);

            // Button styling
            clsUITheme.ApplySuccessButtonStyle(btnRelease);
            clsUITheme.ApplySecondaryButtonStyle(btnClose);

            // GroupBox styling
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    clsUITheme.ApplyGroupBoxStyle(gb);
                }
            }

            // Label styling for data labels
            StyleLabel(lblApplicationID);
            StyleLabel(lblDetainID);
            StyleLabel(lblLicenseID);
            StyleLabel(lblDetainDate);
            StyleLabel(lblFineFees);
            StyleLabel(lblApplicationFees);
            StyleLabel(lblTotalFees);
            StyleLabel(lblCreatedByUser);

            // Link label styling
            clsUITheme.ApplyLinkLabelStyle(llShowLicenseHistory);
            clsUITheme.ApplyLinkLabelStyle(llShowLicenseInfo);
        }

        private void StyleLabel(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbl.ForeColor = clsUITheme.PrimaryColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained())
            {
                MessageBox.Show("Selected License is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _applicationFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            lblApplicationFees.Text = clsFormat.FormatMoney(_applicationFees);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
           
            lblCreatedByUser.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            _fineFees = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees;
            lblFineFees.Text = clsFormat.FormatMoney(_fineFees);
            _totalFees = _applicationFees + _fineFees;
            lblTotalFees.Text = clsFormat.FormatMoney(_totalFees);

            btnRelease.Enabled = true;
        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
             new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm =
           new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID);

            lblApplicationID.Text = ApplicationID.ToString();

            if (ApplicationID == -1)
            {
                MessageBox.Show("Failed to release the Detained License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }
    }
}
