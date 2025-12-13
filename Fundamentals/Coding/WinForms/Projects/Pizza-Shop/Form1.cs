// ...existing code...
        void UpdateTotalPrice()
        {

            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
            lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69); // Ensure green color stays

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
            this.BackgroundImage = null; // Ensure background image is removed at runtime
            this.BackColor = Color.White; // Ensure background color is white
        }
// ...existing code...
