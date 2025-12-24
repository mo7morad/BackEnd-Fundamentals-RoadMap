using DVLD.Classes;

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

namespace DVLD.Applications
{
    public partial class frmEditApplicationType : Form
    {

        private int _ApplicationTypeID=-1;
        private clsApplicationType _ApplicationType;

        public frmEditApplicationType(int ApplicationTypeID )
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID; 

        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            // Apply modern UI theme
            _ApplyModernTheme();
            
            lblApplicationTypeID.Text=_ApplicationTypeID.ToString();

            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType!=null)
            {
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text = _ApplicationType.Fees.ToString();


            }

        }
        
        private void _ApplyModernTheme()
        {
            // Apply theme to form
            this.BackColor = clsUITheme.SurfaceColor;
            
            // Style title
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = clsUITheme.TitleColor;
            
            // Style labels
            label4.Font = clsUITheme.LabelFont;
            label4.ForeColor = clsUITheme.TextSecondaryColor;
            label1.Font = clsUITheme.LabelFont;
            label1.ForeColor = clsUITheme.TextSecondaryColor;
            label2.Font = clsUITheme.LabelFont;
            label2.ForeColor = clsUITheme.TextSecondaryColor;
            
            // Style value label
            lblApplicationTypeID.Font = clsUITheme.BodyBoldFont;
            lblApplicationTypeID.ForeColor = clsUITheme.TextPrimaryColor;
            
            // Style textboxes
            clsUITheme.StyleTextBox(txtTitle);
            clsUITheme.StyleTextBox(txtFees);
            
            // Style buttons
            clsUITheme.StyleButton(btnSave, clsUITheme.ButtonStyle.Primary);
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _ApplicationType.Title= txtTitle.Text.Trim();
            _ApplicationType.Fees = Convert.ToSingle( txtFees.Text.Trim());


            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
           
          
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            };


        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {


            
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            };

            
            if (!clsValidatoin.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            };

        }

    }
}
