﻿using CapaNegocio;
using CapaPresentacion.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmIngreso : Form, IFormularioReceptorArticulo, IFormularioReceptorProveedor
    {
        public int Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        private static FrmIngreso _instancia;

        public static FrmIngreso GetInstancia()
        {
            if(_instancia==null)
            {
                _instancia = new FrmIngreso();
            }
            return _instancia;
        }
        public void setProveedor(string idproveedor,string nombre)
        {
            this.txtIdproveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }


        public void setEncargado(string idEncargadoTransportista, string EncargadoTransportista)
        {
            this.txtIdencargado.Text = idEncargadoTransportista;
            this.txtEncargado.Text = EncargadoTransportista;
        }

        public void setArticulo (string idarticulo,string nombre)
        {
            this.txtIdarticulo.Text = idarticulo;
            this.txtArticulo.Text = nombre;
        }
        public FrmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor,"Seleccione el Proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el número del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el Artículo de compra");
            this.txtIdproveedor.Visible = false;
            this.txtIdencargado.Visible = false;

            this.txtIdarticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtEncargado.ReadOnly = true; 
            this.txtArticulo.ReadOnly = true;

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


            this.dtFecha.Value = DateTime.Now;
            this.txtIdingreso.Text = string.Empty;

            this.txtIdproveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;

            this.txtIdencargado.Text = string.Empty;
            this.txtEncargado.Text = string.Empty;

            //
            this.dtp_inicio.Value = DateTime.Now;
            this.dtp_fin.Value = DateTime.Now;


            this.txtBultos.Text = string.Empty;
            this.txtDUA.Text = string.Empty;


            this.txtCorrelativoUnico.Text = string.Empty;
            this.txtCorrelativoUnico.Text = obtenercorrelativoUnico();


            //


            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
            this.txtIgv.Text = "18";

            //

            this.crearTabla();


        }

        private string obtenercorrelativoUnico()
        {
            string val  = string.Empty;


            val = NIngreso.ObtenerCorrelativoUnico();

            return val;
        
            
        }


        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;

            this.txtLote.Text = string.Empty;

            //
            cb_limpio.Checked = false;

            cb_deteriorado.Checked = false;

            cb_envasecerrado.Checked = false;

            cb_certanalisis.Checked = false;

            cb_sanitario.Checked = false;

            //


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdingreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;


            //
            this.txtBultos.ReadOnly = !valor;
            this.txtDUA.ReadOnly = !valor;
            this.txtCorrelativoUnico.ReadOnly = !valor;


            this.txtIdingreso.ReadOnly = true;
            this.txtCorrelativoUnico.ReadOnly = true;


            this.cbTipo_Producto.Enabled = valor;  
            //

            this.dtp_inicio.Enabled = valor;
            this.dtp_fin.Enabled = valor;


            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;

            this.cbTipo_Comprobante.Enabled = valor;

            this.cbTipo_Ingreso.Enabled = valor;

            this.txtStock.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;

            this.txtLote.ReadOnly = !valor;



            this.dtFecha_Produccion.Enabled = valor;
            this.dtFecha_Vencimiento.Enabled = valor;
            
            this.btnBuscarArticulo.Enabled = valor;

            //
            this.cb_limpio.Enabled = valor;
            this.cb_deteriorado.Enabled = valor;
            this.cb_envasecerrado.Enabled = valor;
            this.cb_certanalisis.Enabled = valor;
            this.cb_sanitario.Enabled = valor;

            //

            this.btnBuscarProveedor.Enabled = valor;

            this.btnBuscarEncargado.Enabled = valor;
            

            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo ) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
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
            this.dataListado.DataSource = NIngreso.Mostrar();


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

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"));

            var resultado = this.dataListado.DataSource;



            if (resultado != null)
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


        //private void BuscarFechas()
        //{
        //    this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
        //        this.dtFecha2.Value.ToString("dd/MM/yyyy"));

        //    var resultado = this.dataListado.DataSource;



        //    if (resultado != null)
        //    {

        //        foreach (DataGridViewColumn col in dataListado.Columns)
        //        {
        //            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        //            // Limitar el ancho máximo
        //            if (col.Width > 300)
        //            {
        //                col.Width = 300;
        //            }
        //        }

        //        this.OcultarColumnas();
        //        lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        //    }

        //}


        private void MostrarDetalle()
        {



            //this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdingreso.Text);


            DataTable dtOriginal = NIngreso.MostrarDetalle(this.txtIdingreso.Text);

            //this.dataListadoDetalle.Columns.Add("sanitario", typeof(bool));
            //fila["sanitario"] = true; // o false

            //this.dataListadoDetalle.Columns.Add("limpio", typeof(bool));
            //this.dtDetalle.Columns.Add("limpio", typeof(bool));

            DataTable dtClon = dtOriginal.Clone();

            // Cambiar el tipo de las columnas deseadas a bool
            dtClon.Columns["limpio"].DataType = typeof(bool);
            dtClon.Columns["deteriorado"].DataType = typeof(bool);
            dtClon.Columns["envasecerrado"].DataType = typeof(bool);
            dtClon.Columns["certanalisis"].DataType = typeof(bool);
            dtClon.Columns["sanitario"].DataType = typeof(bool);

            //fila["sanitario"] = true; // o false


            foreach (DataRow filaOriginal in dtOriginal.Rows)
            {
                DataRow filaNueva = dtClon.NewRow();

                foreach (DataColumn columna in dtOriginal.Columns)
                {
                    string nombreColumna = columna.ColumnName;

                    if (dtClon.Columns[nombreColumna].DataType == typeof(bool))
                    {
                        string valorTexto = filaOriginal[nombreColumna]?.ToString().Trim().ToLower();
                        filaNueva[nombreColumna] = (valorTexto == "activo");
                    }
                    else
                    {
                        filaNueva[nombreColumna] = filaOriginal[nombreColumna];
                    }
                }

                dtClon.Rows.Add(filaNueva);
            }

            // 4.Asignar al DataGridView
            this.dataListadoDetalle.DataSource = dtClon;

            //foreach (DataGridViewRow fila in dataListadoDetalle.Rows)
            //{
            //    nuevaFila["limpio"] = row["limpio"].ToString() == "Activo";
            //    nuevaFila["deteriorado"] = row["deteriorado"].ToString() == "Activo";
            //    nuevaFila["envasecerrado"] = row["envasecerrado"].ToString() == "Activo";
            //    nuevaFila["certanalisis"] = row["certanalisis"].ToString() == "Activo";
            //    nuevaFila["sanitario"] = row["sanitario"].ToString() == "Activo";
            //}

            //foreach (DataGridViewRow fila in dataListadoDetalle.Rows)
            //{
            //    if (fila.IsNewRow) continue;
            //    fila.Cells["limpio"].Value = true;
            //}



            if (this.dataListadoDetalle.DataSource != null)
            {
                foreach (DataGridViewColumn col in dataListadoDetalle.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Limitar el ancho máximo
                    if (col.Width > 300)
                    {
                        col.Width = 300;
                    }
                }
            }

            

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");

            this.dtDetalle.Columns.Add("idarticulo",System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns["idarticulo"].ReadOnly = true;


            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns["articulo"].ReadOnly = true;

            this.dtDetalle.Columns.Add("lote", System.Type.GetType("System.String"));
            this.dtDetalle.Columns["lote"].ReadOnly = true;

            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["precio_compra"].ReadOnly = true;

            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["precio_venta"].ReadOnly = true;

            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns["stock_inicial"].ReadOnly = true;
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns["fecha_produccion"].ReadOnly = true;
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns["fecha_vencimiento"].ReadOnly = true;
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["subtotal"].ReadOnly = true;
            this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns["Impuesto"].ReadOnly = true;


            //this.dtDetalle.Columns.Add("limpio", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("limpio", typeof(bool));
            this.dtDetalle.Columns["limpio"].ReadOnly = true;
            this.dtDetalle.Columns.Add("deteriorado", typeof(bool));

            this.dtDetalle.Columns["deteriorado"].ReadOnly = true;
            this.dtDetalle.Columns.Add("envasecerrado", typeof(bool));

            this.dtDetalle.Columns["envasecerrado"].ReadOnly = true;
            this.dtDetalle.Columns.Add("certanalisis", typeof(bool));

            this.dtDetalle.Columns["certanalisis"].ReadOnly = true;
            this.dtDetalle.Columns.Add("sanitario", typeof(bool));

            this.dtDetalle.Columns["sanitario"].ReadOnly = true;



            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }


        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        public void setProovedor(string id, string nombre)
        {
            this.txtIdproveedor.Text = id;          // Asegúrate de tener este TextBox
            this.txtProveedor.Text = nombre;  // Asegúrate de tener este TextBox
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso(this);
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ingreso vista = new FrmVistaArticulo_Ingreso(this);
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anuló Correctamente el Ingreso");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.limpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {


                //TimeSpan hora = TimeSpan.Parse(horaInicio);

                DateTime hora_Inicio = dtp_inicio.Value;
                string horaInicio = hora_Inicio.ToString("HH:mm");

                DateTime hora_Fin = dtp_fin.Value;
                string horaFin = hora_Fin.ToString("HH:mm");


                DateTime horaInicioDT = DateTime.Today.Add(TimeSpan.Parse(horaInicio));
                DateTime horaFinDT = DateTime.Today.Add(TimeSpan.Parse(horaFin));

                // te da algo como 2025-07-06 14:30:00
                //cmd.Parameters.AddWithValue("@hora", hora);



                string rpta = "";
                if (this.txtIdproveedor.Text == string.Empty || this.txtSerie.Text == string.Empty
                    || this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty
                    || this.txtIdencargado.Text == string.Empty
                    )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdproveedor, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");
                    errorIcono.SetError(txtEncargado, "Ingrese un Encargado");
                    

                    //errorIcono.SetError(txtLote, "Ingrese un lote");
                }
                else
                {




                    if (dtDetalle != null && dtDetalle.Rows.Count > 0)
                    {
                        errorIcono.Clear();

                        if (this.IsNuevo)
                        {
                            rpta = NIngreso.Insertar(Idtrabajador, 
                                Convert.ToInt32(this.txtIdproveedor.Text),
                                dtFecha.Value, 
                                cbTipo_Comprobante.Text,
                                txtSerie.Text,
                                txtCorrelativo.Text,
                                Convert.ToDecimal(txtIgv.Text), "EMITIDO",

                                cbTipo_Ingreso.Text,
                                Convert.ToInt32(this.txtIdencargado.Text),

                                horaInicioDT,
                                horaFinDT,


                                cbTipo_Producto.Text,
                                txtBultos.Text,
                                txtDUA.Text,
                                txtCorrelativoUnico.Text,


                                dtDetalle
                                );

                        }


                        if (rpta.Equals("OK"))
                        {
                            if (this.IsNuevo)
                            {
                                this.MensajeOk("Se Insertó de forma correcta el registro");
                            }


                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.IsNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.limpiarDetalle();
                        this.Mostrar();

                    }
                    else
                    {

                        errorIcono.SetError(dataListadoDetalle, "Ingrese un valor al Detalle ");
                    }

                     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.txtIdarticulo.Text == string.Empty || this.txtStock.Text == string.Empty
                    || this.txtPrecio_Compra.Text == string.Empty || this.txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Compra, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");
                    errorIcono.SetError(txtLote, "Ingrese un Lote");
                }
                else
                {
                    errorIcono.Clear();

                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"])==Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar)
                    {

                        //bool estaMarcado = cb_limpio.Checked;

                        //bool cb_limpio_b = cb_limpio.Checked;
                        //string txt_cb_limpio = cb_limpio_b.ToString();

                        //bool cb_limpio_b = cb_limpio.Checked;
                        //string txt_cb_limpio = cb_limpio_b ? "Activo" : "Inactivo";


                        //bool cb_deteriorado_b = cb_deteriorado.Checked;
                        //string txt_cb_deteriorado = cb_deteriorado_b.ToString();

                        //bool cb_deteriorado_b = cb_deteriorado.Checked;
                        //string txt_cb_deteriorado = cb_deteriorado_b ? "Activo" : "Inactivo";

                        ////bool cb_deteriorado_b = true;
                        ////string txt_cb_deteriorado = cb_deteriorado_b ? "Activo" : "Inactivo";

                        //bool cb_envasecerrado_b = cb_envasecerrado.Checked;
                        //string txt_cb_envasecerrado = cb_envasecerrado_b ? "Activo" : "Inactivo";

                        ////bool cb_certanalisis_b = cb_certanalisis.Checked;
                        ////string txt_cb_certanalisis = cb_certanalisis_b.ToString();

                        //bool cb_certanalisis_b = cb_certanalisis.Checked;
                        //string txt_cb_certanalisis = cb_certanalisis_b ? "Activo" : "Inactivo";


                        //bool cb_sanitario_b = cb_sanitario.Checked;
                        //string txt_cb_sanitario = cb_sanitario_b ? "Activo" : "Inactivo"; 



                        decimal subTotal=Convert.ToDecimal(this.txtStock.Text)*Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fecha_produccion"] = dtFecha_Produccion.Value;
                        row["fecha_vencimiento"] = dtFecha_Vencimiento.Value;
                        row["subtotal"] = subTotal;

                        row["lote"] = this.txtLote.Text;




                        row["limpio"] = cb_limpio.Checked;
                        row["deteriorado"] = cb_deteriorado.Checked; 
                        row["envasecerrado"] = cb_envasecerrado.Checked;
                        row["certanalisis"] = cb_certanalisis.Checked;
                        row["sanitario"] = cb_sanitario.Checked;


                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }

                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text=totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            //SE DEBE LIMPIAR PRIMERO, PARA DESPUES SETEAR

            //ES EL EVENTO CANCELAR
            //INI

            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
            //FIN


            this.txtIdingreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idingreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.txtIgv.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuesto"].Value);

            this.txtEncargado .Text = Convert.ToString(this.dataListado.CurrentRow.Cells["EncargadoTransportista"].Value);

            this.dtp_inicio.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["horaInicio"].Value);
            this.dtp_fin.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["horaFin"].Value);


            this.cbTipo_Producto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cbTipo_Producto"].Value);
            this.txtBultos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["bultos"].Value);
            this.txtDUA.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["dua"].Value);
            this.txtCorrelativoUnico.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativoUnico"].Value);
   //         isnull(i.cbTipo_Producto, '') as 'cbTipo_Producto',
			//isnull(i.bultos, '') as 'bultos',
			//isnull(i.dua, '') as 'dua',
			//isnull(i.correlativoUnico, '') as 'correlativoUnico'


            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteCompras frm = new Reportes.FrmReporteCompras();
            frm.Texto = Convert.ToString(dtFecha1.Value);
            frm.Texto2 = Convert.ToString(dtFecha2.Value);
            frm.ShowDialog();
        }

        private void btnBuscarEncargado_Click(object sender, EventArgs e)
        {
            FrmVistaEncargado_Ingreso vista = new FrmVistaEncargado_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscarProveedor_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimirCargo_Click(object sender, EventArgs e)
        {

            //Reportes.FrmReporteIngresoCargo frm2 = new Reportes.FrmReporteIngresoCargo();
            //frm2.idingreso = 3016;//Convert.ToString(dtFecha1.Value);
            ////frm.Texto2 = Convert.ToString(dtFecha2.Value);
            //frm2.ShowDialog();

            if (this.dataListado.CurrentRow != null &&
            this.dataListado.CurrentRow.Cells["idingreso"].Value != DBNull.Value)
            {
                try
                {
                    Reportes.FrmReporteIngresoCargo frm2 = new Reportes.FrmReporteIngresoCargo();
                    //frm2.idingreso = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idingreso"].Value);

                    frm2.idingreso = 3016;

                    frm2.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el reporte: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila válida que contenga un ID de ingreso.");
            }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
