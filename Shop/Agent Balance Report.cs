using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shop
{
    public partial class Agent_Balance_Report : Form
    {
        public static string category;
        public static string company;
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public Agent_Balance_Report()
        {
            InitializeComponent();
        }

        private void Agent_Balance_Report_Load(object sender, EventArgs e)
        {
            FillCombo();
            // TODO: This line of code loads data into the 'shopDataSet2.agentbalances' table. You can move, or remove it, as needed.
            this.agentbalancesTableAdapter.Fill(this.shopDataSet2.agentbalances);
            this.reportViewer1.RefreshReport();
        }
        public void FillCombo()
        {
            try
            {
                con.Open();
                string ct = "select RTRIM(username) from users order by username";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUsername.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void Agent_Balance_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.agentBalanceRecordReport = 0;
        }

        private void btnAllProducts_Click(object sender, EventArgs e)
        {
            this.agentbalancesTableAdapter.Fill(this.shopDataSet2.agentbalances);
            this.reportViewer1.RefreshReport();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            this.agentbalancesTableAdapter.FillBy(this.shopDataSet2.agentbalances,Convert.ToInt32(txtProductCode.Text));
            this.reportViewer1.RefreshReport();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.agentbalancesTableAdapter.FillBy1(this.shopDataSet2.agentbalances,cmbCategories.Text);
            this.reportViewer1.RefreshReport();
        }

        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.agentbalancesTableAdapter.FillBy1(this.shopDataSet2.agentbalances, cmbUsername.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
