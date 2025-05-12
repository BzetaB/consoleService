using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using layer_data;
using System.Data;

namespace layer_bussiness
{
    public class clsDatosConduit
    {
        clsConduitMoodle tranData = new clsConduitMoodle();
        #region  Obtencion de datos de usuarios, cursos y roles para enviar a conduit       
        public DataTable ListaUsuarios(string university) {
            DataTable dtUs = new DataTable();
            dtUs = tranData.ListaUsersConduit(university);
            return dtUs;
        }
        public DataTable ListaCursos(string university) {
            DataTable dtCu = new DataTable();
            dtCu = tranData.ListaCoursesConduit(university);
            return dtCu;
        }
        public DataTable ListaRoles(string university) {
            DataTable dtRl = new DataTable();
            dtRl = tranData.ListaRolesConduit(university);
            return dtRl;
        }
        public DataTable ListaRolesDesactivados() {
            DataTable dtRlDes = new DataTable();
            dtRlDes = tranData.ListaRolesDesactivadosConduit();
            return dtRlDes;
        }
        #endregion
        #region Obtencion de registros anteriores usuarios, roles, cursos
        public DataTable UsuarioAnterior(decimal pidm,string type,string university) {
            DataTable dtUAnt = new DataTable();
            dtUAnt = tranData.UsuarioAnterior(pidm, type, university);
            return dtUAnt;
        }
        public DataTable CursoAnterior(string term,string nrc,string university){
            DataTable dtCAnt = new DataTable();
            dtCAnt = tranData.CursoAnterior(term,nrc,university);
            return dtCAnt;
        }
        public DataTable RolAnterior(decimal pidm,string term,string nrc,string university) {
            DataTable dtRAnt = new DataTable();
            dtRAnt = tranData.RolAnterior(pidm,term,nrc,university);
            return dtRAnt;
        }        
        #endregion
        #region Registro de estados de registro de roles, cursos y usuarios en conduit  
        public DataTable RegistrarResultadoCurso(string observacion, string verifica, string accion, decimal idCourse, string term, string nrc, string shortName, string idNumber, string fullName, string category, string university) {
            DataTable dtRC = new DataTable();
            dtRC = tranData.RegistroCourseConduit(observacion,verifica, accion, idCourse, term, nrc, shortName, idNumber, fullName, category, university);
            return dtRC;
        }
        public DataTable RegistrarResultadoUsuario(string observacion, string verifica, string accion, decimal idUser, decimal pidm, string type, string userName, string auth, string email, string lastName, string fisrtName, string university)
        {
            DataTable dtRU = new DataTable();
            dtRU = tranData.RegistroUserConduit(observacion, verifica, accion, idUser, pidm, type, userName, auth, email, lastName, fisrtName, university);
            return dtRU;
        }
        public DataTable RegistrarResultadoRol(string observacion, string verifica, string accion, decimal idRole, decimal pidm, string term, string nrc, string enrollCourse, string userName, string role, string status, string university)
        {
            DataTable dtRR = new DataTable();
            dtRR = tranData.RegistroRoleConduit(observacion, verifica, accion, idRole, pidm, term, nrc, enrollCourse, userName, role, status, university);
            return dtRR;
        }
        public DataTable RegistrarResultadoRolDes(string observacion, decimal pidm, string term, string nrc, string enrollCourse, string userName, string role, string status) {
            DataTable dtRRD = new DataTable();
            dtRRD = tranData.RegistroRoleDisableConduit( observacion,  pidm,  term,  nrc,  enrollCourse,  userName,  role,  status);
            return dtRRD;
        }
        #endregion
        #region Obtencion de datos en bloque
        public DataTable ListaCursosBloque()
        {
            DataTable dtltcursos = new DataTable();
            dtltcursos = tranData.bloqueCursos();
            return dtltcursos;
        }
        public DataTable ListaUsuariosBloque()
        {
            DataTable dtltusuarios = new DataTable();
            dtltusuarios = tranData.bloqueUsuarios();
            return dtltusuarios;
        }
        public DataTable ListaMatriculacionesBloque()
        {
            DataTable dtltmatric = new DataTable();
            dtltmatric = tranData.bloqueMatriculaciones();
            return dtltmatric;
        }
        #endregion
        #region Obtencion de datos individuales directo
        public DataTable rolesBuscados(string busqueda, string university)
        {
            DataTable dtBusca = new DataTable();
            dtBusca = tranData.buscarRoles(busqueda,university);
            return dtBusca;
        }
        public DataTable cursoBuscado(string curso)
        {
            DataTable dtBusca = new DataTable();
            dtBusca = tranData.buscarCurso(curso);
            return dtBusca;
        }
        public DataTable usuarioBuscado(string usuario)
        {
            DataTable dtBusca = new DataTable();
            dtBusca = tranData.buscarUsuario(usuario);
            return dtBusca;
        }
        #endregion
        #region Obtencion de datos individuales directo desde cambios ttablas de trabajo
        public DataTable usuarioModificado(string username) {
            DataTable dtu = new DataTable();
            dtu = tranData.modifUsuario(username);
            return dtu;
        }
        public DataTable cursoModificado(string shortname)
        {
            DataTable dtc = new DataTable();
            dtc = tranData.modifCurso(shortname);
            return dtc;
        }
        public DataTable rolModificado(string shortname,string username)
        {
            DataTable dtr = new DataTable();
            dtr = tranData.modifRol(shortname,username);
            return dtr;
        }
        #endregion
    }
}

