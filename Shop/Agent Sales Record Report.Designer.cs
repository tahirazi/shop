namespace Shop
{
    partial class Agent_Sales_Record_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.shopDataSet2 = new Shop.shopDataSet2();
            this.salesaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesaTableAdapter = new Shop.shopDataSet2TableAdapters.salesaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.salesaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Shop.rptAgentSalesRecord.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(875, 404);
            this.reportViewer1.TabIndex = 0;
            // 
            // shopDataSet2
            // 
            this.shopDataSet2.DataSetName = "shopDataSet2";
            this.shopDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesaBindingSource
            // 
            this.salesaBindingSource.DataMember = "salesa";
            this.salesaBindingSource.DataSource = this.shopDataSet2;
            // 
            // salesaTableAdapter
            // 
            this.salesaTableAdapter.ClearBeforeFill = true;
            // 
            // Agent_Sales_Record_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 404);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Agent_Sales_Record_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent Sales Record Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Agent_Sales_Record_Report_FormClosing);
            this.Load += new System.EventHandler(this.Agent_Sales_Record_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource salesaBindingSource;
        private shopDataSet2 shopDataSet2;
        private shopDataSet2TableAdapters.salesaTableAdapter salesaTableAdapter;
    }
}