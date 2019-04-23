using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MohuFramework.Entity;
using System.Reflection;

namespace MohuFramework.DataAccess
{
    public class SqlDataAccessor : IDataAccessor
    {
        public SqlDataAccessor() { }
        public SqlDataAccessor(string connStr)
        {
            this.ConnStr = connStr;
            this.ConnFrom = DataAccessorFactory.ConnStringFrom.String;
        }

        private DataAccessorFactory.ConnStringFrom _ConnFrom = DataAccessorFactory.ConnStringFrom.File;//�ַ���������Դ
        private string _ConnStr;//�ַ�������
        private bool _IsPwdEncript = false;

        public bool IsPwdEncript
        {
            get { return _IsPwdEncript; }
            set { _IsPwdEncript = value; }
        }

        public string ConnStr
        {
            get { return _ConnStr; }
            set { _ConnStr = value; }
        }

        public DataAccessorFactory.ConnStringFrom ConnFrom
        {
            get { return _ConnFrom; }
            set { _ConnFrom = value; }
        }

        //��ȡsql����
        private SqlConnection GetSqlConnection()
        {
            string strConn = string.Empty;
            if (this.ConnFrom == DataAccessorFactory.ConnStringFrom.File)
            {
                strConn = MohuFramework.Common.ConfigSettings.GetConnectionString();
            }
            else
            {
                strConn = this.ConnStr;
            }

            //�����Ǽ��ܵģ���Ҫ����
            if (this.IsPwdEncript)
            {
                if (strConn.IndexOf("pwd=") != -1)
                {
                    string pwd = strConn.Substring(strConn.IndexOf("pwd=") + 4);
                    strConn = strConn.Substring(0, strConn.IndexOf("pwd=")) + "pwd=" + Common.Utils.Decode(pwd);
                }
            }

            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        /// <summary>
        /// ��ȡ���ݿ�����
        /// </summary>
        /// <returns></returns>
        public object GetPublicConnection()
        {
            string strConn = string.Empty;
            if (this.ConnFrom == DataAccessorFactory.ConnStringFrom.File)
            {
                strConn = MohuFramework.Common.ConfigSettings.GetConnectionString();
            }
            else
            {
                strConn = this.ConnStr;
            }

            //�����Ǽ��ܵģ���Ҫ����
            if (this.IsPwdEncript)
            {
                if (strConn.IndexOf("pwd=") != -1)
                {
                    string pwd = strConn.Substring(strConn.IndexOf("pwd=") + 4);
                    strConn = strConn.Substring(0, strConn.IndexOf("pwd=")) + "pwd=" + Common.Utils.Decode(pwd);
                }
            }

            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        //ִ�ж�sql server���ݿ�ı�¼�������ɹ�����true��ʧ��Ϊfalse
        public bool ExecuteNonQuery(string sql)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public DataTable Query(string sql)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public DataSet QueryDataSet(string sql)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public DataTable Query(string sql, params object[] paras)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter sp in paras)
                {
                    cmd.Parameters.Add(sp);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public DataSet QueryDataSet(string sql, params object[] paras)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter sp in paras)
                {
                    cmd.Parameters.Add(sp);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// ���ص�һ�е�һ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// ���ص�һ�е�һ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params object[] paras)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter sp in paras)
                {
                    cmd.Parameters.Add(sp);
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool InsertEntity(IEntity entity)
        {
            SqlConnection conn = null;
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();

                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //����sql���
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into [" + type.Name + "](");
                sqlValue.Append(" values(");
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (info.Name == keyName ||
                        value == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("@" + info.Name + ",");
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@" + info.Name;
                    p.Value = value;
                    cmd.Parameters.Add(p);
                }
                string sqlGetId = "select max(" + keyName + ") from " + type.Name;
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ");" + sqlGetId;
                cmd.CommandText = cmdText;

                //������
                PropertyInfo keyNameInfo = null;
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        keyNameInfo = info;
                        break;
                    }
                }

                object id = cmd.ExecuteScalar();
                keyNameInfo.SetValue(entity, id, null);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// ��������ʱ������������Ҳ����������ֵ
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertEntityNotSetPK(IEntity entity)
        {
            SqlConnection conn = null;
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();

                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //����sql���
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into [" + type.Name + "](");
                sqlValue.Append(" values(");
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (value == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("@" + info.Name + ",");
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@" + info.Name;
                    p.Value = value;
                    cmd.Parameters.Add(p);
                }
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ");";
                cmd.CommandText = cmdText;
                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// �˷���Ϊ���ⲿ�������ݿ����ӣ������ⲿ�������ݿ�Ĵ򿪺͹ر�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connObject"></param>
        /// <returns></returns>
        public bool InsertEntity(IEntity entity, object connObject)
        {
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();

                SqlConnection conn = connObject as SqlConnection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //����sql���
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into [" + type.Name + "](");
                sqlValue.Append(" values(");
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (info.Name == keyName ||
                        value == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("@" + info.Name + ",");
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@" + info.Name;
                    p.Value = value;
                    cmd.Parameters.Add(p);
                }
                string sqlGetId = "select max(" + keyName + ") from " + type.Name;
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ");" + sqlGetId;
                cmd.CommandText = cmdText;

                //������
                PropertyInfo keyNameInfo = null;
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        keyNameInfo = info;
                        break;
                    }
                }

                object id = cmd.ExecuteScalar();
                keyNameInfo.SetValue(entity, id, null);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //��ȡ����
        private string GetKeyName(string tableName)
        {
            string keyName = "";
            SqlConnection conn = GetSqlConnection();
            conn.Open();
            SqlCommand cmdGetKeyName = new SqlCommand("sp_pkeys", conn);
            cmdGetKeyName.CommandType = CommandType.StoredProcedure;
            SqlParameter pKey = new SqlParameter();
            pKey.ParameterName = "@table_name";
            pKey.Value = tableName;
            cmdGetKeyName.Parameters.Add(pKey);
            SqlDataReader reader = cmdGetKeyName.ExecuteReader();
            if (reader.Read())
            {
                keyName = reader.GetString(3);
            }
            reader.Close();
            conn.Close();
            return keyName;
        }

        public IEntity GetEntity(IEntity entity)//ֻ�ܸ���������ѯ
        {
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                string sql = "select top 1 * from [" + type.Name + "] where ";
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        sql += info.Name + "='" + info.GetValue(entity, null) + "'";
                        break;
                    }
                }
                DataTable dt = Query(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < list.Length; j++)
                    {
                        string columnName = list[j].Name;
                        if (columnName == keyName ||
                            dt.Rows[0][columnName] is DBNull)
                        {
                            continue;
                        }
                        object value = dt.Rows[0][columnName];
                        list[j].SetValue(entity, value, null);
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetEntity<T>(T entity) where T : new()//ֻ�ܸ���������ѯ
        {
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                string sql = "select top 1 * from [" + type.Name + "] where ";
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        sql += info.Name + "='" + info.GetValue(entity, null) + "'";
                        break;
                    }
                }
                DataTable dt = Query(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < list.Length; j++)
                    {
                        string columnName = list[j].Name;
                        if (columnName == keyName ||
                            dt.Rows[0][columnName] is DBNull)
                        {
                            continue;
                        }
                        object value = dt.Rows[0][columnName];
                        list[j].SetValue(entity, value, null);
                    }
                    return entity;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // һ�����ݿ���������ĳЩ��֮�����ж���ѯ
        private string GetTableColNameExceptSome(string tableName, params string[] listExcept)
        {
            string result = string.Empty;
            string sql = "select column_name from information_schema.columns where table_name='" + tableName + "'";
            DataTable dt = this.Query(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string col = Convert.ToString(dt.Rows[i]["column_name"]);
                bool isExist = false;
                for (int j = 0; j < listExcept.Length; j++)
                {
                    if (col.Equals(listExcept[j]))
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    result += tableName + "." + col + ",";
                }
            }
            return result.TrimEnd(',');
        }

        public bool UpdateEntity(IEntity entity)//����ָ��ID
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //����sql���
                StringBuilder sql = new StringBuilder();
                sql.Append("update " + type.Name + " set ");
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (info.Name == keyName ||
                        value == null)
                    {
                        continue;
                    }
                    sql.Append(info.Name + "=@" + info.Name + ",");
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@" + info.Name;
                    p.Value = value;
                    cmd.Parameters.Add(p);
                }
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' });
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        cmdText += " where " + info.Name + "='" + info.GetValue(entity, null) + "'";
                        break;
                    }
                }
                cmd.CommandText = cmdText;

                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// ��ѯʵ���ࣨɸѡĳЩ�ֶΣ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T GetEntityExceptSomeCol<T>(T entity, params string[] cols) where T : new()//ֻ�ܸ���������ѯ
        {
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                string sql = "select top 1 " + this.GetTableColNameExceptSome(type.Name, cols) + " from [" + type.Name + "] where ";
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        sql += info.Name + "='" + info.GetValue(entity, null) + "'";
                        break;
                    }
                }
                DataTable dt = Query(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < list.Length; j++)
                    {
                        string columnName = list[j].Name;

                        bool isExist = false;
                        foreach (string col in cols)
                        {
                            if (col.Equals(columnName))
                            {
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist)
                        {
                            continue;
                        }

                        if (columnName == keyName ||
                            dt.Rows[0][columnName] is DBNull)
                        {
                            continue;
                        }
                        object value = dt.Rows[0][columnName];
                        list[j].SetValue(entity, value, null);
                    }
                    return entity;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteEntity(IEntity entity)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                conn = GetSqlConnection();
                conn.Open();
                tran = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                string sql = "delete from [" + type.Name + "] where ";
                string keyName = this.GetKeyName(type.Name);
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        sql += info.Name + "='" + info.GetValue(entity, null) + "'";
                        break;
                    }
                }
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public bool ExecuteStoreProc(string procName, params object[] paras)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sp in paras)
                {
                    cmd.Parameters.Add(sp);
                }
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// ��ȡʵ���б�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="listCon"></param>
        /// <returns></returns>
        public List<T> GetList<T>(T entity, string sql) where T : new()
        {
            Type type = entity.GetType();
            PropertyInfo[] list = type.GetProperties();
            string keyName = this.GetKeyName(type.Name);
            StringBuilder sb = new StringBuilder();
            DataTable dt = Query(sql);
            List<T> arr = new List<T>(4);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    entity = new T();
                    for (int j = 0; j < list.Length; j++)
                    {
                        string columnName = list[j].Name;
                        if (dt.Rows[i][columnName] is DBNull)
                        {
                            continue;
                        }
                        object value = dt.Rows[i][columnName];
                        list[j].SetValue(entity, value, null);
                    }
                    arr.Add(entity);
                }
            }
            return arr;
        }

        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertEntityList(List<IEntity> listEntity)
        {
            bool result = false;
            SqlConnection conn = null;
            SqlTransaction tran = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
                string keyName = string.Empty;

                StringBuilder sbAllSql = new StringBuilder();
                for (int i = 0; i < listEntity.Count; i++)
                {
                    IEntity entity = listEntity[i];
                    Type type = entity.GetType();
                    PropertyInfo[] list = type.GetProperties();

                    //����sql���
                    StringBuilder sql = new StringBuilder();
                    StringBuilder sqlValue = new StringBuilder();
                    sql.Append("insert into [" + type.Name + "](");
                    sqlValue.Append(" values(");
                    if (string.IsNullOrEmpty(keyName))
                    {
                        keyName = this.GetKeyName(type.Name);
                    }
                    foreach (PropertyInfo info in list)
                    {
                        object value = info.GetValue(entity, null);
                        if (info.Name == keyName ||
                            value == null)
                        {
                            continue;
                        }
                        sql.Append("[" + info.Name + "],");
                        sqlValue.Append("@" + info.Name + "_" + i + ",");
                        SqlParameter p = new SqlParameter();
                        p.ParameterName = "@" + info.Name + "_" + i;
                        p.Value = value;
                        cmd.Parameters.Add(p);
                    }
                    string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                        sqlValue.ToString().TrimEnd(new char[] { ',' }) + ")";
                    sbAllSql.Append(cmdText + ";");
                }
                cmd.CommandText = sbAllSql.ToString();
                cmd.ExecuteNonQuery();
                result = true;
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// �����б�ֱ����sql���������������ã���Ϊ���ݽ϶࣬��������2100�������
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertEntityListSql(List<IEntity> listEntity)
        {
            bool result = false;
            SqlConnection conn = null;
            SqlTransaction tran = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
                string keyName = string.Empty;

                StringBuilder sbAllSql = new StringBuilder();
                for (int i = 0; i < listEntity.Count; i++)
                {
                    IEntity entity = listEntity[i];
                    Type type = entity.GetType();
                    PropertyInfo[] list = type.GetProperties();

                    //����sql���
                    StringBuilder sql = new StringBuilder();
                    StringBuilder sqlValue = new StringBuilder();
                    sql.Append("insert into [" + type.Name + "](");
                    sqlValue.Append(" values(");
                    if (string.IsNullOrEmpty(keyName))
                    {
                        keyName = this.GetKeyName(type.Name);
                    }
                    foreach (PropertyInfo info in list)
                    {
                        object value = info.GetValue(entity, null);
                        if (info.Name == keyName ||
                            value == null)
                        {
                            continue;
                        }
                        sql.Append("[" + info.Name + "],");
                        sqlValue.Append("'" + value + "',");
                    }
                    string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                        sqlValue.ToString().TrimEnd(new char[] { ',' }) + ")";
                    sbAllSql.Append(cmdText + ";");
                }
                cmd.CommandText = sbAllSql.ToString();
                cmd.ExecuteNonQuery();
                result = true;
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// �����б��Զ��ָ�
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertEntityListByBatch(List<IEntity> listEntity)
        {
            bool result = false;
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();

                int batch = 50;//ִ������
                int zhengshu = listEntity.Count / batch;
                int lingtou = listEntity.Count % batch;

                //����ѭ����
                for (int zhengshuxunhuan = 0; zhengshuxunhuan < zhengshu; zhengshuxunhuan++)
                {
                    InsertListLimitSql(listEntity, conn, zhengshuxunhuan * batch, (zhengshuxunhuan + 1) * batch);
                }

                //�����ͷ��ѭ��
                if (lingtou != 0)
                {
                    InsertListLimitSql(listEntity, conn, zhengshu * batch, listEntity.Count);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// �����б��Զ��ָ�
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertEntityListByBatch(List<IEntity> listEntity,int batchSize)
        {
            bool result = false;
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                conn.Open();

                int batch = batchSize;//ִ������
                int zhengshu = listEntity.Count / batch;
                int lingtou = listEntity.Count % batch;

                //����ѭ����
                for (int zhengshuxunhuan = 0; zhengshuxunhuan < zhengshu; zhengshuxunhuan++)
                {
                    InsertListLimitSql(listEntity, conn, zhengshuxunhuan * batch, (zhengshuxunhuan + 1) * batch);
                }

                //�����ͷ��ѭ��
                if (lingtou != 0)
                {
                    InsertListLimitSql(listEntity, conn, zhengshu * batch, listEntity.Count);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }

        private void InsertListLimit(List<IEntity> listEntity, SqlConnection conn, int begin, int end)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string keyName = string.Empty;

            StringBuilder sbAllSql = new StringBuilder();
            for (int i = begin; i < end; i++)
            {
                IEntity entity = listEntity[i];
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();

                //����sql���
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into [" + type.Name + "](");
                sqlValue.Append(" values(");
                if (string.IsNullOrEmpty(keyName))
                {
                    keyName = this.GetKeyName(type.Name);
                }
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (info.Name == keyName ||
                        value == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("@" + info.Name + "_" + i + ",");
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@" + info.Name + "_" + i;
                    p.Value = value;
                    cmd.Parameters.Add(p);
                }
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ")";
                sbAllSql.Append(cmdText + ";");
            }
            cmd.CommandText = sbAllSql.ToString();
            cmd.ExecuteNonQuery();
        }

        private void InsertListLimitSql(List<IEntity> listEntity, SqlConnection conn, int begin, int end)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string keyName = string.Empty;

            StringBuilder sbAllSql = new StringBuilder();
            for (int i = begin; i < end; i++)
            {
                IEntity entity = listEntity[i];
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();

                //����sql���
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into [" + type.Name + "](");
                sqlValue.Append(" values(");
                if (string.IsNullOrEmpty(keyName))
                {
                    keyName = this.GetKeyName(type.Name);
                }
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (info.Name == keyName ||
                        value == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("'" + value +  "',");
                }
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ")";
                sbAllSql.Append(cmdText + ";");
            }
            cmd.CommandText = sbAllSql.ToString();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// �˷���Ϊ���ⲿ�������ݿ����ӣ������ⲿ�������ݿ�Ĵ򿪺͹ر�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connObject"></param>
        /// <returns></returns>
        public string GetInsertEntitySql(IEntity entity)
        {
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();

                //����sql���
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into [" + type.Name + "](");
                sqlValue.Append(" values(");
                foreach (PropertyInfo info in list)
                {
                    object value = info.GetValue(entity, null);
                    if (value == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("'" + value + "',");
                }
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ");";

                return cmdText;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ��ȡ�޸ĵ�sql
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string GetUpdateEntitySql(IEntity entity, string keyName, string keyValue)
        {
            Type type = entity.GetType();
            PropertyInfo[] list = type.GetProperties();

            //����sql���
            StringBuilder sql = new StringBuilder();
            sql.Append("update " + type.Name + " set ");
            foreach (PropertyInfo info in list)
            {
                object value = info.GetValue(entity, null);
                if (value == null)
                {
                    continue;
                }
                sql.Append(info.Name + "='" + value + "',");

            }
            string cmdText = sql.ToString().TrimEnd(new char[] { ',' });

            cmdText += " where " + keyName + "='" + keyValue + "'";
            return cmdText;
        }
    }
}
