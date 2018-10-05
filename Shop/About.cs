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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Transparent;
            tableLayoutPanel.BackColor = Color.Transparent;
            logoPictureBox.BackColor = Color.Transparent;
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.about = 0;
        }
    }
}
