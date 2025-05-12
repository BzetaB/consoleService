using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Data;
using System.Net.Http;
using layer_bussiness;

namespace IntMoodleRooms
{
    public class clsWSConduit
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Metodos Usuarios        
        public async Task<string> UserConduit(string xml) {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string rsp;
            string uri= string.Format(clsWSConfig.url + clsWSConfig.wsUser + "?method={0}&token={1}&xml={2}", "handle", clsWSConfig.token,  xml);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, new StringContent(xml));
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();

                logger.Info("Conduit status: " + res.StatusCode);
            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;
                logger.Error("*****Error en UserConduit*****");
                logger.Error("Message: " + e.Message.ToString());
            }
            client.Dispose();
            return rsp;
        }

        public async Task<string> GetUser(string username) {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string rsp;
            string uri = string.Format(clsWSConfig.url + clsWSConfig.wsUser + "?method={0}&token={1}", "get_user", clsWSConfig.token);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("value", username));
            HttpContent body = new FormUrlEncodedContent(postData);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, body);
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;
                logger.Error("*****Error en GetUser*****");
                logger.Error("Message: " + e.Message.ToString());
            }
            client.Dispose();
            return rsp;          
        }

        public DataTable RegistrarRespuestaUser(string observacion, string verifica, string accion, decimal idUser, decimal pidm, string type, string userName, string auth, string email, string lastName, string fisrtName,string university)
        {
            clsDatosConduit wsdata = new clsDatosConduit();
            DataTable dtRespUser = new DataTable();
            dtRespUser=wsdata.RegistrarResultadoUsuario( observacion, verifica, accion,  idUser,  pidm,  type, userName,  auth,  email,  lastName,  fisrtName, university);
            return dtRespUser;
        }

        public DataTable ObtenerUserAnterior(decimal pidm,string type,string university) {
            clsDatosConduit wsdata = new clsDatosConduit();
            DataTable dtUserAnt = new DataTable();
            dtUserAnt = wsdata.UsuarioAnterior(pidm,type,university);
            return dtUserAnt;
        }
        #endregion
        
        #region Metodos Asignaturas
        public async Task<string> CourseConduit(string xml) {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string rsp;
            string uri = string.Format(clsWSConfig.url + clsWSConfig.wsCourse + "?method={0}&token={1}&xml={2}", "handle", clsWSConfig.token, xml);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, new StringContent(xml));
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();
                logger.Info("Conduit status: " + res.StatusCode);
            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;
                logger.Error("*****Error en CourseConduit*****");
                logger.Error("Message: " + e.Message.ToString());
            }
            client.Dispose();
            return rsp;
        }

        public async Task<string> GetCourse(string shortname)
        {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls; 
            string rsp;
            string uri = string.Format(clsWSConfig.url + clsWSConfig.wsCourse + "?method={0}&token={1}", "get_course", clsWSConfig.token);
            
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("value", shortname));
            HttpContent body = new FormUrlEncodedContent(postData);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, body);
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;
                logger.Error("*****Error en GetCourse*****");
                logger.Error("Message: " + e.Message.ToString());
            }
            client.Dispose();
            return rsp;
        }

        public DataTable RegistrarRespuestaCourse(string observacion, string verifica, string accion, decimal idCourse, string term, string nrc, string shortName, string idNumber, string fullName, string category, string university)
        {
            clsDatosConduit wsdata = new clsDatosConduit();
            DataTable dtRespCourse = new DataTable();
            dtRespCourse = wsdata.RegistrarResultadoCurso( observacion, verifica,  accion,  idCourse,  term,  nrc,  shortName,  idNumber,  fullName,  category, university);
            return dtRespCourse;
        }

        public DataTable ObtenerCouseAnterior(string term, string nrc, string university) {
            clsDatosConduit wsdata = new clsDatosConduit();
            DataTable dtCourseAnt = new DataTable();
            dtCourseAnt = wsdata.CursoAnterior(term,nrc,university);
            return dtCourseAnt;
        }
        #endregion
        
        #region Metodos Matriculaciones
        public async Task<string> EnrollConduit(string xml)
        {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string rsp;
            string uri = string.Format(clsWSConfig.url + clsWSConfig.wsEnroll + "?method={0}&token={1}&xml={2}", "handle", clsWSConfig.token, xml);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, new StringContent(xml));
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();
                
                logger.Info("Conduit status: " + res.StatusCode);
            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;
                logger.Error("*****Error en EnrollConduit*****");
                logger.Error("Message: " + e.Message.ToString());
            }
            client.Dispose();
            return rsp;
        }
        public DataTable RegistrarRespuestaRole(string observacion, string verifica, string accion, decimal idRole, decimal pidm, string term, string nrc, string enrollCourse, string userName, string role, string status, string university)
        {
            clsDatosConduit wsdata = new clsDatosConduit();
            DataTable dtRespRole = new DataTable();
            dtRespRole = wsdata.RegistrarResultadoRol( observacion, verifica,  accion,  idRole,  pidm,  term,  nrc,  enrollCourse,  userName,  role,  status, university);
            return dtRespRole;
        }
        public DataTable RegistrarRespuestaRoleDes(string observacion, decimal pidm, string term, string nrc, string enrollCourse, string userName, string role, string status) {
            DataTable dtRespRoleDes = new DataTable();
            clsDatosConduit wsdata = new clsDatosConduit();
            dtRespRoleDes = wsdata.RegistrarResultadoRolDes( observacion,  pidm,  term,  nrc,  enrollCourse,  userName,  role,  status);
            return dtRespRoleDes;
        }
        public async Task<string> GetEnroll(string username,string enrollCourse)
        {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string rsp;
            string uri = string.Format(clsWSConfig.url + clsWSConfig.wsUser + "?method={0}&token={1}", "get_user_course_recent_activity", clsWSConfig.token);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("USERNAME", username));
            postData.Add(new KeyValuePair<string, string>("ENROLLCOURSE", enrollCourse));
            postData.Add(new KeyValuePair<string, string>("maxdays", "0")); //SOFTBRILLIANCE 2024: ANADIR CAMPO MAXDAYS POR ACTUALIZACION DEL SERVICIO CONDUIT
            HttpContent body = new FormUrlEncodedContent(postData);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, body);
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;

                logger.Error("*****Error GetEnroll*****");
                logger.Error("Usuario " + username + ", Curso: " + enrollCourse + ".");
                logger.Error("Message: " + e.Message.ToString());
                string mensaje = "Ocurrió un error al procesar el enrolamiento o desenrolamiento del usuario " + username + " al curso: " + enrollCourse + ".";
                logger.Info(mensaje);                
            }
            client.Dispose();
            return rsp;
        }
        public async Task<string> GetEnrolls(string username)
        {
            HttpClient client = new HttpClient();
            //Agregado para nuevo protocolo de seguridad 2021
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string rsp;
            string uri = string.Format(clsWSConfig.url + clsWSConfig.wsUser + "?method={0}&token={1}", "get_user_course_recent_activity", clsWSConfig.token);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("USERNAME", username));
            postData.Add(new KeyValuePair<string, string>("maxdays", "360")); //SOFTBRILLIANCE 2024: ANADIR CAMPO MAXDAYS POR ACTUALIZACION DEL SERVICIO CONDUIT
            HttpContent body = new FormUrlEncodedContent(postData);
            try
            {
                HttpResponseMessage res = await client.PostAsync(uri, body);
                res.EnsureSuccessStatusCode();
                rsp = await res.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                rsp = e.Message;
                logger.Error("*****Error al Get enrolls*****");
                logger.Error("Message: " + e.Message.ToString());
            }
            client.Dispose();
            return rsp;
        }
        public DataTable ObtenerRolAnterior(decimal pidm,string term,string nrc,string university) {
            clsDatosConduit wsdata = new clsDatosConduit();
            DataTable dtRoleAnt = new DataTable();
            dtRoleAnt = wsdata.RolAnterior(pidm, term, nrc, university);
            return dtRoleAnt;
        }
        #endregion
        
        #region metodos adicionales 
        //Genera xml string desde datarows ingresados data origen
        public string GeneraXMLOri(DataRow row, List<string> ListaNomCol)
        {
            string accion = string.Empty;
            string header = "<?xml version='1.0' encoding='UTF-8'?>";
            string body = string.Empty;
            accion = "update";                  
            body = "<data><datum action='" + accion + "'>";
            foreach (string col in ListaNomCol)
            {
                body = body + "<mapping name='" + col + "'>" + row[col].ToString() + "</mapping>";
            }
            string xmlfinal = header + body + "</datum></data>";
            return xmlfinal;
        }
        //Genera xml string desde datarows ingresados 
        public string GeneraXML(DataRow row, List<string> ListaNomCol) {
            string accion=string.Empty;           
             string header = "<?xml version='1.0' encoding='UTF-8'?>";
            string body=string.Empty;

           
                switch (row["0ACCION"].ToString())
                {
                    case "INSERT":
                        accion = "create";
                        break;
                    case "UPDATE":
                        accion = "update";
                        break;
                    case "DISABLED ROLE":
                        accion = "update";
                        break;
                    case "DELETE":
                            accion = "delete";
                            break;
                }
                body = "<data><datum action='" + accion + "'>";
                foreach (string col in ListaNomCol) {
                    body = body + "<mapping name='" + col + "'>" + row[col].ToString() + "</mapping>";
                }
              
            string xmlfinal = header + body + "</datum></data>";
           
            return xmlfinal;
        }

        //Genera xml string ingresando directamente la transaccion a usar 
        public string GeneraXMLDelete(string valor, string nomCampo)
        {
            string header = "<?xml version='1.0' encoding='UTF-8'?>";
            string body = string.Empty;            
            body = "<data><datum action='delete'>";
            body = body + "<mapping name='" + nomCampo + "'>" + valor + "</mapping>";            
            string xmlfinal = header + body + "</datum></data>";
            return xmlfinal;
        }
        //Genera XML string para borrado de roles 
        public string GeneraXMLDeleteRole(string enrollcourse, string usename)
        {
            string header="<?xml version='1.0' encoding='UTF-8'?>";
            string body=string.Empty;
            body=body+"<data><datum action='delete'>";
            body=body+"<mapping name='ENROLLCOURSE'>"+enrollcourse+"</mapping>";
            body=body+"<mapping name='USERNAME'>"+usename+"</mapping>";
            string xmlfinal=header+body+"</datum></data>";
            return xmlfinal;
        }
        //Obtiene nombres de columnas de datatable para pasarlo a xml tipo string 
        public List<string> dtNombresColumnas(DataTable dt) {
            List<string> listaNomCol= new List<string>(); 
            foreach (DataColumn col in dt.Columns) {
                if (col.ColumnName.ToString().Substring(0,1)!="0")
                { 
                    listaNomCol.Add(col.ColumnName.ToString());
                }
            }
            return listaNomCol;
        }
        public DataTable ConvertirXML2DataTable(string xml)
        {
            StringReader Lector = new StringReader(xml);
            DataSet dsLector = new DataSet();
            dsLector.ReadXml(Lector);
            return dsLector.Tables[2];
        }

        public DataTable ConvertirXML2DataTableEnroll(string xml)
        {
            StringReader Lector = new StringReader(xml);
            DataSet dsLector = new DataSet();
            dsLector.ReadXml(Lector);
            return dsLector.Tables[2];
        }
        #endregion
    }
}
