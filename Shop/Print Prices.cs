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
    public partial class Print_Prices : Form
    {
        public Print_Prices()
        {
            InitializeComponent();
        }

        private void Print_Prices_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.config' table. You can move, or remove it, as needed.
            this.configTableAdapter.Fill(this.DataSet1.config);

            this.reportViewer1.RefreshReport();
        }
    }
}
