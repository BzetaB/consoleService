using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using layer_bussiness;
using System.IO;

namespace wfGenerarXMLBloque
{
    public partial class fmBloque : Form
    {
        clsDatosConduit transaccion = new clsDatosConduit();
        public fmBloque()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML Archivo|*.xml";
            saveFileDialog1.Title = "Guardar un archivo XML";

            switch (cbEntidad.Text)
            {
                case "Cursos":
                    saveFileDialog1.FileName = "course";
                    break;
                case "Usuarios":
                    saveFileDialog1.FileName = "auth";
                    break;
                case "Matriculaciones":
                    saveFileDialog1.FileName = "enroll";
                    break;
            }                                     
            saveFileDialog1.ShowDialog();
            
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =(System.IO.FileStream)saveFileDialog1.OpenFile();
                txtRutaXML.Text = saveFileDialog1.FileNames[0];
                fs.Close();
            }
        }

        private void btnGeneraXML_Click(object sender, EventArgs e)
        {
            btnGeneraXML.Visible = false;
            DataTable dtDatos = new DataTable();
            List<string> listaColumnas = new List<string>();
            
            switch (cbEntidad.Text) {
                case "Cursos":
                    dtDatos = Cursosenbloque();
                    break;
                case "Usuarios":
                    dtDatos = Usuariosenbloque();
                    break;
                case "Matriculaciones":
                    dtDatos = Matriculacionesenbloque();
                    break;
            }            
            listaColumnas = dtNombresColumnas(dtDatos);
            GeneraXML(dtDatos,listaColumnas, txtRutaXML.Text);               
        }

        #region Metodos Adicionales
        private List<string> dtNombresColumnas(DataTable dt)
        {
            List<string> listaNomCol = new List<string>();
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName.ToString().Substring(0, 1) != "0")
                {
                    listaNomCol.Add(col.ColumnName.ToString());
                }
            }
            return listaNomCol;
        }
        private void GeneraXML(DataTable dt, List<string> ListaNomCol,string rutaArchivo)
        {
            btnGeneraXML.Visible = false;
            StreamWriter sr = new StreamWriter(rutaArchivo);
            string accion = string.Empty;
            string header = "<?xml version='1.0' encoding='UTF-8'?>";
            string body = string.Empty;

            if (rbCrear.Checked == true)
            {
                accion = "create";
            }
            else if (rbActualizar.Checked == true)
            {
                accion = "update";
            }
            else if (rbEliminar.Checked==true)
            {
                accion = "delete";
            }
            pbXML.Maximum = dt.Rows.Count*ListaNomCol.Count+3;
            pbXML.Minimum = 0;
            pbXML.Value = 0;
            pbXML.Step = 1;
            pbXML.Visible = true;

            sr.WriteLine(header);
            body = "<data>";
            sr.WriteLine(body);
            foreach (DataRow rw in dt.Rows)
            {
                body = "<datum action='" + accion + "'>";
                sr.WriteLine(body);
                if (accion == "delete")
                {
                    switch (cbEntidad.Text)
                    {
                        case "Cursos":
                            body = "<mapping name='SHORTNAME'>" + rw["SHORTNAME"].ToString() + "</mapping>";
                            sr.WriteLine(body);
                            pbXML.PerformStep();
                            break;
                        case "Usuarios":
                            body = "<mapping name='USERNAME'>" + rw["USERNAME"].ToString() + "</mapping>";
                            sr.WriteLine(body);
                            pbXML.PerformStep();
                            break;
                        case "Matriculaciones":
                            body = "<mapping name='ENROLLCOURSE'>" + rw["ENROLLCOURSE"].ToString() + "</mapping>";
                            sr.WriteLine(body);
                            body = "<mapping name='USERNAME'>" + rw["USERNAME"].ToString() + "</mapping>";
                            sr.WriteLine(body);
                            pbXML.PerformStep();
                            break;
                    }                    
                }
                else
                {
                    foreach (string col in ListaNomCol)
                    {
                        body = "<mapping name='" + col + "'>" + rw[col].ToString() + "</mapping>";
                        sr.WriteLine(body);
                        pbXML.PerformStep();
                    }
                }               
                body = "</datum>";
                sr.WriteLine(body);
            } 
            body= "</data>";
            sr.WriteLine(body);
            sr.Close();
            pbXML.Visible = false;
            btnGeneraXML.Visible = true;
            //return xmlfinal;
        }
        private DataTable Cursosenbloque() {
            DataTable dtCursos = transaccion.ListaCursosBloque();
            return dtCursos;    
        }
        private DataTable Usuariosenbloque()
        {
            DataTable dtUsuarios = transaccion.ListaUsuariosBloque();
            return dtUsuarios;
        }
        private DataTable Matriculacionesenbloque()
        {
            DataTable dtMatric = transaccion.ListaMatriculacionesBloque();
            return dtMatric;
        }

        #endregion

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            pbXML.Visible = false;
        }
    }
}
