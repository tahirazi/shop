using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Shop
{
    public partial class Config_Record : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        SqlDataReader rdr;
        public Config_Record()
        {
            InitializeComponent();
        }

        private void Config_Record_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT config_id AS [Product Code], product_name AS [Product Name], features AS Features, price AS Price, sale_price AS [Sales Price], agentprice AS [Agent Price] FROM config order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5]);
                }
                rdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void txtProductname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT config_id AS [Product Code], product_name AS [Product Name], features AS Features, price AS Price, sale_price AS [Sales Price], agentprice AS [Agent Price] FROM config where product_name like '" + txtProductname.Text + "%' order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5]);
                }
                rdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                Config obj = new Config();
                obj.MdiParent = Main.ActiveForm;
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                obj.Show();
                obj.txtConfigID.Text = dr.Cells[0].Value.ToString();
                obj.cmbProductName.Text = dr.Cells[1].Value.ToString();
                obj.txtFeatures.Text = dr.Cells[2].Value.ToString();
                obj.txtPrice.Text = dr.Cells[3].Value.ToString();
                obj.txtSalesPrice.Text = dr.Cells[4].Value.ToString();
                obj.txtAgentPrice.Text = dr.Cells[5].Value.ToString();
                obj.btnUpdate.Enabled = true;
                obj.btnDelete.Enabled = true;
                obj.btnSave.Enabled = false;
                obj.cmbProductName.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Config_Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Config frm = new Config();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT config_id AS [Product Code], product_name AS [Product Name], features AS Features, price AS Price, sale_price AS [Sales Price], agentprice AS [Agent Price] FROM config LEFT JOIN stock ON config.config_id=stock.config_id WHERE stock.config_id IS NULL order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5]);
                }
                rdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProductCode.Text == "")
            {
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT config_id AS [Product Code], product_name AS [Product Name], features AS Features, price AS Price, sale_price AS [Sales Price], agentprice AS [Agent Price] FROM config where config_id like '" + Int32.Parse(txtProductCode.Text) + "%' order by product_name", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                    }
                    rdr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void btnPrintPrices_Click(object sender, EventArgs e)
        {
            Print_Prices frm = new Print_Prices();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
        }
    }
}
