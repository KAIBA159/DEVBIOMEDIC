﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        //Variables
        private int _Iddetalle_Ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private string _Lote;  
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;


        private string _Limpio;
        private string _Deteriorado;
        private string _Envasecerrado;
        private string _Certanalisis;
        private string _Sanitario;

        //Propiedades


        public string Sanitario
        {
            get { return _Sanitario; }
            set { _Sanitario = value; }
        }


        public string Certanalisis
        {
            get { return _Certanalisis; }
            set { _Certanalisis = value; }
        }


        public string Envasecerrado
        {
            get { return _Envasecerrado; }
            set { _Envasecerrado = value; }
        }

        public string Deteriorado
        {
            get { return _Deteriorado; }
            set { _Deteriorado = value; }
        }

        public string Limpio
        {
            get { return _Limpio; }
            set { _Limpio = value; }
        }


        public int Iddetalle_Ingreso
        {
            get { return _Iddetalle_Ingreso; }
            set { _Iddetalle_Ingreso = value; }
        }

        
        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }
        
        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
        }
        

        public decimal Precio_Compra
        {
            get { return _Precio_Compra; }
            set { _Precio_Compra = value; }
        }
        
        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }
        
        public int Stock_Inicial
        {
            get { return _Stock_Inicial; }
            set { _Stock_Inicial = value; }
        }
        

        public int Stock_Actual
        {
            get { return _Stock_Actual; }
            set { _Stock_Actual = value; }
        }
        
        public DateTime Fecha_Produccion
        {
            get { return _Fecha_Produccion; }
            set { _Fecha_Produccion = value; }
        }
        
        public DateTime Fecha_Vencimiento
        {
            get { return _Fecha_Vencimiento; }
            set { _Fecha_Vencimiento = value; }
        }

        public string Lote
        {
            get { return _Lote; }
            set { _Lote = value; }
        }

        //Constructores 
        public DDetalle_Ingreso()
        {

        }
        public DDetalle_Ingreso(int iddetalle_ingreso,int idingreso,
            int idarticulo,decimal precio_compra,decimal precio_venta,
            int stock_inicial,int stock_actual,DateTime fecha_produccion,
            DateTime fecha_vencimiento,
            string limpio,
            string deteriorado,
            string envasecerrado,
            string certanalisis,
            string sanitario


            )
        {
            this.Iddetalle_Ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccion = fecha_produccion;
            this.Fecha_Vencimiento = fecha_vencimiento;

            this.Limpio = limpio;
            this.Deteriorado = deteriorado;
            this.Envasecerrado = envasecerrado;
            this.Certanalisis = certanalisis;
            this.Sanitario = sanitario;


        }

        //Método Insertar
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso,
            ref SqlConnection SqlCon,ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParIdingreso= new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo= new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle_Ingreso.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);


                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@precio_compra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Money;
                ParPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                
                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParFecha_Produccion = new SqlParameter();
                ParFecha_Produccion.ParameterName = "@fecha_produccion";
                ParFecha_Produccion.SqlDbType = SqlDbType.Date;
                ParFecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter();
                ParFecha_Vencimiento.ParameterName = "@fecha_vencimiento";
                ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Vencimiento.Value = Detalle_Ingreso.Fecha_Vencimiento;
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);


                SqlParameter ParLote = new SqlParameter();
                ParLote.ParameterName = "@lote";
                ParLote.SqlDbType = SqlDbType.VarChar;
                ParLote.Size = 50;
                ParLote.Value = Detalle_Ingreso.Lote;
                SqlCmd.Parameters.Add(ParLote);


                ////
                ///
                SqlParameter ParLimpio = new SqlParameter();
                ParLimpio.ParameterName = "@limpio";
                ParLimpio.SqlDbType = SqlDbType.VarChar;
                ParLimpio.Size = 10;
                ParLimpio.Value = Detalle_Ingreso.Limpio;
                SqlCmd.Parameters.Add(ParLimpio);

                SqlParameter ParDeteriorado = new SqlParameter();
                ParDeteriorado.ParameterName = "@deteriorado";
                ParDeteriorado.SqlDbType = SqlDbType.VarChar;
                ParDeteriorado.Size = 10;
                ParDeteriorado.Value = Detalle_Ingreso.Deteriorado;
                SqlCmd.Parameters.Add(ParDeteriorado);

                SqlParameter ParEnvasecerrado = new SqlParameter();
                ParEnvasecerrado.ParameterName = "@envasecerrado";
                ParEnvasecerrado.SqlDbType = SqlDbType.VarChar;
                ParEnvasecerrado.Size = 10;
                ParEnvasecerrado.Value = Detalle_Ingreso.Envasecerrado;
                SqlCmd.Parameters.Add(ParEnvasecerrado);

                SqlParameter ParCertanalisis = new SqlParameter();
                ParCertanalisis.ParameterName = "@certanalisis";
                ParCertanalisis.SqlDbType = SqlDbType.VarChar;
                ParCertanalisis.Size = 10;
                ParCertanalisis.Value = Detalle_Ingreso.Certanalisis;
                SqlCmd.Parameters.Add(ParCertanalisis);

                SqlParameter ParSanitario = new SqlParameter();
                ParSanitario.ParameterName = "@sanitario";
                ParSanitario.SqlDbType = SqlDbType.VarChar;
                ParSanitario.Size = 10;
                ParSanitario.Value = Detalle_Ingreso.Sanitario;
                SqlCmd.Parameters.Add(ParSanitario);



                ////





                //SqlParameter ParLote = new SqlParameter();
                //ParLote.ParameterName = "@lote";
                //ParLote.SqlDbType = SqlDbType.Int;
                //ParLote.Value = Detalle_Ingreso.Lote;
                //SqlCmd.Parameters.Add(ParLote);

                ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            
            return rpta;

        }

    }
}
