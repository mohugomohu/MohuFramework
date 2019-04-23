using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MohuFramework.Entity;

namespace MohuFramework.DataAccess
{
    public interface IDataAccessor
    {
        bool ExecuteNonQuery(string sql);
        DataTable Query(string sql);
        DataSet QueryDataSet(string sql);
        DataTable Query(string sql, params object[] paras);
        DataSet QueryDataSet(string sql, params object[] paras);
        bool InsertEntity(IEntity entity);
        bool InsertEntityNotSetPK(IEntity entity);
        bool InsertEntity(IEntity entity,object connObject);
        IEntity GetEntity(IEntity entity);
        T GetEntity<T>(T entity) where T : new();
        T GetEntityExceptSomeCol<T>(T entity,params string[] cols) where T : new();
        bool UpdateEntity(IEntity entity);
        bool DeleteEntity(IEntity entity);
        object ExecuteScalar(string sql);
        object ExecuteScalar(string sql, params object[] paras);
        bool ExecuteStoreProc(string procName, params object[] paras);
        List<T> GetList<T>(T entity,string sql) where T : new();
        bool InsertEntityList(List<IEntity> listEntity);
        bool InsertEntityListSql(List<IEntity> listEntity);
        bool InsertEntityListByBatch(List<IEntity> listEntity);
        bool InsertEntityListByBatch(List<IEntity> listEntity,int batchSize);
        object GetPublicConnection();
        string GetInsertEntitySql(IEntity entity);
        string GetUpdateEntitySql(IEntity entity, string keyName, string keyValue);
    }
}
