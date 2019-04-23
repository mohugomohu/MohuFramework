using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MohuFramework.DataAccess
{
    public class DataAccessorFactory
    {
        /// <summary>
        /// 返回 DataAccessorFactory 的唯一实例；
        /// </summary>
        public static DataAccessorFactory Instance
        {
            get
            {
                return new DataAccessorFactory();
            }
        }

        public IDataAccessor GetDataAccessor(AccessorType type)
        {
            if (type == AccessorType.SqlServer)
            {
                return new SqlDataAccessor();
            }
            else
            {
                throw new NotImplementedException("还没有实现！");
            }
        }

        public IDataAccessor GetDataAccessor(AccessorType type, bool IsPwdEncript)
        {
            if (type == AccessorType.SqlServer)
            {
                SqlDataAccessor sda = new SqlDataAccessor();
                sda.IsPwdEncript = IsPwdEncript;
                return sda;
            }
            else
            {
                throw new NotImplementedException("还没有实现！");
            }
        }

        public IDataAccessor GetDataAccessor(AccessorType type, string connStr)
        {
            if (type == AccessorType.SqlServer)
            {
                if (string.IsNullOrEmpty(connStr))
                {
                    return new SqlDataAccessor();
                }
                else
                {
                    return new SqlDataAccessor(connStr);
                }
            }
            else
            {
                throw new NotImplementedException("还没有实现！");
            }
        }

        public IDataAccessor GetDataAccessor(AccessorType type, string connStr, bool IsPwdEncript)
        {
            if (type == AccessorType.SqlServer)
            {
                if (string.IsNullOrEmpty(connStr))
                {
                    SqlDataAccessor sda = new SqlDataAccessor();
                    sda.IsPwdEncript = IsPwdEncript;
                    return sda;
                }
                else
                {
                    SqlDataAccessor sda = new SqlDataAccessor(connStr);
                    sda.IsPwdEncript = IsPwdEncript;
                    return sda;
                }
            }
            else
            {
                throw new NotImplementedException("还没有实现！");
            }
        }

        public IDataAccessor GetDataAccessor(string className)
        {
            IDataAccessor classInstance = (IDataAccessor)Assembly.Load("MohuFramework").CreateInstance("MohuFramework.DataAccess." + className);
            if (classInstance == null)
            {
                throw new Exception("在MohuFramework.DataAccess程序集中找不到" + className + "这个类!");
            }
            return classInstance;
        }

        /// <summary>
        /// 保证单例的私有构造函数；
        /// </summary>
        private DataAccessorFactory() { }

        /// <summary>
        /// 数据库的类型
        /// </summary>
        public enum AccessorType
        {
            SqlServer,
            Access
        }

        /// <summary>
        /// 连接字符串来源于自带的配置文件还是手动输入
        /// </summary>
        public enum ConnStringFrom
        {
            File = 0,
            String = 1
        }
    }
}
