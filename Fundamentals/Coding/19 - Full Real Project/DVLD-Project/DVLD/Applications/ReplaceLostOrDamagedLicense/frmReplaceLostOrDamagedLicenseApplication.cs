using DVLD.Classes;
using DVLD.DriverLicense;

using DVLD.Licenses.International_License;
using DVLD_Buisness;
using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static DVLD_Buisness.clsLicense;

namespace DVLD.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            // Apply modern UI theme
            _ApplyModernTheme();
            
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            rbDamagedLicense.Checked = true;
        }
        
        private void _ApplyModernTheme()
        {
            // Apply theme to form
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style title
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = clsUITheme.TitleColor;
            
            // Style GroupBoxes
            gpApplicationInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular);
            gpApplicationInfo.ForeColor = clsUITheme.TitleColor;
            gpApplicationInfo.BackColor = clsUITheme.SurfaceColor;
            
            gbReplacementFor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular);
            gbReplacementFor.ForeColor = clsUITheme.TitleColor;
            gbReplacementFor.BackColor = clsUITheme.SurfaceColor;
            
            // Style RadioButtons
            rbDamagedLicense.Font = clsUITheme.BodyFont;
            rbDamagedLicense.ForeColor = clsUITheme.TextPrimaryColor;
            rbLostLicense.Font = clsUITheme.BodyFont;
            rbLostLicense.ForeColor = clsUITheme.TextPrimaryColor;
            
            // Style caption labels
            Label[] captionLabels = { label4, label5, label10, label12, label1, label2 };
            foreach (Label lbl in captionLabels)
            {
                lbl.Font = clsUITheme.LabelFont;
                lbl.ForeColor = clsUITheme.TextSecondaryColor;
            }
            
            // Style value labels
            Label[] valueLabels = { lblApplicationID, lblApplicationDate, lblRreplacedLicenseID, 
                                   lblOldLicenseID, lblApplicationFees, lblCreatedByUser };
            foreach (Label lbl in valueLabels)
            {
                lbl.Font = clsUITheme.BodyBoldFont;
                lbl.ForeColor = clsUITheme.TextPrimaryColor;
            }
            
            // Style buttons
            clsUITheme.StyleButton(btnIssueReplacement, clsUITheme.ButtonStyle.Primary);
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
            
            // Style link labels
            clsUITheme.StyleLinkLabel(llShowLicenseHistory);
            clsUITheme.StyleLinkLabel(llShowLicenseInfo);
        }

        private async void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Damaged License";
            this.Text = lblTitle.Text;
            var appType = await clsApplicationType.FindAsync(_GetApplicationTypeID());
            var fees = appType?.Fees ?? 0f;
            lblApplicationFees.Text = clsFormat.FormatMoney(fees);
        }

        private async void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Lost License";
            this.Text = lblTitle.Text;
            var appType = await clsApplicationType.FindAsync(_GetApplicationTypeID());
            var fees = appType?.Fees ?? 0f;
            lblApplicationFees.Text = clsFormat.FormatMoney(fees);
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
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

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

        private async void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = await ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplaceAsync(_GetIssueReason(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblRreplacedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
