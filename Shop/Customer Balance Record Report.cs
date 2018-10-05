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
    public partial class Customer_Balance_Record_Report : Form
    {
        public Customer_Balance_Record_Report()
        {
            InitializeComponent();
        }

        private void Customer_Balance_Record_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet2.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.shopDataSet2.users);
            // TODO: This line of code loads data into the 'shopDataSet21.salesc' table. You can move, or remove it, as needed.
            this.salescTableAdapter.Fill(this.shopDataSet21.salesc);
            // TODO: This line of code loads data into the 'shopDataSet2.balances' table. You can move, or remove it, as needed.
            this.balancesTableAdapter.Fill(this.shopDataSet2.balances);

            this.reportViewer1.RefreshReport();
        }

        private void Customer_Balance_Record_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.PrintBalReport = 0;
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            this.balancesTableAdapter.FillBy(this.shopDataSet2.balances,Convert.ToInt32(txtProductCode.Text));

            this.reportViewer1.RefreshReport();
        }

        private void btnAllProducts_Click(object sender, EventArgs e)
        {
            this.balancesTableAdapter.Fill(this.shopDataSet2.balances);

            this.reportViewer1.RefreshReport();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.balancesTableAdapter.FillBy1(this.shopDataSet2.balances, cmbCategories.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
