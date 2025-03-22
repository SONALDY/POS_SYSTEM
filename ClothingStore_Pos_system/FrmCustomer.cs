using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class FrmCustomer : Form
    {

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void btnOpenCus_Click(object sender, EventArgs e)
        {
            FrmAddCustomer addCustomerForm = new FrmAddCustomer(this);
            addCustomerForm.Show();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            loadDate(customerdata);
        }

        public void loadDate(Guna2DataGridView customerdata)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCustomers", DataConnection.DataCon);
            DataTable dt = new DataTable();
            da.Fill(dt);

            customerdata.ColumnHeadersVisible = true;
            customerdata.ColumnHeadersHeight = 30;
            customerdata.RowTemplate.Height = 40;
            customerdata.DataSource = dt;
        }

        private void customerdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void customerdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customerdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = customerdata.Rows[e.RowIndex];

               
                int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value); 
                string first_name = row.Cells["First_name"].Value.ToString();
                string last_name = row.Cells["Last_name"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string phone = row.Cells["Phone"].Value.ToString();
                string address = row.Cells["Address_"].Value.ToString();

                
                FrmAddCustomer addCustomerForm = new FrmAddCustomer(customerId, first_name, last_name, email, phone, address);
                addCustomerForm.Show();
            }
        }

        private void searchtextcus_TextChanged(object sender, EventArgs e)
        {
            if (searchtextcus.Text == "")
            {
                loadDate(customerdata);
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM tblCustomers WHERE Last_name LIKE @Last_name;";
                    SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon);
                    cmd.Parameters.AddWithValue("@Last_name", "%" + searchtextcus.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    customerdata.DataSource = dt; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }   
}
