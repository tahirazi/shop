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
    public partial class Sold_Products_Category_Wise : Form
    {
        public Sold_Products_Category_Wise()
        {
            InitializeComponent();
        }

        private void Sold_Products_Category_Wise_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet1.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.shopDataSet1.category);
            // TODO: This line of code loads data into the 'DataSet1.DataTable2' table. You can move, or remove it, as needed.
            
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataTable2TableAdapter.Fill(this.DataSet1.DataTable2, cmbCategories.Text);

            this.reportViewer1.RefreshReport();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            this.DataTable2TableAdapter.FillBy(this.DataSet1.DataTable2, Convert.ToInt32(txtProductCode.Text));

            this.reportViewer1.RefreshReport();
        }

        private void btnAllProducts_Click(object sender, EventArgs e)
        {
            this.DataTable2TableAdapter.FillBy1(this.DataSet1.DataTable2);

            this.reportViewer1.RefreshReport();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
