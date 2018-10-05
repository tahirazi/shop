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
    public partial class Invoice_Print : Form
    {
        public static string abc="";
        public Invoice_Print()
        {
            InitializeComponent();
        }

        private void Invoice_Print_Load(object sender, EventArgs e)
        {
            string invoice;
            Invoice frm = new Invoice();
            invoice = frm.txtInvoiceNo.Text;
            DataSet1.EnforceConstraints = false;
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1, abc);

            this.reportViewer1.RefreshReport();
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet1.EnforceConstraints = false;
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1, textBox1.Text);

            this.reportViewer1.RefreshReport();
        }

        private void Invoice_Print_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.invoice_print = 0;
        }
    }
}
