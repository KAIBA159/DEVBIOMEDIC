using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese los Apellidos del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del Cliente");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el número de documento del Cliente");

        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdcliente.ReadOnly = true;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();


            if (dataListado != null)
            {
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Limitar el ancho máximo
                    if (col.Width > 300)
                    {
                        col.Width = 300;
                    }
                }

                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            }

            
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            
            this.tabControl1.SelectedIndex = 1;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty ||  
                    this.txtNum_Documento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidos, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, dtFechaNac.Value, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text);

                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, dtFechaNac.Value, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (!this.txtIdcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtIdcliente.Text = string.Empty;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteCliente frm = new Reportes.FrmReporteCliente();
            frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //20100190797 

            string numeroRuc = "20123456789"; // Ejemplo RUC

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                // Ir a la página de SUNAT
                driver.Navigate().GoToUrl("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaWeb.jsp");

                // Esperar que cargue el frame y cambiarlo
                driver.SwitchTo().Frame("main");

                // Seleccionar la pestaña por RUC
                IWebElement rucInput = driver.FindElement(By.Id("txtRuc"));
                rucInput.SendKeys(numeroRuc);

                Console.WriteLine("✅ Ingresa el CAPTCHA manualmente y presiona ENTER aquí cuando esté listo.");
                Console.ReadLine(); // Pausa para que el usuario resuelva el CAPTCHA

                // Presionar el botón "Consultar"
                IWebElement botonConsultar = driver.FindElement(By.Name("btnAceptar"));
                botonConsultar.Click();

                // Esperar a que cargue la respuesta (puedes ajustar el tiempo)
                Thread.Sleep(3000);

                // Obtener datos: Número de RUC y Domicilio Fiscal
                string rucResultado = driver.FindElement(By.XPath("//td[contains(text(),'Número de RUC')]/following-sibling::td")).Text;
                string domicilioFiscal = driver.FindElement(By.XPath("//td[contains(text(),'Dirección del Domicilio Fiscal')]/following-sibling::td")).Text;

                Console.WriteLine($"Número de RUC: {rucResultado}");
                Console.WriteLine($"Domicilio Fiscal: {domicilioFiscal}");
            }

        }

        //public Contribuyente ObtenerDatos(string Ruc, string tipdoc)
        //{
        //    Contribuyente contrib = new Contribuyente();
        //    try
        //    {
        //        var myTask = ExtraerDatosAsync(Ruc, tipdoc);
        //        string result = myTask.Result;

        //        CuTexto oCuTexto = new CuTexto();

        //        string nombreInicio = "<HEAD><TITLE>";
        //        string nombreFin = "</TITLE></HEAD>";
        //        string contenidoBusqueda = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
        //        if (contenidoBusqueda == ".:: Pagina de Mensajes ::.")
        //        {
        //            nombreInicio = "<p class=\"error\">";
        //            nombreFin = "</p>";
        //            contrib.TipoRespuesta = 2;
        //            contrib.Mensaje = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
        //        }
        //        else if (contenidoBusqueda == ".:: Pagina de Error ::.")
        //        {
        //            nombreInicio = "<p class=\"error\">";
        //            nombreFin = "</p>";
        //            contrib.TipoRespuesta = 3;
        //            contrib.Mensaje = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
        //        }
        //        else
        //        {
        //            contrib.TipoRespuesta = 2;
        //            nombreInicio = "<div class=\"list-group\">";
        //            nombreFin = "<div class=\"panel-footer text-center\">";
        //            contenidoBusqueda = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
        //            if (contenidoBusqueda == "")
        //            {
        //                nombreInicio = "<strong>";
        //                nombreFin = "</strong>";
        //                contrib.Mensaje = oCuTexto.ExtraerContenidoEntreTagString(result, 0, nombreInicio, nombreFin);
        //                if (contrib.Mensaje == "")
        //                    contrib.Mensaje = "No se encuentra las cabeceras principales del contenido HTML";
        //            }
        //            else
        //            {
        //                result = contenidoBusqueda;
        //                contrib.Mensaje = "Mensaje del inconveniente no especificado";
        //                nombreInicio = "<h4 class=\"list-group-item-heading\">";
        //                nombreFin = "</h4>";
        //                int resultadoBusqueda = result.IndexOf(nombreInicio, 0, StringComparison.OrdinalIgnoreCase);
        //                if (resultadoBusqueda > -1)
        //                {
        //                    // Modificar cuando el estado del Contribuyente es "BAJA DE OFICIO", porque se agrega un elemento con clase "list-group-item"
        //                    resultadoBusqueda += nombreInicio.Length;
        //                    string[] arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, resultadoBusqueda,
        //                        nombreInicio, nombreFin);

        //                    string razon = "";
        //                    if (arrResultado != null)
        //                    {
        //                        contrib.RUC = arrResultado[1].Substring(0, 11);
        //                        string[] razonsoc = arrResultado[1].Split('-');

        //                        for (int i = 1; i < razonsoc.Length; i++)
        //                        {
        //                            if (i == 1)
        //                            {
        //                                razon += razonsoc[i];
        //                            }
        //                            else
        //                            {
        //                                razon += "-" + razonsoc[i];
        //                            }
        //                        }

        //                        //contrib.Razon = "’" + razon;
        //                        contrib.Razon = razon.Replace("\u0092", "’");

        //                        contrib.TipoDoc = (contrib.RUC.Substring(0, 1).ToString() == "1") ? "DNI" : "";
        //                        contrib.NumDoc = (contrib.TipoDoc == "DNI") ? contrib.RUC.Substring(2, 8) : "";


        //                        // Tipo Contribuyente
        //                        nombreInicio = "<p class=\"list-group-item-text\">";
        //                        nombreFin = "</p>";
        //                        arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                            nombreInicio, nombreFin);
        //                        if (arrResultado != null)
        //                        {
        //                            contrib.Tipo = arrResultado[1];
        //                            try
        //                            {
        //                                contrib.TieneNegocio = (contrib.Tipo.Substring(16, 11).ToString() == "CON NEGOCIO") ? "Y" : "N";
        //                            }
        //                            catch (Exception)
        //                            {

        //                                contrib.TieneNegocio = "N";
        //                            }

        //                            // Nombre Comercial
        //                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                nombreInicio, nombreFin);
        //                            if (arrResultado != null)
        //                            {
        //                                if (contrib.TipoDoc != "DNI")
        //                                {
        //                                    contrib.NombreComercial = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();
        //                                }

        //                                // Fecha de Inscripción
        //                                arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                    nombreInicio, nombreFin);
        //                                if (arrResultado != null)
        //                                {
        //                                    //oEnSUNAT.f = arrResultado[1];

        //                                    // Fecha de Inicio de Actividades: 
        //                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                        nombreInicio, nombreFin);
        //                                    if (arrResultado != null)
        //                                    {
        //                                        // oEnSUNAT.FechaInicioActividades = arrResultado[1];

        //                                        // Estado del Contribuyente                                               

        //                                        if (Ruc.Substring(0, 2) == "10")
        //                                        {
        //                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, 3101,
        //                                            nombreInicio, nombreFin);


        //                                        }
        //                                        else
        //                                        {
        //                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                            nombreInicio, nombreFin);
        //                                        }

        //                                        if (arrResultado != null)
        //                                        {
        //                                            contrib.Estado = arrResultado[1].Trim();

        //                                            // Condición del Contribuyente


        //                                            if (Ruc.Substring(0, 2) == "10")
        //                                            {
        //                                                arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, 3728,
        //                                                nombreInicio, nombreFin);
        //                                            }
        //                                            else
        //                                            {
        //                                                arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                nombreInicio, nombreFin);
        //                                            }

        //                                            if (arrResultado != null)
        //                                            {
        //                                                string[] stringSeparators = new string[] { "\r\n\t\t" };
        //                                                string[] condicionLines = arrResultado[1].Trim().Split(stringSeparators, StringSplitOptions.None);
        //                                                contrib.Condicion = condicionLines[0].Trim();

        //                                                // Domicilio Fiscal
        //                                                if (Ruc.Substring(0, 2) == "10")
        //                                                {
        //                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, 4048,
        //                                                    nombreInicio, nombreFin);
        //                                                }
        //                                                else
        //                                                {
        //                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                    nombreInicio, nombreFin);
        //                                                }

        //                                                if (arrResultado != null)
        //                                                {
        //                                                    contrib.Direccion = arrResultado[1].Trim();
        //                                                    Ciudad(ref contrib, contrib.Direccion);

        //                                                    // Actividad(es) Económica(s)
        //                                                    nombreInicio = "<tbody>";
        //                                                    nombreFin = "</tbody>";
        //                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                        nombreInicio, nombreFin);
        //                                                    if (arrResultado != null)
        //                                                    {
        //                                                        //oEnSUNAT.ActividadesEconomicas = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();

        //                                                        // Comprobantes de Pago c/aut. de impresión (F. 806 u 816)
        //                                                        arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                            nombreInicio, nombreFin);
        //                                                        if (arrResultado != null)
        //                                                        {
        //                                                            //  oEnSUNAT.ComprobantesPago = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();

        //                                                            // Sistema de Emisión Electrónica
        //                                                            arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                                nombreInicio, nombreFin);
        //                                                            if (arrResultado != null)
        //                                                            {
        //                                                                // oEnSUNAT.SistemaEmisionComprobante = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim();

        //                                                                // Afiliado al PLE desde
        //                                                                nombreInicio = "<p class=\"list-group-item-text\">";
        //                                                                nombreFin = "</p>";
        //                                                                arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                                    nombreInicio, nombreFin);
        //                                                                if (arrResultado != null)
        //                                                                {
        //                                                                    // oEnSUNAT.AfiliadoPLEDesde = arrResultado[1];

        //                                                                    // Padrones 
        //                                                                    nombreInicio = "<tbody>";
        //                                                                    nombreFin = "</tbody>";
        //                                                                    arrResultado = oCuTexto.ExtraerContenidoEntreTag(result, Convert.ToInt32(arrResultado[0]),
        //                                                                        nombreInicio, nombreFin);
        //                                                                    if (arrResultado != null)
        //                                                                    {
        //                                                                        nombreInicio = "<tr>";
        //                                                                        nombreFin = "</tr>";
        //                                                                        string[] values = arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Split(new string[] { "<tr>", "</tr>", "<td>", "</td>" }, StringSplitOptions.RemoveEmptyEntries);

        //                                                                        foreach (var value in values)
        //                                                                        {
        //                                                                            if (value.Contains("Excluido") && value.Contains("Retención"))
        //                                                                            {
        //                                                                                contrib.Retencion = "NO";
        //                                                                            }

        //                                                                            if (value.Contains("Incorporado") && value.Contains("Retención"))
        //                                                                            {
        //                                                                                contrib.Retencion = "SI";
        //                                                                            }

        //                                                                            if (value.Contains("Excluido") && value.Contains("Percepción"))
        //                                                                            {
        //                                                                                contrib.Percepcion = "NO";
        //                                                                            }

        //                                                                            if (value.Contains("Incorporado") && value.Contains("Percepción"))
        //                                                                            {
        //                                                                                contrib.Percepcion = "SI";
        //                                                                            }
        //                                                                            if (value.Contains("Incorporado") && value.Contains("Buenos Contribuyentes"))
        //                                                                            {
        //                                                                                contrib.BuenContribuyente = "SI";
        //                                                                            }
        //                                                                        }
        //                                                                        if (string.IsNullOrEmpty(contrib.Percepcion))
        //                                                                            contrib.Percepcion = "NO";

        //                                                                        if (string.IsNullOrEmpty(contrib.Retencion))
        //                                                                            contrib.Retencion = "NO";

        //                                                                        if (string.IsNullOrEmpty(contrib.BuenContribuyente))
        //                                                                            contrib.BuenContribuyente = "NO";

        //                                                                        //contrib.BuenContribuyente = (arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Contains("Buenos Contribuyentes")) ? "SI" : "NO";
        //                                                                        //contrib.Retencion = (arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Contains("Retención")) ? "SI" : "NO";
        //                                                                        //contrib.Percepcion = (arrResultado[1].Replace("\r\n", "").Replace("\t", "").Trim().Contains("Percepción")) ? "SI" : "NO";
        //                                                                    }
        //                                                                    else
        //                                                                    {
        //                                                                        contrib.BuenContribuyente = "NO";
        //                                                                        contrib.Retencion = "NO";
        //                                                                        contrib.Percepcion = "NO";
        //                                                                    }
        //                                                                }

        //                                                                contrib.TipoRespuesta = 1;
        //                                                                contrib.Mensaje = "";
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        contrib.Mensaje = ex.Message;
        //    }

        //    return contrib;
        //}




    }
}
