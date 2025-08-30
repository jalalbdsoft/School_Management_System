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
    public class StudentDAL
    {
        public DataTable Get_SpStudent(int StudentId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("Get_SpStudent");
            db.AddInParameter(dbCmd, "StudentId", DbType.Int32, StudentId);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable StudentSearch(string StuName, int District,int Upazila,int RollNo)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("Student_SpGetByParam");
            db.AddInParameter(dbCmd, "StuName", DbType.String, StuName);
            db.AddInParameter(dbCmd, "District", DbType.Int32, District);
            db.AddInParameter(dbCmd, "Upazila", DbType.Int32, Upazila);
            db.AddInParameter(dbCmd, "RollNo", DbType.Int32, RollNo);
           
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public int InsertUpdateDelete_Student(Entity.EStudent objEStu)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateStudent");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEStu.action);
            db.AddInParameter(dbCmd, "StudentId", DbType.Int32, objEStu.StudentId);
            db.AddInParameter(dbCmd, "RegistrationNo", DbType.String, objEStu.RegistrationNo);
            db.AddInParameter(dbCmd, "FirstName", DbType.String, objEStu.FirstName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objEStu.LastName);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objEStu.ContactNo);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEStu.Email);
            db.AddInParameter(dbCmd, "Nationality", DbType.String, objEStu.Nationality);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objEStu.ReligionId);
            db.AddInParameter(dbCmd, "Gender", DbType.String, objEStu.Gender);
            db.AddInParameter(dbCmd, "DOB", DbType.String, objEStu.DOB);
            db.AddInParameter(dbCmd, "BloodGroup", DbType.String, objEStu.BloodGroup);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, objEStu.DistrictId);
            db.AddInParameter(dbCmd, "UpazilaId", DbType.Int32, objEStu.UpazilaId);
            db.AddInParameter(dbCmd, "Address", DbType.String, objEStu.Address);
            db.AddInParameter(dbCmd, "FatherName", DbType.String, objEStu.FatherName);
            db.AddInParameter(dbCmd, "FatherContact", DbType.String, objEStu.FatherContact);
            db.AddInParameter(dbCmd, "FatherOccupation", DbType.String, objEStu.FatherOccupation);
            db.AddInParameter(dbCmd, "MotherName", DbType.String, objEStu.MotherName);
            db.AddInParameter(dbCmd, "MotherContact", DbType.String, objEStu.MotherContact);
            db.AddInParameter(dbCmd, "MotherOccupation", DbType.String, objEStu.MotherOccupation);
            db.AddInParameter(dbCmd, "GuardianName", DbType.String, objEStu.GuardianName);
            db.AddInParameter(dbCmd, "GuardianRelation", DbType.String, objEStu.GuardianRelation);
            db.AddInParameter(dbCmd, "GuardianContact", DbType.String, objEStu.GuardianContact);
            db.AddInParameter(dbCmd, "StudentImg", DbType.String, objEStu.StudentImg);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEStu.EntryBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEStu.IsActive);


            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

    }
}
