using DVLD.Classes;

using DVLD.People;
using DVLD.Properties;
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

namespace DVLD.Controls.ApplicationControls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private clsApplication _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
            _ApplyModernTheme();
        }
        
        private void _ApplyModernTheme()
        {
            // Apply theme to the control
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style GroupBox
            groupBox1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular);
            groupBox1.ForeColor = clsUITheme.TitleColor;
            groupBox1.BackColor = clsUITheme.SurfaceColor;
            
            // Style static labels (captions)
            _StyleCaptionLabels();
            
            // Style value labels
            _StyleValueLabels();
            
            // Style link label
            clsUITheme.StyleLinkLabel(llViewPersonInfo);
        }
        
        private void _StyleCaptionLabels()
        {
            Label[] captionLabels = { label4, label3, label10, label8, label5, label12, label1, label2 };
            foreach (Label lbl in captionLabels)
            {
                lbl.Font = clsUITheme.LabelFont;
                lbl.ForeColor = clsUITheme.TextSecondaryColor;
            }
        }
        
        private void _StyleValueLabels()
        {
            Label[] valueLabels = { lblApplicationID, lblStatus, lblType, lblApplicant, lblDate, lblStatusDate, lblCreatedByUser, lblFees };
            foreach (Label lbl in valueLabels)
            {
                lbl.Font = clsUITheme.BodyBoldFont;
                lbl.ForeColor = clsUITheme.TextPrimaryColor;
            }
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblFees.Text = clsFormat.FormatMoney(_Application.PaidFees);
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();

            //Refresh
            LoadApplicationInfo(_ApplicationID);

        }
    }
}
