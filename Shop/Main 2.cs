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
    public partial class Main_2 : Form
    {
        public Main_2()
        {
            InitializeComponent();
        }

        private void Main_2_Load(object sender, EventArgs e)
        {
            lblLoginUser.Text = "Welcome : " + Global.username;
        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.about++;
            if (Global.about == 1)
            {
                About frm = new About();
                frm.Show();
            }
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.invoice++;
            if (Global.invoice == 1)
            {
                Invoice frm = new Invoice();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.sales_record++;
            if (Global.sales_record == 1)
            {
                Sales_Record frm = new Sales_Record();
                frm.Show();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Label frm = new Label();
            frm.Show();
        }

        private void Main_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.username = "";
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void customerInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.customerInvoice++;
            if (Global.customerInvoice == 1)
            {
                Invoice_for_Customer icus = new Invoice_for_Customer();
                icus.MdiParent = this;
                icus.Show();
            }
        }

        private void agentInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.invoiceForAgents++;
            if (Global.invoiceForAgents == 1)
            {
                Invoice_for_Agents frm = new Invoice_for_Agents();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
