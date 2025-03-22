namespace ClothingStore_Pos_system
{
    partial class FrmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenCus = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.searchtextcus = new Guna.UI2.WinForms.Guna2TextBox();
            this.customerdata = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customerdata)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(72, 177);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1280, 10);
            this.guna2Separator1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Customer List";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnOpenCus
            // 
            this.btnOpenCus.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnOpenCus.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnOpenCus.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCus.Image")));
            this.btnOpenCus.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnOpenCus.ImageRotate = 0F;
            this.btnOpenCus.Location = new System.Drawing.Point(72, 82);
            this.btnOpenCus.Name = "btnOpenCus";
            this.btnOpenCus.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnOpenCus.Size = new System.Drawing.Size(103, 75);
            this.btnOpenCus.TabIndex = 7;
            this.btnOpenCus.Click += new System.EventHandler(this.btnOpenCus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1036, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // searchtextcus
            // 
            this.searchtextcus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchtextcus.DefaultText = "";
            this.searchtextcus.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchtextcus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchtextcus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchtextcus.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchtextcus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchtextcus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchtextcus.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchtextcus.IconLeft = ((System.Drawing.Image)(resources.GetObject("searchtextcus.IconLeft")));
            this.searchtextcus.IconLeftCursor = System.Windows.Forms.Cursors.No;
            this.searchtextcus.Location = new System.Drawing.Point(1041, 95);
            this.searchtextcus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchtextcus.Name = "searchtextcus";
            this.searchtextcus.PasswordChar = '\0';
            this.searchtextcus.PlaceholderText = "";
            this.searchtextcus.SelectedText = "";
            this.searchtextcus.Size = new System.Drawing.Size(301, 52);
            this.searchtextcus.TabIndex = 5;
            this.searchtextcus.TextOffset = new System.Drawing.Point(10, 0);
            this.searchtextcus.TextChanged += new System.EventHandler(this.searchtextcus_TextChanged);
            // 
            // customerdata
            // 
            this.customerdata.AllowUserToAddRows = false;
            this.customerdata.AllowUserToDeleteRows = false;
            this.customerdata.AllowUserToResizeColumns = false;
            this.customerdata.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.customerdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.customerdata.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerdata.DefaultCellStyle = dataGridViewCellStyle3;
            this.customerdata.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.customerdata.Location = new System.Drawing.Point(74, 219);
            this.customerdata.Name = "customerdata";
            this.customerdata.RowHeadersVisible = false;
            this.customerdata.RowHeadersWidth = 62;
            this.customerdata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerdata.RowTemplate.Height = 28;
            this.customerdata.Size = new System.Drawing.Size(1277, 496);
            this.customerdata.StandardTab = true;
            this.customerdata.TabIndex = 10;
            this.customerdata.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.customerdata.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.customerdata.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.customerdata.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.customerdata.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.customerdata.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.customerdata.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.customerdata.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.customerdata.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.customerdata.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerdata.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.customerdata.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.customerdata.ThemeStyle.HeaderStyle.Height = 4;
            this.customerdata.ThemeStyle.ReadOnly = false;
            this.customerdata.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.customerdata.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.customerdata.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerdata.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.customerdata.ThemeStyle.RowsStyle.Height = 28;
            this.customerdata.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.customerdata.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.customerdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerdata_CellContentClick);
            this.customerdata.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerdata_CellContentDoubleClick);
            this.customerdata.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerdata_CellDoubleClick);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 746);
            this.Controls.Add(this.customerdata);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenCus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchtextcus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCustomer";
            this.Text = "FrmCustomer";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton btnOpenCus;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox searchtextcus;
        public Guna.UI2.WinForms.Guna2DataGridView customerdata;
    }
}