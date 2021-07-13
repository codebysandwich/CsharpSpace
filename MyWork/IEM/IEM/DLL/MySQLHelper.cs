using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace DLL
{
    public class MySQLHelper
    {
        #region test
        //static MySqlConnection conn;
        ////static string connString = "Database = 'fjemcmanage'; Data Source = 'localhost'; User Id = 'root'; Password = ''; charset = 'utf-8'; pooling = true";
        //static public void ConnectSql(string connString)
        //{
        //    conn = new MySqlConnection(connString);
        //}
        //static public int NonQuery(string sql)
        //{
        //    MySqlCommand cmd = new MySqlCommand(sql);
        //    conn.Open();
        //    int result =  cmd.ExecuteNonQuery();
        //    conn.Close();
        //    return result;
        //}
        //static public void CloseConnect()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        //static public MySqlDataReader ExcuteReader(string sql, params MySqlParameter[] cmdParams)
        //{

        //}
        #endregion
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        #region 封装格式化sql语句执行的各种方法
        public static int Update(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static int Update(string sql)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 单一查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static object GetSingleResult(string sql)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static MySqlDataReader GetReader(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorInfo = "调用public static MySqlDataReader GetReader(string sql)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
        }
        public static DataSet GetDateSet(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd); //创建数据适配器对象
            DataSet ds = new DataSet(); //创建内存数据集
            try
            {
                conn.Open();
                da.Fill(ds);    //使用适配器填充数据集
                return ds;
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static DataSet GetDateSet(string sql)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region 封装带参数的sql语句，执行的各种方法
        public static int Update(string sql, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);     //注入待封装的参数
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static int Update(string sql, MySqlParameter[] param)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 单一查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static object GetSingleResult(string sql, MySqlParameter[] param)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static MySqlDataReader GetReader(string sql, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorInfo = "调用public static MySqlDataReader GetReader(string sql, MySqlParameter[] param)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
        }
        /// <summary>
        /// 启用事务提交多条带参数的sql语句
        /// </summary>
        /// <param name="mainSql">主表的sql语句</param>
        /// <param name="mainParam">主表Sql对应的参数</param>
        /// <param name="detailSql">明细表sql语句</param>
        /// <param name="detailParam">明细表sql语句参数的集合（说明明细表的输入不至一个）</param>
        /// <returns></returns>
        public static bool UpdateByTran(string mainSql, MySqlParameter[] mainParam, string detailSql, List<MySqlParameter[]> detailParam)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();      //开启事物
                if (mainSql != null && mainSql.Length != 0)
                {
                    cmd.CommandText = mainSql;
                    cmd.Parameters.AddRange(mainParam);
                    cmd.ExecuteNonQuery();
                }
                foreach (MySqlParameter[] param in detailParam)
                {
                    cmd.CommandText = detailSql;
                    cmd.Parameters.Clear();     //清除之前的参数
                    cmd.Parameters.AddRange(param);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();     //回滚事务
                }
                string errorInfo = "调用public static bool UpdateByTran(string mainSql, MySqlParameter[] mainParam, string detailSql, List<MySqlParameter[]> detailParam)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;     //清空事务
                }
                conn.Close(); 
            }
        }
        /// <summary>
        /// 启用事务调用带参数的存储过程
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="paramArray"></param>
        /// <returns></returns>
        public static bool UpdateByTran(string procedureName, List<MySqlParameter[]> paramArray)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;      //声明存储过程
                cmd.CommandText = procedureName;
                cmd.Transaction = conn.BeginTransaction();      //开启事物
                foreach (MySqlParameter[] param in paramArray)
                {
                    cmd.Parameters.Clear();     //清除之前的参数
                    cmd.Parameters.AddRange(param);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();     //回滚事务
                }
                string errorInfo = "调用public static bool UpdateByTran(string mainSql, MySqlParameter[] mainParam, string detailSql, List<MySqlParameter[]> detailParam)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;     //清空事务
                }
                conn.Close();
            }
        }
        #endregion
        #region 封装调用存储过程的操作
        public static int UpdateByProcedure(string spName, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;  //声明存储过程
                cmd.Parameters.AddRange(param);     //注入待封装的参数
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static int Update(string sql, MySqlParameter[] param)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 单一查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResultByProcedure(string spName, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static object GetSingleResultByProcedure(string spName, MySqlParameter[] param)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static MySqlDataReader GetReaderByProcedure(string spName, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorInfo = "调用public static MySqlDataReader GetReaderByProcedure(string spName, MySqlParameter[] param)时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
        }
        #endregion
        #region 其他方法
        private static void WriteLog(string log)
        {
            FileStream fs = new FileStream("sqlhelper.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + " " + log);
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
