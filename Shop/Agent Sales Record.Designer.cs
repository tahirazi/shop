namespace Shop
{
    partial class Agent_Sales_Record
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBySaleMan = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtCreditDebit = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpInvoiceDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpInvoiceDateFrom = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnBySaleMan);
            this.GroupBox2.Controls.Add(this.btnReport);
            this.GroupBox2.Controls.Add(this.btnGetData);
            this.GroupBox2.Controls.Add(this.btnReset);
            this.GroupBox2.Location = new System.Drawing.Point(309, 26);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(455, 87);
            this.GroupBox2.TabIndex = 35;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "             ";
            // 
            // btnBySaleMan
            // 
            this.btnBySaleMan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBySaleMan.Location = new System.Drawing.Point(310, 27);
            this.btnBySaleMan.Name = "btnBySaleMan";
            this.btnBySaleMan.Size = new System.Drawing.Size(131, 39);
            this.btnBySaleMan.TabIndex = 8;
            this.btnBySaleMan.Text = "By Current User";
            this.btnBySaleMan.UseVisualStyleBackColor = true;
            this.btnBySaleMan.Click += new System.EventHandler(this.btnBySaleMan_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(210, 26);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(94, 40);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "&View Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(16, 26);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(94, 40);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "&Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(112, 26);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 40);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // txtCreditDebit
            // 
            this.txtCreditDebit.Location = new System.Drawing.Point(102, 135);
            this.txtCreditDebit.Name = "txtCreditDebit";
            this.txtCreditDebit.ReadOnly = true;
            this.txtCreditDebit.Size = new System.Drawing.Size(124, 20);
            this.txtCreditDebit.TabIndex = 27;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtCreditDebit);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.txtReceived);
            this.GroupBox3.Controls.Add(this.txtDiscount);
            this.GroupBox3.Controls.Add(this.txtTotal);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Location = new System.Drawing.Point(786, 115);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(237, 173);
            this.GroupBox3.TabIndex = 37;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Credit/Debit";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(102, 99);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.Size = new System.Drawing.Size(124, 20);
            this.txtReceived.TabIndex = 25;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(102, 62);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(124, 20);
            this.txtDiscount.TabIndex = 25;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(102, 26);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(124, 20);
            this.txtTotal.TabIndex = 24;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(6, 102);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(63, 18);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Received";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 66);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 18);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Discount";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 31);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 18);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "Total";
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(772, 67);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(125, 21);
            this.cmbUsers.TabIndex = 38;
            this.cmbUsers.Text = "Select User";
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dtpInvoiceDateTo);
            this.GroupBox1.Controls.Add(this.dtpInvoiceDateFrom);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(14, 25);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(290, 87);
            this.GroupBox1.TabIndex = 34;
            this.GroupBox1.TabStop = false;
            // 
            // dtpInvoiceDateTo
            // 
            this.dtpInvoiceDateTo.CustomFormat = "dd/MMM/yyyy";
            this.dtpInvoiceDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDateTo.Location = new System.Drawing.Point(154, 42);
            this.dtpInvoiceDateTo.Name = "dtpInvoiceDateTo";
            this.dtpInvoiceDateTo.Size = new System.Drawing.Size(120, 20);
            this.dtpInvoiceDateTo.TabIndex = 1;
            // 
            // dtpInvoiceDateFrom
            // 
            this.dtpInvoiceDateFrom.CustomFormat = "dd/MMM/yyyy";
            this.dtpInvoiceDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDateFrom.Location = new System.Drawing.Point(24, 42);
            this.dtpInvoiceDateFrom.Name = "dtpInvoiceDateFrom";
            this.dtpInvoiceDateFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpInvoiceDateFrom.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(20, 18);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 21);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "From";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(150, 18);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(28, 21);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "To";
            // 
            // DataGridView1
            // 
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(14, 118);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(766, 409);
            this.DataGridView1.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(770, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 21);
            this.label6.TabIndex = 39;
            this.label6.Text = "Search By Users";
            // 
            // Agent_Sales_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 552);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.label6);
            this.Name = "Agent_Sales_Record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent Sales Record";
            this.Load += new System.EventHandler(this.Agent_Sales_Record_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Button btnBySaleMan;
        internal System.Windows.Forms.Button btnReport;
        internal System.Windows.Forms.Button btnGetData;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.TextBox txtCreditDebit;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtReceived;
        internal System.Windows.Forms.TextBox txtDiscount;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cmbUsers;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.DateTimePicker dtpInvoiceDateTo;
        internal System.Windows.Forms.DateTimePicker dtpInvoiceDateFrom;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Label label6;
    }
}