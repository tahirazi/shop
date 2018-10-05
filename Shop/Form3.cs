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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.config' table. You can move, or remove it, as needed.
            this.configTableAdapter.Fill(this.DataSet1.config);

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataSet1.EnforceConstraints = false;
            this.configTableAdapter.FillBy(this.DataSet1.config, Convert.ToInt32(txtProductNo.Text));
            this.reportViewer1.RefreshReport();
        }
    }
}
