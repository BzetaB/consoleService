namespace wfGenerarXMLBloque
{
    partial class fmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerXMLPorBloqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerXMLIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obtenerXMLPorBloqueToolStripMenuItem,
            this.obtenerXMLIndividualToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // obtenerXMLPorBloqueToolStripMenuItem
            // 
            this.obtenerXMLPorBloqueToolStripMenuItem.Name = "obtenerXMLPorBloqueToolStripMenuItem";
            this.obtenerXMLPorBloqueToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.obtenerXMLPorBloqueToolStripMenuItem.Text = "Obtener XML por bloque";
            this.obtenerXMLPorBloqueToolStripMenuItem.Click += new System.EventHandler(this.obtenerXMLPorBloqueToolStripMenuItem_Click);
            // 
            // obtenerXMLIndividualToolStripMenuItem
            // 
            this.obtenerXMLIndividualToolStripMenuItem.Name = "obtenerXMLIndividualToolStripMenuItem";
            this.obtenerXMLIndividualToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.obtenerXMLIndividualToolStripMenuItem.Text = "Obtener XML individual";
            this.obtenerXMLIndividualToolStripMenuItem.Click += new System.EventHandler(this.obtenerXMLIndividualToolStripMenuItem_Click);
            // 
            // fmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 317);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generacion de Archivos XML - Conduit MoodleRooms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obtenerXMLPorBloqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obtenerXMLIndividualToolStripMenuItem;
    }
}