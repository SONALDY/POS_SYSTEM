using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCategory addCategoryForm = new FrmAddCategory(this); 
            addCategoryForm.Show();

        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            getData(CategoryData);
        }

        public void getData( Guna2DataGridView CategoryData)
        {
            try
            {
                SqlCommand s = new SqlCommand("Select * From tblCategory", DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                CategoryData.RowTemplate.Height = 40;
                CategoryData.Rows.Clear();
                while (r.Read())
                {
                    int CategoryID = Convert.ToInt32(r[0].ToString());
                    string CategoryName = r[1] + "";
                    CategoryData.Rows.Add(CategoryID, CategoryName);
                }
                r.Close();
                s.Dispose();

            }
            catch { }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }
        private void DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM tblCategory WHERE CategoryID = @CategoryID";

            using (SqlCommand cmd = new SqlCommand(query, DataConnection.DataCon))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category has been deleted successfully!");
                    getData(CategoryData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void CategoryData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CategoryData.Columns[e.ColumnIndex].Name == "catedit")
            {
                int categoryId = Convert.ToInt32(CategoryData.Rows[e.RowIndex].Cells[0].Value);
                string categoryName = CategoryData.Rows[e.RowIndex].Cells[1].Value.ToString();
                FrmAddCategory addCategoryForm = new FrmAddCategory(this, categoryId, categoryName);
                addCategoryForm.ShowDialog();
            }
            if (e.RowIndex >= 0 && CategoryData.Columns[e.ColumnIndex].Name == "catremove")
            {
                int categoryId = Convert.ToInt32(CategoryData.Rows[e.RowIndex].Cells[0].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this expense?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteCategory(categoryId);
                }
            }
        }

        private void searchtextcat_TextChanged(object sender, EventArgs e)
        {
            if (searchtextcat.Text == "")
            {
                getData(CategoryData);
            }
            else
            {
                try
                {
                    string query = "SELECT * FROM tblCategory WHERE CategoryName LIKE @CategoryName;"; // Use LIKE
                    using (SqlConnection con = DataConnection.DataCon) // Use using to manage connection
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", "%" + searchtextcat.Text + "%"); // Use LIKE pattern
                            CategoryData.RowTemplate.Height = 40;
                            CategoryData.Rows.Clear();
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    int CategoryID = Convert.ToInt32(r[0].ToString());
                                    string CategoryName = r[1] + "";
                                    CategoryData.Rows.Add(CategoryID, CategoryName);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
