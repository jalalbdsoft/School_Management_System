using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class SetupBLL
    {
        SetupDAL objSetup = new SetupDAL();
        public int InsertUpdateDelete_CategoryInfo(int action, string category, int UserId, int catid = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Category( action,  category, UserId,  catid );
            return ret;
        }

        public int InsertUpdateDelete_SubCategoryInfo(int action, int CategoryId, string Subcategory, int UserId, int Subcatid = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_SubCategory(action, CategoryId, Subcategory, UserId, Subcatid);
            return ret;
        }

        public int InsertUpdateDelete_ClassInfo(int action, string ClassName, int UserId, int clsid = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Class(action, ClassName, UserId, clsid);
            return ret;
        }

        public int InsertUpdateDelete_SubjectInfo(int action, string SubjectName, int UserId, int subjectid = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Subject(action, SubjectName, UserId, subjectid);
            return ret;
        }

        public int InsertUpdateDelete_DesignationInfo(int action, string DesignationName, int UserId, int Position, bool IsActive, int DesignationId = 0)
        { 
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Designation(action, DesignationName, UserId, Position, IsActive, DesignationId);
            return ret;
        }

        public int InsertUpdateDelete_InstituteTypeInfo(int action, string InstName, int UserId, int isA, int InstId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_InstituteType(action, InstName, UserId, isA, InstId);
            return ret;
        }
        public int InsertUpdateDelete_ClassAssignInfo(int action, int ClassId, int SubjectId, int TeacherId, string StartTime, string EndTime, int UserId,bool IsActive, int ClassAssignId=0 )
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_ClassAssign(action, ClassId, SubjectId, TeacherId, StartTime, EndTime, UserId, IsActive, ClassAssignId);
            return ret;
        }

        public int InsertUpdateDelete_DistrictInfo(int Action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_District(Action, DistrictName, UserId, DistrictId);
            return ret;
        }
        public int InsertUpdateDelete_UpazilaInfo(int Action, int DistrictId, string UpazilaName, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Upazila(Action, DistrictId, UpazilaName, UserId, UpazilaId);
            return ret;
        }

        public int InsertUpdateDelete_StudentAttendancnceInfo(int StudentId, int ClassId, string Shift,bool AttendanceStatus,int UserId, int SAId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_StudentAttendance(StudentId,  ClassId,  Shift,  AttendanceStatus,  UserId , SAId = 0);
            return ret;
        }

        public DataTable Set_getCategoryInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getCategory();
            return ret;
        }
        public DataTable Set_getSubCategoryInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getSubCategory();
            return ret;
        }

        public DataTable Set_getClassInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getClass();
            return ret;
        }

        public DataTable Set_getSubjectInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getSubject();
            return ret;
        }

        public DataTable Set_getDesignationInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getDesignation();
            return ret;
        }

        public DataTable Set_getInstituteTypeInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getInstituteType();
            return ret;
        }
        public DataTable Set_getClassAssignInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.getClassAssign();
            return ret;
        }

        public DataTable Set_getDistrictInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.getDistrict();
            return ret;
        }

        public DataTable Set_getUpazilaInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.getUpazila();
            return ret;
        }



    }
}
