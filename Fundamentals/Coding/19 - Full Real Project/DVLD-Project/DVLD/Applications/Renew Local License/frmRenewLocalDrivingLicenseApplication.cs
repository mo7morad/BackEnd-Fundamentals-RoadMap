using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD.GlobalClasses;
using DVLD.Licenses.International_License;
using DVLD.Licenses.International_Licenses;
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

namespace DVLD.Licenses
{
    public partial class frmRenewLocalDrivingLicenseApplication: Form
    {
        private int _NewLicenseID = -1;
        private float _applicationFees = 0f;
        private float _licenseFees = 0f;
        private float _totalFees = 0f;
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            // Apply modern UI theme
            _ApplyModernTheme();
            
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();


            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            _applicationFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            lblApplicationFees.Text = clsFormat.FormatMoney(_applicationFees);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

        }
        
        private void _ApplyModernTheme()
        {
            // Apply theme to form
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style title
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = clsUITheme.TitleColor;
            
            // Style GroupBox
            gpApplicationInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular);
            gpApplicationInfo.ForeColor = clsUITheme.TitleColor;
            gpApplicationInfo.BackColor = clsUITheme.SurfaceColor;
            
            // Style caption labels
            Label[] captionLabels = { label4, label5, label6, label8, label10, label12, label1, label2, label3, label7, label9 };
            foreach (Label lbl in captionLabels)
            {
                lbl.Font = clsUITheme.LabelFont;
                lbl.ForeColor = clsUITheme.TextSecondaryColor;
            }
            
            // Style value labels
            Label[] valueLabels = { lblApplicationID, lblApplicationDate, lblIssueDate, lblExpirationDate, 
                                   lblRenewedLicenseID, lblOldLicenseID, lblApplicationFees, lblLicenseFees, 
                                   lblTotalFees, lblCreatedByUser };
            foreach (Label lbl in valueLabels)
            {
                lbl.Font = clsUITheme.BodyBoldFont;
                lbl.ForeColor = clsUITheme.TextPrimaryColor;
            }
            
            // Style TextBox
            clsUITheme.StyleTextBox(txtNotes);
            
            // Style buttons
            clsUITheme.StyleButton(btnRenewLicense, clsUITheme.ButtonStyle.Primary);
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
            
            // Style link labels
            clsUITheme.StyleLinkLabel(llShowLicenseHistory);
            clsUITheme.StyleLinkLabel(llShowLicenseInfo);
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            int DefaultValidityLength = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            _licenseFees = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees;
            lblLicenseFees.Text = clsFormat.FormatMoney(_licenseFees);
            _totalFees = _applicationFees + _licenseFees;
            lblTotalFees.Text = clsFormat.FormatMoney(_totalFees);
            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;


            //check the license is not Expired.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate)    
                    ,"Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            //check the license is not Expired.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license." 
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }


           
            btnRenewLicense.Enabled = true;

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

           
            clsLicense NewLicense = 
                ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(),
                clsGlobal.CurrentUser.UserID);

            if (NewLicense==null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text= NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenewLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;

            

        }

        private void frmRenewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
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
           new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
