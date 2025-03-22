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
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

namespace ClothingStore_Pos_system
{
    public partial class LoginForm : Form
    {
        public static LoginForm instance;
        public LoginForm()
        {
            InitializeComponent();
            instance = this;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = checkShowpass.Checked ? '\0' : '*';
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WELCOME_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = checkShowpass.Checked ? '\0' : '*';
        }
            
        private void btnClear_Click(object sender, EventArgs e)
        {
            Txtusername.Clear();
            TxtPassword.Clear();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Btnlogin2_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = "SONALDY";
                string dbName = "Pos_database";
                string dbUser = "sa";
                string dbPassword = "death";
                DataConnection.ConnectionDB(ip, dbName, dbUser, dbPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            string username = Txtusername.Text.Trim();
            string passwordlogin = TxtPassword.Text.Trim();

            try
            {
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && passwordlogin == "admin123")
                {
                    MessageBox.Show("Welcome To POS System Administrator"); 
                    new Dashboard().Show();
                    this.Hide(); 
                }
                else if (username.Equals("sale", StringComparison.OrdinalIgnoreCase) && passwordlogin == "sale123")
                {
                    MessageBox.Show("Welcome To POS System SalePerson"); 
                    new DashBoardSale().Show();
                    this.Hide(); 
                }
                else
                {
                    Txtusername.Clear();
                    TxtPassword.Clear();
                    MessageBox.Show("Login Failed! Incorrect username or password.", "Failed Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
