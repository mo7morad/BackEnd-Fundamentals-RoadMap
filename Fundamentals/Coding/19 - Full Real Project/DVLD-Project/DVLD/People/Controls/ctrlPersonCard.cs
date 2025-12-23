using DVLD.Properties;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using DVLD.People;
using DVLD.Classes;

namespace DVLD.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        private int  _PersonID=-1;

        public int PersonID   
        {
            get { return _PersonID; }   
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Apply modern styling to the control
            this.BackColor = clsUITheme.BackgroundWhite;
            
            // Style the groupbox
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.ForeColor = clsUITheme.PrimaryColor;
            groupBox1.BackColor = clsUITheme.BackgroundWhite;
            
            // Style all labels
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 11F);
                    
                    // Bold labels (field names)
                    if (lbl.Name.StartsWith("label") || lbl.Name == "label22")
                    {
                        lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        lbl.ForeColor = clsUITheme.TextPrimary;
                    }
                    
                    // Full name label - special styling
                    if (lbl == lblFullName)
                    {
                        lbl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                        lbl.ForeColor = clsUITheme.PrimaryColor;
                    }
                }
            }
            
            // Style the link label
            clsUITheme.ApplyLinkLabelStyle(llEditPersonInfo);
            
            // Style the person image with rounded corners
            pbPersonImage.BorderStyle = BorderStyle.None;
            clsUITheme.ApplyRoundedPictureBoxStyle(pbPersonImage, 15);
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            if (_Person.gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation= ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text=_Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblgender.Text = _Person.gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text= clsCountry.Find( _Person.NationalityCountryID).CountryName ;
            lblAddress.Text= _Person.Address;
            _LoadPersonImage();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbgender.Image = Resources.Man_32;
            lblgender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson( _PersonID );
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }
    }
}
