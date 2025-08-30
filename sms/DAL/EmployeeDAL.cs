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
   public class EmployeeDAL
    {
        public DataTable Get_SpEmployee(int EmployeeId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("Get_SpEmployee");
            db.AddInParameter(dbCmd, "EmployeeId", DbType.Int32, EmployeeId);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }



        public int InsertUpdateDelete_Employee(Entity.EEmployee objEEmp)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateEmployee");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEEmp.action);
            db.AddInParameter(dbCmd, "EmployeeId", DbType.Int32, objEEmp.EmployeeId);
            db.AddInParameter(dbCmd, "FirstName", DbType.String, objEEmp.FirstName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objEEmp.LastName);
            db.AddInParameter(dbCmd, "EmployeeType", DbType.String, objEEmp.EmployeeType);
            db.AddInParameter(dbCmd, "DesignationId", DbType.Int32, objEEmp.DesignationId);
            db.AddInParameter(dbCmd, "StartingSalary", DbType.Double, objEEmp.StartingSalary);
            db.AddInParameter(dbCmd, "Nationality", DbType.String, objEEmp.Nationality);
            db.AddInParameter(dbCmd, "NID", DbType.String, objEEmp.NID);
            db.AddInParameter(dbCmd, "DOB", DbType.DateTime, objEEmp.DOB);
            db.AddInParameter(dbCmd, "JoiningDate", DbType.DateTime, objEEmp.JoiningDate);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objEEmp.ReligionId);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, objEEmp.DistrictId);
            db.AddInParameter(dbCmd, "UpazilaId", DbType.Int32, objEEmp.UpazilaId);
            db.AddInParameter(dbCmd, "Address", DbType.String, objEEmp.Address);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEEmp.Email);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objEEmp.ContactNo);
            db.AddInParameter(dbCmd, "Gender", DbType.String, objEEmp.Gender);
            db.AddInParameter(dbCmd, "BloodGroup", DbType.String, objEEmp.BloodGroup);
            db.AddInParameter(dbCmd, "EmpImg", DbType.String, objEEmp.EmpImg);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEEmp.EntryBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEEmp.IsActive);


            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

    }
}
