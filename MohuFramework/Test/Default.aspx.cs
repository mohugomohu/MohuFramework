using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using MohuFramework.Common;
using MohuFramework.Entity;
using MohuFramework.DataAccess;
using MohuFramework.WebControl;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using Entity;
using System.Xml;
using System.Net;

public partial class _Default : System.Web.UI.Page
{

    IDataAccessor da = DataAccessorFactory.Instance.GetDataAccessor(DataAccessorFactory.AccessorType.SqlServer, true);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<IEntity> list = new List<IEntity>();
        Basic_Weather ss = new Basic_Weather();
        ss.mudidi = "sdf";
        ss.LowTemperature = "2";
        list.Add(ss);

        Basic_Weather ss2 = new Basic_Weather();
        ss2.mudidi = "sdf";
        ss2.LowTemperature = "2";
        list.Add(ss2);

        da.InsertEntityListByBatch(list, 2000);
    }

}
