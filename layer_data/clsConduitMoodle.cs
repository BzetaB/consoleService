using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace layer_data
{
    public class clsConduitMoodle
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        clsHelp transac = new clsHelp();

        #region Obtencion de datos de usuarios, cursos y roles para enviar a conduit
        public DataTable ListaCoursesConduit(string university)
        {
            DataTable dtCourses = new DataTable();
            try
            {
                object[] vparams = new object[] { university };
                dtCourses = transac.sp_EjecParams("P_LISTA_CURSOSCONDUIT", "SZKDMRB", "BANINST1", "0", vparams);
                logger.Info("Cantidad de cursos a procesar: " + dtCourses.Rows.Count);
                return dtCourses;
                
            }
            catch (Exception e){
                logger.Error("Message: " + e.Message.ToString());
                return dtCourses;
            }
        }
        public DataTable ListaUsersConduit(string university)
        {
            DataTable dtUsers = new DataTable();
            try
            {
                object[] vparams = new object[] { university };
                dtUsers = transac.sp_EjecParams("P_LISTA_USUARIOSCONDUIT", "SZKDMRB", "BANINST1", "0", vparams);
                logger.Info("Cantidad de usuarios a procesar: " + dtUsers.Rows.Count);
                return dtUsers;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());
            
                return dtUsers;
            }
        }
        public DataTable ListaRolesConduit(string university)
        {

            DataTable dtRoles = new DataTable();
            try
            {
                object[] vparams = new object[] { university};
                dtRoles = transac.sp_EjecParams("P_LISTA_ROLESCONDUIT", "SZKDMRB", "BANINST1", "0", vparams);
                logger.Info("Cantidad de enrolamientos a procesar: " + dtRoles.Rows.Count);
                return dtRoles;
            }
            catch (Exception e)
            {
               logger.Error("Message: " + e.Message.ToString());
            
                return dtRoles;
            }
            
        }
        public DataTable ListaRolesDesactivadosConduit() {
            DataTable dtRolesDes = new DataTable();
            try
            {
                dtRolesDes = transac.sp_Ejec("P_LISTADESACTIVAROLESCONDUIT", "BANINST1", "SZKDMRB", "0");
                return dtRolesDes;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());
            
                return dtRolesDes;
            } 
        }
        #endregion
        #region Obtencion de registros anteriores usuarios, roles, cursos
        public DataTable UsuarioAnterior(decimal pidm,string type,string university)
        {
            DataTable dtUserAnt = new DataTable();
            
            try
            {
                object[] vparams = new object[] { pidm, type, university };
                dtUserAnt = transac.sp_EjecParams("P_GETUSERNAMEANT", "SZKDMRB", "BANINST1", "0", vparams);
                return dtUserAnt;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());
            
                return dtUserAnt;
            }
        }
        public DataTable CursoAnterior(string term,string nrc,string university) {
            DataTable dtCursoAnt = new DataTable();
          
            try
            {
                object[] vparams = new object[] { term, nrc, university };
                dtCursoAnt = transac.sp_EjecParams("P_GETSHORTNAMEANT", "SZKDMRB", "BANINST1", "0", vparams);
                return dtCursoAnt;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());
            
                return dtCursoAnt;
            }
        }
        public DataTable RolAnterior(decimal pidm, string term, string nrc, string university) {
            DataTable dtRolAnt = new DataTable();
            
            try
            {
                object[] vparams = new object[] { pidm, term, nrc, university };
                dtRolAnt = transac.sp_EjecParams("P_GETROLEANT", "SZKDMRB", "BANINST1", "0", vparams);
                return dtRolAnt;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());
           
                return dtRolAnt;
            }
        }
        #endregion
        #region Registro de estados de registro de roles, cursos y usuarios en conduit  
        public DataTable RegistroCourseConduit(string observacion, string verifica, string accion,decimal idCourse,string term,string nrc,string shortName,string idNumber,string fullName,string category,string domain) {
            DataTable dtRegCourse = new DataTable();
           
            try
            {
                object[] vparams = new object[] { accion, category, nrc, fullName, idCourse, idNumber, observacion.Trim(), shortName, term, verifica.Trim(), domain};
                dtRegCourse = transac.sp_EjecParams("P_INSRESPCOURSE", "SZKDMRB", "BANINST1", "0", vparams);
                return dtRegCourse;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message);
                return dtRegCourse;
            }
        }
        public DataTable RegistroUserConduit(string observacion, string verifica, string accion, decimal idUser, decimal pidm, string type, string userName, string auth, string email, string lastName, string firstName, string university)
        {
            DataTable dtRegUser = new DataTable();

            try
            {
                object[] vparams = new object[] { accion, auth, email, firstName, idUser, lastName, observacion, pidm, type, userName, verifica, university };
                dtRegUser = transac.sp_EjecParams("P_INSRESPUSER", "SZKDMRB", "BANINST1", "0", vparams);
                return dtRegUser;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());
           
                return dtRegUser;
            }
        }
        public DataTable RegistroRoleConduit(string observacion, string verifica, string accion, decimal idRole, decimal pidm, string term, string nrc, string enrollCourse, string userName, string role, string status, string university)
        {
            DataTable dtRegRole = new DataTable();            
            try
            {
                object[] vparams = new object[] { accion, enrollCourse, idRole, nrc, observacion, pidm, role, status, term, userName, verifica, university };
                dtRegRole = transac.sp_EjecParams("P_INSRESPROLE", "SZKDMRB", "BANINST1", "0", vparams);
                return dtRegRole;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtRegRole;
            }
        }
        public DataTable RegistroRoleDisableConduit(string observacion, decimal pidm, string term, string nrc, string enrollCourse, string userName, string role, string status) {
            DataTable dtRegRoleDis = new DataTable();
            try
            {
                object[] vparams = new object[] { enrollCourse, nrc, observacion, pidm, role, status, term, userName };
                dtRegRoleDis = transac.sp_EjecParams("P_INSRESPROLEDES", "SZKDMRB", "BANINST1", "0", vparams);
                return dtRegRoleDis;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtRegRoleDis;
            }
        }
        #endregion
        #region Obtencion de datos en bloque
        public DataTable bloqueCursos() {
            DataTable dtCursos = new DataTable();
            
            DataTable dtRegRoleDis = new DataTable();
            try
            {
                dtCursos = transac.sp_Ejec("P_COURSESBLOCK", "SZKDMRB", "BANINST1", "0");
                return dtCursos;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtCursos;
            }
        }
        public DataTable bloqueUsuarios()
        {
            DataTable dtUsuarios = new DataTable();
            
            try
            {
                dtUsuarios = transac.sp_Ejec("P_USERSBLOCK", "SZKDMRB", "BANINST1", "0");
                return dtUsuarios;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtUsuarios;
            }
        }
        public DataTable bloqueMatriculaciones()
        {
            DataTable dtMatriculaciones = new DataTable();
            
            try
            {
                dtMatriculaciones = transac.sp_Ejec("P_ENROLLSBLOCK", "SZKDMRB", "BANINST1", "0");
                return dtMatriculaciones;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtMatriculaciones;
            }
        }
        #endregion
        #region Obtencion de datos individuales directo 
        public DataTable buscarRoles(string busqueda,string university) {
            DataTable dtbusca = new DataTable();
            
            try
            {
                object[] vparams = new object[] { busqueda, university };
                dtbusca = transac.sp_EjecParams("P_BUSQUEDAROLES", "SZKDMRB", "BANINST1", "0", vparams);
                return dtbusca;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtbusca;
            }
        }
        public DataTable buscarCurso(string curso)
        {
            DataTable dtbusca = new DataTable();
            
            try
            {
                object[] vparams = new object[] { curso };
                dtbusca = transac.sp_EjecParams("P_BUSQUEDACURSOS", "SZKDMRB", "BANINST1", "0", vparams);
                return dtbusca;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtbusca;
            }
        }
        public DataTable buscarUsuario(string usuario)
        {
            DataTable dtbusca = new DataTable();
            
            try
            {
                object[] vparams = new object[] { usuario };
                dtbusca = transac.sp_EjecParams("P_BUSQUEDAUSUARIOS", "SZKDMRB", "BANINST1", "0", vparams);
                return dtbusca;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtbusca;
            }
        }
        #endregion
        #region Obtencion de datos individuales directo desde cambios ttablas de trabajo  
        public DataTable modifUsuario(string username) {
            DataTable dtU = new DataTable();
            
            try
            {
                object[] vparams = new object[] { username };
                dtU = transac.sp_EjecParams("P_USUARIOSCONDUIT", "SZKDMRB", "BANINST1", "0", vparams);
                return dtU;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtU;
            }
        }
        public DataTable modifCurso(string shortname)
        {
            DataTable dtC = new DataTable();
            
            try
            {
                object[] vparams = new object[] { shortname };
                dtC = transac.sp_EjecParams("P_CURSOCONDUIT", "SZKDMRB", "BANINST1", "0", vparams);
                return dtC;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtC;
            }
        }
        public DataTable modifRol(string shortname,string username)
        {
            DataTable dtR = new DataTable();
           
            try
            {
                object[] vparams = new object[] { shortname, username };
                dtR = transac.sp_EjecParams("P_ROLESCONDUIT", "SZKDMRB", "BANINST1", "0", vparams);
                return dtR;
            }
            catch (Exception e)
            {
                logger.Error("Message: " + e.Message.ToString());

                return dtR;
            }
        }
        #endregion
    }
}
