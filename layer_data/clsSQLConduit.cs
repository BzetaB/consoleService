using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace layer_data
{
    public class clsSQLConduit
    {
        dsBDUCCI.sp_ConduitUsuariosDataTable dtUsers = new dsBDUCCI.sp_ConduitUsuariosDataTable();
        dsBDUCCITableAdapters.sp_ConduitUsuariosTableAdapter taUsers= new dsBDUCCITableAdapters.sp_ConduitUsuariosTableAdapter();
        dsBDUCCITableAdapters.QueriesTableAdapter tranRol = new dsBDUCCITableAdapters.QueriesTableAdapter();
        public DataTable UsersTotalBAnner() {
            dtUsers = taUsers.GetData();
            return dtUsers;
        }
        public int InsertRol(string ENROLLCOURSE, string USERNAME, string ROLE, string STATUS) {
            int rsp;
            rsp = tranRol.sp_InsertRolesConduit(ENROLLCOURSE,USERNAME,ROLE,STATUS);
            return rsp;
        } 

    }
}
