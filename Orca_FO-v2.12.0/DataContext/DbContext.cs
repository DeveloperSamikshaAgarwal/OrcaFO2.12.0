using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca_FO_v2._12._0.DataContext
{
    public class DbContext
    {
        private static SqlConnection sqlCon = null;
        private static String SqlconString = ConfigurationManager.ConnectionStrings["OrcaData"].ConnectionString;
        

        public static void ExecuteSp(string spName, List<SqlParameter> spParams)
        {
            try
            {
                using (sqlCon = new SqlConnection(SqlconString))
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

        public static DataSet FillUpDataSetFromSP(string spName, List<SqlParameter> spParams = null)
        {
            var ds = new DataSet();
            string strTableNames = "";
            using (var connection = new SqlConnection(SqlconString))
            {
                var da = new SqlDataAdapter(spName, connection)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 600
                    }
                };
                if (spParams != null)
                {
                    foreach (var spParam in spParams)
                    {
                        da.SelectCommand.Parameters.Add(spParam);
                    }
                }
                var param = new SqlParameter("@tablename", SqlDbType.VarChar, 8000)
                {
                    Direction = ParameterDirection.Output
                };
                da.SelectCommand.Parameters.Add(param);
                da.Fill(ds);
                strTableNames = da.SelectCommand.Parameters["@tablename"].Value.ToString();
                connection.Close();
            }
            var tableNames = strTableNames.Split(',');
            for (var i = 0; i < tableNames.Length; i++)
            {
                var name = tableNames[i].Trim().Replace(" ", "");
                ds.Tables[i].TableName = name;
            }
            return ds;
        }

        public static object ExecuteScalerFunction(string functionQuery, List<SqlParameter> sqlParameters = null)
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

        public static DataSet GetDataSetFromQuery(string query)
        {
            using (sqlCon = new SqlConnection(SqlconString))
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
        public static void ExecuteSPWithTableName(DataTable dataTable, string spName)
        {
            using (var conn = new SqlConnection(SqlconString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var parameters = new List<SqlParameter>();
                    SqlParameter sqlParam = cmd.Parameters.AddWithValue("@TempTable", dataTable);
                    sqlParam.SqlDbType = SqlDbType.Structured;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void ExecuteSPByPassingDataTable(string spName, Dictionary<string, DataTable> spArgs, List<SqlParameter> sqlParameters = null)
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
    }
}

