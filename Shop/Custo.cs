using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace Shop
{
    public partial class Custo : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;

        public Custo()
        {
            InitializeComponent();
        }

        private void Custo_Load(object sender, EventArgs e)
        {
            GetData();
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[3].Width = 200;
        }

        #region Functions and methods
        public void GetData()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [id] as [ID],[customer_name] as [Name],[phone] as Phone ,[customer_address] as [Customer Address] FROM [Shop].[dbo].[customers]", con);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }
        public void clear()
        {
            txtAddress.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
        }
        public void delete_records()
        {
            try
            {
                con.Open();
                string query = "DELETE FROM customers WHERE id='" + Convert.ToInt32(lblCustomerID.Text) + "'";
                cmd = new SqlCommand(query);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
                MessageBox.Show("Successfully Deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void GetDataByCustomerName()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [id] as [ID],[customer_name] as [Name],[phone] as Phone ,[customer_address] as [Customer Address] FROM [Shop].[dbo].[customers] Where customer_name like '" + txtCustomerNameSearch.Text + "%' order by customer_name", con);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        public void GetDataByCustomerID()
        {
            if (txtCustomerIDsearch.Text == "")
            {
                GetData();
            }
            else
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT [id] as [ID],[customer_name] as [Name],[phone] as Phone ,[customer_address] as [Customer Address] FROM [Shop].[dbo].[customers] Where id like '" + txtCustomerIDsearch.Text + "%' order by customer_name", con);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        #endregion

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.customers = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerName.Text == "")
                {
                    MessageBox.Show("Please Enter Customer name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustomerName.Focus();
                }
                else if (txtPhoneNumber.Text == "")
                {
                    MessageBox.Show("Please Enter Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNumber.Focus();
                }
                else
                {
                    con.Open();
                    string query = "INSERT INTO customers VALUES ('" + txtCustomerName.Text.Trim() + "','" + txtPhoneNumber.Text.Trim() + "','" + txtAddress.Text.Trim() + "')";
                    cmd = new SqlCommand(query);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();
                    MessageBox.Show("Successfully Added.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    GetData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
            lblCustomerID.Text = "abc";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
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
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void txtCustomerIDsearch_TextChanged(object sender, EventArgs e)
        {
            GetDataByCustomerID();
        }

        private void txtCustomerNameSearch_TextChanged(object sender, EventArgs e)
        {
            GetDataByCustomerName();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
        }

        private void Custo_Load_1(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "UPDATE [shop].[dbo].[customers] SET [customer_name] ='" + txtCustomerName.Text + "',[phone] ='" + txtPhoneNumber.Text + "',[customer_address] ='" + txtAddress.Text + "' WHERE id='" + Convert.ToInt32(lblCustomerID.Text) + "'";
                cmd = new SqlCommand(query);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
                MessageBox.Show("Successfully Updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void Custo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.customers = 0;
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnExport_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                lblCustomerID.Text = dr.Cells[0].Value.ToString();
                txtCustomerName.Text = dr.Cells[1].Value.ToString();
                txtPhoneNumber.Text = dr.Cells[2].Value.ToString();
                txtAddress.Text = dr.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerNameSearch_TextChanged_1(object sender, EventArgs e)
        {
            GetDataByCustomerName();
        }

        private void txtCustomerIDsearch_TextChanged_1(object sender, EventArgs e)
        {
            GetDataByCustomerID();
        }

        private void Custo_Load_2(object sender, EventArgs e)
        {

        }
    }
}
