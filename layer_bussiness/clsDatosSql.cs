using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using layer_data;
using System.Data;

namespace layer_bussiness
{
    public class clsDatosSql
    {
        clsSQLConduit tr = new clsSQLConduit();
        public DataTable totalsuarios() {
            DataTable dt = new DataTable();
            dt = tr.UsersTotalBAnner();
            return dt;
        }
        public int insertaRol(string ENROLLCOURSE, string USERNAME, string ROLE, string STATUS) {
            int rsp;
            rsp = tr.InsertRol(ENROLLCOURSE,USERNAME,ROLE,STATUS);
            return rsp;
        }
    }
}
