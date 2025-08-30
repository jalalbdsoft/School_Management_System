using BLL;
using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class TeacherAssign : System.Web.UI.Page
    {
        TeacherAssignBLL objTABLL = new TeacherAssignBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                CommonDAL.ddlLoad(ddlTeacher, "SELECT EmployeeInfo.FirstName + ' ' + EmployeeInfo.LastName + '-' + Con_Designation.DesignationName AS TeacherName, " +
                    "EmployeeInfo.EmployeeId, Con_Designation.DesignationId FROM EmployeeInfo " +
                    "INNER JOIN " +
                    "Con_Designation ON EmployeeInfo.DesignationId = Con_Designation.DesignationId WHERE(EmployeeInfo.EmployeeType = 'Teacher')", "TeacherName", "EmployeeId");

                
            }
        
        }

        private bool checkValue()
        {
            rmMsg.SetResponseMessageVisibleFalse();
            bool isReq = false;
            DataTable dt = new DataTable();

            if (gvTeacherAssign.Rows.Count > 0)
            {
                dt = (DataTable)ViewState["VSCS"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string TeacherId = dt.Rows[i]["TeacherId"].ToString();
                    string shift = dt.Rows[i]["shift"].ToString();
                    string ClassId = dt.Rows[i]["ClassId"].ToString();
                    string ScheduleId = dt.Rows[i]["ScheduleId"].ToString();

                    if (TeacherId==ddlTeacher.SelectedValue && shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && ScheduleId == ddlSchedule.SelectedValue)
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "This Schedule already Exist.";

                    }
                    else if ( shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && ScheduleId == ddlSchedule.SelectedValue &&  TeacherId == ddlTeacher.SelectedValue)
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "Teacher already Exist.";
                    }
                   

                }
            }

            return isReq;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValue() == false)
            {
                ListAdd();
            }



        }
        private void ListAdd()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Teacher", typeof(String)));
            dt.Columns.Add(new DataColumn("TeacherId", typeof(String)));
            dt.Columns.Add(new DataColumn("Shift", typeof(String)));
            dt.Columns.Add(new DataColumn("Class", typeof(String)));
            dt.Columns.Add(new DataColumn("ClassId", typeof(String)));
            dt.Columns.Add(new DataColumn("Schedule", typeof(String)));
            dt.Columns.Add(new DataColumn("ScheduleId", typeof(String)));

            if (ViewState["VSTA"] != null)
            {
                dt = (DataTable)ViewState["VSTA"];
            }
            DataRow dr = dt.NewRow();
            dr[0] = ddlTeacher.SelectedItem.Text;
            dr[1] = ddlTeacher.SelectedValue;
            dr[2] = ddlShift.SelectedValue;
            dr[3] = ddlClass.SelectedItem.Text;
            dr[4] = ddlClass.SelectedValue;
            dr[5] = ddlSchedule.SelectedItem.Text;
            dr[6] = ddlSchedule.SelectedValue;
            dt.Rows.Add(dr);

            gvTeacherAssign.DataSource = dt;
            gvTeacherAssign.DataBind();
            ViewState["VSTA"] = dt;

        }

        List<ETeacherAssign> collection = new List<ETeacherAssign>();

        private void Save()
        {
            if (gvTeacherAssign.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                if (ViewState["VSTA"] != null)
                {
                    dt = (DataTable)ViewState["VSTA"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ETeacherAssign objTA = new ETeacherAssign();
                        objTA.TeacherId = int.Parse(dt.Rows[i]["TeacherId"].ToString());
                        objTA.Shift = dt.Rows[i]["Shift"].ToString();
                        objTA.ClassId = int.Parse(dt.Rows[i]["ClassId"].ToString());
                        objTA.ScheduleId = int.Parse(dt.Rows[i]["ScheduleId"].ToString());
                        objTA.EntryBy = int.Parse(Session["UserId"].ToString());
                        collection.Add(objTA);
                    }
                    int save = objTABLL.InsertUpdateDelete_TeacherAssignInfo(collection);
                    if (save > 0)
                    {
                        rmMsg.SuccessMessage = "Save Done";
                    }
                    else
                    {
                        rmMsg.FailureMessage = "Save Failure.";
                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "There is no data.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }


        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlClass, @"SELECT ClassSchedule.ClassId, Con_Class.ClassName
            FROM ClassSchedule INNER JOIN
            Con_Class ON ClassSchedule.ClassId = Con_Class.ClassId
            WHERE (Shift = '"+ddlShift.SelectedValue+ "') GROUP BY ClassSchedule.ClassId, Con_Class.ClassName "
           , "ClassName", "ClassId");
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT    CScheduleId, Schedule, Shift, ClassId
FROM vw_clsShedule WHERE (Shift = '" + ddlShift.SelectedValue + "') AND (vw_clsShedule.ClassId = " + ddlClass.SelectedValue+")";
            CommonDAL.ddlLoad(ddlSchedule, sqlStr, "Schedule", "CScheduleId");
        }

        
        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT TeacherAssign.TeacherId, (EmployeeInfo.FirstName+' '+ EmployeeInfo.LastName) as Teacher , TeacherAssign.Shift, TeacherAssign.ClassId, Con_Class.ClassName Class, TeacherAssign.ScheduleId, 
            ClassSchedule.WeekDay + ' - ' + Con_Subject.SubjectName + ' --> ' + CONVERT(varchar(5), CAST(ClassSchedule.StartTime AS time)) + ' to ' + CONVERT(varchar(5), 
            CAST(ClassSchedule.EndTime AS time)) AS Schedule FROM TeacherAssign 
            INNER JOIN
            Con_Class ON TeacherAssign.ClassId = Con_Class.ClassId INNER JOIN
            EmployeeInfo ON TeacherAssign.TeacherId = EmployeeInfo.EmployeeId AND TeacherAssign.TeacherId = EmployeeInfo.EmployeeId INNER JOIN
            ClassSchedule ON TeacherAssign.ScheduleId = ClassSchedule.CScheduleId AND Con_Class.ClassId = ClassSchedule.ClassId INNER JOIN
            Con_Subject ON ClassSchedule.SubjectId = Con_Subject.SubjectId WHERE (TeacherAssign.TeacherId = " + ddlTeacher.SelectedValue + ")";
            dt = objc.Loaddt(sqlStr);
            gvTeacherAssign.DataSource = dt;
            gvTeacherAssign.DataBind();

            ViewState["VSCS"] = dt;
        }
    }
}