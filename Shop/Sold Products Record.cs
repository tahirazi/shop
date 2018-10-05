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
    public partial class Sold_Products_Record : Form
    {
        public Sold_Products_Record()
        {
            InitializeComponent();
        }

        private void Sold_Products_Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet.DataTable1' table. You can move, or remove it, as needed.
            
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Fill(this.shopDataSet.DataTable1,Convert.ToInt32(txtProductCode.Text));

            this.reportViewer1.RefreshReport();
        }

        private void btnAllProducts_Click(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.FillBy(this.shopDataSet.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
