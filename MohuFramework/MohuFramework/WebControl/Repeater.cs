using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Data;
using MohuFramework.DataAccess;
using System.ComponentModel;

namespace MohuFramework.WebControl
{
    [ToolboxData("<{0}:Repeater runat=server></{0}:Repeater>")]
    public class Repeater : System.Web.UI.WebControls.Repeater
    {
        #region 属性
        private string _RecordCount;//获取记录的数量
        private string _TableName;//表名
        private string _OrderField;//排序的字段
        private string _OrderType;//排序方式
        private string _FilterField;//筛选的字段
        private string _FilterValue;//筛选的值

        public string FilterValue
        {
            get
            {
                return _FilterValue;
            }
            set
            {
                _FilterValue = value;
            }
        }
        public string FilterField
        {
            get
            {
                return _FilterField;
            }
            set
            {
                _FilterField = value;
            }
        }
        public string OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                _OrderType = value;
            }
        }
        public string OrderField
        {
            get
            {
                return _OrderField;
            }
            set
            {
                _OrderField = value;
            }
        }
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }
        public string RecordCount
        {
            get
            {
                return _RecordCount;
            }
            set
            {
                _RecordCount = value;
            }
        }
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            this.DataSource = this.GetMyData();
            this.DataBind();
            base.Render(writer);
        }

        //获取数据
        private DataTable GetMyData()
        {
            IDataAccessor da = DataAccessorFactory.Instance.GetDataAccessor("SqlDataAccessor");
            string sql = "select ";
            if (!string.IsNullOrEmpty(this.RecordCount))//记录数
            {
                sql += "top " + this.RecordCount;
            }
            sql += " * from " + this.TableName;
            if (!string.IsNullOrEmpty(this.FilterField) && !string.IsNullOrEmpty(this.FilterValue))//筛选
            {
                sql += " where " + this.FilterField + "=" + this.FilterValue;
            }
            if (!string.IsNullOrEmpty(this.OrderField) && !string.IsNullOrEmpty(this.OrderType))//排序
            {
                sql += " order by " + this.OrderField + " " + this.OrderType;
            }
            try
            {
                DataTable dt = da.Query(sql);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(sql, ex);
            }
        }
    }
}
