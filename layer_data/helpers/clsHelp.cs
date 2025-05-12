using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace layer_data
{
    public class clsHelp
    {
        #region procedimiento que llama otros procedures desde oracle   
             
        public DataTable sp_Ejec(string nomSP,string nomPackage, string nomOwner,string TipoTransac) {            
            OracleConnection cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["oraCon"].ConnectionString);
            OracleCommand cmdOra = new OracleCommand();
            DataTable dtOra= new DataTable();
            cmdOra.Connection = cnx;
            cmdOra.CommandType = CommandType.StoredProcedure;
            cmdOra.CommandText = nomOwner+"."+nomPackage + "."+nomSP;

            List<clsParametros> paramt = ListarParametros(nomPackage, nomSP);

            foreach (clsParametros lt in paramt){
                OracleDbType tipoVS= new OracleDbType(); 
                ParameterDirection tipo= new ParameterDirection();
                switch(lt.tipoDato)
                {
                    case "DATE":
                        tipoVS = OracleDbType.Date;
                        break;
                    case "VARCHAR2":
                        tipoVS = OracleDbType.Varchar2;
                        break;
                    case "NUMBER":
                        tipoVS = OracleDbType.Decimal;
                        break;
                    case "REF CURSOR":
                        tipoVS = OracleDbType.RefCursor;
                        break;
                    case "LONG":
                        tipoVS = OracleDbType.Int64;
                        break;
                }

                switch(lt.tipoInOut) {
                    case "IN":
                        tipo = ParameterDirection.Input;
                        break;
                    case "OUT":
                        tipo = ParameterDirection.Output;
                        break;
                }              

                cmdOra.Parameters.Add(lt.name.ToString(), tipoVS, tipo);
            }

            cnx.Open();
            if (TipoTransac == "1") {
                //tipo no query 
                int res;
                res = cmdOra.ExecuteNonQuery();
                dtOra.Columns.Add("resp");
                dtOra.Rows.Add(res);
            }
            else {
                //tipo query
                OracleDataReader drOra;
                drOra = cmdOra.ExecuteReader();
                dtOra.Load(drOra);                
            }
            cnx.Close();
            return dtOra;          
        }
        public DataTable sp_EjecParams(string nomSP, string nomPackage, string nomOwner ,string TipoTransac,object[] valParams)
        {
            OracleConnection cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["oraCon"].ConnectionString);
            OracleCommand cmdOra = new OracleCommand();
            DataTable dtOra = new DataTable();
            cmdOra.Connection = cnx;
            cmdOra.CommandType = CommandType.StoredProcedure;
            cmdOra.CommandText = nomOwner+"."+nomPackage + "." + nomSP;
            int i=0; 

            List<clsParametros> paramt = ListarParametros(nomPackage, nomSP);

            foreach (clsParametros lt in paramt)
            {
                OracleDbType tipoVS = new OracleDbType();
                ParameterDirection tipo = new ParameterDirection();
                switch (lt.tipoDato)
                {
                    case "DATE":
                        tipoVS = OracleDbType.Date;
                        break;
                    case "VARCHAR2":
                        tipoVS = OracleDbType.Varchar2;
                        break;
                    case "NUMBER":
                        tipoVS = OracleDbType.Decimal;
                        break;
                    case "REF CURSOR":
                        tipoVS = OracleDbType.RefCursor;
                        break;
                    case "LONG":
                        tipoVS = OracleDbType.Int64;
                        break;
                }

                switch (lt.tipoInOut)
                {
                    case "IN":
                        tipo = ParameterDirection.Input;
                        cmdOra.Parameters.Add(lt.name.ToString(), tipoVS, valParams[i], tipo);
                        i = i + 1;
                        break;
                    case "OUT":
                        tipo = ParameterDirection.Output;
                        cmdOra.Parameters.Add(lt.name.ToString(), tipoVS, tipo);
                        break;
                }             
                
            }


            cnx.Open();
            if (TipoTransac == "1")
            {
                //tipo no query 
                int res;
                res = cmdOra.ExecuteNonQuery();
                dtOra.Columns.Add("resp");
                dtOra.Rows.Add(res);
            }
            else
            {
                //tipo query
                OracleDataReader drOra;
                drOra = cmdOra.ExecuteReader();
                dtOra.Load(drOra);
            }
            cnx.Close();
            return dtOra;
        }
        #endregion
        #region procedimiento que lista parametros de procedimientos desde oracle 
        public List<clsParametros> ListarParametros(string package,string sp) {
            List<clsParametros> listaPar = new List<clsParametros>();
            string queryString = "SELECT ARGUMENT_NAME, DATA_TYPE, IN_OUT FROM SYS.ALL_ARGUMENTS WHERE PACKAGE_NAME = :P_PACKAGE AND OBJECT_NAME = :P_NAMESP ORDER BY IN_OUT,ARGUMENT_NAME";
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["oraCon"].ConnectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                command.Parameters.Add("P_PACKAGE",OracleDbType.Varchar2,package,ParameterDirection.Input);
                command.Parameters.Add("P_NAMESP", OracleDbType.Varchar2,sp,ParameterDirection.Input);
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();            
                while (reader.Read())
                {
                    clsParametros param = new clsParametros();
                    param.name = reader["ARGUMENT_NAME"].ToString();
                    param.tipoDato = reader["DATA_TYPE"].ToString();
                    param.tipoInOut = reader["IN_OUT"].ToString();
                    listaPar.Add(param);
                }                     
                reader.Close();
                return listaPar;                
            }           
        }
        #endregion
    }
}
