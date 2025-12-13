namespace _8Pool
{
    partial class Form1
    {
        // ...existing fields...
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblSubTitle;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ...existing Dispose...

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.poolTable5 = new _8Pool.PoolTable();
            this.poolTable8 = new _8Pool.PoolTable();
            this.poolTable9 = new _8Pool.PoolTable();
            this.poolTable7 = new _8Pool.PoolTable();
            this.poolTable6 = new _8Pool.PoolTable();
            this.poolTable4 = new _8Pool.PoolTable();
            this.poolTable3 = new _8Pool.PoolTable();
            this.poolTable2 = new _8Pool.PoolTable();
            this.poolTable1 = new _8Pool.PoolTable();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 10;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAppTitle.AutoSize = false;
            this.lblAppTitle.Width = 600;
            this.lblAppTitle.Text = "8-Ball Pool Manager";
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubTitle.Text = "Double?click any table to edit its info. Click End to finish a session.";
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // existing poolTable controls (keep positions/sizes, only minor color tweaks)
            // 
            this.poolTable5.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable8.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable9.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable7.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable6.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable4.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable3.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable2.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.poolTable1.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);

            // ...existing poolTable initialization code remains unchanged...

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
            this.ClientSize = new System.Drawing.Size(1924, 1053);
            this.Controls.Add(this.pnlHeader);
            // ...existing Controls.Add for pool tables...
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pool Table Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblSubTitle;

        // ...existing field declarations for poolTable1..9...
    }
}
