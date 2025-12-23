using DVLD.Controls;
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

namespace DVLD.Licenses.International_License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
           

        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;   
        }
        
        private void _ApplyModernTheme()
        {
            this.BackColor = clsUITheme.SurfaceColor;
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            _ApplyModernTheme();

            if (_PersonID!= -1)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            } 
                else
            {
                ctrlPersonCardWithFilter1.Enabled= true;
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            
           
            
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID= obj;
            if (_PersonID==-1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
            ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
