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
    public partial class Label_Printing : Form
    {
        public Label_Printing()
        {
            InitializeComponent();
        }

        private void Label_Printing_Load(object sender, EventArgs e)
        {
            reportViewer1.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom",650,500);
            // TODO: This line of code loads data into the 'DataSet1.config' table. You can move, or remove it, as needed.
            this.configTableAdapter.Fill(this.DataSet1.config);

            this.reportViewer1.RefreshReport();
        }

        private void configBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cmbCriteria.Text == "Specific Product")
            {
                DataSet1.EnforceConstraints = false;
                this.configTableAdapter.FillBy(this.DataSet1.config,Convert.ToInt32(txtProductNo.Text));
                this.reportViewer1.RefreshReport();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void Label_Printing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.label_printing = 0;
        }
    }
}
