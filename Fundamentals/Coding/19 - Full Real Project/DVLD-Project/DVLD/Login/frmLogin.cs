using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        // Rounded corners and shadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // For form dragging
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // For form animation
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        // Animation constants
        const int AW_HOR_POSITIVE = 0x00000001;
        const int AW_HOR_NEGATIVE = 0x00000002;
        const int AW_VER_POSITIVE = 0x00000004;
        const int AW_VER_NEGATIVE = 0x00000008;
        const int AW_CENTER = 0x00000010;
        const int AW_HIDE = 0x00010000;
        const int AW_ACTIVATE = 0x00020000;
        const int AW_SLIDE = 0x00040000;
        const int AW_BLEND = 0x00080000;

        private string loggerSourceName = "DVLD App";
        private float currentOpacity = 0;

        public frmLogin()
        {
            InitializeComponent();

            // Apply rounded corners to the form
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Apply rounded corners to login button
            btnLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 10, 10));

            // Create text box with bottom border only
            ApplyTextBoxStyles();

            // Set the tooltips
            toolTip1.SetToolTip(txtUserName, "Enter your username");
            toolTip1.SetToolTip(txtPassword, "Enter your password");
            toolTip1.SetToolTip(btnClose, "Close the application");
            toolTip1.SetToolTip(btnLogin, "Login to the system");
        }

        private void ApplyTextBoxStyles()
        {
            // Apply custom styling for textboxes
            txtUserName.BackColor = Color.WhiteSmoke;
            txtPassword.BackColor = Color.WhiteSmoke;

            txtUserName.BorderStyle = BorderStyle.None;
            txtPassword.BorderStyle = BorderStyle.None;

            // Create bottom line panel for username
            Panel panelUsername = new Panel();
            panelUsername.BackColor = Color.FromArgb(0, 122, 204);
            panelUsername.Size = new Size(txtUserName.Width, 2);
            panelUsername.Location = new Point(txtUserName.Location.X, txtUserName.Bottom + 2);
            panelLoginContainer.Controls.Add(panelUsername);

            // Create bottom line panel for password
            Panel panelPassword = new Panel();
            panelPassword.BackColor = Color.FromArgb(0, 122, 204);
            panelPassword.Size = new Size(txtPassword.Width, 2);
            panelPassword.Location = new Point(txtPassword.Location.X, txtPassword.Bottom + 2);
            panelLoginContainer.Controls.Add(panelPassword);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Fade out effect when closing
            fadeTimer.Tag = "close";
            fadeTimer.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {
                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                //incase the user is not active
                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                logSuccessfulUserLogin();
                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                // Shake effect for invalid login
                ApplyShakeEffect();

                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;

            // Start fade-in animation
            fadeTimer.Start();
        }

        private void logSuccessfulUserLogin()
        {
            try
            {
                if (!EventLog.SourceExists(loggerSourceName))
                {
                    EventLog.CreateEventSource(loggerSourceName, "Application");
                    EventLog.WriteEntry(loggerSourceName, $"User {clsGlobal.CurrentUser} logged Successfully", EventLogEntryType.Information);
                }
                else
                {
                    EventLog.WriteEntry(loggerSourceName, $"User {clsGlobal.CurrentUser} logged Successfully", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(loggerSourceName, $"Error in logging the user log " + ex.Message, EventLogEntryType.Error);
            }
        }

        // Apply gradient background to left panel
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                splitContainer1.Panel1.ClientRectangle,
                Color.FromArgb(45, 45, 48),  // Dark color at top
                Color.FromArgb(25, 25, 28),  // Darker color at bottom
                90f);                        // Vertical gradient

            e.Graphics.FillRectangle(gradientBrush, splitContainer1.Panel1.ClientRectangle);
        }

        // Apply shadow effect to form
        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            // Draw shadow around the form
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.LightGray, 3, ButtonBorderStyle.Solid,
                Color.LightGray, 3, ButtonBorderStyle.Solid,
                Color.LightGray, 3, ButtonBorderStyle.Solid,
                Color.LightGray, 3, ButtonBorderStyle.Solid);
        }

        // Button hover effects
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(0, 102, 184); // Darker shade when hovered
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(0, 122, 204); // Original color
        }

        // Textbox focus effects
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.WhiteSmoke;
        }

        // Form fade-in/fade-out animation
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (fadeTimer.Tag != null && fadeTimer.Tag.ToString() == "close")
            {
                // Fade out
                this.Opacity -= 0.05;
                if (this.Opacity <= 0)
                {
                    fadeTimer.Stop();
                    this.Close();
                }
            }
            else
            {
                // Fade in
                this.Opacity += 0.05;
                if (this.Opacity >= 1)
                {
                    fadeTimer.Stop();
                }
            }
        }

        // Shake effect for invalid login
        private void ApplyShakeEffect()
        {
            Point originalLocation = this.Location;
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                this.Location = new Point(originalLocation.X + rand.Next(-5, 6), originalLocation.Y + rand.Next(-5, 6));
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            }

            this.Location = originalLocation;
        }

        /// <summary>
        /// Resets the login form for a fresh login after sign out.
        /// </summary>
        public void ResetLoginForm()
        {
            // Clear the password field for security
            txtPassword.Text = "";
            
            // Reset opacity for fade-in effect
            this.Opacity = 0;
            
            // Start fade-in animation
            fadeTimer.Tag = null;
            fadeTimer.Start();
            
            // Focus on username or password field
            if (string.IsNullOrEmpty(txtUserName.Text))
                txtUserName.Focus();
            else
                txtPassword.Focus();
        }
    }
}
