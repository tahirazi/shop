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
    public partial class Agent_Invoice_Print : Form
    {
        public static string abc = "";
        public Agent_Invoice_Print()
        {
            InitializeComponent();
        }

        private void Agent_Invoice_Print_Load(object sender, EventArgs e)
        {
            shopDataSet2.EnforceConstraints = false;
            this.DataTable1TableAdapter.Fill(this.shopDataSet2.DataTable1, abc);
            this.reportViewer1.RefreshReport();
        }

        private void Agent_Invoice_Print_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.agentInvoicePrint = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Fill(this.shopDataSet2.DataTable1,textBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
