using BLL;
using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class StudentAttendance : System.Web.UI.Page
    {
        CommonDAL objc = new CommonDAL();
        SetupBLL objSetup = new SetupBLL();
        TeacherAssignBLL objTABLL = new TeacherAssignBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlClass, @"SELECT ClassSchedule.ClassId, Con_Class.ClassName
            FROM ClassSchedule INNER JOIN
            Con_Class ON ClassSchedule.ClassId = Con_Class.ClassId
            WHERE (Shift = '" + ddlShift.SelectedValue + "') GROUP BY ClassSchedule.ClassId, Con_Class.ClassName "
           , "ClassName", "ClassId");
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT        dbo.Student_Admission.StudentId, dbo.StudentProfile.FirstName + ' ' + dbo.StudentProfile.LastName AS StudentName, dbo.Student_Admission.RollNo, dbo.Student_Admission.ClassId, dbo.Student_Admission.Shift, 
            ISNULL(dbo.StudentAttendance.AttendanceStatus,1) as AttendanceStatus, dbo.StudentAttendance.AttendanceStatus AS attsts
            FROM            dbo.Student_Admission INNER JOIN
            dbo.StudentProfile ON dbo.Student_Admission.StudentId = dbo.StudentProfile.StudentId LEFT OUTER JOIN
            dbo.StudentAttendance ON dbo.Student_Admission.ClassId = dbo.StudentAttendance.ClassId AND dbo.Student_Admission.Shift = dbo.StudentAttendance.Shift AND 
            dbo.Student_Admission.StudentId = dbo.StudentAttendance.StudentId AND dbo.StudentAttendance.DateofAttendance = '" + txtDate.Text + "' where (Student_Admission.ClassId=" + ddlClass.SelectedValue + ") and (Student_Admission.Shift='" + ddlShift.SelectedValue + "')";
            dt = objc.Loaddt(sqlStr);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["attsts"].ToString() != "")
                {
                    btnSubmit.Text = "Update";
                }
                else
                {
                    btnSubmit.Text = "Save";
                }
                gvStudentAttendance.DataSource = dt;
                gvStudentAttendance.DataBind();
            }
            else
            {
                gvStudentAttendance.DataSource = null;
                gvStudentAttendance.DataBind();
                btnSubmit.Text = "Save";
            }
        }
        List<ETeacherAssign> collection = new List<ETeacherAssign>();

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvStudentAttendance.Rows.Count; i++)
            {
                HiddenField hdnStudentId = (HiddenField)gvStudentAttendance.Rows[i].FindControl("hdnStudentId");
                CheckBox chkPresent = (CheckBox)gvStudentAttendance.Rows[i].FindControl("chkPresent");
                bool sts = false;
                if (chkPresent.Checked==true)
                {
                    sts = true;
                }
                ETeacherAssign objTA = new ETeacherAssign();
                objTA.StudentId = int.Parse(hdnStudentId.Value);
                objTA.AttendanceStatus = sts;
                objTA.ClassId = int.Parse(ddlClass.Text);
                objTA.Shift = ddlShift.SelectedValue;
                objTA.DateofAttendance = txtDate.Text;
                objTA.EntryBy = int.Parse(Session["UserId"].ToString());
                collection.Add(objTA);


            }
            int save = objTABLL.InsertStuAtt(collection);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Save Done";
            }
            else
            {
                rmMsg.FailureMessage = "Save Failure.";
            }
        }

       
        public void insertData(string str1, string str2, string str3)
        {
            
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT        dbo.Student_Admission.StudentId, dbo.StudentProfile.FirstName + ' ' + dbo.StudentProfile.LastName AS StudentName, dbo.Student_Admission.RollNo, dbo.Student_Admission.ClassId, dbo.Student_Admission.Shift, 
            ISNULL(dbo.StudentAttendance.AttendanceStatus,1) as AttendanceStatus, dbo.StudentAttendance.AttendanceStatus AS attsts
            FROM            dbo.Student_Admission INNER JOIN
            dbo.StudentProfile ON dbo.Student_Admission.StudentId = dbo.StudentProfile.StudentId LEFT OUTER JOIN
            dbo.StudentAttendance ON dbo.Student_Admission.ClassId = dbo.StudentAttendance.ClassId AND dbo.Student_Admission.Shift = dbo.StudentAttendance.Shift AND 
            dbo.Student_Admission.StudentId = dbo.StudentAttendance.StudentId AND dbo.StudentAttendance.DateofAttendance = '" + txtDate.Text + "' where (Student_Admission.ClassId=" + ddlClass.SelectedValue + ") and (Student_Admission.Shift='" + ddlShift.SelectedValue + "')";
            dt = objc.Loaddt(sqlStr);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["attsts"].ToString() != "")
                {
                    btnSubmit.Text = "Update";
                }
                else
                {
                    btnSubmit.Text = "Save";
                }
                gvStudentAttendance.DataSource = dt;
                gvStudentAttendance.DataBind();
            }
            else
            {
                gvStudentAttendance.DataSource = null;
                gvStudentAttendance.DataBind();
                btnSubmit.Text = "Save";
            }
        }
    } 
                               
 }

    

