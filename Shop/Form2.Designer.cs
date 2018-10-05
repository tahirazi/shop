namespace Shop
{
    partial class Form2
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
            this.Label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(378, 149);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(57, 17);
            this.Label11.TabIndex = 150;
            this.Label11.Text = "Remarks";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(37, 107);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(37, 17);
            this.Label5.TabIndex = 148;
            this.Label5.Text = "Total";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(161, 58);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(185, 20);
            this.txtCustomerName.TabIndex = 152;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(161, 106);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(186, 20);
            this.txtTotal.TabIndex = 144;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(378, 106);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(56, 17);
            this.Label12.TabIndex = 149;
            this.Label12.Text = "Discount";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(490, 142);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(89, 20);
            this.txtRemarks.TabIndex = 146;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(477, 103);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(89, 20);
            this.txtDiscount.TabIndex = 145;
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(161, 149);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(132, 20);
            this.txtReceived.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 151;
            this.label1.Text = "Customer Name";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(37, 152);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(57, 17);
            this.Label9.TabIndex = 153;
            this.Label9.Text = "Received";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(162, 20);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(185, 20);
            this.txtInvoiceNo.TabIndex = 155;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(37, 23);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 17);
            this.Label4.TabIndex = 154;
            this.Label4.Text = "Invoice No.";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(503, 16);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(120, 24);
            this.dtpInvoiceDate.TabIndex = 157;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(378, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 17);
            this.Label3.TabIndex = 156;
            this.Label3.Text = "Invoice Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 158;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 525);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtCustomerName;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.TextBox txtDiscount;
        internal System.Windows.Forms.TextBox txtReceived;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtInvoiceNo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button button1;
    }
}