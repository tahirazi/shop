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
    public partial class Customer_Sales_Record_rpt : Form
    {
        public Customer_Sales_Record_rpt()
        {
            InitializeComponent();
        }

        private void Customer_Sales_Record_rpt_Load(object sender, EventArgs e)
        {
            this.salescTableAdapter.FillBy(this.shopDataSet2.salesc,Convert.ToDateTime(Customer_Sales_Record.from),Convert.ToDateTime(Customer_Sales_Record.to));
            this.reportViewer1.RefreshReport();
        }

        private void Customer_Sales_Record_rpt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.CustomerSalesRecordReport = 0;
        }
    }
}
