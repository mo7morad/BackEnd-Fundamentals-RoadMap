using DVLD.Classes;
using DVLD.GlobalClasses;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTakeTest: Form
    {
        private int _AppointmentID;
        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
        private clsTest _Test;


        public frmTakeTest(int AppointmentID,clsTestType.enTestType TestType )
        {
            InitializeComponent();
            _AppointmentID= AppointmentID;
            _TestType = TestType;

        }
        
        private void _ApplyModernTheme()
        {
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style labels
            clsUITheme.StyleLabel(label8);
            clsUITheme.StyleLabel(label10);
            
            // Style textbox
            clsUITheme.StyleTextBox(txtNotes);
            
            // Style buttons
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
            clsUITheme.StyleButton(btnSave, clsUITheme.ButtonStyle.Primary);
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _ApplyModernTheme();
            
            ctrlSecheduledTest1.TestTypeID = _TestType;

            ctrlSecheduledTest1.LoadInfo(_AppointmentID);
            
            if (ctrlSecheduledTest1.TestAppointmentID==-1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;


            int _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = clsTest.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                   txtNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rbFail.Enabled=false; 
                rbPass.Enabled=false;
            }
            
            else
                _Test = new clsTest();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

          if (  MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.No
             )
            {
                return;
            }

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID=clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
