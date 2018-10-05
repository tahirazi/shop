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
    public partial class Company_Record : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader dr;
        SqlCommand cmd;
        public Company_Record()
        {
            InitializeComponent();
        }

        private void Company_Record_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
        public void GetData()
        {
            try
            {
                con.Open();
                String sql = "SELECT * from company order by company_name";
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (dr.Read() == true)
                {
                    dataGridView1.Rows.Add(dr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            Company frm = new Company();
            frm.MdiParent = Main.ActiveForm;
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.Show();
            frm.txtCompanyName.Text = dr.Cells[0].Value.ToString();
            frm.textBox1.Text = dr.Cells[0].Value.ToString();
            frm.btnDelete.Enabled = true;
            frm.btnUpdate.Enabled = true;
            frm.txtCompanyName.Focus();
            frm.btnSave.Enabled = false;
        }

        private void Company_Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Company frm = new Company();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
        }
    }
}
