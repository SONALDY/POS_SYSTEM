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
    public partial class FrmPrint : Form
    {
        public FrmPrint()
        {
            InitializeComponent();
        }
        public void setSource(List<ReportDetails> list)
        {
            CrystalReport11.SetDataSource(list);
        }
        public void setparamater(int index, object value)
        {
            CrystalReport11.SetParameterValue(index, value);
        }
        public void Print(int numpage, bool condition, int start, int end)
        {
            CrystalReport11.PrintToPrinter(numpage, condition, start, end);
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
