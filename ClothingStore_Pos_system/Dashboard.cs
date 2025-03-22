using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            CenterPanel.Controls.Add(f);
            f.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new FrmHome());
        }

        private void btCategory_Click(object sender, EventArgs e)
        {
            AddControls(new FrmCategory());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            AddControls(new FrmCustomer());
        }

        private void btCategory_Click_1(object sender, EventArgs e)
        {
            AddControls(new FrmCategory());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new FrmProductView());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new FrmStaffView());
        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnExpense_Click(object sender, EventArgs e)
        {
            AddControls(new FrmExpenseView());
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm.instance.Show(); 
                this.Close(); 
            }
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            AddControls(new FrmPosOrder());
        }
    }
}
