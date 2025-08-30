 using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentBLL
    {
        StudentDAL objStuDAL = new StudentDAL();

        public int InsertUpdateDelete_StudentInfo(EStudent objEStu)
        {
            int ret = 0;
            ret = objStuDAL.InsertUpdateDelete_Student(objEStu);
            return ret;
        }
        public DataTable Get_SpStudentList(int StudentId = 0)
        {
            DataTable dt = new DataTable();
            dt = objStuDAL.Get_SpStudent(StudentId);
            return dt;
        }

        public DataTable  StudentSearchByParam(string StuName, int District, int Upazila, int RollNo)
        {
            DataTable dt = new DataTable();
            dt = objStuDAL.StudentSearch( StuName,  District,  Upazila,  RollNo);
            return dt;
        }
    }
}
