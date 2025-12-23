using DVLD.GlobalClasses;
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

namespace DVLD.Tests
{
    public partial class frmScheduleTest: Form
    {


        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID=-1;


        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int AppointmentID=-1)
        {
            
            InitializeComponent();
            
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
           

        }
        
        private void _ApplyModernTheme()
        {
            this.BackColor = clsUITheme.SurfaceColor;
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _ApplyModernTheme();
            ctrlScheduleTest1.TestTypeID= _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
