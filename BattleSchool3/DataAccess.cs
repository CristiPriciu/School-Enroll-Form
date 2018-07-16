using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BattleSchool3
{
    public static class DataAccess
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            }
        }

        public static void RunSP(string spName, List<SqlDbParameter> inPars, ref DataTable destTable)
        {
            SqlDataAdapter DBAdapter = null;
            SqlConnection DBConn = new System.Data.SqlClient.SqlConnection(ConnectionString);
            DBConn.Open();

            try
            {
                var DBComm = DBConn.CreateCommand();
                DBComm.CommandType = CommandType.StoredProcedure;
                DBComm.CommandText = spName;
                DBAdapter = new SqlDataAdapter(DBComm);

                if (inPars.Count > 0)
                {
                    foreach (var sqlDbParameter in inPars)
                    {
                        DBAdapter.SelectCommand.Parameters.AddWithValue("@" + sqlDbParameter.ParName, sqlDbParameter.ParValue);
                    }
                }

                var ds = new DataSet();
                DBAdapter.Fill(ds);
                DBAdapter.Dispose();
                DBComm.Dispose();

                destTable = ds.Tables[0];
            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (DBAdapter != null)
                    DBAdapter.Dispose();

                DBConn.Close();
            }
        }
    }
}
