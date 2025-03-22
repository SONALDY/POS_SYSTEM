namespace ClothingStore_Pos_system
{
    partial class FrmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayment));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btncloseapp = new System.Windows.Forms.PictureBox();
            this.Payment = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.checkbox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnpay = new Guna.UI2.WinForms.Guna2Button();
            this.txtCashReturned = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiscountPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboDiscount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btncloseapp)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btncloseapp);
            this.guna2Panel1.Controls.Add(this.Payment);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.SystemColors.AppWorkspace;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(563, 72);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btncloseapp
            // 
            this.btncloseapp.BackColor = System.Drawing.Color.Transparent;
            this.btncloseapp.Image = ((System.Drawing.Image)(resources.GetObject("btncloseapp.Image")));
            this.btncloseapp.Location = new System.Drawing.Point(532, 0);
            this.btncloseapp.Name = "btncloseapp";
            this.btncloseapp.Size = new System.Drawing.Size(31, 33);
            this.btncloseapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btncloseapp.TabIndex = 3;
            this.btncloseapp.TabStop = false;
            this.btncloseapp.Click += new System.EventHandler(this.btncloseapp_Click);
            // 
            // Payment
            // 
            this.Payment.AutoSize = true;
            this.Payment.BackColor = System.Drawing.Color.Transparent;
            this.Payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Payment.ForeColor = System.Drawing.Color.White;
            this.Payment.Location = new System.Drawing.Point(164, 9);
            this.Payment.Name = "Payment";
            this.Payment.Size = new System.Drawing.Size(221, 55);
            this.Payment.TabIndex = 2;
            this.Payment.Text = "Payment";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.checkbox);
            this.guna2Panel2.Controls.Add(this.btnpay);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 483);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(563, 84);
            this.guna2Panel2.TabIndex = 1;
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.BackColor = System.Drawing.Color.Transparent;
            this.checkbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkbox.CheckedState.BorderRadius = 0;
            this.checkbox.CheckedState.BorderThickness = 0;
            this.checkbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox.ForeColor = System.Drawing.Color.White;
            this.checkbox.Location = new System.Drawing.Point(30, 22);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(187, 50);
            this.checkbox.TabIndex = 2;
            this.checkbox.Text = "Preview";
            this.checkbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkbox.UncheckedState.BorderRadius = 0;
            this.checkbox.UncheckedState.BorderThickness = 0;
            this.checkbox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkbox.UseVisualStyleBackColor = false;
            // 
            // btnpay
            // 
            this.btnpay.BackColor = System.Drawing.Color.Transparent;
            this.btnpay.BorderRadius = 20;
            this.btnpay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnpay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnpay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnpay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnpay.FillColor = System.Drawing.Color.Black;
            this.btnpay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpay.ForeColor = System.Drawing.Color.White;
            this.btnpay.Location = new System.Drawing.Point(371, 12);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(180, 60);
            this.btnpay.TabIndex = 0;
            this.btnpay.Text = "Pay";
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // txtCashReturned
            // 
            this.txtCashReturned.Location = new System.Drawing.Point(275, 386);
            this.txtCashReturned.Multiline = true;
            this.txtCashReturned.Name = "txtCashReturned";
            this.txtCashReturned.Size = new System.Drawing.Size(262, 35);
            this.txtCashReturned.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 37);
            this.label7.TabIndex = 23;
            this.label7.Text = "Cash Returned:";
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Location = new System.Drawing.Point(275, 323);
            this.txtCashReceived.Multiline = true;
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(262, 35);
            this.txtCashReceived.TabIndex = 22;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 37);
            this.label6.TabIndex = 21;
            this.label6.Text = "Cash Received:";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(277, 269);
            this.txtPayment.Multiline = true;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(262, 35);
            this.txtPayment.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 37);
            this.label5.TabIndex = 19;
            this.label5.Text = "Payment:";
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Location = new System.Drawing.Point(275, 218);
            this.txtDiscountPrice.Multiline = true;
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Size = new System.Drawing.Size(262, 35);
            this.txtDiscountPrice.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 37);
            this.label4.TabIndex = 17;
            this.label4.Text = "Discount Price:";
            // 
            // comboDiscount
            // 
            this.comboDiscount.FormattingEnabled = true;
            this.comboDiscount.Items.AddRange(new object[] {
            "0%",
            "5%",
            "10%",
            "20%",
            "50%"});
            this.comboDiscount.Location = new System.Drawing.Point(273, 166);
            this.comboDiscount.Name = "comboDiscount";
            this.comboDiscount.Size = new System.Drawing.Size(260, 33);
            this.comboDiscount.TabIndex = 16;
            this.comboDiscount.SelectedIndexChanged += new System.EventHandler(this.comboDiscount_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "Discount:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(273, 115);
            this.txtTotalAmount.Multiline = true;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(262, 35);
            this.txtTotalAmount.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Total Amount:";
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 567);
            this.Controls.Add(this.txtCashReturned);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDiscountPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPayment";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btncloseapp)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label Payment;
        private Guna.UI2.WinForms.Guna2CheckBox checkbox;
        private Guna.UI2.WinForms.Guna2Button btnpay;
        private System.Windows.Forms.TextBox txtCashReturned;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiscountPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btncloseapp;
    }
}