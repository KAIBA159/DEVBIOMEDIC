namespace CapaPresentacion.Reportes
{
    partial class FrmReporteKardexv4xLoteMes
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
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.spkardexproductoxlotexmesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_kardex_producto_x_lote_x_mesTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.sp_kardex_producto_x_lote_x_mesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkardexproductoxlotexmesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.spkardexproductoxlotexmesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptKardexv4_lote_mes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(853, 604);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spkardexproductoxlotexmesBindingSource
            // 
            this.spkardexproductoxlotexmesBindingSource.DataMember = "sp_kardex_producto_x_lote_x_mes";
            this.spkardexproductoxlotexmesBindingSource.DataSource = this.dsPrincipal;
            // 
            // sp_kardex_producto_x_lote_x_mesTableAdapter
            // 
            this.sp_kardex_producto_x_lote_x_mesTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteKardexv4xLoteMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 604);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteKardexv4xLoteMes";
            this.Text = "Reporte Karde por Lote y Mes";
            this.Load += new System.EventHandler(this.FrmReporteKardexv4xLoteMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkardexproductoxlotexmesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spkardexproductoxlotexmesBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.sp_kardex_producto_x_lote_x_mesTableAdapter sp_kardex_producto_x_lote_x_mesTableAdapter;
    }
}