using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEncargadoTransportista    
    {
        //Variables
        private int _IdEncargadoTransportista;

        private string _EncargadoTransportista;

        private string _Tipo_Documento;

        private string _Num_Documento;

        private string _Placa;

        private string _TextoBuscar;



        //Propiedades
        public int IdEncargadoTransportista
        {
            get { return _IdEncargadoTransportista; }
            set { _IdEncargadoTransportista = value; }
        }


        public string EncargadoTransportista
        {
            get { return _EncargadoTransportista; }
            set { _EncargadoTransportista = value; }
        }



        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }

        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }

        public string Placa
        {
            get { return _Placa; }
            set { _Placa = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public DEncargadoTransportista()
        {

        }
        public DEncargadoTransportista( int idEncargadoTransportista,
                                        string encargadoTransportista,
                                        string tipo_documento, 
                                        string num_documento, 
                                        string placa, 
                                        string textobuscar)
        {
            this.IdEncargadoTransportista = idEncargadoTransportista;
            this.EncargadoTransportista = encargadoTransportista;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Placa = placa;
            this.TextoBuscar = textobuscar;

        }
        //Métodos
        public string Insertar(DEncargadoTransportista EncargadoTransportista)
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
                SqlCmd.CommandText = "spinsertar_EncargadoTransportista";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidEncargadoTransportista = new SqlParameter();
                ParidEncargadoTransportista.ParameterName = "@idEncargadoTransportista";
                ParidEncargadoTransportista.SqlDbType = SqlDbType.Int;
                ParidEncargadoTransportista.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParidEncargadoTransportista);

                SqlParameter ParEncargadoTransportista = new SqlParameter();
                ParEncargadoTransportista.ParameterName = "@EncargadoTransportista";
                ParEncargadoTransportista.SqlDbType = SqlDbType.VarChar;
                ParEncargadoTransportista.Size = 200;
                ParEncargadoTransportista.Value = EncargadoTransportista.EncargadoTransportista;
                SqlCmd.Parameters.Add(ParEncargadoTransportista);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = EncargadoTransportista.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 15;
                ParNum_Documento.Value = EncargadoTransportista.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter Parplaca = new SqlParameter();
                Parplaca.ParameterName = "@placa";
                Parplaca.SqlDbType = SqlDbType.VarChar;
                Parplaca.Size = 50;
                Parplaca.Value = EncargadoTransportista.Placa;
                SqlCmd.Parameters.Add(Parplaca);





                //SqlParameter ParSectorComercial = new SqlParameter();
                //ParSectorComercial.ParameterName = "@sector_comercial";
                //ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                //ParSectorComercial.Size = 50;
                //ParSectorComercial.Value = EncargadoTransportista.Sector_Comercial;
                //SqlCmd.Parameters.Add(ParSectorComercial);

                

              

                //SqlParameter ParDireccion = new SqlParameter();
                //ParDireccion.ParameterName = "@direccion";
                //ParDireccion.SqlDbType = SqlDbType.VarChar;
                //ParDireccion.Size = 100;
                //ParDireccion.Value = EncargadoTransportista.Direccion;
                //SqlCmd.Parameters.Add(ParDireccion);

                //SqlParameter ParTelefono = new SqlParameter();
                //ParTelefono.ParameterName = "@telefono";
                //ParTelefono.SqlDbType = SqlDbType.VarChar;
                //ParTelefono.Size = 11;
                //ParTelefono.Value = EncargadoTransportista.Telefono;
                //SqlCmd.Parameters.Add(ParTelefono);

                //SqlParameter ParEmail = new SqlParameter();
                //ParEmail.ParameterName = "@email";
                //ParEmail.SqlDbType = SqlDbType.VarChar;
                //ParEmail.Size = 50;
                //ParEmail.Value = EncargadoTransportista.Email;
                //SqlCmd.Parameters.Add(ParEmail);


                //SqlParameter ParUrl = new SqlParameter();
                //ParUrl.ParameterName = "@url";
                //ParUrl.SqlDbType = SqlDbType.VarChar;
                //ParUrl.Size = 150;
                //ParUrl.Value = EncargadoTransportista.Url;
                //SqlCmd.Parameters.Add(ParUrl);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


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

        //Método Editar
        public string Editar(DEncargadoTransportista EncargadoTransportista)
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
                SqlCmd.CommandText = "speditar_EncargadoTransportista";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidEncargadoTransportista = new SqlParameter();
                ParidEncargadoTransportista.ParameterName = "@idEncargadoTransportista";
                ParidEncargadoTransportista.SqlDbType = SqlDbType.Int;
                ParidEncargadoTransportista.Value = EncargadoTransportista.IdEncargadoTransportista;
                SqlCmd.Parameters.Add(ParidEncargadoTransportista);



                SqlParameter ParEncargadoTransportista = new SqlParameter();
                ParEncargadoTransportista.ParameterName = "@EncargadoTransportista";
                ParEncargadoTransportista.SqlDbType = SqlDbType.VarChar;
                ParEncargadoTransportista.Size = 200;
                ParEncargadoTransportista.Value = EncargadoTransportista.EncargadoTransportista;
                SqlCmd.Parameters.Add(ParEncargadoTransportista);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = EncargadoTransportista.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 15;
                ParNum_Documento.Value = EncargadoTransportista.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter Parplaca = new SqlParameter();
                Parplaca.ParameterName = "@placa";
                Parplaca.SqlDbType = SqlDbType.VarChar;
                Parplaca.Size = 50;
                Parplaca.Value = EncargadoTransportista.Placa;
                SqlCmd.Parameters.Add(Parplaca);




                ////SqlParameter ParRazon_Social = new SqlParameter();
                ////ParRazon_Social.ParameterName = "@razon_social";
                ////ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                ////ParRazon_Social.Size = 150;
                ////ParRazon_Social.Value = EncargadoTransportista.Razon_Social;
                ////SqlCmd.Parameters.Add(ParRazon_Social);

                ////SqlParameter ParSectorComercial = new SqlParameter();
                ////ParSectorComercial.ParameterName = "@sector_comercial";
                ////ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ////ParSectorComercial.Size = 50;
                ////ParSectorComercial.Value = EncargadoTransportista.Sector_Comercial;
                ////SqlCmd.Parameters.Add(ParSectorComercial);

                ////SqlParameter ParTipoDocumento = new SqlParameter();
                ////ParTipoDocumento.ParameterName = "@tipo_documento";
                ////ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ////ParTipoDocumento.Size = 20;
                ////ParTipoDocumento.Value = EncargadoTransportista.Tipo_Documento;
                ////SqlCmd.Parameters.Add(ParTipoDocumento);

                ////SqlParameter ParNum_Documento = new SqlParameter();
                ////ParNum_Documento.ParameterName = "@num_documento";
                ////ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ////ParNum_Documento.Size = 11;
                ////ParNum_Documento.Value = EncargadoTransportista.Num_Documento;
                ////SqlCmd.Parameters.Add(ParNum_Documento);

                ////SqlParameter ParDireccion = new SqlParameter();
                ////ParDireccion.ParameterName = "@direccion";
                ////ParDireccion.SqlDbType = SqlDbType.VarChar;
                ////ParDireccion.Size = 100;
                ////ParDireccion.Value = EncargadoTransportista.Direccion;
                ////SqlCmd.Parameters.Add(ParDireccion);

                ////SqlParameter ParTelefono = new SqlParameter();
                ////ParTelefono.ParameterName = "@telefono";
                ////ParTelefono.SqlDbType = SqlDbType.VarChar;
                ////ParTelefono.Size = 11;
                ////ParTelefono.Value = EncargadoTransportista.Telefono;
                ////SqlCmd.Parameters.Add(ParTelefono);

                ////SqlParameter ParEmail = new SqlParameter();
                ////ParEmail.ParameterName = "@email";
                ////ParEmail.SqlDbType = SqlDbType.VarChar;
                ////ParEmail.Size = 50;
                ////ParEmail.Value = EncargadoTransportista.Email;
                ////SqlCmd.Parameters.Add(ParEmail);


                ////SqlParameter ParUrl = new SqlParameter();
                ////ParUrl.ParameterName = "@url";
                ////ParUrl.SqlDbType = SqlDbType.VarChar;
                ////ParUrl.Size = 150;
                ////ParUrl.Value = EncargadoTransportista.Url;
                ////SqlCmd.Parameters.Add(ParUrl);
                //////Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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

        //Método Eliminar
        public string Eliminar(DEncargadoTransportista EncargadoTransportista)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                ////////Código
                //////SqlCon.ConnectionString = Conexion.Cn;
                //////SqlCon.Open();
                ////////Establecer el Comando
                //////SqlCommand SqlCmd = new SqlCommand();
                //////SqlCmd.Connection = SqlCon;
                //////SqlCmd.CommandText = "speliminar_proveedor";
                //////SqlCmd.CommandType = CommandType.StoredProcedure;

                //////SqlParameter ParIdproveedor = new SqlParameter();
                //////ParIdproveedor.ParameterName = "@idproveedor";
                //////ParIdproveedor.SqlDbType = SqlDbType.Int;
                //////ParIdproveedor.Value = EncargadoTransportista.Idproveedor;
                //////SqlCmd.Parameters.Add(ParIdproveedor);


                ////////Ejecutamos nuestro comando

                //////rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


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
            DataTable DtResultado = new DataTable("EncargadoTransportista");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_EncargadoTransportista";
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


        //Método BuscarNombre
        public DataTable BuscarRazon_Social(DEncargadoTransportista EncargadoTransportista)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = EncargadoTransportista.TextoBuscar;
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




        public DataTable BuscarNum_Documento(DEncargadoTransportista EncargadoTransportista)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = EncargadoTransportista.TextoBuscar;
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
