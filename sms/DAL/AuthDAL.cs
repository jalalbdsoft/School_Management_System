using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class AuthDAL
    {
        public DataTable ChekUser(string UserName, string UPassword)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("AuthSp_CheckLogin");
            db.AddInParameter(dbCmd, "UserName", DbType.String, UserName);
            db.AddInParameter(dbCmd, "UPassword", DbType.String, UPassword);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable GetUserReg(int ReligionId, int Gender, int userId)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("AuthSp_GetUserReg");
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, ReligionId);
            db.AddInParameter(dbCmd, "Gender", DbType.Int32, Gender);
            db.AddInParameter(dbCmd, "UserId", DbType.Int32, userId);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable ddlLoad(string query)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public int Insert_UserReg(Entity.EUserReg objEUR)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("AuthSp_InsertUserReg");
            db.AddInParameter(dbCmd, "UserName", DbType.String, objEUR.UserName);
            db.AddInParameter(dbCmd, "Firstname", DbType.String, objEUR.Firstname);
            db.AddInParameter(dbCmd, "MidleName", DbType.String, objEUR.MidleName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objEUR.LastName);
            db.AddInParameter(dbCmd, "Gender", DbType.Int32, objEUR.Gender);
            db.AddInParameter(dbCmd, "DateofBirth", DbType.String, objEUR.DateofBirth);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objEUR.ContactNo);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEUR.Email);
            db.AddInParameter(dbCmd, "Address", DbType.String, objEUR.Address);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objEUR.ReligionId);
            //db.AddInParameter(dbCmd, "EntryDate", DbType.DateTime, objEUR.EntryDate);
            db.AddInParameter(dbCmd, "UserImage", DbType.String, objEUR.UserImage);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int Approved_UserReg(int UserId,string AppStatus,string Password)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("AuthSp_ApprovesUser");
            db.AddInParameter(dbCmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "AppStatus", DbType.String, AppStatus);
            db.AddInParameter(dbCmd, "Password", DbType.String, Password);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

    }
}
