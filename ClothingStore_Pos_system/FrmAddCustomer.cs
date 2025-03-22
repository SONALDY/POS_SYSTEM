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
using System.Xml.Linq;

namespace ClothingStore_Pos_system
{
    public partial class FrmAddCustomer : Form
    {
        private FrmCustomer _customer;
        private int _customerId = -1; // Default value for "Add" mode
        private bool _isEditMode = false; // Flag to determine the mode
        public FrmAddCustomer( FrmCustomer customer)
        {
            InitializeComponent();
            _customer = customer;
            btnUpdateCus.Visible = false;
        }
        public FrmAddCustomer(int customerId, string first_name, string last_name, string email, string phone, string address)
        {
            InitializeComponent();
            // Store the customer ID and set the mode
            _customerId = customerId;
            _isEditMode = true;

            // Populate the textboxes with the passed data
            txtFname.Text = first_name;
            txtLname.Text = last_name;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;

            // Update the UI for "Edit" mode
            btnaddcus.Visible = false; // Hide the Add button
            btnUpdateCus.Visible = true; // Show the Update button
            this.Text = "Edit Customer";
        }
        private void btnaddcus_Click(object sender, EventArgs e)
        {
            try
            {
               
                string sql = "INSERT INTO tblCustomers (First_name,Last_name,Email,Phone,Address_)VALUEs(@First_name,@Last_name,@Email,@Phone,@Address_)";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@First_name", txtFname.Text);
                        cmd.Parameters.AddWithValue("@Last_name", txtLname.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Address_", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                        if (_customer != null)
                        {
                            _customer.loadDate(_customer.customerdata);
                        }
                        else
                        {
                            MessageBox.Show("Customer form instance is null.");
                        }
                        MessageBox.Show("Your Data have been added");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateCus_Click(object sender, EventArgs e)
        {
            try
            {
               
                // Update existing customer
                string sql = "UPDATE tblCustomers SET First_name = @First_name, Last_name = @Last_name, Email = @Email, Phone = @Phone, Address_ = @Address_ WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@First_name", txtFname.Text);
                    cmd.Parameters.AddWithValue("@Last_name", txtLname.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address_", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CustomerID", _customerId);
                    cmd.ExecuteNonQuery();
                    if (_customer != null)
                    {
                        _customer.loadDate(_customer.customerdata);
                    }
                    else
                    {
                        MessageBox.Show("Customer form instance is null.");
                    }
                    MessageBox.Show("Customer data has been updated.");
                }

                // Close the form after updating
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
