﻿namespace Shop
{
    partial class Customer_Balance_Record
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCreditORDebit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGrossAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCreditDebit = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search for Balance Data Here.";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(128, 35);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(168, 20);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Enter Customer Code";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionNo,
            this.InvoiceNo,
            this.date,
            this.amount,
            this.balance});
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(493, 305);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // TransactionNo
            // 
            this.TransactionNo.HeaderText = "Trans. No";
            this.TransactionNo.Name = "TransactionNo";
            this.TransactionNo.ReadOnly = true;
            this.TransactionNo.Width = 75;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice No.";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 125;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 75;
            // 
            // balance
            // 
            this.balance.HeaderText = "Balance";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            this.balance.Width = 75;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtCreditORDebit);
            this.GroupBox3.Controls.Add(this.label9);
            this.GroupBox3.Controls.Add(this.txtGrossAmount);
            this.GroupBox3.Controls.Add(this.label4);
            this.GroupBox3.ForeColor = System.Drawing.Color.White;
            this.GroupBox3.Location = new System.Drawing.Point(511, 86);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(184, 305);
            this.GroupBox3.TabIndex = 27;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Total";
            // 
            // txtCreditORDebit
            // 
            this.txtCreditORDebit.Location = new System.Drawing.Point(36, 112);
            this.txtCreditORDebit.Name = "txtCreditORDebit";
            this.txtCreditORDebit.ReadOnly = true;
            this.txtCreditORDebit.Size = new System.Drawing.Size(100, 20);
            this.txtCreditORDebit.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 27;
            this.label9.Text = "Credit/Debit";
            // 
            // txtGrossAmount
            // 
            this.txtGrossAmount.Location = new System.Drawing.Point(37, 49);
            this.txtGrossAmount.Name = "txtGrossAmount";
            this.txtGrossAmount.ReadOnly = true;
            this.txtGrossAmount.Size = new System.Drawing.Size(102, 20);
            this.txtGrossAmount.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Gross Amount";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(154, 61);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtNetAmount.TabIndex = 32;
            this.txtNetAmount.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(142, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "Received Amount";
            this.label8.Visible = false;
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(166, 63);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.Size = new System.Drawing.Size(102, 20);
            this.txtReceived.TabIndex = 25;
            this.txtReceived.Visible = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(147, 59);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(102, 20);
            this.txtDiscount.TabIndex = 25;
            this.txtDiscount.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(163, 61);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 18);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Net Amount";
            this.Label5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(157, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Discount Amount";
            this.label2.Visible = false;
            // 
            // lblCreditDebit
            // 
            this.lblCreditDebit.AutoSize = true;
            this.lblCreditDebit.ForeColor = System.Drawing.Color.White;
            this.lblCreditDebit.Location = new System.Drawing.Point(577, 70);
            this.lblCreditDebit.Name = "lblCreditDebit";
            this.lblCreditDebit.Size = new System.Drawing.Size(64, 13);
            this.lblCreditDebit.TabIndex = 33;
            this.lblCreditDebit.Text = "Debit/Credit";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(302, 33);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(75, 23);
            this.btnPrintReport.TabIndex = 34;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // Customer_Balance_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(712, 403);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.lblCreditDebit);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Label5);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.Name = "Customer_Balance_Record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Balance Record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customer_Balance_Record_FormClosing);
            this.Load += new System.EventHandler(this.Customer_Balance_Record_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.TextBox txtCreditORDebit;
        private System.Windows.Forms.TextBox txtNetAmount;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtReceived;
        internal System.Windows.Forms.TextBox txtDiscount;
        internal System.Windows.Forms.TextBox txtGrossAmount;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCreditDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.Button btnPrintReport;
    }
}