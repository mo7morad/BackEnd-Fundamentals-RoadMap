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

namespace DVLD.DriverLicense
{
    public partial class frmShowLicenseInfo : Form
    {
        private int _LicenseID;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID= LicenseID;

        }
        
        private void _ApplyModernTheme()
        {
            this.BackColor = clsUITheme.SurfaceColor;
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            _ApplyModernTheme();
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);

        }
    }
}
