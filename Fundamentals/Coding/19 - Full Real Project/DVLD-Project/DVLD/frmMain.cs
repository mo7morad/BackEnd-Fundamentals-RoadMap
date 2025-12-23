using DVLD.Applications;
using DVLD.Applications.Detain_License;
using DVLD.Applications.International_License;
using DVLD.Applications.ReplaceLostOrDamagedLicense;
using DVLD.Applications.Rlease_Detained_License;
using DVLD.Classes;
using DVLD.Drivers;
using DVLD.Licenses;
using DVLD.Licenses.International_License;
using DVLD.Login;
using DVLD.People;
using DVLD.Tests;
using DVLD.User;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace DVLD
{

    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        private bool _isSigningOut = false;

        public frmMain( frmLogin frm )
        {
            InitializeComponent();
            _frmLogin= frm;
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.BackColor = clsUITheme.BackgroundLight;
            this.Font = clsUITheme.FontNormal;

            // MenuStrip styling - modern dark theme
            msMainMenue.BackColor = clsUITheme.SecondaryColor;
            msMainMenue.ForeColor = clsUITheme.TextLight;
            msMainMenue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            msMainMenue.Padding = new Padding(10, 5, 0, 5);
            msMainMenue.Renderer = new ModernMenuRenderer();

            // Apply style to all menu items
            foreach (ToolStripItem item in msMainMenue.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    ApplyMenuItemStyle(menuItem);
                }
            }

            // Status label styling
            lblLoggedInUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLoggedInUser.ForeColor = clsUITheme.PrimaryColor;
            lblLoggedInUser.BackColor = Color.Transparent;
        }

        private void ApplyMenuItemStyle(ToolStripMenuItem menuItem)
        {
            menuItem.ForeColor = clsUITheme.TextLight;
            menuItem.Padding = new Padding(10, 8, 10, 8);

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    subMenuItem.ForeColor = clsUITheme.TextPrimary;
                    subMenuItem.BackColor = clsUITheme.BackgroundWhite;
                    subMenuItem.Padding = new Padding(8, 4, 8, 4);
                    ApplyMenuItemStyle(subMenuItem);
                }
            }
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = clsUITheme.BackgroundLight;
            lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSigningOut = true;
            clsGlobal.CurrentUser = null;
            _frmLogin.ResetLoginForm();
            _frmLogin.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();

        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();
        }

      
        private void vehiclesLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();

        }

      

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications();
            frm.ShowDialog();

        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();

        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm= new frmReleaseDetainedLicenseApplication();   
            frm.ShowDialog();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Only close the login form if we're not signing out
            if (!_isSigningOut)
            {
                _frmLogin.Close();
            }
        }
    }

    /// <summary>
    /// Custom menu renderer for modern appearance
    /// </summary>
    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernMenuColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
            
            if (e.Item.Selected || e.Item.Pressed)
            {
                using (SolidBrush brush = new SolidBrush(clsUITheme.SecondaryLight))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else if (e.Item.Owner is MenuStrip)
            {
                using (SolidBrush brush = new SolidBrush(clsUITheme.SecondaryColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(clsUITheme.BackgroundWhite))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
                if (e.Item.Selected)
                {
                    using (SolidBrush brush = new SolidBrush(clsUITheme.BackgroundHover))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Owner is MenuStrip)
            {
                e.TextColor = clsUITheme.TextLight;
            }
            else
            {
                e.TextColor = clsUITheme.TextPrimary;
            }
            base.OnRenderItemText(e);
        }
    }

    /// <summary>
    /// Custom color table for modern menu appearance
    /// </summary>
    public class ModernMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder => clsUITheme.BorderLight;
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuItemSelected => clsUITheme.BackgroundHover;
        public override Color MenuItemSelectedGradientBegin => clsUITheme.SecondaryLight;
        public override Color MenuItemSelectedGradientEnd => clsUITheme.SecondaryLight;
        public override Color MenuItemPressedGradientBegin => clsUITheme.SecondaryDark;
        public override Color MenuItemPressedGradientEnd => clsUITheme.SecondaryDark;
        public override Color MenuStripGradientBegin => clsUITheme.SecondaryColor;
        public override Color MenuStripGradientEnd => clsUITheme.SecondaryColor;
        public override Color ToolStripDropDownBackground => clsUITheme.BackgroundWhite;
        public override Color ImageMarginGradientBegin => clsUITheme.BackgroundLight;
        public override Color ImageMarginGradientMiddle => clsUITheme.BackgroundLight;
        public override Color ImageMarginGradientEnd => clsUITheme.BackgroundLight;
        public override Color SeparatorDark => clsUITheme.BorderLight;
        public override Color SeparatorLight => clsUITheme.BackgroundWhite;
    }
}
