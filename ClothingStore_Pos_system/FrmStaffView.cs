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
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClothingStore_Pos_system
{
    public partial class FrmStaffView : Form
    {
        public FrmStaffView()
        {
            InitializeComponent();
        }
        
        private void btnOpenPro_Click(object sender, EventArgs e)
        {
            FrmAddStaff frmAddStaff = new FrmAddStaff(this);
            frmAddStaff.ShowDialog();
        }
        private void FrmStaffView_Load(object sender, EventArgs e)
        {
            staffDatabase();
        }
        public class StaffData
        {
            public int StaffID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Position { get; set; }
            public float Salary { get; set; }
            public DateTime DOB { get; set; }
            public DateTime HiredDate { get; set; }
            public byte[] Photo { get; set; }
        }
        public void staffDatabase()
        {
            try
            {
                using (SqlCommand s = new SqlCommand("SELECT * FROM tblStaff", DataConnection.DataCon))
                {
                    using (SqlDataReader r = s.ExecuteReader())
                    {
                        StaffDataGrid.RowTemplate.Height = 100;
                        StaffDataGrid.Rows.Clear();
                        while (r.Read())
                        {
                            byte[] photo = r["Photo"] != DBNull.Value ? (byte[])r["Photo"] : null;
                            System.Drawing.Image picturedata = null;

                            if (photo != null && photo.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(photo))
                                {
                                    picturedata = System.Drawing.Image.FromStream(ms);
                                }
                            }

                            int id = r["StaffID"] != DBNull.Value ? Convert.ToInt32(r["StaffID"]) : 0;
                            string First_name = r["First_name"].ToString();
                            string Last_name = r["Last_name"].ToString();
                            string Username = r["Username"].ToString();
                            string Password = r["Password"].ToString();
                            string Position = r["Position"].ToString();
                            string Email = r["Email"].ToString();
                            string Phone = r["Phone"].ToString();
                            DateTime HiredDate = r["Hired_Date"] != DBNull.Value ? Convert.ToDateTime(r["Hired_Date"]) : DateTime.MinValue;
                            float Salary = r["Salary"] != DBNull.Value ? Convert.ToSingle(r["Salary"]) : 0.0f;
                            StaffDataGrid.Rows.Add(picturedata, id, First_name, Last_name, Username, Password, Position, Email, Phone, HiredDate.ToString("MM-dd-yyyy"), Salary);
                        }
                    } // r is automatically closed and disposed here
                } // s is automatically disposed here
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private StaffData GetStaffDataById(int staffID)
        {
            StaffData staffData = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblStaff WHERE StaffID = @StaffID", DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@StaffID", staffID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            staffData = new StaffData
                            {
                                StaffID = staffID,
                                FirstName = reader["First_Name"].ToString(),
                                LastName = reader["Last_Name"].ToString(),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["Password"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Position = reader["Position"].ToString(),
                                Salary = Convert.ToSingle(reader["Salary"]),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                HiredDate = Convert.ToDateTime(reader["Hired_Date"]),
                                Photo = reader["Photo"] != DBNull.Value ? (byte[])reader["Photo"] : null
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching staff data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return staffData;
        }
        public int staffIDupdate;
        private void DeleteStaff(int StaffId)
        {
            try
            {
                string sql = "DELETE FROM tblStaff WHERE StaffID = @StaffID";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@StaffID", StaffId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Staff deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the product list after deletion
                staffDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StaffDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && StaffDataGrid.Columns[e.ColumnIndex].Name == "staffedit")
            {
                try
                {
                    // Get the StaffID from the selected row
                    staffIDupdate = Convert.ToInt32(StaffDataGrid.Rows[e.RowIndex].Cells["StaffID"].Value); // Assign to the public variable

                    // Fetch the staff data from the database
                    var staffData = GetStaffDataById(staffIDupdate);

                    if (staffData != null)
                    {
                        // Open the FrmAddStaff form in edit mode with the retrieved data
                        FrmAddStaff editForm = new FrmAddStaff(
                            this,
                            staffData.StaffID,
                            staffData.FirstName,
                            staffData.LastName,
                            staffData.Username,
                            staffData.PasswordHash,
                            staffData.Email,
                            staffData.Phone,
                            staffData.Position,
                            staffData.Salary,
                            staffData.DOB,
                            staffData.HiredDate,
                            staffData.Photo
                        );

                        editForm.ShowDialog();

                        // Refresh the grid after editing
                        staffDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Staff data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving staff data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.RowIndex >= 0 && StaffDataGrid.Columns[e.ColumnIndex].Name == "staffremove")
            {
                int stafftodelete = Convert.ToInt32(StaffDataGrid.Rows[e.RowIndex].Cells["StaffID"].Value);
                // Confirm with the user before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteStaff(stafftodelete);
                }
                // Refresh the product list after editing
            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text=="")
            {
                staffDatabase();
            }
            else
            {
                try
                {
                    string query = "Select * from tblStaff where Last_name LIKE @Last_name;";
                    SqlCommand cmd = new SqlCommand(query, DataConnection.DataCon);
                    cmd.Parameters.AddWithValue("@Last_name", "%" + guna2TextBox1.Text + "%");
                    StaffDataGrid.Rows.Clear();
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        byte[] photo = r["Photo"] != DBNull.Value ? (byte[])r["Photo"] : null;
                        System.Drawing.Image picturedata = null;

                        if (photo != null && photo.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(photo))
                            {
                                picturedata = System.Drawing.Image.FromStream(ms);
                            }
                        }

                        int id = r["StaffID"] != DBNull.Value ? Convert.ToInt32(r["StaffID"]) : 0;
                        string First_name = r["First_name"].ToString();
                        string Last_name = r["Last_name"].ToString();
                        string Username = r["Username"].ToString();
                        string Password = r["Password"].ToString();
                        string Position = r["Position"].ToString();
                        string Email = r["Email"].ToString();
                        string Phone = r["Phone"].ToString();
                        DateTime HiredDate = r["Hired_Date"] != DBNull.Value ? Convert.ToDateTime(r["Hired_Date"]) : DateTime.MinValue;
                        float Salary = r["Salary"] != DBNull.Value ? Convert.ToSingle(r["Salary"]) : 0.0f;
                        StaffDataGrid.Rows.Add(picturedata, id, First_name, Last_name, Username, Password, Position, Email, Phone, HiredDate.ToString("MM-dd-yyyy"), Salary);
                    }r.Close();
                    cmd.Dispose();



                }
                catch (Exception ex) { MessageBox.Show($"Error:{ex}", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
    }
}
    
        
    


