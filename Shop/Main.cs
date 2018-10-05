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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.category++;
            if (Global.category == 1)
            {
                Category category = new Category();
                category.Show();
            }
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.company++;
            if (Global.company == 1)
            {
                Company frm = new Company();
                frm.Show();
            }
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.products++;
            if (Global.products == 1)
            {
                Products frm = new Products();
                frm.Show();
            }
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.config++;
            if (Global.config == 1)
            {
                Config frm = new Config();
                frm.Show();
            }
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.stock++;
            if (Global.stock == 1)
            {
                Stock frm = new Stock();
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

        private void printLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.label_printing++;
            if (Global.label_printing == 1)
            {
                Label_Printing frm = new Label_Printing();
                frm.Show();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.username = "";
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            lblLoginUser.Text = "Welcome : " + Global.username;
            menuStrip3.BackColor = Color.Gray;
            menuStrip1.BackColor = Color.Gray;
            registrationToolStripMenuItem.BackColor = Color.Gray;
            
            
            //GoFullscreen(true);
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
            
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.sales_record++;
            if (Global.sales_record == 1)
            {
                Sales_Record frm = new Sales_Record();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void productsToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void sensationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.about++;
            if (Global.about == 1)
            {
                About frm = new About();
                frm.Show();
            }
        }

        private void companyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.company++;
            if (Global.company == 1)
            {
                Company frm = new Company();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.about++;
            if (Global.about == 1)
            {
                About frm = new About();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.category++;
            if (Global.category == 1)
            {
                Category frm = new Category();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.config++;
            if(Global.config==1)
            {
                Config frm = new Config();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void sTOCKToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Global.stock++;
            if(Global.stock==1)
            {
            Stock frm = new Stock();
            frm.MdiParent = this;
            frm.Show();
            }
        }

        private void lABELToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.label_printing++;
            if (Global.label_printing == 1)
            {
                Label_Printing frm = new Label_Printing();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void sALESToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Global.sales_record++;
            if (Global.sales_record == 1)
            {
                Sales_Record frm = new Sales_Record();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.stock_bulk_entry++;
            if (Global.stock_bulk_entry == 1)
            {
                Stock_Bulk_Entry frm = new Stock_Bulk_Entry();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void bulkDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.bulk_data_insertion++;
            if (Global.bulk_data_insertion == 1)
            {
                Bulk_Data_Insertion frm = new Bulk_Data_Insertion();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.backup++;
            if (Global.backup == 1)
            {
                Backup frm = new Backup();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_Update frm = new Sales_Update();
            frm.Show();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returns frm = new Returns();
            frm.MdiParent = this;
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.users++;
            if (Global.users == 1)
            {
                Users usr = new Users();
                usr.MdiParent = this;
                usr.Show();
            }
        }

        private void customerInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cashBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.CashBook++;
            if (Global.CashBook == 1)
            {
                CashBook cb = new CashBook();
                cb.MdiParent = this;
                cb.Show();
            }

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void balancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salesRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.CustomerSalesRecord++;
            if (Global.CustomerSalesRecord == 1)
            {
                Customer_Sales_Record frm = new Customer_Sales_Record();
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
            }
        }

        private void customerRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.customers++;
            if (Global.customers == 1)
            {
                Custo cu = new Custo();
                cu.MdiParent = this;
                cu.Show();
            }
        }

        private void agentBasicDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.agents++;
            if (Global.agents == 1)
            {
                Agents frm = new Agents();
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
            }
        }

        private void invoiceForAgentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.invoiceForAgents++;
            if (Global.invoiceForAgents == 1)
            {
                Invoice_for_Agents frm = new Invoice_for_Agents();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void agentBalanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.agentBalanceRecord++;
            if (Global.agentBalanceRecord == 1)
            {
                Agent_Balance frm = new Agent_Balance();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void agentSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.agentSalesRecord++;
            if (Global.agentSalesRecord == 1)
            {
                Agent_Sales_Record frm = new Agent_Sales_Record();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void productsToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Global.products++;
            if (Global.products == 1)
            {
                Products frm = new Products();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void balaceDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.customerbalancerecord++;
            if (Global.customerbalancerecord == 1)
            {
                Customer_Balance_Record frm = new Customer_Balance_Record();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void invoiceForCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.customerInvoice++;
            if (Global.customerInvoice == 1)
            {
                Invoice_for_Customer icus = new Invoice_for_Customer();
                icus.MdiParent = this;
                icus.Show();
            }
        }
    }
}
