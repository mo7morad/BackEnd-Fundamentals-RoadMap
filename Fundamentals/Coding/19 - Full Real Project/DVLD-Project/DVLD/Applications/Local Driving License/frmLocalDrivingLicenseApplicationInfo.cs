using DVLD.Controls;
using DVLD.GlobalClasses;
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
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _ApplicationID=-1;

        public frmLocalDrivingLicenseApplicationInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            this.Size = new Size(800, 600);
            this.MinimumSize = new Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            // Apply modern UI theme
            _ApplyModernTheme();
            
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_ApplicationID);
        }
        
        private void _ApplyModernTheme()
        {
            // Apply theme to form
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style button
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
        }
    }
}
