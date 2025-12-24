using System;
using DVLD.Classes;
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
    public partial class frmUserInfo: Form
    {
        private int _UserID;

        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID=UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            _ApplyModernTheme();
            ctrlUserCard1.LoadUserInfo(_UserID);
        }
        
        private void _ApplyModernTheme()
        {
            this.BackColor = clsUITheme.SurfaceColor;
            clsUITheme.StyleButton(btnClose, clsUITheme.ButtonStyle.Secondary);
        }
    }
}
