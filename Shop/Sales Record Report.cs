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
    public partial class Sales_Record_Report : Form
    {
        public Sales_Record_Report()
        {
            InitializeComponent();
        }

        private void Sales_Record_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.sales' table. You can move, or remove it, as needed.
            //this.salesTableAdapter.Fill(this.DataSet1.sales);
            this.salesTableAdapter.FillBy(this.DataSet1.sales, Convert.ToDateTime(Sales_Record.from), Convert.ToDateTime(Sales_Record.to));
            //this.salesTableAdapter.Fill(this.DataSet1.sales);
            
            this.rptViewer.RefreshReport();
        }
    }
}
