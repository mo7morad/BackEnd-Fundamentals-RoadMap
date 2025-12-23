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
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Buisness.clsApplication;

namespace DVLD.Applications.International_License
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        
        private int _InternationalLicenseID = -1;
      
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1) 
            
            {
                return;
            }

            

          
            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssueLicense.Enabled = false;
                return;
            }

            btnIssueLicense.Enabled = true;

        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            // Apply modern UI theme
            _ApplyModernTheme();

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblFees.Text = clsFormat.FormatMoney(clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees);
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
            Label[] captionLabels = { label4, label5, label6, label8, label10, label12, label1, label2 };
            foreach (Label lbl in captionLabels)
            {
                lbl.Font = clsUITheme.LabelFont;
                lbl.ForeColor = clsUITheme.TextSecondaryColor;
            }
            
            // Style value labels
            Label[] valueLabels = { lblApplicationID, lblApplicationDate, lblIssueDate, lblExpirationDate, 
                                   lblInternationalLicenseID, lblLocalLicenseID, lblFees, lblCreatedByUser };
            foreach (Label lbl in valueLabels)
            {
                lbl.Font = clsUITheme.BodyBoldFont;
                lbl.ForeColor = clsUITheme.TextPrimaryColor;
            }
            
            // Style buttons
            clsUITheme.StyleButton(btnIssueLicense, clsUITheme.ButtonStyle.Primary);
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
            
            // Style link labels
            clsUITheme.StyleLinkLabel(llShowLicenseHistory);
            clsUITheme.StyleLinkLabel(llShowLicenseInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
           
            if ( MessageBox.Show("Are you sure you want to issue the license?","Confirm",MessageBoxButtons.YesNo ,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }

           

          


           clsInternationalLicense InternationalLicense= new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

           
            InternationalLicense.DriverID= ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate= DateTime.Now;
            InternationalLicense.ExpirationDate= DateTime.Now.AddYears(1);
           
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString() , "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;


        }

        private void llShowDriverLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

            frmShowPersonLicenseHistory  frm = 
                new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
              new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
    }
}
