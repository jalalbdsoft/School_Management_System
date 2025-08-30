using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdmissionDAL
    {
        public DataTable Get_SpAdmission(int AdmissionId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("Get_SpAdmission");
            db.AddInParameter(dbCmd, "AdmissionId", DbType.Int32, AdmissionId);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }



        public int InsertUpdateDelete_Admission(Entity.EAdmission objEAdm)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateAdmission");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEAdm.action);
            db.AddInParameter(dbCmd, "AdmissionId", DbType.Int32, objEAdm.AdmissionId);
            db.AddInParameter(dbCmd, "RegistrationNo", DbType.String, objEAdm.RegistrationNo);
            db.AddInParameter(dbCmd, "RegSl", DbType.Int32, objEAdm.RegSl);
            db.AddInParameter(dbCmd, "StudentId", DbType.Int32, objEAdm.StudentId);
            db.AddInParameter(dbCmd, "Shift", DbType.String, objEAdm.Shift);
            db.AddInParameter(dbCmd, "ClassId", DbType.Int32, objEAdm.ClassId);
            db.AddInParameter(dbCmd, "RollNo", DbType.String, objEAdm.RollNo);
            db.AddInParameter(dbCmd, "SessionYear", DbType.Int32, objEAdm.SessionYear);
            db.AddInParameter(dbCmd, "AdmissionDate", DbType.DateTime, objEAdm.AdmissionDate);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEAdm.EntryBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEAdm.IsActive);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
    }
}
