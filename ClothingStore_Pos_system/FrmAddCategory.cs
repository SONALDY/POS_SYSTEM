using Guna.UI2.WinForms;
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
    public partial class FrmAddCategory : Form
    {
        private FrmCategory _categoryForm;
        private int? _categoryId;
        public FrmAddCategory(FrmCategory categoryForm)
        {
            InitializeComponent();
            _categoryForm = categoryForm;
            _categoryId = null;
            btnupdate.Visible = false;
            btnaddcat.Visible = true;
        }
        public FrmAddCategory(FrmCategory categoryForm, int categoryId, string categoryName)
        {
            InitializeComponent();
            _categoryForm = categoryForm;
            _categoryId = categoryId;

            txtnamecat.Text = categoryName; 
            btnupdate.Visible = true;
            btnaddcat.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void btnaddcat_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblCategory(CategoryName)VALUES(@CategoryName)";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", txtnamecat.Text);
                        cmd.ExecuteNonQuery();
                        _categoryForm.getData(_categoryForm.CategoryData);
                        MessageBox.Show("Your Data have been Added");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (_categoryId.HasValue) 
            {
                try
                {
                    string query = "UPDATE tblCategory SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
                    using (SqlCommand cmd = new SqlCommand(query, DataConnection.DataCon))
                    {
                        if (DataConnection.DataCon.State != ConnectionState.Open)
                        {
                            DataConnection.DataCon.Open();
                        }

                        cmd.Parameters.AddWithValue("@CategoryName", txtnamecat.Text);
                        cmd.Parameters.AddWithValue("@CategoryID", _categoryId.Value);

                        cmd.ExecuteNonQuery();
                        _categoryForm.getData(_categoryForm.CategoryData);
                        MessageBox.Show("Category updated successfully!");

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
