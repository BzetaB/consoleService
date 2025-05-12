using System;
using System.Collections.Generic;
using layer_bussiness;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace IntMoodleRooms
{
    class Program
    {
        static void Main(string[] args)
        {

            /* tarea ObjTarea = new tarea();
             int con = 0;
             while (true) {
                 Thread hilo1 = new Thread(ObjTarea.ejecTarea);
                 hilo1.Start();
                 Thread.Sleep(1000);
                 con = con + 1;
                 if (con == 86400000)
                 {
                     Thread hilo2 = new Thread(ObjTarea.ejecTarea24h);
                     hilo2.Start();
                     con = 0;
                 }
             }*/
            /*while (true)
            {              
                   Thread hilo1 = new Thread(tarea.ejecTarea);
                   hilo1.Start();
                   Thread.Sleep(600000);         
            }*/
            
            tarea.ejecTarea(); 

            //tarea.ejecTarea24h();
            //try
            //{
            //   tarea.ejecTareaInd();               
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadLine();
            //}
            //tarea.ejecTarea24h();
            //tarea.ejecProcesarErroresRoles();
            //tarea.ejecTareaInd();
        }
    }

    public class tarea
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region procesos para hilos       
        public static void ejecTarea()
        {
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Inicio de replica de datos a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀**************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Replicando Asignaturas a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            logger.Info("*****Inicio de replica de datos a Conduit*****");
            logger.Info("***********************************************");
            logger.Info("*****Replicando Cursos a Conduit*****");
            List<DataTable> cursos = new List<DataTable>();
            cursos = ProcesarCursos();
            logger.Info("*****Fin Replicando Cursos a Conduit*****");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin Replicando Asignaturas a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            logger.Info("***********************************************");
            logger.Info("*****Replicando Usuarios a Conduit*****");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Replicando Usuarios a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            List<DataTable> usuarios = new List<DataTable>();
            usuarios = ProcesarUsuarios();
            logger.Info("*****Fin Replicando Usuarios a Conduit*****");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin Replicando Usuarios a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
           
            
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Replicando Matriculaciones a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            logger.Info("***********************************************");
            logger.Info("*****Replicando Matriculaciones a Conduit*****");

            List<DataTable> roles = new List<DataTable>();
            roles = ProcesarEnrolamientos();

            logger.Info("*****Fin Replicando Matriculaciones a Conduit*****");

            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin Replicando Matriculaciones a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
          
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀*************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin de replica de datos a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");

            logger.Info("***********************************************");
            logger.Info("*****Fin de replica de datos a Conduit*****");
            
          
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ {0}                ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║", DateTime.Now);
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public static void ejecTarea24h()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Replicando desactivacion de Matriculaciones a Conduit cada 24 horas ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀*********************************************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            List<DataTable> rolesDes = new List<DataTable>();
            rolesDes = ProcesarDesenrolamientos();
            foreach (DataTable dtRolDes in rolesDes)
            {
                Console.WriteLine(dtRolDes.Rows[0]["RSP"].ToString());
            }
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀**********************************************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin Replicando desactivacion Matriculaciones a Conduit cada 24 horas ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
            Console.ReadLine();
        }
        public static void ejecProcesarErroresRoles()
        {
            List<int> respu = new List<int>();
            respu = rolesConduit();
            foreach (int t in respu)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void ejecTareaInd() {
            DataTable dtRolesTotal = new DataTable();
            clsDatosConduit ws = new clsDatosConduit();
            List<DataTable> listarsp = new List<DataTable>();
            string businessUnit = clsWSConfig.BusinessUnit;
            dtRolesTotal = ws.ListaRoles(businessUnit);
            if (dtRolesTotal.Rows.Count > 0)
            {
                foreach (DataRow dtr in dtRolesTotal.Rows)
                {
                    listarsp = ProcesarAulaVirtualConduit(dtr["USERNAME"].ToString(), dtr["ENROLLCOURSE"].ToString());
                    Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Inicio de replica de datos a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                    Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀**************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                    foreach (DataTable dtrr in listarsp)
                    {
                        Console.WriteLine(dtrr.Rows[0]["RSP"].ToString());
                    }
                    Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀*************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                    Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin de replica de datos a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ {0}                ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║", DateTime.Now);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            } else {
                Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Inicio de replica de datos a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀**************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀       Sin roles modificados          ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀*************************************▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ Fin de replica de datos a Conduit ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║");
                //Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("║▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ {0}                ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║", DateTime.Now);
            }         
        }
        #endregion

        #region procesos para replica de data de usuarios, cursos y matriculaciones
        public static List<DataTable> ProcesarAulaVirtualConduit(string username, string course) {
            string businessUnit = clsWSConfig.BusinessUnit;
            string origenDatosUser = "0";
            string origenDatosCourse = "0";
            string origenDatosEnroll = "0";
            clsDatosConduit tr = new clsDatosConduit();
            DataTable dtUser = new DataTable();
            DataTable dtCourse = new DataTable();
            DataTable dtEnroll = new DataTable();

            DataTable rspu = new DataTable();
            DataTable opeu = new DataTable();
            string xmlu = string.Empty, xmlantu, resu, verificau, resdelu, actualizaRolesu;

            DataTable rspc = new DataTable();
            DataTable opec = new DataTable();
            string xmlc = string.Empty, xmlantc, resc, verificac, resdelc;
            DataTable rspr = new DataTable();
            DataTable oper = new DataTable();
            string xmlr = string.Empty, xmlantr, resr, verificar, resdelr;

            List<string> ListaNomColdtUsuarios = new List<string>();
            List<string> ListaNomColdtCursos = new List<string>();
            List<string> ListaNomColdtRoles = new List<string>();
            DataTable userAnterior = new DataTable();
            DataTable courseAnterior = new DataTable();
            DataTable rolAnterior = new DataTable();
            clsWSConduit ws = new clsWSConduit();
            clsDatosConduit dw = new clsDatosConduit();
            List<DataTable> listaRespuestas = new List<DataTable>();
            dtUser = dw.usuarioModificado(username);
            if (dtUser.Rows.Count == 0) {
                dtUser = dw.usuarioBuscado(username);
                origenDatosUser = "1";
            }
            dtCourse = dw.cursoModificado(course);
            if (dtCourse.Rows.Count == 0)
            {
                dtCourse = dw.cursoBuscado(course);
                origenDatosCourse = "1";
            }
            dtEnroll = dw.rolModificado(course, username);
            if (dtEnroll.Rows.Count == 0)
            {
                dtEnroll = dw.rolesBuscados(course,businessUnit);
                origenDatosEnroll = "1";
            }
            //Obtenemos nombres de campos de dt de cursos
            ListaNomColdtUsuarios = ws.dtNombresColumnas(dtUser);
            //Obtenemos nombres de campos de dt de cursos
            ListaNomColdtCursos = ws.dtNombresColumnas(dtCourse);
            //Obtenemos nombres de campos de dt de cursos
            ListaNomColdtRoles = ws.dtNombresColumnas(dtEnroll);
            //if (dtUser.Rows.Count > 0 && dtCourse.Rows.Count > 0 && dtEnroll.Rows.Count > 0)
            //{
            /*=========================usuario============================*/
            if (origenDatosUser == "0")
            {
                if (dtUser.Rows.Count > 0)
                {
                    actualizaRolesu = DesenrolarPorUsuario(username,businessUnit);
                 
                    switch (dtUser.Rows[0]["0ACCION"].ToString())
                    {
                        case "INSERT":
                            xmlu = ws.GeneraXML(dtUser.Rows[0], ListaNomColdtUsuarios);
                            break;
                        case "UPDATE":
                            //data para actualizar usuario
                            xmlu = ws.GeneraXML(dtUser.Rows[0], ListaNomColdtUsuarios);
                            //data de usuario anterior                            
                            userAnterior = ws.ObtenerUserAnterior(Convert.ToDecimal(dtUser.Rows[0]["0PIDM"].ToString()), dtUser.Rows[0]["0TYPE"].ToString(), businessUnit);
                            if (userAnterior.Rows.Count == 0)
                            {
                                userAnterior.Rows.Add(0, "#vacio#");
                            }
                            //comparamos usernames
                            if (dtUser.Rows[0]["USERNAME"].ToString() != userAnterior.Rows[0]["USERNAME"].ToString())
                            {
                                //sino eliminar anterior y crear el nuevo 
                                xmlantu = ws.GeneraXMLDelete(userAnterior.Rows[0]["USERNAME"].ToString(), "USERNAME");
                                resdelu = ws.UserConduit(xmlantu).Result.ToString();
                            }
                            break;
                        case "DELETE":
                            xmlu = ws.GeneraXMLDelete(dtUser.Rows[0]["USERNAME"].ToString(), "USERNAME");
                            break;
                    }
                    resu = ws.UserConduit(xmlu).Result.ToString();
                    verificau = ws.GetUser(dtUser.Rows[0]["USERNAME"].ToString()).Result.ToString();
                    if (verificau.Contains("<id>") == true)
                    {
                        opeu = ws.ConvertirXML2DataTable(verificau);
                        rspu = ws.RegistrarRespuestaUser(resu, verificau, dtUser.Rows[0]["0ACCION"].ToString(), Convert.ToInt32(opeu.Rows[0]["id"].ToString()), Convert.ToDecimal(dtUser.Rows[0]["0PIDM"].ToString()), dtUser.Rows[0]["0TYPE"].ToString(), dtUser.Rows[0]["USERNAME"].ToString(), dtUser.Rows[0]["AUTH"].ToString(), dtUser.Rows[0]["EMAIL"].ToString(), dtUser.Rows[0]["LAST_NAME"].ToString(), dtUser.Rows[0]["FIRST_NAME"].ToString(),businessUnit);
                    }
                    else
                    {
                        rspu = ws.RegistrarRespuestaUser(resu, verificau, dtUser.Rows[0]["0ACCION"].ToString(), 0, Convert.ToDecimal(dtUser.Rows[0]["0PIDM"].ToString()), dtUser.Rows[0]["0TYPE"].ToString(), dtUser.Rows[0]["USERNAME"].ToString(), dtUser.Rows[0]["AUTH"].ToString(), dtUser.Rows[0]["EMAIL"].ToString(), dtUser.Rows[0]["LAST_NAME"].ToString(), dtUser.Rows[0]["FIRST_NAME"].ToString(),businessUnit);
                    }                    
                }
            }
            else
            {
                rspu.Columns.Add("IDRSP");
                rspu.Columns.Add("RSP");
                if (dtUser.Rows.Count>0)
                {
                    xmlu = ws.GeneraXMLOri(dtUser.Rows[0], ListaNomColdtUsuarios);
                    resu = ws.UserConduit(xmlu).Result.ToString();
                    rspu.Rows.Add("1", "Se actualizo usuario no existente en tablas de trabajo Username: " + dtUser.Rows[0]["USERNAME"].ToString());
                }
                else
                {
                    rspu.Rows.Add("2", "No se tiene data de usuario en tablas de trabajo ni en consulta directa");
                }                
            }
            listaRespuestas.Add(rspu);
            /*=========================fin usuario============================*/
            /*=========================asignatura============================*/
            if (origenDatosCourse == "0")
            {
                if (dtCourse.Rows.Count > 0)
                {

                    switch (dtCourse.Rows[0]["0ACCION"].ToString())
                    {
                        case "INSERT":
                            xmlc = ws.GeneraXML(dtCourse.Rows[0], ListaNomColdtCursos);
                            break;
                        case "UPDATE":
                            //data para actualizar usuario
                            xmlc = ws.GeneraXML(dtCourse.Rows[0], ListaNomColdtCursos);
                            //data de usuario anterior                            
                            courseAnterior = ws.ObtenerCouseAnterior(dtCourse.Rows[0]["0TERM"].ToString(), dtCourse.Rows[0]["0NRC"].ToString(),businessUnit);
                            if (courseAnterior.Rows.Count == 0)
                            {
                                courseAnterior.Rows.Add(0, "#vacio#");
                            }
                            //comparamos shortnames
                            if (dtCourse.Rows[0]["SHORTNAME"].ToString() != courseAnterior.Rows[0]["SHORTNAME"].ToString())
                            {
                                //sino eliminar anterior y crear el nuevo
                                xmlantc = ws.GeneraXMLDelete(courseAnterior.Rows[0]["SHORTNAME"].ToString(), "SHORTNAME");
                                resdelc = ws.CourseConduit(xmlantc).Result.ToString();
                            }
                            break;
                        case "DELETE":
                            xmlc = ws.GeneraXMLDelete(dtCourse.Rows[0]["SHORTNAME"].ToString(), "SHORTNAME");
                            break;
                    }
                    resc = ws.CourseConduit(xmlc).Result.ToString();
                    verificac = ws.GetCourse(dtCourse.Rows[0]["SHORTNAME"].ToString()).Result.ToString();
                    if (verificac.Contains("<id>") == true)
                    {
                        opec = ws.ConvertirXML2DataTable(verificac);
                        rspc = ws.RegistrarRespuestaCourse(resc, verificac, dtCourse.Rows[0]["0ACCION"].ToString(), Convert.ToInt32(opec.Rows[0]["id"].ToString()), dtCourse.Rows[0]["0TERM"].ToString(), dtCourse.Rows[0]["0NRC"].ToString(), dtCourse.Rows[0]["SHORTNAME"].ToString(), dtCourse.Rows[0]["IDNUMBER"].ToString(), dtCourse.Rows[0]["FULLNAME"].ToString(), dtCourse.Rows[0]["CATEGORY"].ToString(),businessUnit);
                    }
                    else
                    {
                        rspc = ws.RegistrarRespuestaCourse(resc, verificac, dtCourse.Rows[0]["0ACCION"].ToString(), 0, dtCourse.Rows[0]["0TERM"].ToString(), dtCourse.Rows[0]["0NRC"].ToString(), dtCourse.Rows[0]["SHORTNAME"].ToString(), dtCourse.Rows[0]["IDNUMBER"].ToString(), dtCourse.Rows[0]["FULLNAME"].ToString(), dtCourse.Rows[0]["CATEGORY"].ToString(),businessUnit);
                    }
                }
            }
            else
            {
                rspc.Columns.Add("IDRSP");
                rspc.Columns.Add("RSP");
                if (dtCourse.Rows.Count > 0)
                {
                    xmlc = ws.GeneraXMLOri(dtCourse.Rows[0], ListaNomColdtCursos);
                    resc = ws.CourseConduit(xmlc).Result.ToString();                    
                    rspc.Rows.Add("1", "Se actualizo asignatura no existente en tablas de trabajo Course: " + dtCourse.Rows[0]["SHORTNAME"].ToString());
                }
                else
                {
                    rspc.Rows.Add("2", "No se tiene data de asignatura en tablas de trabajo ni en consulta directa");
                }                
            }
            listaRespuestas.Add(rspc);
            /*=========================fin asignatura============================*/
            /*=========================matriculacion============================*/
            if (origenDatosEnroll=="0")
            {
                if (dtEnroll.Rows.Count > 0)
                {
                    switch (dtEnroll.Rows[0]["0ACCION"].ToString())
                    {
                        case "INSERT":
                            xmlr = ws.GeneraXML(dtEnroll.Rows[0], ListaNomColdtRoles);
                            break;
                        case "UPDATE":
                            //data para actualizar usuario
                            xmlr = ws.GeneraXML(dtEnroll.Rows[0], ListaNomColdtRoles);
                            //data de usuario anterior                            
                            rolAnterior = ws.ObtenerRolAnterior(Convert.ToDecimal(dtEnroll.Rows[0]["0PIDM"].ToString()), dtEnroll.Rows[0]["0TERM"].ToString(), dtEnroll.Rows[0]["0NRC"].ToString(),businessUnit);
                            if (rolAnterior.Rows.Count == 0)
                            {
                                rolAnterior.Rows.Add(0, "#vacio#");
                            }
                            //comparamos usernames
                            if ((dtEnroll.Rows[0]["USERNAME"].ToString() != rolAnterior.Rows[0]["USERNAME"].ToString()) && (dtEnroll.Rows[0]["ENROLLCOURSE"].ToString() != rolAnterior.Rows[0]["ENROLLCOURSE"].ToString()))
                            {
                                //sino eliminar anterior y crear el nuevo 
                                xmlantr = ws.GeneraXMLDeleteRole(rolAnterior.Rows[0]["ENROLLCOURSE"].ToString(), rolAnterior.Rows[0]["USERNAME"].ToString());
                                resdelr = ws.EnrollConduit(xmlantr).Result.ToString();
                            }
                            break;
                        case "DELETE":
                            xmlr = ws.GeneraXMLDeleteRole(dtEnroll.Rows[0]["ENROLLCOURSE"].ToString(), dtEnroll.Rows[0]["USERNAME"].ToString());
                            break;
                    }
                    resr = ws.EnrollConduit(xmlr).Result.ToString();
                    verificar = ws.GetEnroll(dtEnroll.Rows[0]["USERNAME"].ToString(), dtEnroll.Rows[0]["ENROLLCOURSE"].ToString()).Result.ToString();
                    if (verificar.Contains("<id>") == true)
                    {
                        oper = ws.ConvertirXML2DataTable(verificar);
                        rspr = ws.RegistrarRespuestaRole(resr, verificar, dtEnroll.Rows[0]["0ACCION"].ToString(), Convert.ToInt32(oper.Rows[0]["id"].ToString()), Convert.ToDecimal(dtEnroll.Rows[0]["0PIDM"].ToString()), dtEnroll.Rows[0]["0TERM"].ToString(), dtEnroll.Rows[0]["0NRC"].ToString(), dtEnroll.Rows[0]["ENROLLCOURSE"].ToString(), dtEnroll.Rows[0]["USERNAME"].ToString(), dtEnroll.Rows[0]["ROLE"].ToString(), dtEnroll.Rows[0]["STATUS"].ToString(),businessUnit);
                    }
                    else
                    {
                        rspr = ws.RegistrarRespuestaRole(resr, verificar, dtEnroll.Rows[0]["0ACCION"].ToString(), 0, Convert.ToDecimal(dtEnroll.Rows[0]["0PIDM"].ToString()), dtEnroll.Rows[0]["0TERM"].ToString(), dtEnroll.Rows[0]["0NRC"].ToString(), dtEnroll.Rows[0]["ENROLLCOURSE"].ToString(), dtEnroll.Rows[0]["USERNAME"].ToString(), dtEnroll.Rows[0]["ROLE"].ToString(), dtEnroll.Rows[0]["STATUS"].ToString(),businessUnit);
                    }                    
                }
            }
            else
            {
                rspr.Columns.Add("IDRSP");
                rspr.Columns.Add("RSP");
                if (dtEnroll.Rows.Count>0)
                {
                    xmlr = ws.GeneraXMLOri(dtEnroll.Rows[0], ListaNomColdtRoles);
                    resr = ws.EnrollConduit(xmlr).Result.ToString();
                    rspr.Rows.Add("1", "Se actualizo matriculacion no existente en tablas de trabajo Course: " + dtEnroll.Rows[0]["ENROLLCOURSE"].ToString() + " - User: " + dtEnroll.Rows[0]["USERNAME"].ToString());
                }
                else
                {
                    rspr.Rows.Add("2", "No se tiene data de matriculacion en tablas de trabajo ni en consulta directa");
                }                
            }
            listaRespuestas.Add(rspr);
            /*=========================fin matriculacion============================*/
            //}
            return listaRespuestas;
        }       
        private static List<DataTable> ProcesarCursos()
        {
            //Declaramos variables necesarias
            List<DataTable> listaRespuestas = new List<DataTable>();
            DataTable dtCursos = new DataTable();
            List<string> ListaNomColdtCursos = new List<string>();
            clsDatosConduit DatosCursos = new clsDatosConduit();
            clsWSConduit ws = new clsWSConduit();
            DataTable rsp = new DataTable();
            string xml=string.Empty, xmlant, res, verifica, resdel;
            string asunto = "";
            DataTable courseAnterior = new DataTable();
            DataTable ope = new DataTable();
            //Variable para identificar unidad de negocio
            string businessUnit = clsWSConfig.BusinessUnit;
            //Obtenemos data de asignaturas 
            logger.Info("*** Obtención de data de cursos a procesar ***");
            dtCursos = DatosCursos.ListaCursos(businessUnit);
            //Obtenemos nombres de campos de dt de cursos
            ListaNomColdtCursos = ws.dtNombresColumnas(dtCursos);
            //Verificamos si hay data obtenida                   
            if (dtCursos.Rows.Count > 0 && ListaNomColdtCursos.Count > 0)
            {
                foreach (DataRow RowCurso in dtCursos.Rows)
                {
                    logger.Info("Action: " + RowCurso["0ACCION"].ToString()
                        + " - course:  " + RowCurso["SHORTNAME"].ToString());
                    switch (RowCurso["0ACCION"].ToString())
                    {
                        case "INSERT":
                            asunto = "la creación del curso";
                            xml = ws.GeneraXML(RowCurso, ListaNomColdtCursos);
                            break;
                        case "UPDATE":
                            //data para actualizar usuario
                            asunto = "la actualización del curso";
                            xml = ws.GeneraXML(RowCurso, ListaNomColdtCursos);
                            //data de usuario anterior                            
                            courseAnterior = ws.ObtenerCouseAnterior(RowCurso["0TERM"].ToString(), RowCurso["0NRC"].ToString(), businessUnit);
                            if (courseAnterior.Rows.Count == 0)
                            {
                                courseAnterior.Rows.Add(0, "#vacio#");
                            }
                            //comparamos shortnames
                            if (RowCurso["SHORTNAME"].ToString() != courseAnterior.Rows[0]["SHORTNAME"].ToString())
                            {
                                //sino eliminar anterior y crear el nuevo
                                xmlant = ws.GeneraXMLDelete(courseAnterior.Rows[0]["SHORTNAME"].ToString(), "SHORTNAME");
                                resdel = ws.CourseConduit(xmlant).Result.ToString();
                            }
                            break;
                        case "DELETE":
                            asunto = "la eliminación del curso";
                            xml = ws.GeneraXMLDelete(RowCurso["SHORTNAME"].ToString(), "SHORTNAME");
                            break;
                    }
                    res = ws.CourseConduit(xml).Result.ToString();
                    verifica = ws.GetCourse(RowCurso["SHORTNAME"].ToString()).Result.ToString();
                    

                    if (verifica.Contains("<id>") == true)
                    {
                        ope = ws.ConvertirXML2DataTable(verifica);
                        rsp = ws.RegistrarRespuestaCourse(res, verifica, RowCurso["0ACCION"].ToString(), Convert.ToInt32(ope.Rows[0]["id"].ToString()), RowCurso["0TERM"].ToString(), RowCurso["0NRC"].ToString(), RowCurso["SHORTNAME"].ToString(), RowCurso["IDNUMBER"].ToString(), RowCurso["FULLNAME"].ToString(), RowCurso["CATEGORY"].ToString(), businessUnit);

                        if (RowCurso["0ACCION"].ToString()=="DELETE" && verifica.Contains(RowCurso["SHORTNAME"].ToString())) {
                            string mensaje = "Ocurrió un error al procesar el curso " + RowCurso["SHORTNAME"] + ", NRC: " + RowCurso["0NRC"].ToString() + ".";
                            logger.Info(mensaje);
                            SendGridBL.SendMail(asunto, mensaje).Wait();
                        }
                    }
                    else
                    {
                            string mensaje = "Ocurrió un error al procesar el curso " + RowCurso["SHORTNAME"] + ", NRC: " + RowCurso["0NRC"].ToString() + ".";
                            logger.Info(mensaje);
                            SendGridBL.SendMail(asunto, mensaje).Wait();
                        
                        rsp = ws.RegistrarRespuestaCourse(res,verifica, RowCurso["0ACCION"].ToString(), 0, RowCurso["0TERM"].ToString(), RowCurso["0NRC"].ToString(), RowCurso["SHORTNAME"].ToString(), RowCurso["IDNUMBER"].ToString(), RowCurso["FULLNAME"].ToString(), RowCurso["CATEGORY"].ToString(), businessUnit);
                    }
                    listaRespuestas.Add(rsp);
                    
                }
            }
            else
            {
                rsp.Columns.Add("IDRSP");
                rsp.Columns.Add("RSP");
                rsp.Rows.Add("3", "Sin datos para cursos!!!");
                listaRespuestas.Add(rsp);
                logger.Info("Sin datos para cursos!!!");
            }         
            return listaRespuestas;
        }
        private static List<DataTable> ProcesarUsuarios()
        {
            //Declaramos variables necesarias
            List<DataTable> listaRespuestas = new List<DataTable>();
            DataTable dtUsuarios = new DataTable();
            List<string> ListaNomColdtUsuarios = new List<string>();
            clsDatosConduit DatosUsuarios = new clsDatosConduit();
            clsWSConduit ws = new clsWSConduit();
            DataTable rsp = new DataTable();
            string xml=string.Empty, xmlant, res, verifica, resdel, actualizaRoles;
            string asunto = "";
            DataTable userAnterior = new DataTable();
            DataTable ope = new DataTable();
            //Variable para identificar unidad de negocio
            string businessUnit = clsWSConfig.BusinessUnit;
            //Obtenemos data de usuarios 
            logger.Info("*** Obtención de data de usuarios a procesar ***");
            dtUsuarios = DatosUsuarios.ListaUsuarios(businessUnit);

            //Obtenemos nombres de campos de dt de usuarios
            ListaNomColdtUsuarios = ws.dtNombresColumnas(dtUsuarios);
            //Verificamos si hay data obtenida  
            
            if (dtUsuarios.Rows.Count > 0 && ListaNomColdtUsuarios.Count > 0)
            {
                foreach (DataRow RowUsuario in dtUsuarios.Rows)
                {
                    logger.Info("Action: " + RowUsuario["0ACCION"].ToString()
                        + " - user:  " + RowUsuario["USERNAME"].ToString());

                    actualizaRoles = DesenrolarPorUsuario(RowUsuario["USERNAME"].ToString(),businessUnit);
                    switch (RowUsuario["0ACCION"].ToString())
                    {
                        case "INSERT":
                            asunto = "la creación de usuario";
                            xml = ws.GeneraXML(RowUsuario, ListaNomColdtUsuarios);
                            break;
                        case "UPDATE":
                            //data para actualizar usuario
                            ListaNomColdtUsuarios.Remove("COD_EST");
                            asunto = "la actualización de usuario";
                            xml = ws.GeneraXML(RowUsuario, ListaNomColdtUsuarios);
                            //data de usuario anterior                            
                            userAnterior = ws.ObtenerUserAnterior(Convert.ToDecimal(RowUsuario["0PIDM"].ToString()), RowUsuario["0TYPE"].ToString(),businessUnit);
                            if (userAnterior.Rows.Count == 0)
                            {
                                userAnterior.Rows.Add(0, "#vacio#");
                            }
                            //comparamos usernames
                            if (RowUsuario["USERNAME"].ToString() != userAnterior.Rows[0]["USERNAME"].ToString())
                            {
                                //sino eliminar anterior y crear el nuevo 
                                xmlant = ws.GeneraXMLDelete(userAnterior.Rows[0]["USERNAME"].ToString(), "USERNAME");
                                resdel = ws.UserConduit(xmlant).Result.ToString();
                            }
                            break;
                        case "DELETE": //Revision de metodo
                            ListaNomColdtUsuarios.Remove("COD_EST");
                            asunto = "la eliminación de usuario";
                            xml = ws.GeneraXMLDelete(RowUsuario["USERNAME"].ToString(), "USERNAME");
                            break;
                    }
                    res = ws.UserConduit(xml).Result.ToString();
                    verifica = ws.GetUser(RowUsuario["USERNAME"].ToString()).Result.ToString();
                    if (verifica.Contains("<id>") == true)
                    {
                        ope = ws.ConvertirXML2DataTable(verifica);
                        rsp = ws.RegistrarRespuestaUser(res, verifica, RowUsuario["0ACCION"].ToString(), Convert.ToInt32(ope.Rows[0]["id"].ToString()), Convert.ToDecimal(RowUsuario["0PIDM"].ToString()), RowUsuario["0TYPE"].ToString(), RowUsuario["USERNAME"].ToString(), RowUsuario["AUTH"].ToString(), RowUsuario["EMAIL"].ToString(), RowUsuario["LAST_NAME"].ToString(), RowUsuario["FIRST_NAME"].ToString(), businessUnit);

                        if (RowUsuario["0ACCION"].ToString() == "DELETE")
                        {
                            string mensaje = "Ocurrió un error al eliminar al usuario " + RowUsuario["USERNAME"] + ", PDIM: " + RowUsuario["0PIDM"].ToString() + ".";
                            logger.Info(mensaje);
                            SendGridBL.SendMail(asunto, mensaje).Wait();
                        }

                    }
                    else
                    {
                            string mensaje = "Ocurrió un error al procesar al usuario " + RowUsuario["USERNAME"]+", PDIM: "+ RowUsuario["0PIDM"].ToString() + ".";
                            logger.Info(mensaje);
                            SendGridBL.SendMail(asunto, mensaje).Wait();
                        
                        rsp = ws.RegistrarRespuestaUser(res, verifica, RowUsuario["0ACCION"].ToString(), 0, Convert.ToDecimal(RowUsuario["0PIDM"].ToString()), RowUsuario["0TYPE"].ToString(), RowUsuario["USERNAME"].ToString(), RowUsuario["AUTH"].ToString(), RowUsuario["EMAIL"].ToString(), RowUsuario["LAST_NAME"].ToString(), RowUsuario["FIRST_NAME"].ToString(), businessUnit);
                    }
                    listaRespuestas.Add(rsp);
                }

            }
            else
            {
                rsp.Columns.Add("IDRSP");
                rsp.Columns.Add("RSP");
                rsp.Rows.Add("3", "Sin datos para usuarios!!!");
                listaRespuestas.Add(rsp);
                logger.Info("Sin datos para usuarios!!!");
            }
            return listaRespuestas;
        }
        public static List<DataTable> ProcesarEnrolamientos()
        {
            //Declaramos variables necesarias
            List<DataTable> listaRespuestas = new List<DataTable>();
            DataTable dtRoles = new DataTable();
            List<string> ListaNomColdtRoles = new List<string>();
            clsDatosConduit DatosRoles = new clsDatosConduit();
            clsWSConduit ws = new clsWSConduit();
            DataTable rsp = new DataTable();
            string xml=string.Empty, xmlant, res, verifica, resdel;
            int contError = 0;
            DataTable rolAnterior = new DataTable();
            DataTable ope = new DataTable();
            //Variable para identificar unidad de negocio
            string businessUnit = clsWSConfig.BusinessUnit;
            logger.Info("*** Obtención de data de enrolamientos a procesar ***");
            //Obtenemos data de asignaturas 
            dtRoles = DatosRoles.ListaRoles(businessUnit);
            
            //Obtenemos nombres de campos de dt de cursos
            ListaNomColdtRoles = ws.dtNombresColumnas(dtRoles);
            //Verificamos si hay data obtenida                   
            if (dtRoles.Rows.Count > 0 && ListaNomColdtRoles.Count > 0)
            {
                dtRoles.Columns.Add("resultado", typeof(string));

                foreach (DataRow RowRol in dtRoles.Rows)
                {
                    logger.Info($"INICIO DEL ENROLAMIENTO: -ACCION: {RowRol["0ACCION"]} - CURSO: {RowRol["ENROLLCOURSE"]} - USUARIO: {RowRol["USERNAME"]}");

                    switch (RowRol["0ACCION"].ToString())
                    {
                        case "INSERT":
                            xml = ws.GeneraXML(RowRol, ListaNomColdtRoles);
                            break;
                        case "UPDATE": 
                            //data para actualizar usuario
                            xml = ws.GeneraXML(RowRol, ListaNomColdtRoles);
                            //data de usuario anterior                            
                            rolAnterior = ws.ObtenerRolAnterior(Convert.ToDecimal(RowRol["0PIDM"].ToString()), RowRol["0TERM"].ToString(), RowRol["0NRC"].ToString(), businessUnit);
                            if (rolAnterior.Rows.Count == 0)
                            {
                                rolAnterior.Rows.Add(0, "#vacio#");
                            }
                            //comparamos usernames
                            if ((RowRol["USERNAME"].ToString() != rolAnterior.Rows[0]["USERNAME"].ToString()) && (RowRol["ENROLLCOURSE"].ToString() != rolAnterior.Rows[0]["ENROLLCOURSE"].ToString()))
                            {
                                //sino eliminar anterior y crear el nuevo 
                                xmlant = ws.GeneraXMLDeleteRole(rolAnterior.Rows[0]["ENROLLCOURSE"].ToString(), rolAnterior.Rows[0]["USERNAME"].ToString());
                                resdel = ws.EnrollConduit(xmlant).Result.ToString();
                            }
                            break;
                        case "DELETE":
                            xml = ws.GeneraXML(RowRol, ListaNomColdtRoles);
                            break;
                    }

                    res = ws.EnrollConduit(xml).Result.ToString();
                    RowRol["resultado"] = res;
                    
                    logger.Info($"FIN DEL ENROLAMIENTO: -ACCION: {RowRol["0ACCION"]} - CURSO: {RowRol["ENROLLCOURSE"]} - USUARIO: {RowRol["USERNAME"]}");
                }
                
                // Verificar cada enrolamiento al finalizar todos los procesos anteriores
                foreach (DataRow RowRol in dtRoles.Rows)
                {
                    verifica = ws.GetEnroll(RowRol["USERNAME"].ToString(), RowRol["ENROLLCOURSE"].ToString()).Result.ToString();

                    switch (RowRol["0ACCION"].ToString())
                    {
                        case "INSERT":
                        case "UPDATE":
                            if (verifica.Contains(RowRol["ENROLLCOURSE"].ToString()))
                            {
                                ope = ws.ConvertirXML2DataTableEnroll(verifica);
                                DataRow[] rowEnroll = ope.Select("shortname = '" + RowRol["ENROLLCOURSE"].ToString() + "'");
                                var verificaEnroll = string.Join(", ", rowEnroll[0].ItemArray);
                                rsp = ws.RegistrarRespuestaRole(RowRol["resultado"].ToString(), $"Success: { verificaEnroll }", RowRol["0ACCION"].ToString(), Convert.ToInt32(rowEnroll[0]["id"].ToString()), Convert.ToDecimal(RowRol["0PIDM"].ToString()), RowRol["0TERM"].ToString(), RowRol["0NRC"].ToString(), RowRol["ENROLLCOURSE"].ToString(), RowRol["USERNAME"].ToString(), RowRol["ROLE"].ToString(), RowRol["STATUS"].ToString(), businessUnit);

                            }
                            else
                            {
                                contError++;
                                string mensaje = $"Ocurrió un error al verificar: {RowRol["0ACCION"]} del enrolamiento: - usuario: {RowRol["USERNAME"]} ({RowRol["0PIDM"]}) - curso: {RowRol["ENROLLCOURSE"]} ({RowRol["0NRC"]}).";
                                logger.Error("ERROR: " + mensaje);
                                logger.Error(verifica);

                                string insertmsg = $"INSERT INTO SZTRIMR(SZTRIMR_ID, " +
                                $"SZTRIMR_ACCION, SZTRIMR_KEYGEN, SZTRIMR_PIDM," +
                                $" SZTRIMR_TERM_CODE, SZTRIMR_CRN, SZTRIMR_ENROLLCOURSE, " +
                                $"SZTRIMR_USERNAME, SZTRIMR_ROLE, SZTRIMR_STATUS," +
                                $"SZTRIMR_BLOCK)VALUES(LV_ID+{contError}, '{RowRol["0ACCION"]}' , '{RowRol["0KEYGEN"]}', '{RowRol["0PIDM"]}', '{RowRol["0TERM"]}', '{RowRol["0NRC"]}', '{RowRol["ENROLLCOURSE"]}','{RowRol["USERNAME"]}', '{RowRol["ROLE"]}', '0', '{RowRol["BLOCK"]}');";

                                rsp = ws.RegistrarRespuestaRole(RowRol["resultado"].ToString(), $"Error, volver a procesar: { insertmsg }" , RowRol["0ACCION"].ToString(), Convert.ToInt32(0), Convert.ToDecimal(RowRol["0PIDM"].ToString()), RowRol["0TERM"].ToString(), RowRol["0NRC"].ToString(), RowRol["ENROLLCOURSE"].ToString(), RowRol["USERNAME"].ToString(), RowRol["ROLE"].ToString(), RowRol["STATUS"].ToString(), businessUnit);
                                SendGridBL.SendMail(RowRol["0ACCION"].ToString(), mensaje).Wait();
                            }
                            break;
                        case "DELETE":
                            if (verifica.Contains(RowRol["ENROLLCOURSE"].ToString()))
                            {
                                contError++;
                                string mensaje = $"Ocurrió un error al verificar: {RowRol["0ACCION"]} del enrolamiento: - usuario: {RowRol["USERNAME"]} ({RowRol["0PIDM"]}) - curso: {RowRol["ENROLLCOURSE"]} ({RowRol["0NRC"]}).";
                                logger.Error("ERROR: " + mensaje);
                                logger.Error(verifica);

                                string insertmsg = $"INSERT INTO SZTRIMR(SZTRIMR_ID, " +
                                $"SZTRIMR_ACCION, SZTRIMR_KEYGEN, SZTRIMR_PIDM," +
                                $" SZTRIMR_TERM_CODE, SZTRIMR_CRN, SZTRIMR_ENROLLCOURSE, " +
                                $"SZTRIMR_USERNAME, SZTRIMR_ROLE, SZTRIMR_STATUS," +
                                $"SZTRIMR_BLOCK)VALUES(LV_ID+{contError}, '{RowRol["0ACCION"]}' , '{RowRol["0KEYGEN"]}', '{RowRol["0PIDM"]}', '{RowRol["0TERM"]}', '{RowRol["0NRC"]}', '{RowRol["ENROLLCOURSE"]}','{RowRol["USERNAME"]}', '{RowRol["ROLE"]}', '0', '{RowRol["BLOCK"]}');";

                                ope = ws.ConvertirXML2DataTableEnroll(verifica);
                                DataRow[] rowEnroll = ope.Select("shortname = '" + RowRol["ENROLLCOURSE"].ToString() + "'");

                                rsp = ws.RegistrarRespuestaRole(RowRol["resultado"].ToString(), $"Error, volver a procesar: { insertmsg }", RowRol["0ACCION"].ToString(), Convert.ToInt32(rowEnroll[0]["id"].ToString()), Convert.ToDecimal(RowRol["0PIDM"].ToString()), RowRol["0TERM"].ToString(), RowRol["0NRC"].ToString(), RowRol["ENROLLCOURSE"].ToString(), RowRol["USERNAME"].ToString(), RowRol["ROLE"].ToString(), RowRol["STATUS"].ToString(), businessUnit);

                                SendGridBL.SendMail(RowRol["0ACCION"].ToString(), mensaje).Wait();

                            }
                            else
                            {
                                rsp = ws.RegistrarRespuestaRole(RowRol["resultado"].ToString(), "Success", RowRol["0ACCION"].ToString(), Convert.ToInt32(0), Convert.ToDecimal(RowRol["0PIDM"].ToString()), RowRol["0TERM"].ToString(), RowRol["0NRC"].ToString(), RowRol["ENROLLCOURSE"].ToString(), RowRol["USERNAME"].ToString(), RowRol["ROLE"].ToString(), RowRol["STATUS"].ToString(), businessUnit);
                            }
                            break;
                    }
                    listaRespuestas.Add(rsp);
                }
            }
            else
            {
                rsp.Columns.Add("IDRSP");
                rsp.Columns.Add("RSP");
                rsp.Rows.Add("3", "Sin datos para roles!!!");
                listaRespuestas.Add(rsp);
                logger.Info("Sin datos para roles!!!");
            }
            return listaRespuestas;
            
        }
        public static List<DataTable> ProcesarDesenrolamientos()
        {
            //Declaramos variables necesarias
            List<DataTable> listaRespuestas = new List<DataTable>();
            DataTable dtRolesDes = new DataTable();
            List<string> ListaNomColdtRolesDes = new List<string>();
            clsDatosConduit DatosRolesDes = new clsDatosConduit();
            clsWSConduit ws = new clsWSConduit();
            DataTable rsp = new DataTable();
            string xml, res;
            DataTable ope = new DataTable();
            //Obtenemos data de asignaturas 
            dtRolesDes = DatosRolesDes.ListaRolesDesactivados();
            //Obtenemos nombres de campos de dt de cursos
            ListaNomColdtRolesDes = ws.dtNombresColumnas(dtRolesDes);
            //Verificamos si hay data obtenida  
            if (dtRolesDes.Rows.Count > 0 && ListaNomColdtRolesDes.Count > 0)
            {
                foreach (DataRow RowRolDes in dtRolesDes.Rows)
                {
                    xml = ws.GeneraXMLDeleteRole(RowRolDes["ENROLLCOURSE"].ToString(),RowRolDes["USERNAME"].ToString());
                    //xml = ws.GeneraXML(RowRolDes, ListaNomColdtRolesDes);
                    res = ws.EnrollConduit(xml).Result.ToString();
                    rsp = ws.RegistrarRespuestaRoleDes(res, Convert.ToDecimal(RowRolDes["0PIDM"].ToString()), RowRolDes["0TERM"].ToString(), RowRolDes["0NRC"].ToString(), RowRolDes["ENROLLCOURSE"].ToString(), RowRolDes["USERNAME"].ToString(), RowRolDes["ROLE"].ToString(), RowRolDes["STATUS"].ToString());
                    listaRespuestas.Add(rsp);
                }
            }
            else
            {
                rsp.Columns.Add("IDRSP");
                rsp.Columns.Add("RSP");
                rsp.Rows.Add("3", "Sin datos para desactivar roles!!!");
                listaRespuestas.Add(rsp);
            }
            return listaRespuestas;
        }
        public static string DesenrolarPorUsuario(string username,string businessUnit) {
            int cont = 0;
            string valor, xml, res;
            clsDatosConduit transacBANNER = new clsDatosConduit();
            clsWSConduit transacCONDUIT = new clsWSConduit();
            string RolesConduit = string.Empty;
            DataTable dtRolesBanner = new DataTable();
            DataTable dtRolesConduit = new DataTable();
            res = "Eliminacion de matriculaciones por usuarios - sin registros que procesar.....";
            dtRolesBanner = transacBANNER.rolesBuscados(username,businessUnit);
            RolesConduit = transacCONDUIT.GetEnrolls(username).Result.ToString();
            if (RolesConduit.Contains("<id>") == true)
            {
                dtRolesConduit = transacCONDUIT.ConvertirXML2DataTable(RolesConduit);
                foreach (DataRow drRolesConduit in dtRolesConduit.Rows) {
                    cont = 0;
                    foreach (DataRow drRolesBanner in dtRolesBanner.Rows) {
                        if (drRolesConduit["shortname"].ToString() == drRolesBanner["ENROLLCOURSE"].ToString()) 
                        {
                            cont= cont + 1;                        
                        }
                    }
                    if (cont == 0)
                    {
                        valor = drRolesConduit["shortname"].ToString();
                        xml = transacCONDUIT.GeneraXMLDeleteRole(valor,username);
                        res = transacCONDUIT.EnrollConduit(xml).Result.ToString();
                    }
                }
            }
            return res;
        }
        public static List<int> rolesConduit() {
            clsWSConduit trn = new clsWSConduit();
            clsDatosSql users = new clsDatosSql();
            DataTable dtUsers = new DataTable();
            DataTable dtRolesConduit = new DataTable();
            string  roles;
            string user;
            clsDatosConduit DatosRoles = new clsDatosConduit();
            List<int> listaresp = new List<int>();
            dtUsers = users.totalsuarios();
            foreach (DataRow dr in dtUsers.Rows) {
                user = dr["USERNAME"].ToString();
                roles = trn.GetEnrolls(user).Result.ToString();
                if (roles.Contains("<id>") == true) {
                    dtRolesConduit = trn.ConvertirXML2DataTable(roles);
                    foreach (DataRow drt in dtRolesConduit.Rows)
                    {
                        logger.Info("*****Metodo rolesConduit*****");
                        logger.Info("Message: " + "  course:  " + drt["shortname"].ToString()
                            + "  user:  " + drt["USERNAME"].ToString());
                        int rsp;
                        rsp = users.insertaRol(drt["shortname"].ToString(), dr["USERNAME"].ToString(), "active", "0");
                        listaresp.Add(rsp);
                    }
                }                             
            }
            return listaresp;            
        }
        #endregion
    }
}