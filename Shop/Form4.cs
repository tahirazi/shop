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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.shopDataSet.DataTable2);

            this.reportViewer1.RefreshReport();
        }
    }
}
