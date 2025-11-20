namespace CapaPresentacion.Reportes
{
    partial class FrmReporteKardexv3xFabricante
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
            this.spkardexresumenporfabricanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_kardex_resumen_por_fabricanteTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.sp_kardex_resumen_por_fabricanteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkardexresumenporfabricanteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.spkardexresumenporfabricanteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptKardexv3_fabricante.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(825, 567);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spkardexresumenporfabricanteBindingSource
            // 
            this.spkardexresumenporfabricanteBindingSource.DataMember = "sp_kardex_resumen_por_fabricante";
            this.spkardexresumenporfabricanteBindingSource.DataSource = this.dsPrincipal;
            // 
            // sp_kardex_resumen_por_fabricanteTableAdapter
            // 
            this.sp_kardex_resumen_por_fabricanteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteKardexv3xFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 567);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteKardexv3xFabricante";
            this.Text = "FrmReporteKardexv3xFabricante";
            this.Load += new System.EventHandler(this.FrmReporteKardexv3xFabricante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkardexresumenporfabricanteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spkardexresumenporfabricanteBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.sp_kardex_resumen_por_fabricanteTableAdapter sp_kardex_resumen_por_fabricanteTableAdapter;
    }
}