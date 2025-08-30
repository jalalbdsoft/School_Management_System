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
    public class InstituteDAL
    {


        public DataTable Get_SpInstitute (int InstituteId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("Get_SpInstitute");
            db.AddInParameter(dbCmd, "InstituteId", DbType.Int32,InstituteId);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }



        public int InsertUpdateDelete_Institute(Entity.EInstitute objEIns)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateInstitute");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEIns.action);
            db.AddInParameter(dbCmd, "InstituteId", DbType.Int32, objEIns.InstituteId);
            db.AddInParameter(dbCmd, "EIIN_RegistrationNo", DbType.String, objEIns.EIIN_RegistrationNo);
            db.AddInParameter(dbCmd, "InstituteName", DbType.String, objEIns.InstituteName);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEIns.Email);
            db.AddInParameter(dbCmd, "Phone", DbType.String, objEIns.Phone);
            db.AddInParameter(dbCmd, "Fax", DbType.String, objEIns.Fax);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, objEIns.DistrictId);
            db.AddInParameter(dbCmd, "UpazilaId", DbType.Int32, objEIns.UpazilaId);
            db.AddInParameter(dbCmd, "Address", DbType.String, objEIns.Address);
            db.AddInParameter(dbCmd, "InstituteTypeId", DbType.Int32, objEIns.InstituteTypeId);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEIns.EntryBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEIns.IsActive);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

      

    }
}
