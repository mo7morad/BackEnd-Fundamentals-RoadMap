using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmUserInfo : Form
    {
        private int _UserID;

        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.Size = new Size(900, 650);
            this.MinimumSize = new Size(800, 550);
            this.BackColor = clsUITheme.BackgroundLight;
            this.Font = clsUITheme.FontNormal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Title styling
            if (this.Controls.Find("lblTitle", true).Length > 0)
                clsUITheme.ApplyTitleLabelStyle((Label)this.Controls.Find("lblTitle", true)[0]);

            // Button styling
            clsUITheme.ApplyPrimaryButtonStyle(btnClose);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
        }
    }
}
