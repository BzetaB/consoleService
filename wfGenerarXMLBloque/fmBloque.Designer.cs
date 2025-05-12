namespace wfGenerarXMLBloque
{
    partial class fmBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmBloque));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEliminar = new System.Windows.Forms.RadioButton();
            this.rbActualizar = new System.Windows.Forms.RadioButton();
            this.rbCrear = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRutaXML = new System.Windows.Forms.TextBox();
            this.sfdRutaXML = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbEntidad = new System.Windows.Forms.ComboBox();
            this.pbXML = new System.Windows.Forms.ProgressBar();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnGeneraXML = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEliminar);
            this.groupBox1.Controls.Add(this.rbActualizar);
            this.groupBox1.Controls.Add(this.rbCrear);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 119);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione una accion para el XML ";
            // 
            // rbEliminar
            // 
            this.rbEliminar.AutoSize = true;
            this.rbEliminar.Location = new System.Drawing.Point(33, 89);
            this.rbEliminar.Name = "rbEliminar";
            this.rbEliminar.Size = new System.Drawing.Size(85, 25);
            this.rbEliminar.TabIndex = 1;
            this.rbEliminar.TabStop = true;
            this.rbEliminar.Text = "Eliminar";
            this.rbEliminar.UseVisualStyleBackColor = true;
            // 
            // rbActualizar
            // 
            this.rbActualizar.AutoSize = true;
            this.rbActualizar.Location = new System.Drawing.Point(33, 59);
            this.rbActualizar.Name = "rbActualizar";
            this.rbActualizar.Size = new System.Drawing.Size(96, 25);
            this.rbActualizar.TabIndex = 1;
            this.rbActualizar.TabStop = true;
            this.rbActualizar.Text = "Actualizar";
            this.rbActualizar.UseVisualStyleBackColor = true;
            // 
            // rbCrear
            // 
            this.rbCrear.AutoSize = true;
            this.rbCrear.Location = new System.Drawing.Point(33, 28);
            this.rbCrear.Name = "rbCrear";
            this.rbCrear.Size = new System.Drawing.Size(66, 25);
            this.rbCrear.TabIndex = 0;
            this.rbCrear.TabStop = true;
            this.rbCrear.Text = "Crear";
            this.rbCrear.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRutaXML);
            this.groupBox2.Controls.Add(this.btnSeleccionar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione una ubicacion para el archivo XML";
            // 
            // txtRutaXML
            // 
            this.txtRutaXML.Location = new System.Drawing.Point(16, 28);
            this.txtRutaXML.Name = "txtRutaXML";
            this.txtRutaXML.ReadOnly = true;
            this.txtRutaXML.Size = new System.Drawing.Size(320, 29);
            this.txtRutaXML.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbEntidad);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccione un tipo de entidad para los datos";
            // 
            // cbEntidad
            // 
            this.cbEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntidad.FormattingEnabled = true;
            this.cbEntidad.Items.AddRange(new object[] {
            "Cursos",
            "Usuarios",
            "Matriculaciones"});
            this.cbEntidad.Location = new System.Drawing.Point(27, 22);
            this.cbEntidad.Name = "cbEntidad";
            this.cbEntidad.Size = new System.Drawing.Size(231, 29);
            this.cbEntidad.TabIndex = 2;
            // 
            // pbXML
            // 
            this.pbXML.Location = new System.Drawing.Point(39, 310);
            this.pbXML.Name = "pbXML";
            this.pbXML.Size = new System.Drawing.Size(311, 23);
            this.pbXML.TabIndex = 3;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::wfGenerarXMLBloque.Properties.Resources.detail;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(217, 63);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(119, 31);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "Seleccionar...";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnGeneraXML
            // 
            this.btnGeneraXML.Image = global::wfGenerarXMLBloque.Properties.Resources.just;
            this.btnGeneraXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneraXML.Location = new System.Drawing.Point(227, 312);
            this.btnGeneraXML.Name = "btnGeneraXML";
            this.btnGeneraXML.Size = new System.Drawing.Size(129, 44);
            this.btnGeneraXML.TabIndex = 0;
            this.btnGeneraXML.Text = "Generar XML";
            this.btnGeneraXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneraXML.UseVisualStyleBackColor = true;
            this.btnGeneraXML.Click += new System.EventHandler(this.btnGeneraXML_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(416, 368);
            this.Controls.Add(this.pbXML);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGeneraXML);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generacion de XML en bloque  Conduit - BANNER";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGeneraXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEliminar;
        private System.Windows.Forms.RadioButton rbActualizar;
        private System.Windows.Forms.RadioButton rbCrear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRutaXML;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.SaveFileDialog sfdRutaXML;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbEntidad;
        private System.Windows.Forms.ProgressBar pbXML;
    }
}

