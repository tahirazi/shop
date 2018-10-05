﻿namespace Shop
{
    partial class Customer_Balance_Record_Report
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.balancesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopDataSet2 = new Shop.shopDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.balancesTableAdapter = new Shop.shopDataSet2TableAdapters.balancesTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.salescBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopDataSet21 = new Shop.shopDataSet2();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.btnAllProducts = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.salescTableAdapter = new Shop.shopDataSet2TableAdapters.salescTableAdapter();
            this.shopDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new Shop.shopDataSet2TableAdapters.usersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.balancesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salescBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // balancesBindingSource
            // 
            this.balancesBindingSource.DataMember = "balances";
            this.balancesBindingSource.DataSource = this.shopDataSet2;
            // 
            // shopDataSet2
            // 
            this.shopDataSet2.DataSetName = "shopDataSet2";
            this.shopDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.balancesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Shop.Report8.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(805, 527);
            this.reportViewer1.TabIndex = 0;
            // 
            // balancesTableAdapter
            // 
            this.balancesTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbCategories);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtProductCode);
            this.panel2.Controls.Add(this.btnAllProducts);
            this.panel2.Controls.Add(this.btnGO);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 55);
            this.panel2.TabIndex = 8;
            // 
            // cmbCategories
            // 
            this.cmbCategories.DataSource = this.usersBindingSource;
            this.cmbCategories.DisplayMember = "username";
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(486, 21);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(164, 21);
            this.cmbCategories.TabIndex = 5;
            this.cmbCategories.ValueMember = "username";
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // salescBindingSource
            // 
            this.salescBindingSource.DataMember = "salesc";
            this.salescBindingSource.DataSource = this.shopDataSet21;
            // 
            // shopDataSet21
            // 
            this.shopDataSet21.DataSetName = "shopDataSet2";
            this.shopDataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "By User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Customer Code Here";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(154, 21);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(100, 20);
            this.txtProductCode.TabIndex = 1;
            // 
            // btnAllProducts
            // 
            this.btnAllProducts.Location = new System.Drawing.Point(320, 19);
            this.btnAllProducts.Name = "btnAllProducts";
            this.btnAllProducts.Size = new System.Drawing.Size(80, 23);
            this.btnAllProducts.TabIndex = 4;
            this.btnAllProducts.Text = "All Customers";
            this.btnAllProducts.UseVisualStyleBackColor = true;
            this.btnAllProducts.Click += new System.EventHandler(this.btnAllProducts_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(267, 19);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(47, 23);
            this.btnGO.TabIndex = 2;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // salescTableAdapter
            // 
            this.salescTableAdapter.ClearBeforeFill = true;
            // 
            // shopDataSet2BindingSource
            // 
            this.shopDataSet2BindingSource.DataSource = this.shopDataSet2;
            this.shopDataSet2BindingSource.Position = 0;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.shopDataSet2BindingSource;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // Customer_Balance_Record_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 590);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Customer_Balance_Record_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Balance Record Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customer_Balance_Record_Report_FormClosing);
            this.Load += new System.EventHandler(this.Customer_Balance_Record_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.balancesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salescBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource balancesBindingSource;
        private shopDataSet2 shopDataSet2;
        private shopDataSet2TableAdapters.balancesTableAdapter balancesTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnAllProducts;
        private System.Windows.Forms.Button btnGO;
        private shopDataSet2 shopDataSet21;
        private System.Windows.Forms.BindingSource salescBindingSource;
        private shopDataSet2TableAdapters.salescTableAdapter salescTableAdapter;
        private System.Windows.Forms.BindingSource shopDataSet2BindingSource;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private shopDataSet2TableAdapters.usersTableAdapter usersTableAdapter;
    }
}