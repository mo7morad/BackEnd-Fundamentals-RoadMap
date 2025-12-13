namespace WinForms.Projects.Pizza_Shop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblWhereToEat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCrustType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblToppings = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.rbLarge = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbSamll = new System.Windows.Forms.RadioButton();
            this.gbToppings = new System.Windows.Forms.GroupBox();
            this.chkVegetables = new System.Windows.Forms.CheckBox();
            this.chkBeef = new System.Windows.Forms.CheckBox();
            this.chkTuna = new System.Windows.Forms.CheckBox();
            this.chkMushrooms = new System.Windows.Forms.CheckBox();
            this.chkMixCheese = new System.Windows.Forms.CheckBox();
            this.chkChicken = new System.Windows.Forms.CheckBox();
            this.gbCrustType = new System.Windows.Forms.GroupBox();
            this.rbStuffedCrust = new System.Windows.Forms.RadioButton();
            this.rbThinCrust = new System.Windows.Forms.RadioButton();
            this.gbWhereToEat = new System.Windows.Forms.GroupBox();
            this.rbTakeAway = new System.Windows.Forms.RadioButton();
            this.rbEatIn = new System.Windows.Forms.RadioButton();
            this.btnOrderPizza = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbSize.SuspendLayout();
            this.gbToppings.SuspendLayout();
            this.gbCrustType.SuspendLayout();
            this.gbWhereToEat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.rbLarge);
            this.gbSize.Controls.Add(this.rbMedium);
            this.gbSize.Controls.Add(this.rbSamll);
            this.gbSize.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.gbSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.gbSize.Location = new System.Drawing.Point(54, 128);
            this.gbSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSize.Name = "gbSize";
            this.gbSize.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSize.Size = new System.Drawing.Size(248, 187);
            this.gbSize.TabIndex = 0;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            this.gbSize.BackColor = System.Drawing.Color.White;
            // 
            // rbLarge
            // 
            this.rbLarge.AutoSize = true;
            this.rbLarge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbLarge.Location = new System.Drawing.Point(40, 131);
            this.rbLarge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbLarge.Name = "rbLarge";
            this.rbLarge.Size = new System.Drawing.Size(61, 23);
            this.rbLarge.TabIndex = 2;
            this.rbLarge.Tag = "40";
            this.rbLarge.Text = "Large";
            this.rbLarge.UseVisualStyleBackColor = true;
            this.rbLarge.CheckedChanged += new System.EventHandler(this.rbLarge_CheckedChanged);
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Checked = true;
            this.rbMedium.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbMedium.Location = new System.Drawing.Point(40, 85);
            this.rbMedium.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(78, 23);
            this.rbMedium.TabIndex = 1;
            this.rbMedium.TabStop = true;
            this.rbMedium.Tag = "30";
            this.rbMedium.Text = "Medium";
            this.rbMedium.UseVisualStyleBackColor = true;
            this.rbMedium.CheckedChanged += new System.EventHandler(this.rbMedium_CheckedChanged);
            // 
            // rbSamll
            // 
            this.rbSamll.AutoSize = true;
            this.rbSamll.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbSamll.Location = new System.Drawing.Point(40, 39);
            this.rbSamll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSamll.Name = "rbSamll";
            this.rbSamll.Size = new System.Drawing.Size(60, 23);
            this.rbSamll.TabIndex = 0;
            this.rbSamll.Tag = "20";
            this.rbSamll.Text = "Small";
            this.rbSamll.UseVisualStyleBackColor = true;
            this.rbSamll.CheckedChanged += new System.EventHandler(this.rbSamll_CheckedChanged);
            // 
            // gbToppings
            // 
            this.gbToppings.Controls.Add(this.chkVegetables);
            this.gbToppings.Controls.Add(this.chkBeef);
            this.gbToppings.Controls.Add(this.chkTuna);
            this.gbToppings.Controls.Add(this.chkMushrooms);
            this.gbToppings.Controls.Add(this.chkMixCheese);
            this.gbToppings.Controls.Add(this.chkChicken);
            this.gbToppings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.gbToppings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.gbToppings.Location = new System.Drawing.Point(345, 128);
            this.gbToppings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbToppings.Name = "gbToppings";
            this.gbToppings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbToppings.Size = new System.Drawing.Size(335, 187);
            this.gbToppings.TabIndex = 1;
            this.gbToppings.TabStop = false;
            this.gbToppings.Text = "Toppings";
            this.gbToppings.BackColor = System.Drawing.Color.White;
            // 
            // chkVegetables
            // 
            this.chkVegetables.AutoSize = true;
            this.chkVegetables.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkVegetables.Location = new System.Drawing.Point(166, 111);
            this.chkVegetables.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVegetables.Name = "chkVegetables";
            this.chkVegetables.Size = new System.Drawing.Size(94, 23);
            this.chkVegetables.TabIndex = 5;
            this.chkVegetables.Tag = "5";
            this.chkVegetables.Text = "Vegetables";
            this.chkVegetables.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkVegetables.UseVisualStyleBackColor = true;
            this.chkVegetables.CheckedChanged += new System.EventHandler(this.chckGreenPeppers_CheckedChanged);
            // 
            // chkBeef
            // 
            this.chkBeef.AutoSize = true;
            this.chkBeef.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkBeef.Location = new System.Drawing.Point(8, 111);
            this.chkBeef.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBeef.Name = "chkBeef";
            this.chkBeef.Size = new System.Drawing.Size(55, 23);
            this.chkBeef.TabIndex = 4;
            this.chkBeef.Tag = "5";
            this.chkBeef.Text = "Beef";
            this.chkBeef.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBeef.UseVisualStyleBackColor = true;
            this.chkBeef.CheckedChanged += new System.EventHandler(this.chkTomatos_CheckedChanged);
            // 
            // chkTuna
            // 
            this.chkTuna.AutoSize = true;
            this.chkTuna.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTuna.Location = new System.Drawing.Point(166, 73);
            this.chkTuna.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTuna.Name = "chkTuna";
            this.chkTuna.Size = new System.Drawing.Size(58, 23);
            this.chkTuna.TabIndex = 3;
            this.chkTuna.Tag = "5";
            this.chkTuna.Text = "Tuna";
            this.chkTuna.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkTuna.UseVisualStyleBackColor = true;
            this.chkTuna.CheckedChanged += new System.EventHandler(this.chkOlives_CheckedChanged);
            // 
            // chkMushrooms
            // 
            this.chkMushrooms.AutoSize = true;
            this.chkMushrooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkMushrooms.Location = new System.Drawing.Point(8, 73);
            this.chkMushrooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMushrooms.Name = "chkMushrooms";
            this.chkMushrooms.Size = new System.Drawing.Size(100, 23);
            this.chkMushrooms.TabIndex = 2;
            this.chkMushrooms.Tag = "5";
            this.chkMushrooms.Text = "Mushrooms";
            this.chkMushrooms.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkMushrooms.UseVisualStyleBackColor = true;
            this.chkMushrooms.CheckedChanged += new System.EventHandler(this.chkMushrooms_CheckedChanged);
            // 
            // chkMixCheese
            // 
            this.chkMixCheese.AutoSize = true;
            this.chkMixCheese.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkMixCheese.Location = new System.Drawing.Point(166, 39);
            this.chkMixCheese.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMixCheese.Name = "chkMixCheese";
            this.chkMixCheese.Size = new System.Drawing.Size(98, 23);
            this.chkMixCheese.TabIndex = 1;
            this.chkMixCheese.Tag = "5";
            this.chkMixCheese.Text = "Mix Cheese";
            this.chkMixCheese.UseVisualStyleBackColor = true;
            this.chkMixCheese.CheckedChanged += new System.EventHandler(this.chkOnion_CheckedChanged);
            // 
            // chkChicken
            // 
            this.chkChicken.AutoSize = true;
            this.chkChicken.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkChicken.Location = new System.Drawing.Point(8, 39);
            this.chkChicken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkChicken.Name = "chkChicken";
            this.chkChicken.Size = new System.Drawing.Size(76, 23);
            this.chkChicken.TabIndex = 0;
            this.chkChicken.Tag = "5";
            this.chkChicken.Text = "Chicken";
            this.chkChicken.UseVisualStyleBackColor = true;
            this.chkChicken.CheckedChanged += new System.EventHandler(this.chkExtraChees_CheckedChanged);
            // 
            // gbCrustType
            // 
            this.gbCrustType.Controls.Add(this.rbStuffedCrust);
            this.gbCrustType.Controls.Add(this.rbThinCrust);
            this.gbCrustType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.gbCrustType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.gbCrustType.Location = new System.Drawing.Point(54, 334);
            this.gbCrustType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCrustType.Name = "gbCrustType";
            this.gbCrustType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCrustType.Size = new System.Drawing.Size(248, 126);
            this.gbCrustType.TabIndex = 2;
            this.gbCrustType.TabStop = false;
            this.gbCrustType.Text = "Crust Type";
            this.gbCrustType.BackColor = System.Drawing.Color.White;
            // 
            // rbStuffedCrust
            // 
            this.rbStuffedCrust.AutoSize = true;
            this.rbStuffedCrust.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbStuffedCrust.Location = new System.Drawing.Point(17, 83);
            this.rbStuffedCrust.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbStuffedCrust.Name = "rbStuffedCrust";
            this.rbStuffedCrust.Size = new System.Drawing.Size(106, 23);
            this.rbStuffedCrust.TabIndex = 1;
            this.rbStuffedCrust.Tag = "10";
            this.rbStuffedCrust.Text = "Stuffed Crust";
            this.rbStuffedCrust.UseVisualStyleBackColor = true;
            this.rbStuffedCrust.CheckedChanged += new System.EventHandler(this.rbThickCrust_CheckedChanged);
            // 
            // rbThinCrust
            // 
            this.rbThinCrust.AutoSize = true;
            this.rbThinCrust.Checked = true;
            this.rbThinCrust.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbThinCrust.Location = new System.Drawing.Point(17, 37);
            this.rbThinCrust.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbThinCrust.Name = "rbThinCrust";
            this.rbThinCrust.Size = new System.Drawing.Size(88, 23);
            this.rbThinCrust.TabIndex = 0;
            this.rbThinCrust.TabStop = true;
            this.rbThinCrust.Tag = "0";
            this.rbThinCrust.Text = "Thin Crust";
            this.rbThinCrust.UseVisualStyleBackColor = true;
            this.rbThinCrust.CheckedChanged += new System.EventHandler(this.rbThinCrust_CheckedChanged);
            // 
            // gbWhereToEat
            // 
            this.gbWhereToEat.Controls.Add(this.rbTakeAway);
            this.gbWhereToEat.Controls.Add(this.rbEatIn);
            this.gbWhereToEat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.gbWhereToEat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.gbWhereToEat.Location = new System.Drawing.Point(345, 334);
            this.gbWhereToEat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbWhereToEat.Name = "gbWhereToEat";
            this.gbWhereToEat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbWhereToEat.Size = new System.Drawing.Size(335, 85);
            this.gbWhereToEat.TabIndex = 3;
            this.gbWhereToEat.TabStop = false;
            this.gbWhereToEat.Text = "Where To Eat";
            this.gbWhereToEat.BackColor = System.Drawing.Color.White;
            // 
            // rbTakeAway
            // 
            this.rbTakeAway.AutoSize = true;
            this.rbTakeAway.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbTakeAway.Location = new System.Drawing.Point(119, 37);
            this.rbTakeAway.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbTakeAway.Name = "rbTakeAway";
            this.rbTakeAway.Size = new System.Drawing.Size(91, 23);
            this.rbTakeAway.TabIndex = 1;
            this.rbTakeAway.Text = "Take Away";
            this.rbTakeAway.UseVisualStyleBackColor = true;
            this.rbTakeAway.CheckedChanged += new System.EventHandler(this.rbTakeOut_CheckedChanged);
            // 
            // rbEatIn
            // 
            this.rbEatIn.AutoSize = true;
            this.rbEatIn.Checked = true;
            this.rbEatIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbEatIn.Location = new System.Drawing.Point(17, 37);
            this.rbEatIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbEatIn.Name = "rbEatIn";
            this.rbEatIn.Size = new System.Drawing.Size(61, 23);
            this.rbEatIn.TabIndex = 0;
            this.rbEatIn.TabStop = true;
            this.rbEatIn.Tag = "";
            this.rbEatIn.Text = "Eat In";
            this.rbEatIn.UseVisualStyleBackColor = true;
            this.rbEatIn.CheckedChanged += new System.EventHandler(this.rbEatIn_CheckedChanged);
            // 
            // btnOrderPizza
            // 
            this.btnOrderPizza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnOrderPizza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderPizza.FlatAppearance.BorderSize = 0;
            this.btnOrderPizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPizza.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOrderPizza.ForeColor = System.Drawing.Color.White;
            this.btnOrderPizza.Location = new System.Drawing.Point(345, 437);
            this.btnOrderPizza.Name = "btnOrderPizza";
            this.btnOrderPizza.Size = new System.Drawing.Size(119, 40);
            this.btnOrderPizza.TabIndex = 4;
            this.btnOrderPizza.Text = "Order Pizza";
            this.btnOrderPizza.UseVisualStyleBackColor = false;
            this.btnOrderPizza.Click += new System.EventHandler(this.btnOrderPizza_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.BackColor = System.Drawing.Color.White;
            this.btnResetForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnResetForm.FlatAppearance.BorderSize = 1;
            this.btnResetForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetForm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnResetForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnResetForm.Location = new System.Drawing.Point(561, 437);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(119, 40);
            this.btnResetForm.TabIndex = 5;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = false;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalPrice);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblWhereToEat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblCrustType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblToppings);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblSize);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.groupBox2.Location = new System.Drawing.Point(703, 128);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(335, 349);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Summary";
            this.groupBox2.BackColor = System.Drawing.Color.White;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(116, 256);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(84, 65);
            this.lblTotalPrice.TabIndex = 10;
            this.lblTotalPrice.Text = "$0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(19, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total Price: ";
            // 
            // lblWhereToEat
            // 
            this.lblWhereToEat.AutoSize = true;
            this.lblWhereToEat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWhereToEat.Location = new System.Drawing.Point(125, 209);
            this.lblWhereToEat.Name = "lblWhereToEat";
            this.lblWhereToEat.Size = new System.Drawing.Size(43, 19);
            this.lblWhereToEat.TabIndex = 8;
            this.lblWhereToEat.Text = "Eat In";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(19, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Where to Eat: ";
            // 
            // lblCrustType
            // 
            this.lblCrustType.AutoSize = true;
            this.lblCrustType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCrustType.Location = new System.Drawing.Point(125, 155);
            this.lblCrustType.Name = "lblCrustType";
            this.lblCrustType.Size = new System.Drawing.Size(71, 19);
            this.lblCrustType.TabIndex = 6;
            this.lblCrustType.Text = "Thin Crust";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(19, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Crust Type:";
            // 
            // lblToppings
            // 
            this.lblToppings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblToppings.Location = new System.Drawing.Point(63, 102);
            this.lblToppings.Name = "lblToppings";
            this.lblToppings.Size = new System.Drawing.Size(265, 53);
            this.lblToppings.TabIndex = 4;
            this.lblToppings.Text = "No Toppings.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(19, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Toppings:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSize.Location = new System.Drawing.Point(63, 38);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(59, 19);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Meduim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point((this.panelHeader.Width - this.label2.Width) / 2, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "Make Your Pizza";
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1075, 80);
            this.panelHeader.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1075, 522);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnOrderPizza);
            this.Controls.Add(this.gbWhereToEat);
            this.Controls.Add(this.gbCrustType);
            this.Controls.Add(this.gbToppings);
            this.Controls.Add(this.gbSize);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pizzeria";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.gbToppings.ResumeLayout(false);
            this.gbToppings.PerformLayout();
            this.gbCrustType.ResumeLayout(false);
            this.gbCrustType.PerformLayout();
            this.gbWhereToEat.ResumeLayout(false);
            this.gbWhereToEat.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblWhereToEat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCrustType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblToppings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.RadioButton rbLarge;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbSamll;
        private System.Windows.Forms.GroupBox gbToppings;
        private System.Windows.Forms.CheckBox chkVegetables;
        private System.Windows.Forms.CheckBox chkBeef;
        private System.Windows.Forms.CheckBox chkTuna;
        private System.Windows.Forms.CheckBox chkMushrooms;
        private System.Windows.Forms.CheckBox chkMixCheese;
        private System.Windows.Forms.CheckBox chkChicken;
        private System.Windows.Forms.GroupBox gbCrustType;
        private System.Windows.Forms.RadioButton rbStuffedCrust;
        private System.Windows.Forms.RadioButton rbThinCrust;
        private System.Windows.Forms.GroupBox gbWhereToEat;
        private System.Windows.Forms.RadioButton rbTakeAway;
        private System.Windows.Forms.RadioButton rbEatIn;
        private System.Windows.Forms.Button btnOrderPizza;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label7;
    }
}
