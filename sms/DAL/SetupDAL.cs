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
    public class SetupDAL
    {
        public int InsertUpdateDelete_Category(int action, string category, int UserId, int catid=0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateCategory");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "CategoryId", DbType.Int32, catid);
            db.AddInParameter(dbCmd, "Category", DbType.String, category);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
          
            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_SubCategory(int action,int CategoryId, string Subcategory, int UserId, int Subcatid = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateSubCategory");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "CategoryId", DbType.Int32, CategoryId);
            db.AddInParameter(dbCmd, "SubCategory", DbType.String, Subcategory);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "SubCategoryId", DbType.Int32, Subcatid);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_Class(int action, string ClassName, int UserId, int clsid = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateClass");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "ClassId", DbType.Int32, clsid);
            db.AddInParameter(dbCmd, "ClassName", DbType.String, ClassName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_Subject(int action, string SubjectName, int UserId, int subjectid = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateSubject");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "SubjectId", DbType.Int32, subjectid);
            db.AddInParameter(dbCmd, "SubjectName", DbType.String, SubjectName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_Designation(int action, string DesignationName, int UserId,int Position, bool IsActive, int DesignationId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDesignation");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "DesignationId", DbType.Int32, DesignationId);
            db.AddInParameter(dbCmd, "DesignationName", DbType.String, DesignationName);
            db.AddInParameter(dbCmd, "Position", DbType.Int32, Position);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "IsActive", DbType.Int32, IsActive);




            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_InstituteType(int action, string InstName, int UserId, int isA, int InstId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateInstituteType");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "InstituteTypeId", DbType.Int32, InstId);
            db.AddInParameter(dbCmd, "InstituteTypeName", DbType.String, InstName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "IsActive", DbType.Int32, isA);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
        public int InsertUpdateDelete_ClassAssign(int action, int ClassId, int SubjectId, int TeacherId, string StartTime, string EndTime, int UserId, bool IsActive, int ClassAssignId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateClassAssign");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "ClassId", DbType.Int32, ClassId);
            db.AddInParameter(dbCmd, "SubjectId", DbType.Int32, SubjectId);
            db.AddInParameter(dbCmd, "TeacherId", DbType.Int32, TeacherId);
            db.AddInParameter(dbCmd, "StartTime", DbType.Int32, StartTime);
            db.AddInParameter(dbCmd, "IsActive", DbType.Int32, IsActive);
            db.AddInParameter(dbCmd, "EndTime", DbType.Int32, EndTime);
            db.AddInParameter(dbCmd, "IsActive", DbType.Int32, IsActive);
            db.AddInParameter(dbCmd, "ClassAssignId", DbType.Int32, ClassAssignId);
            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_District(int Action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("conSp_InsertUpdateDistrict");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DistrictName", DbType.String, DistrictName);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int InsertUpdateDelete_Upazila (int Action, int DistrictId, string UpazilaName, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("conSp_InsertUpdateUpazila");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbcmd, "UpazilaName", DbType.String, UpazilaName);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, UpazilaId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int InsertUpdateDelete_StudentAttendance(int StudentId, int ClassId, string Shift, bool AttendanceStatus, int UserId, int SAId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("conSp_InsertUpdateStudentAttendancnce");
            db.AddInParameter(dbcmd, "StudentId", DbType.Int32,StudentId);
            db.AddInParameter(dbcmd, "ClassId", DbType.Int32,ClassId);
            db.AddInParameter(dbcmd, "Shift", DbType.String,Shift);
            
            db.AddInParameter(dbcmd, "AttendanceStatus", DbType.Boolean,AttendanceStatus);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "SAId", DbType.Int32, SAId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable Set_getCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetCategory");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getSubCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetSubCategory");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getClass()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetClass");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getSubject()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetSubject");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getDesignation()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetDesignation");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getInstituteType()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetInstituteType");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable getClassAssign()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetClassAssign");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable getDistrict()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetDistrict");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }


        public DataTable getUpazila()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetUpazila");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

    }
}
