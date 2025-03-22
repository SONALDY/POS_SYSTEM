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
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClothingStore_Pos_system
{
    public partial class FrmAddStaff : Form
    {
        public Image StaffPictureBoxImage
        {
            get { return staffpicturebox.Image; }
            set { staffpicturebox.Image = value; }
        }
        private FrmStaffView _staffView;
        public bool IsEditMode = false;
        private List<string> staffID = new List<string>();

        public FrmAddStaff(FrmStaffView staffView, int staffID = 0, string firstName = "", string lastName = "", string username = "", string password = "", string email = "", string phone = "", string position = "", float salary = 0, DateTime dob = default, DateTime hiredDate = default, byte[] photo = null)
        {
            InitializeComponent();
            _staffView = staffView;

            // Populate fields if in edit mode
            if (staffID > 0)
            {
                txtfirstname.Text = firstName;
                txtlastname.Text = lastName;
                txtusername.Text = username;
                txtpassword.Text = password;
                txtemail.Text = email;
                txtphone.Text = phone;
                txtposition.Text = position;
                txtsalary.Text = salary.ToString();
                dtpDOB.MinDate = new DateTime(1900, 1, 1);

                // Assign the value only if it's within valid range
                if (dob != null && dob >= dtpDOB.MinDate && dob <= dtpDOB.MaxDate)
                {
                    dtpDOB.Value = dob;
                }
                else
                {
                    dtpDOB.Value = dtpDOB.MinDate; // Safe fallback
                }
                dtpHired.MinDate = new DateTime(1900, 1, 1);

                // Assign the value only if it's within valid range
                if (hiredDate != null && hiredDate >= dtpHired.MinDate && hiredDate <= dtpHired.MaxDate)
                {
                    dtpHired.Value = hiredDate;
                }
                else
                {
                    dtpHired.Value = dtpHired.MinDate; // Safe fallback
                }
                if (photo != null && photo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(photo))
                    {
                        staffpicturebox.Image = Image.FromStream(ms);
                    }
                }

                btnAddStaff.Visible = false; // Hide the "Add" button
                btnUpdateStaff.Visible = true; // Show the "Update" button
            }
            else
            {
                btnAddStaff.Visible = true; // Show the "Add" button
                btnUpdateStaff.Visible = false; // Hide the "Update" button
            }
        }

        private void FrmAddStaff_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblStaff (First_Name,Last_Name,Username,Password,Email,Phone,DOB,Position,Salary,Photo,Hired_Date)VALUES(@First_Name,@Last_Name,@Username,@Password,@Email,@Phone,@DOB,@Position,@Salary,@Photo,@Hired_Date) ";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@First_Name", txtfirstname.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", txtlastname.Text);
                        cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
                        cmd.Parameters.AddWithValue("@Hired_Date", dtpHired.Value);
                        cmd.Parameters.AddWithValue("@Position", txtposition.Text);
                        cmd.Parameters.AddWithValue("@Salary", txtsalary.Text);
                        MemoryStream memoryStream = new MemoryStream();
                        staffpicturebox.Image.Save(memoryStream, staffpicturebox.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@photo", memoryStream.ToArray());
                        cmd.ExecuteNonQuery();
                        _staffView.staffDatabase();
                        MessageBox.Show("Staff Data have been Added");
                    }

                    catch { }
                }
            }
            catch { }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".bmp")
                {
                    try
                    {
                        staffpicturebox.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid image format. Please select a JPEG, PNG, or BMP file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE tblStaff SET First_Name=@First_Name, Last_Name=@Last_Name, Username=@Username, Password=@Password, Email=@Email, Phone=@Phone, DOB=@DOB, Position=@Position, Salary=@Salary, Photo=@Photo, Hired_Date=@Hired_Date WHERE StaffID=@StaffID"; // Corrected Staff_ID to StaffID

                using (SqlConnection connection = DataConnection.GetConnection()) // Get a new connection
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection)) // Use the new connection
                    {
                        cmd.Parameters.AddWithValue("@First_Name", txtfirstname.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", txtlastname.Text);
                        cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
                        cmd.Parameters.AddWithValue("@Hired_Date", dtpHired.Value);
                        cmd.Parameters.AddWithValue("@Position", txtposition.Text);
                        cmd.Parameters.AddWithValue("@Salary", Convert.ToSingle(txtsalary.Text));
                        cmd.Parameters.AddWithValue("@StaffID", _staffView.staffIDupdate); // Use the correct staffIDupdate

                        // Check if an image is uploaded
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (Image tempImage = new Bitmap(staffpicturebox.Image)) // Create a copy
                            {
                                tempImage.Save(memoryStream, staffpicturebox.Image.RawFormat);
                            }
                            cmd.Parameters.AddWithValue("@Photo", memoryStream.ToArray());
                        }

                        cmd.ExecuteNonQuery();
                        _staffView.staffDatabase();
                        MessageBox.Show("Staff data updated successfully.");
                    }
                } // connection is closed here
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating staff: " + ex.Message);
            }
        }
    }
}
