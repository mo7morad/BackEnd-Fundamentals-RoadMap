using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD.Classes;
using DVLD.GlobalClasses;
using static System.Net.Mime.MediaTypeNames;
using DVLD.Tests;
using DVLD.DriverLicense;

namespace DVLD.Controls.ApplicationControls
{
    public partial class ctrlDrivingLicenseApplicationInfo: UserControl
    {

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
            _ApplyModernTheme();
        }
        
        private void _ApplyModernTheme()
        {
            // Style GroupBox
            clsUITheme.StyleGroupBox(groupBox1);
            
            // Style caption labels (label4=L.D.L.AppID, label10=AppliedFor, label2=PassedTests)
            clsUITheme.StyleLabel(label4);
            clsUITheme.StyleLabel(label10);
            clsUITheme.StyleLabel(label2);
            
            // Style value labels
            lblLocalDrivingLicenseApplicationID.Font = clsUITheme.BodyFont;
            lblLocalDrivingLicenseApplicationID.ForeColor = clsUITheme.TextSecondaryColor;
            lblAppliedFor.Font = clsUITheme.BodyFont;
            lblAppliedFor.ForeColor = clsUITheme.TextSecondaryColor;
            lblPassedTests.Font = clsUITheme.BodyFont;
            lblPassedTests.ForeColor = clsUITheme.TextSecondaryColor;
            
            // Style link label
            clsUITheme.StyleLinkLabel(llShowLicenceInfo);
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                

                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
              
                _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
                _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
           
            //incase there is license enable the show link.
            llShowLicenceInfo.Enabled = (_LicenseID != -1);

           
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find( _LocalDrivingLicenseApplication.LicenseClassID).ClassName ;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() +"/3" ; 
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";


        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            frm.ShowDialog();

        }
    }
}
