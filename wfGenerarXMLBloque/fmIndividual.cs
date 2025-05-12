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
    public partial class fmIndividual : Form
    {
        clsDatosConduit tran = new clsDatosConduit();
        DataTable DTXMLRole = new DataTable();        
        DataTable DTXMLUser = new DataTable();
        DataTable DTXMLCourse = new DataTable();
        List<string> ListaColumnasRole = new List<string>();
        List<string> ListaColumnasUser = new List<string>();
        List<string> ListaColumnasCourse = new List<string>();
        List<string> ListaEntidades = new List<string>();
        string rutaRole = string.Empty;
        string rutaUser = string.Empty;
        string rutaCourse = string.Empty;
        int contr = 0;
        int contu = 0;
        int contc = 0;
        public fmIndividual()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = tran.rolesBuscados(txtBuscar.Text.Trim(), "");
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DTXMLRole.Clear();
            //role           
            if (dgvDatos.Rows.Count > 0)
            {
                foreach (DataGridViewColumn cl in dgvDatos.Columns)
                {
                    ListaColumnasRole.Add(cl.Name);
                    foreach (DataColumn dcl in DTXMLRole.Columns)
                    {
                        if (cl.Name == dcl.ColumnName.ToString())
                        {
                            contr = contr + 1;
                        }
                    }
                    if (contr == 0)
                    {
                        DTXMLRole.Columns.Add(cl.Name);
                    }
                }
                DTXMLRole.Rows.Add(dgvDatos.Rows[e.RowIndex].Cells[0].Value, dgvDatos.Rows[e.RowIndex].Cells[1].Value, dgvDatos.Rows[e.RowIndex].Cells[2].Value, dgvDatos.Rows[e.RowIndex].Cells[3].Value);                
                rutaRole = txtRuta.Text.Trim().Substring(0, txtRuta.Text.Trim().Length - 7) + "enroll.xml";               
            }
            //fin role
            dvgUsuarios.DataSource = tran.usuarioBuscado(dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString());
            dgvCurso.DataSource = tran.cursoBuscado(dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
            btnGenerar.Enabled = true;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML Archivo|*.xml";
            saveFileDialog1.Title = "Guardar un archivo XML";
            saveFileDialog1.FileName = "log";               
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                txtRuta.Text = saveFileDialog1.FileNames[0];
                fs.Close();
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DTXMLUser.Clear();
            DTXMLCourse.Clear();
            ////role           
            //if (dgvDatos.Rows.Count > 0)
            //{
            //    foreach (DataGridViewColumn cl in dgvDatos.Columns)
            //    {
            //        ListaColumnasRole.Add(cl.Name);
            //        DTXMLRole.Columns.Add(cl.Name);
            //    }
            //    foreach (DataGridViewRow rw in dgvDatos.Rows)
            //    {                    
            //       DTXMLRole.Rows.Add(rw.Cells[0].ToString(), rw.Cells[1].ToString(), rw.Cells[2].ToString(), rw.Cells[3].ToString());                   
            //    }
            //    rutaRole = txtRuta.Text.Trim().Substring(1,txtRuta.Text.Trim().Length-7)+"enroll.xml";
            //    GeneraXML(DTXMLRole,ListaColumnasRole,rutaRole);
            //}
            //role
            if (dgvDatos.Rows.Count > 0)
            {
                GeneraXML(DTXMLRole, ListaColumnasRole, rutaRole, "Matriculacion");
            }
            //fin role
            //user           
            if (dvgUsuarios.Rows.Count > 0)
            {
                foreach (DataGridViewColumn cl in dvgUsuarios.Columns)
                {
                    ListaColumnasUser.Add(cl.Name);                    
                    foreach (DataColumn dcl in DTXMLUser.Columns)
                    {
                        if (cl.Name == dcl.ColumnName.ToString())
                        {
                            contu = contu + 1;
                        }
                    }
                    if (contu == 0)
                    {
                        DTXMLUser.Columns.Add(cl.Name);
                    }
                }
                foreach (DataGridViewRow rw in dvgUsuarios.Rows)
                {
                    DTXMLUser.Rows.Add(rw.Cells[0].Value, rw.Cells[1].Value, rw.Cells[2].Value, rw.Cells[3].Value, rw.Cells[4].Value);
                }
                rutaUser = txtRuta.Text.Trim().Substring(0, txtRuta.Text.Trim().Length - 7) + "auth.xml";
                GeneraXML(DTXMLUser, ListaColumnasUser, rutaUser, "Usuario");
            }
            //fin user
            //course           
            if (dgvCurso.Rows.Count > 0)
            {
                foreach (DataGridViewColumn cl in dgvCurso.Columns)
                {
                    ListaColumnasCourse.Add(cl.Name);
                    foreach (DataColumn dcl in DTXMLCourse.Columns)
                    {
                        if (cl.Name==dcl.ColumnName.ToString())
                        {
                            contc = contc + 1;
                        }
                    }
                    if (contc == 0)
                    {
                        DTXMLCourse.Columns.Add(cl.Name);   
                    }
                }
                foreach (DataGridViewRow rw in dgvCurso.Rows)
                {
                    DTXMLCourse.Rows.Add(rw.Cells[0].Value, rw.Cells[1].Value, rw.Cells[2].Value, rw.Cells[3].Value);
                }
                rutaCourse = txtRuta.Text.Trim().Substring(0, txtRuta.Text.Trim().Length - 7) + "course.xml";
                GeneraXML(DTXMLCourse, ListaColumnasCourse, rutaCourse, "Curso");
            }
            //fin course
            limpiarControles();
        }

        private void GeneraXML(DataTable dt, List<string> ListaNomCol, string rutaArchivo, string entidad)
        {
            //btnGeneraXML.Visible = false;
            //foreach (string entidad in ListaEntidades)
            //{
                    
                    FileStream fs = new FileStream(rutaArchivo,FileMode.Create);
                    fs.Close();
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
                    else if (rbEliminar.Checked == true)
                    {
                        accion = "delete";
                    }
                    //pbXML.Maximum = dt.Rows.Count * ListaNomCol.Count + 3;
                    //pbXML.Minimum = 0;
                    //pbXML.Value = 0;
                    //pbXML.Step = 1;
                    //pbXML.Visible = true;

                    sr.WriteLine(header);
                    body = "<data>";
                    sr.WriteLine(body);
                    foreach (DataRow rw in dt.Rows)
                    {
                        body = "<datum action='" + accion + "'>";
                        sr.WriteLine(body);
                        if (accion == "delete")
                        {
                            switch (entidad)
                            {
                                case "Curso":
                                    body = "<mapping name='SHORTNAME'>" + rw["SHORTNAME"].ToString() + "</mapping>";
                                    sr.WriteLine(body);
                                    //pbXML.PerformStep();
                                    break;
                                case "Usuario":
                                    body = "<mapping name='USERNAME'>" + rw["USERNAME"].ToString() + "</mapping>";
                                    sr.WriteLine(body);
                                    //pbXML.PerformStep();
                                    break;
                                case "Matriculacion":
                                    body = "<mapping name='ENROLLCOURSE'>" + rw["ENROLLCOURSE"].ToString() + "</mapping>";
                                    sr.WriteLine(body);
                                    body = "<mapping name='USERNAME'>" + rw["USERNAME"].ToString() + "</mapping>";
                                    sr.WriteLine(body);
                                    //pbXML.PerformStep();
                                    break;
                            }
                        }
                        else
                        {                   
                            foreach (string col in ListaNomCol)
                            {
                                body = "<mapping name='" + col + "'>" + rw[col].ToString() + "</mapping>";
                                sr.WriteLine(body);
                                //pbXML.PerformStep();
                            }
                        }
                        body = "</datum>";
                        sr.WriteLine(body);
                    }
                    body = "</data>";
                    sr.WriteLine(body);
                    sr.Close();            

            //}
            // pbXML.Visible = false;
            // btnGeneraXML.Visible = true;
            //return xmlfinal;
        }

        private void fmIndividual_Load(object sender, EventArgs e)
        {
            ListaEntidades.Add("Curso");
            ListaEntidades.Add("Usuario");
            ListaEntidades.Add("Matriculacion");
            btnGenerar.Enabled = false;
        }

        private void limpiarControles() {
            txtBuscar.Clear();
            txtRuta.Clear();
            dvgUsuarios.DataSource = null;
            dgvCurso.DataSource = null;
            dgvDatos.DataSource = null;
            btnGenerar.Enabled = false;
        }
    }
}
