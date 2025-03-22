using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class FrmAddProduct : Form
    {
        public FrmAddProduct()
        {
            InitializeComponent();
        }
        private List<string> cid = new List<string>();
        private List<string> cname = new List<string>();
        private int productIdForEdit = -1;  

        public FrmAddProduct(int productId = -1)
        {
            InitializeComponent();
            productIdForEdit = productId;
            if (productIdForEdit != -1)
            {
                LoadProductDetails();
                btnUpdate.Visible = true; 
                btnAddPro.Visible = false; 
            }
            else
            {
                btnUpdate.Visible = false; 
                btnAddPro.Visible = true;          
            }
        }   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int index = ComboCatname.SelectedIndex;
                txtCatid.Text = cid[index];


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ;this.Close();
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM tblCategory";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string CategoryID = r[0].ToString();
                    string CategoryName = r[1].ToString();
                    ComboCatname.Items.Add(CategoryName);
                    cid.Add(CategoryID);
                    cname.Add(CategoryName);
                }
                r.Close();
                s.Dispose();
                ComboCatname.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblProduct (Barcode,ProductName,Size,Colour,Price,Qty,CategoryID,Photo)VALUES(@Barcode,@ProductName,@Size,@Colour,@Price,@Qty,@CategoryID,@Photo)";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtPname.Text);
                        cmd.Parameters.AddWithValue("@Size", txtSize.Text);
                        cmd.Parameters.AddWithValue("@Colour", txtColor.Text);
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                        cmd.Parameters.AddWithValue("@CategoryID", txtCatid.Text);
                        MemoryStream memoryStream = new MemoryStream();
                        guna2PictureBox1.Image.Save(memoryStream, guna2PictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@photo", memoryStream.ToArray());
                        cmd.ExecuteNonQuery();
                        FrmProductView frmProductView = (FrmProductView)Application.OpenForms["FrmProductView"];
                        if (frmProductView != null)
                        {
                            frmProductView.LoadProduct();
                        }
                        MessageBox.Show("Your Data have been Added");

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files| *.jpg; *.jpeg; *.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = Image.FromFile(openFileDialog.FileName);

            }
        }
        private void LoadProductDetails()
        {
            try
            {
                string sql = "SELECT * FROM tblProduct WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productIdForEdit);
                    SqlDataReader r = cmd.ExecuteReader();

                    if (r.Read())
                    {
                        txtBarcode.Text = r["Barcode"].ToString();
                        txtPname.Text = r["ProductName"].ToString();
                        txtSize.Text = r["Size"].ToString();
                        txtColor.Text = r["Colour"].ToString();
                        txtPrice.Text = r["Price"].ToString();
                        txtQty.Text = r["Qty"].ToString();
                        txtCatid.Text = r["CategoryID"].ToString();

                        // Load Image if available
                        if (r["Photo"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])r["Photo"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                guna2PictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    r.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (productIdForEdit == -1)
            {
                MessageBox.Show("No product selected for update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "UPDATE tblProduct SET Barcode = @Barcode, ProductName = @ProductName, Size = @Size, " +
                             "Colour = @Colour, Price = @Price, Qty = @Qty, CategoryID = @CategoryID, Photo = @Photo " +
                             "WHERE ProductID = @ProductID";

                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("@ProductName", txtPname.Text);
                    cmd.Parameters.AddWithValue("@Size", txtSize.Text);
                    cmd.Parameters.AddWithValue("@Colour", txtColor.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", txtCatid.Text);
                    cmd.Parameters.AddWithValue("@ProductID", productIdForEdit);

                    // Convert image to byte array
                    MemoryStream memoryStream = new MemoryStream();
                    guna2PictureBox1.Image.Save(memoryStream, guna2PictureBox1.Image.RawFormat);
                    cmd.Parameters.AddWithValue("@Photo", memoryStream.ToArray());

                    cmd.ExecuteNonQuery();
                    LoadProductDetails();
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
