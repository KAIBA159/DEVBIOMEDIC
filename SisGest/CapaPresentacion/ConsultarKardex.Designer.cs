namespace CapaPresentacion
{
    partial class ConsultarKardex
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_producto = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtbox_rs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ck_btnclic = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtbox_cliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtbox_cliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ck_btnclic);
            this.groupBox1.Controls.Add(this.txtbox_rs);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtbox_producto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(301, 21);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Producto :";
            // 
            // txtbox_producto
            // 
            this.txtbox_producto.Location = new System.Drawing.Point(108, 49);
            this.txtbox_producto.Name = "txtbox_producto";
            this.txtbox_producto.Size = new System.Drawing.Size(292, 20);
            this.txtbox_producto.TabIndex = 5;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::CapaPresentacion.Properties.Resources.Buscar_p;
            this.btnBuscarCliente.Location = new System.Drawing.Point(411, 47);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(46, 25);
            this.btnBuscarCliente.TabIndex = 19;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtbox_rs
            // 
            this.txtbox_rs.Location = new System.Drawing.Point(108, 73);
            this.txtbox_rs.Name = "txtbox_rs";
            this.txtbox_rs.Size = new System.Drawing.Size(120, 20);
            this.txtbox_rs.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Registro Sanitario :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ck_btnclic
            // 
            this.ck_btnclic.Location = new System.Drawing.Point(231, 133);
            this.ck_btnclic.Name = "ck_btnclic";
            this.ck_btnclic.Size = new System.Drawing.Size(169, 23);
            this.ck_btnclic.TabIndex = 22;
            this.ck_btnclic.Text = "Consultar";
            this.ck_btnclic.UseVisualStyleBackColor = true;
            this.ck_btnclic.Click += new System.EventHandler(this.ck_btnclic_event);
            // 
            // button2
            // 
            this.button2.Image = global::CapaPresentacion.Properties.Resources.Buscar_p;
            this.button2.Location = new System.Drawing.Point(411, 97);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 25);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbox_cliente
            // 
            this.txtbox_cliente.Location = new System.Drawing.Point(108, 99);
            this.txtbox_cliente.Name = "txtbox_cliente";
            this.txtbox_cliente.Size = new System.Drawing.Size(292, 20);
            this.txtbox_cliente.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Cliente :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(475, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(60, 20);
            this.textBox4.TabIndex = 26;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(475, 100);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(60, 20);
            this.textBox5.TabIndex = 27;
            // 
            // ConsultarKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 205);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultarKardex";
            this.Text = "ConsultarKardex";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_producto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtbox_rs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtbox_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ck_btnclic;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
    }
}