using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class FrmProductView : Form
    {
        public FrmProductView()
        {
            InitializeComponent();
        }

        private void btnOpenPro_Click(object sender, EventArgs e)
        {
            FrmAddProduct addProductForm = new FrmAddProduct(); 
            addProductForm.ShowDialog();
        }

        private void FrmProductView_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        public void LoadProduct()
        {
            SqlCommand s = new SqlCommand("Select * From tblProduct", DataConnection.DataCon);
            SqlDataReader r = s.ExecuteReader();
            ProductData.RowTemplate.Height = 100;
            ProductData.Rows.Clear();
            while (r.Read())
            {
                int ProductID = Convert.ToInt32(r[0].ToString());
                string ProductName = r[2] + "";
                string Size = r[3] + "";
                string Colour = r[4] + "";
                float Price = Convert.ToInt32(r[5]);
                int Qty = Convert.ToInt32(r[6]);
                string Barcode = r[7] + "";
                byte[] Photo = null;
                if (r[8] != DBNull.Value)
                {
                    Photo = (byte[])r[8];
                }
                ProductData.Rows.Add(ProductID, ProductName, Size, Colour, Price, Qty, Barcode,Photo);
            }
            r.Close();
            s.Dispose();

        }
        private void DeleteProduct(int productId)
        {
            try
            {
                string sql = "DELETE FROM tblProduct WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the product list after deletion
                LoadProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int idforupdate;
        private void ProductData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ProductData.Columns[e.ColumnIndex].Name == "Edit")
            {
                // Get the ProductID from the selected row
                idforupdate = Convert.ToInt32(ProductData.Rows[e.RowIndex].Cells[0].Value);

                // Pass the ID to FrmAddProduct for editing
                FrmAddProduct editForm = new FrmAddProduct(idforupdate);
                editForm.ShowDialog();

                // Refresh the product list after editing
                LoadProduct();
            }
            if (e.RowIndex >= 0 && ProductData.Columns[e.ColumnIndex].Name == "Remove")
            {
                int productIdToDelete = Convert.ToInt32(ProductData.Rows[e.RowIndex].Cells[0].Value);

                // Confirm with the user before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteProduct(productIdToDelete);
                }
                // Refresh the product list after editing
                LoadProduct();
            }
        }

        private void searchtextpro_TextChanged(object sender, EventArgs e)
        {
            if (searchtextpro.Text == "")
            {
                LoadProduct();
            }
            else
            {
                try
                {
                    string sql = "Select * from tblProduct where ProductName LIKE @ProductName;";
                    SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon);
                    cmd.Parameters.AddWithValue("@ProductName", "%" + searchtextpro.Text + "%");
                    ProductData.Rows.Clear();
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int ProductID = Convert.ToInt32(r[0].ToString());
                        string ProductName = r[2] + "";
                        string Size = r[3] + "";
                        string Colour = r[4] + "";
                        float Price = Convert.ToInt32(r[5]);
                        int Qty = Convert.ToInt32(r[6]);
                        string Barcode = r[7] + "";
                        byte[] Photo = null;
                        if (r[8] != DBNull.Value)
                        {
                            Photo = (byte[])r[8];
                        }
                        ProductData.Rows.Add(ProductID, ProductName, Size, Colour, Price, Qty, Barcode, Photo);
                    }
                    r.Close();
                    cmd.Dispose();
                }
                catch (Exception ex) { MessageBox.Show($"Error:{ex}", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
    }
}
