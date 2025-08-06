using CapaNegocio;
using OpenQA.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese Razón Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese Número de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del Proveedor");
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
            this.txtRazon_Social.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtRazon_Social.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSector_Comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;

            this.consultarRuc.Enabled = valor;

            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdproveedor.ReadOnly = !valor;
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
            this.dataListado.DataSource = NProveedor.Mostrar();
            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

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

        //Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
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
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_Social.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();

                string rpta = "";
                if (this.txtRazon_Social.Text == string.Empty || this.txtNum_Documento.Text==string.Empty
                    || this.txtDireccion.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRazon_Social, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text,cbTipo_Documento.Text,
                            txtNum_Documento.Text,txtDireccion.Text,txtTelefono.Text,
                            txtEmail.Text,txtUrl.Text);

                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text),
                            this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text, txtUrl.Text);
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

            if (!this.txtIdproveedor.Text.Equals(""))
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
            this.Limpiar();
            this.txtIdproveedor.Text = string.Empty;
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
            //
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //

            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtRazon_Social.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            this.cbSector_Comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector_comercial"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteProveedor frm = new Reportes.FrmReporteProveedor();
            frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string rpta = string.Empty; 

        //    Contribuyente contribuyente = ObtenerDatosSunatv3("20100190797", "6", rpta);

        //    string rs = contribuyente.Razon;

        //}
        private async void button1_Click(object sender, EventArgs e)
        {



            if (cbTipo_Documento.Text == "RUC" && txtNum_Documento.Text.Trim().Length != 11)
            {
                // = "El RUC ingresado es inválido";
                MensajeError("El RUC ingresado es inválido");

                 return;
            }
            if (cbTipo_Documento.Text != "RUC")
            {
                MensajeError("Debe ser RUC");

                return;
            }

            if (cbTipo_Documento.Text == "RUC" && txtNum_Documento.Text.Trim().Length == 11)
            {
                string texto = txtNum_Documento.Text.Trim();

                bool esNumerico = texto.All(char.IsDigit);

                if (esNumerico)
                {
                    // Solo contiene números
                    string rpta = string.Empty;
                    Contribuyente contribuyente = await ObtenerDatosSunatv3(txtNum_Documento.Text.Trim(), "6", rpta);

                    //string rs = contribuyente.Razon;
                    //string df = contribuyente.Direccion +" - "+ contribuyente.Distrito + " - " + contribuyente.Provincia + " - " + contribuyente.Departamento;


                    txtRazon_Social.Text = contribuyente.Razon ?? "";

                    txtDireccion.Text = (contribuyente.Direccion ?? "") + " - " +
                                       (contribuyente.Distrito ?? "") + " - " +
                                       (contribuyente.Provincia ?? "") + " - " +
                                       (contribuyente.Departamento ?? "");



                }
                else
                {
                    // Contiene letras u otros caracteres
                    MensajeError("Solo debe ser numeros");
                }



                return;
            }
            else
            {
                MensajeError("RUC no Valido");
            }


            
            

            

            //MessageBox.Show("Razón Social: " + rs);
        }

        //public  Contribuyente ObtenerDatosSunatv3(string RUC, string tipdoc, string Excepcion = "")
        //{
        //    Contribuyente contrib = ObtenerDatosSunatv3T(RUC, tipdoc, Excepcion);

        //    return contrib;
        //}
        public async Task<Contribuyente> ObtenerDatosSunatv3(string RUC, string tipdoc, string Excepcion = "")
        {
            Contribuyente contrib = await ObtenerDatosSunatv3T(RUC, tipdoc, Excepcion);
            return contrib;
        }

        //public Contribuyente ObtenerDatosSunatv3T(string RUC, string tipdoc, string excepcion = "")
        public async Task<Contribuyente> ObtenerDatosSunatv3T(string RUC, string tipdoc, string excepcion = "")

        {
            Contribuyente sunat = new Contribuyente();
            if (tipdoc == "6" && RUC.Length != 11)
            {
                sunat.Mensaje = "El RUC ingresado es inválido";

                goto retornar;
            }
            if (tipdoc == "4" && RUC.Length < 5)
            {
                sunat.Mensaje = "El Carnet de extrajeria ingresado es inválido";
                goto retornar;
            }
            for (int i = 1; i <= 10; i++)
            {
                SunatDLv3 sunatDLv = new SunatDLv3();
                //sunat = sunatDLv.ObtenerDatos(RUC, tipdoc);
                sunat = await sunatDLv.ObtenerDatosAsync(RUC, tipdoc);

                if (string.IsNullOrEmpty(sunat.Mensaje) || sunat.Mensaje == "No Existe RUC") goto retornar;
            }
        retornar:
            return sunat;
        }


    }
}
