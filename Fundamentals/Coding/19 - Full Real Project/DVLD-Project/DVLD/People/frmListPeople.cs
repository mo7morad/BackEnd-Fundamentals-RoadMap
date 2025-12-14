using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DVLD.Classes;
using DVLD_Buisness;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
        
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "genderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "genderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        public frmListPeople()
        {
            InitializeComponent();
            this.Size = new Size(1200, 700);
            this.MinimumSize = new Size(900, 500);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            btnAddPerson.FlatAppearance.BorderSize = 0;
            btnAddPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            btnAddPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 101, 192);

            btnAddPerson.MouseEnter += (s, e) => btnAddPerson.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            btnAddPerson.MouseLeave += (s, e) => btnAddPerson.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);

            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 101, 192);

            btnClose.MouseEnter += (s, e) => btnClose.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

            dgvPeople.EnableHeadersVisualStyles = false;
            dgvPeople.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            dgvPeople.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvPeople.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dgvPeople.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvPeople.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F);
            dgvPeople.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            dgvPeople.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvPeople.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
            dgvPeople.BorderStyle = BorderStyle.None;
            dgvPeople.GridColor = System.Drawing.Color.LightGray;

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }
        }
    
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Gender":
                    FilterColumn = "genderCaption";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
       
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            panelFilterUnderline.Visible = (cbFilterBy.Text != "None");

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
            }
            else
                txtFilterValue.Enabled = true;

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }
                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddUpdatePerson();
            frm1.ShowDialog();
            _RefreshPeoplList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
