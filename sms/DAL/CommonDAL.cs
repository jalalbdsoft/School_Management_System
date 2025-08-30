using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class CommonDAL
    {
        
        public static DropDownList ddlLoad(DropDownList ddl,string query,string textField, string ValueField)
        {
            CommonDAL objc = new CommonDAL();
            DataTable dt = new DataTable();
            dt = objc.Loaddt(query);
            ddl.DataSource = dt;
            ddl.DataTextField = textField;
            ddl.DataValueField = ValueField;
            ddl.DataBind();
            ListItem li = new ListItem("Select.....", "0");
            ddl.Items.Insert(0,li);

            return ddl;
        }

        public static DropDownList ddlTextLoad(DropDownList ddl, string query, string textField, string ValueField)
        {
            CommonDAL objc = new CommonDAL();
            DataTable dt = new DataTable();
            dt = objc.Loaddt(query);
            ddl.DataSource = dt;
            ddl.DataTextField = textField;
            ddl.DataValueField = ValueField;
            ddl.DataBind();
            ListItem li = new ListItem("");
            ddl.Items.Insert(1, li);

            return ddl;
        }

        public DataTable Loaddt(string query)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public string getString(string query)
        {
            string ret = "";
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            if (dt.Rows.Count > 0 )
            {
                ret = dt.Rows[0][0].ToString();
            }

            return ret;
        }

        public string loadStr(string query)
        {
            string ret = "";
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbcmd).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ret = dt.Rows[0][0].ToString();
            }
            return ret;
        }

    }
}
