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
    public partial class DashBoardSale : Form
    {
        public DashBoardSale()
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
        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCustomersale_Click(object sender, EventArgs e)
        {
            AddControls(new FrmCustomer());
        }

        private void btnsignoutsale_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm.instance.Show();
                this.Close();
            }
        }

        private void BtnExpensesale_Click(object sender, EventArgs e)
        {
            AddControls(new FrmExpenseView());
        }

        private void btnPossale_Click(object sender, EventArgs e)
        {
            AddControls(new FrmPosOrder());
        }

        private void btnHomesale_Click(object sender, EventArgs e)
        {
            AddControls(new FrmHome());
        }
    }
}
