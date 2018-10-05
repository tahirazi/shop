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
    public partial class Agent_Sales_Record_Report : Form
    {
        public Agent_Sales_Record_Report()
        {
            InitializeComponent();
        }

        private void Agent_Sales_Record_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet2.salesa' table. You can move, or remove it, as needed.
            this.salesaTableAdapter.FillBy(this.shopDataSet2.salesa,Convert.ToDateTime(Agent_Sales_Record.from), Convert.ToDateTime(Agent_Sales_Record.to));

            this.reportViewer1.RefreshReport();
        }

        private void Agent_Sales_Record_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.agentSalesRecordReport = 0;
        }
    }
}
