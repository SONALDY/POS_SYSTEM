using System.Drawing;

namespace ClothingStore_Pos_system
{
    partial class OrderCard
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

        public string Pro_Name { 
         get=>txt_Name.Text;
         set=>txt_Name.Text=value; }
        public string Price 
        {
            get => txt_price.Text;
            set => txt_price.Text = value;
        }
        public Image Photo 
        {
            get=>picture_image.Image;
            set=>picture_image.Image=value; 
        }

        public string Pro_ID
        {
            get;
            set;
        }
        public float TotalAmount { get; set; }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderCard));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txt_price = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Name = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnaddItem = new Guna.UI2.WinForms.Guna2Button();
            this.PName = new System.Windows.Forms.Label();
            this.picture_image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.LightGray;
            this.guna2Panel1.Controls.Add(this.txt_price);
            this.guna2Panel1.Controls.Add(this.txt_Name);
            this.guna2Panel1.Controls.Add(this.BtnaddItem);
            this.guna2Panel1.Controls.Add(this.PName);
            this.guna2Panel1.Controls.Add(this.picture_image);
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(267, 321);
            this.guna2Panel1.TabIndex = 1;
            // 
            // txt_price
            // 
            this.txt_price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_price.DefaultText = "";
            this.txt_price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_price.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_price.FillColor = System.Drawing.Color.LightGray;
            this.txt_price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_price.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_price.Location = new System.Drawing.Point(0, 229);
            this.txt_price.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_price.Name = "txt_price";
            this.txt_price.PasswordChar = '\0';
            this.txt_price.PlaceholderText = "";
            this.txt_price.SelectedText = "";
            this.txt_price.Size = new System.Drawing.Size(267, 39);
            this.txt_price.TabIndex = 11;
            // 
            // txt_Name
            // 
            this.txt_Name.BackColor = System.Drawing.Color.Transparent;
            this.txt_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Name.DefaultText = "";
            this.txt_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Name.FillColor = System.Drawing.Color.LightGray;
            this.txt_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Name.Location = new System.Drawing.Point(-3, 180);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.PasswordChar = '\0';
            this.txt_Name.PlaceholderText = "";
            this.txt_Name.SelectedText = "";
            this.txt_Name.Size = new System.Drawing.Size(270, 49);
            this.txt_Name.TabIndex = 11;
            // 
            // BtnaddItem
            // 
            this.BtnaddItem.BorderRadius = 10;
            this.BtnaddItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnaddItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnaddItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnaddItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnaddItem.FillColor = System.Drawing.Color.Black;
            this.BtnaddItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnaddItem.ForeColor = System.Drawing.Color.White;
            this.BtnaddItem.Location = new System.Drawing.Point(32, 276);
            this.BtnaddItem.Name = "BtnaddItem";
            this.BtnaddItem.Size = new System.Drawing.Size(180, 42);
            this.BtnaddItem.TabIndex = 10;
            this.BtnaddItem.Text = "Add Item";
            this.BtnaddItem.Click += new System.EventHandler(this.BtnaddItem_Click);
            // 
            // PName
            // 
            this.PName.AutoSize = true;
            this.PName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PName.Location = new System.Drawing.Point(17, 191);
            this.PName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PName.Name = "PName";
            this.PName.Size = new System.Drawing.Size(0, 29);
            this.PName.TabIndex = 8;
            // 
            // picture_image
            // 
            this.picture_image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_image.ErrorImage = null;
            this.picture_image.Image = ((System.Drawing.Image)(resources.GetObject("picture_image.Image")));
            this.picture_image.ImageRotate = 0F;
            this.picture_image.Location = new System.Drawing.Point(-3, 5);
            this.picture_image.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picture_image.Name = "picture_image";
            this.picture_image.Size = new System.Drawing.Size(270, 177);
            this.picture_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_image.TabIndex = 7;
            this.picture_image.TabStop = false;
            // 
            // OrderCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "OrderCard";
            this.Size = new System.Drawing.Size(270, 324);
            this.Load += new System.EventHandler(this.OrderCard_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button BtnaddItem;
        private System.Windows.Forms.Label PName;
        private Guna.UI2.WinForms.Guna2PictureBox picture_image;
        private Guna.UI2.WinForms.Guna2TextBox txt_price;
        private Guna.UI2.WinForms.Guna2TextBox txt_Name;
    }
}
