using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class Frm_CR_Ingreso_CrystalReport5 : Form
    {
        public int IdIngreso { get; set; }

        public Frm_CR_Ingreso_CrystalReport5()
        {
            InitializeComponent();
        }

        private void Frm_CR_Ingreso_CrystalReport5_Load(object sender, EventArgs e)
        {

            ////// Crea una instancia del reporte
            ////Reportes.CrystalReport5 rpt = new Reportes.CrystalReport5();

            ////// Asigna el parámetro al reporte
            ////rpt.SetParameterValue("@idIngreso", IdIngreso); //@idIngreso

            ////// Carga el reporte en el visor
            ////crystalReportViewer1.ReportSource = rpt;
            ///


            // 1️⃣ Crear instancia del reporte
            Reportes.CrystalReport5 rpt = new Reportes.CrystalReport5();

            // 2️⃣ Datos de conexión
            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = "DESKTOP-IJHQVMG\\SQLSERVERMEDIC",
                DatabaseName = "dbventas",
                UserID = "sa",
                Password = "Maquina50"
            };

            // 3️⃣ Aplicar conexión a las tablas del reporte principal
            foreach (Table table in rpt.Database.Tables)
            {
                TableLogOnInfo logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(logOnInfo);
            }

            // 4️⃣ Aplicar también a los subreportes
            foreach (ReportDocument subreport in rpt.Subreports)
            {
                foreach (Table table in subreport.Database.Tables)
                {
                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                    logOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(logOnInfo);
                }
            }

            // 5️⃣ Forzar reconexión global (versión moderna)
            rpt.DataSourceConnections[0].SetConnection(
                "DESKTOP-IJHQVMG\\SQLSERVERMEDIC",
                "dbventas",
                "sa",
                "Maquina50"
            );

            foreach (ReportDocument subreport in rpt.Subreports)
            {
                if (subreport.DataSourceConnections.Count > 0)
                {
                    subreport.DataSourceConnections[0].SetConnection(
                        "DESKTOP-IJHQVMG\\SQLSERVERMEDIC",
                        "dbventas",
                        "sa",
                        "Maquina50"
                    );
                }
            }

            // 6️⃣ Pasar parámetros (usa el nombre exacto del parámetro en el reporte)
            rpt.SetParameterValue("@idIngreso", IdIngreso);

            // 7️⃣ Mostrar en el visor
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

        }
    }
}
