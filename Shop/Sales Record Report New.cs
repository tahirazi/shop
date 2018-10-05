using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shop
{
    public partial class Sales_Record_Report_New : Form
    {
        public Sales_Record_Report_New()
        {
            InitializeComponent();
        }

        private void Sales_Record_Report_New_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.FillBy(this.DataSet1.sales, Convert.ToDateTime(Sales_Record.from), Convert.ToDateTime(Sales_Record.to));
            
            this.reportViewer1.RefreshReport();
        }
    }
}
