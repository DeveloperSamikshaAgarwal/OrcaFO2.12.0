using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TradeStationToHedgeFund
{
    class DBContext
    {
        private static SqlConnection sqlCon = null;
        public static DataSet FillUpDataSetFromSp(string ConnectionString, string storedProc, int ConnectionTimeOut = 5000, List<SqlParameter> addParams = null)
        {
            var ds = new DataSet();
            string strTableNames = "";
            using (sqlCon = new SqlConnection(ConnectionString))
            {
                var da = new SqlDataAdapter(storedProc, sqlCon)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = ConnectionTimeOut
                    }
                };
                if (addParams != null)
                {
                    foreach (var p in addParams)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }

                var param = new SqlParameter("@tablename", SqlDbType.VarChar, 8000)
                {
                    Direction = ParameterDirection.Output
                };
                da.SelectCommand.Parameters.Add(param);
                da.Fill(ds);
                strTableNames = da.SelectCommand.Parameters["@tablename"].Value.ToString();
                sqlCon.Close();
            }

            var tableNames = strTableNames.Split(',');

            for (var i = 0; i < tableNames.Length; i++)
            {
                var name = tableNames[i].Trim().Replace(" ", "");
                ds.Tables[i].TableName = name;
            }
            return ds;

        }
        public static void ExecuteSp(string ConnectionString,string spName, List<SqlParameter> spParams)
        {
          
            try
            {
                using (sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand(spName, sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    if (spParams != null)
                    {
                        foreach (var spParam in spParams)
                        {
                            sql_cmnd.Parameters.Add(spParam);
                        }
                    }


                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }
        }
        public static DataSet GetDataSetFromQuery(string ConnectionString,string query)
        {
            using (sqlCon = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    sqlCon.Open();
                    string sqlquery = query;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlquery, sqlCon);
                    dataAdapter.Fill(ds);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    sqlCon.Close();
                }
                return ds;
            }
        }
        public static void ExecuteSPByPassingDataTable(string SqlconString, string spName, Dictionary<string, DataTable> spArgs, List<SqlParameter> sqlParameters = null)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(spName, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var parameters = new List<SqlParameter>();

                    foreach (KeyValuePair<string, DataTable> arg in spArgs)
                    {
                        SqlParameter sqlParam = cmd.Parameters.AddWithValue(arg.Key, arg.Value);
                        sqlParam.SqlDbType = SqlDbType.Structured;
                    }
                    if (sqlParameters != null)
                    {
                        foreach (SqlParameter sqlParameter in sqlParameters)
                        {
                            cmd.Parameters.Add(sqlParameter);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }
        public static object ExecuteScalerFunction(string SqlconString,string functionQuery, List<SqlParameter> sqlParameters = null)
        {
            try
            {
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(functionQuery, sqlCon);
                    command.CommandType = CommandType.Text;

                    if (sqlParameters != null)
                    {
                        foreach (var sqlParameter in sqlParameters)
                            command.Parameters.Add(sqlParameter);
                    }
                    object result = command.ExecuteScalar();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
