namespace CapaPresentacion
{
    partial class ConsultarKardex3AgrupadoFabricante
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.tbt_lote = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txt_idcliente = new System.Windows.Forms.TextBox();
            this.txt_idproducto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtbox_cliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ck_btnclic = new System.Windows.Forms.Button();
            this.txtbox_rs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtbox_producto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbt_lote);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.txt_idcliente);
            this.groupBox1.Controls.Add(this.txt_idproducto);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtbox_cliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ck_btnclic);
            this.groupBox1.Controls.Add(this.txtbox_rs);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtbox_producto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtp_hasta);
            this.groupBox1.Controls.Add(this.dtp_desde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Mes :";
            // 
            // tbt_lote
            // 
            this.tbt_lote.Location = new System.Drawing.Point(429, 122);
            this.tbt_lote.Name = "tbt_lote";
            this.tbt_lote.Size = new System.Drawing.Size(151, 20);
            this.tbt_lote.TabIndex = 31;
            this.tbt_lote.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Lote :";
            this.label6.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.error2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(203, 126);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 28);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Silver;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.imprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(53, 125);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(126, 29);
            this.btnImprimir.TabIndex = 28;
            this.btnImprimir.Text = "&Consulta Kardex";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txt_idcliente
            // 
            this.txt_idcliente.Location = new System.Drawing.Point(507, 82);
            this.txt_idcliente.Name = "txt_idcliente";
            this.txt_idcliente.Size = new System.Drawing.Size(60, 20);
            this.txt_idcliente.TabIndex = 27;
            this.txt_idcliente.Visible = false;
            // 
            // txt_idproducto
            // 
            this.txt_idproducto.Location = new System.Drawing.Point(507, 47);
            this.txt_idproducto.Name = "txt_idproducto";
            this.txt_idproducto.Size = new System.Drawing.Size(60, 20);
            this.txt_idproducto.TabIndex = 26;
            this.txt_idproducto.Visible = false;
            // 
            // button2
            // 
            this.button2.Image = global::CapaPresentacion.Properties.Resources.Buscar_p;
            this.button2.Location = new System.Drawing.Point(405, 41);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 25);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbox_cliente
            // 
            this.txtbox_cliente.Location = new System.Drawing.Point(102, 43);
            this.txtbox_cliente.Name = "txtbox_cliente";
            this.txtbox_cliente.ReadOnly = true;
            this.txtbox_cliente.Size = new System.Drawing.Size(292, 20);
            this.txtbox_cliente.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Cliente :";
            // 
            // ck_btnclic
            // 
            this.ck_btnclic.Location = new System.Drawing.Point(411, 108);
            this.ck_btnclic.Name = "ck_btnclic";
            this.ck_btnclic.Size = new System.Drawing.Size(169, 23);
            this.ck_btnclic.TabIndex = 22;
            this.ck_btnclic.Text = "Consultar";
            this.ck_btnclic.UseVisualStyleBackColor = true;
            this.ck_btnclic.Visible = false;
            this.ck_btnclic.Click += new System.EventHandler(this.ck_btnclic_event);
            // 
            // txtbox_rs
            // 
            this.txtbox_rs.Location = new System.Drawing.Point(460, 137);
            this.txtbox_rs.Name = "txtbox_rs";
            this.txtbox_rs.Size = new System.Drawing.Size(120, 20);
            this.txtbox_rs.TabIndex = 21;
            this.txtbox_rs.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Registro Sanitario :";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::CapaPresentacion.Properties.Resources.Buscar_p;
            this.btnBuscarCliente.Location = new System.Drawing.Point(405, 13);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(46, 25);
            this.btnBuscarCliente.TabIndex = 19;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Visible = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtbox_producto
            // 
            this.txtbox_producto.Location = new System.Drawing.Point(102, 15);
            this.txtbox_producto.Name = "txtbox_producto";
            this.txtbox_producto.ReadOnly = true;
            this.txtbox_producto.Size = new System.Drawing.Size(292, 20);
            this.txtbox_producto.TabIndex = 5;
            this.txtbox_producto.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Producto :";
            this.label3.Visible = false;
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_hasta.Location = new System.Drawing.Point(301, 10);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(99, 20);
            this.dtp_hasta.TabIndex = 3;
            this.dtp_hasta.Visible = false;
            // 
            // dtp_desde
            // 
            this.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_desde.Location = new System.Drawing.Point(108, 10);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(99, 20);
            this.dtp_desde.TabIndex = 2;
            this.dtp_desde.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta : ";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde : ";
            this.label1.Visible = false;
            // 
            // ConsultarKardex3AgrupadoFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 220);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultarKardex3AgrupadoFabricante";
            this.Text = "ConsultarKardex Agrupado Fabricante";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_producto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.TextBox txtbox_rs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtbox_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ck_btnclic;
        private System.Windows.Forms.TextBox txt_idcliente;
        private System.Windows.Forms.TextBox txt_idproducto;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox tbt_lote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
    }
}