﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        //Variables
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;
        private int _IdencargadoTransportista;
        private string _Tipo_Ingreso;

        private DateTime _HoraInicioDT;
        private DateTime _HoraFinDT;

        private string _CbTipo_Producto;
        private string _Bultos;
        private string _Dua;
        private string _CorrelativoUnico;


        //Propiedades
        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }


        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }


        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Tipo_Comprobante
        {
            get { return _Tipo_Comprobante; }
            set { _Tipo_Comprobante = value; }
        }

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }


        public string Correlativo
        {
            get { return _Correlativo; }
            set { _Correlativo = value; }
        }

        public decimal Igv
        {
            get { return _Igv; }
            set { _Igv = value; }
        }


        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string Tipo_Ingreso
        {
            get { return _Tipo_Ingreso; }
            set { _Tipo_Ingreso = value; }
        }

        public int IdencargadoTransportista
        {
            get { return _IdencargadoTransportista; }
            set { _IdencargadoTransportista = value; }
        }

        public DateTime HoraInicioDT
        {
            get { return _HoraInicioDT; }
            set { _HoraInicioDT = value; }
        }

        public DateTime HoraFinDT
        {
            get { return _HoraFinDT; }
            set { _HoraFinDT = value; }
        }

        //Obj.HoraInicioDT = horaInicioDT;
        //    Obj.horaFinDT = horaFinDT;

        public string CbTipo_Producto
        {
            get { return _CbTipo_Producto; }
            set { _CbTipo_Producto = value; }
        }

        public string Bultos
        {
            get { return _Bultos; }
            set { _Bultos = value; }
        }

        public string Dua
        {
            get { return _Dua; }
            set { _Dua = value; }
        }

        public string CorrelativoUnico
        {
            get { return _CorrelativoUnico; }
            set { _CorrelativoUnico = value; }
        }



        //Constructores
        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor,
            DateTime fecha, string tipo_comprobante, string serie,
            string correlativo,
            decimal igv,
            string estado,
            string tipo_Ingreso,
            int idencargadoTransportista,
            DateTime horaInicioDT,
            DateTime horaFinDT,

            string cbTipo_Producto,
            string bultos,
            string dua,
            string correlativoUnico

            )
        {

            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.IdencargadoTransportista = idencargadoTransportista;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;

            this.HoraInicioDT = horaInicioDT;
            this.HoraFinDT = horaFinDT;


            this.CbTipo_Producto = cbTipo_Producto;
            this.Bultos = bultos;
            this.Dua = dua;
            this.CorrelativoUnico = correlativoUnico;


            this.Igv = igv;
            this.Estado = estado;

            this.Tipo_Ingreso = tipo_Ingreso;

        }
        //Métodos
        public string Insertar(DIngreso Ingreso,List<DDetalle_Ingreso> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Ingreso.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);


                SqlParameter Paridencargadotransportista = new SqlParameter();
                Paridencargadotransportista.ParameterName = "@idencargadotransportista";
                Paridencargadotransportista.SqlDbType = SqlDbType.Int;
                Paridencargadotransportista.Value = Ingreso.IdencargadoTransportista;
                SqlCmd.Parameters.Add(Paridencargadotransportista);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter();
                ParTipo_Comprobante.ParameterName = "@tipo_comprobante";
                ParTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_Comprobante.Size = 20;
                ParTipo_Comprobante.Value = Ingreso.Tipo_Comprobante;
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter Partipo_Ingreso = new SqlParameter();
                Partipo_Ingreso.ParameterName = "@tipo_Ingreso";
                Partipo_Ingreso.SqlDbType = SqlDbType.VarChar;
                Partipo_Ingreso.Size = 50;
                Partipo_Ingreso.Value = Ingreso.Tipo_Ingreso;
                SqlCmd.Parameters.Add(Partipo_Ingreso);


                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv;
                SqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //-------------------------------------

                SqlParameter ParhoraInicio = new SqlParameter();
                ParhoraInicio.ParameterName = "@horaInicio";
                ParhoraInicio.SqlDbType = SqlDbType.DateTime;
                ParhoraInicio.Value = Ingreso.HoraInicioDT;
                SqlCmd.Parameters.Add(ParhoraInicio);

                SqlParameter ParhoraFin = new SqlParameter();
                ParhoraFin.ParameterName = "@horaFin";
                ParhoraFin.SqlDbType = SqlDbType.DateTime;
                ParhoraFin.Value = Ingreso.HoraFinDT;
                SqlCmd.Parameters.Add(ParhoraFin);

                //-------------------------------------------------------------------

                SqlParameter ParcbTipo_Producto = new SqlParameter();
                ParcbTipo_Producto.ParameterName = "@cbTipo_Producto";
                ParcbTipo_Producto.SqlDbType = SqlDbType.VarChar;
                ParcbTipo_Producto.Size = 50;
                ParcbTipo_Producto.Value = Ingreso.CbTipo_Producto;
                SqlCmd.Parameters.Add(ParcbTipo_Producto);

                SqlParameter Parbultos = new SqlParameter();
                Parbultos.ParameterName = "@bultos";
                Parbultos.SqlDbType = SqlDbType.VarChar;
                Parbultos.Size = 50;
                Parbultos.Value = Ingreso.Bultos;
                SqlCmd.Parameters.Add(Parbultos);

                SqlParameter Pardua = new SqlParameter();
                Pardua.ParameterName = "@dua";
                Pardua.SqlDbType = SqlDbType.VarChar;
                Pardua.Size = 50;
                Pardua.Value = Ingreso.Dua;
                SqlCmd.Parameters.Add(Pardua);

                SqlParameter ParcorrelativoUnico = new SqlParameter();
                ParcorrelativoUnico.ParameterName = "@correlativoUnico";
                ParcorrelativoUnico.SqlDbType = SqlDbType.VarChar;
                ParcorrelativoUnico.Size = 50;
                ParcorrelativoUnico.Value = Ingreso.CorrelativoUnico;
                SqlCmd.Parameters.Add(ParcorrelativoUnico);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;
                        //Llamar al método insertar de la clase DDetalle_Ingreso
                        rpta = det.Insertar(det,ref SqlCon,ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }

                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
                

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }
        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spanular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se anulo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método Buscarfechas
        public DataTable BuscarFechas(String TextoBuscar,String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public string DObtenerCorrelativoUnico()
        {
            
            string correlativoUnico = string.Empty;

            using (SqlConnection SqlCon = new SqlConnection())
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                using (SqlCommand SqlCmd = new SqlCommand("sp_generar_correlativo_unico", SqlCon))
                {
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuta y obtiene el valor único
                    object result = SqlCmd.ExecuteScalar();

                    if (result != null)
                    {
                        correlativoUnico = result.ToString();
                    }
                }
            }
            return correlativoUnico;
        }


        public DataTable MostrarDetalle(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


    }
}
