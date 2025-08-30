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
    public partial class ClassSchedule : System.Web.UI.Page
    {
        ClassScheduleBLL objclsSBll = new ClassScheduleBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlClass, "SELECT ClassId, ClassName from Con_Class", "ClassName", "ClassId");
                CommonDAL.ddlLoad(ddlSubject, "SELECT SubjectId, SubjectName from Con_Subject", "SubjectName", "SubjectId");
            }
        }

        private bool checkValue()
        {
            rmMsg.SetResponseMessageVisibleFalse();
            bool isReq = false;
            DataTable dt = new DataTable();

            if (gvClassSchedule.Rows.Count > 0)
            {
                dt = (DataTable)ViewState["VSCS"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string shift = dt.Rows[i]["shift"].ToString();
                    string ClassId = dt.Rows[i]["ClassId"].ToString();
                    string WeekDay = dt.Rows[i]["WeekDay"].ToString();
                    string SubjectId = dt.Rows[i]["SubjectId"].ToString();

                    DateTime StartTime = DateTime.Parse(dt.Rows[i]["StartTime"].ToString());
                    DateTime EndTime = DateTime.Parse(dt.Rows[i]["EndTime"].ToString());

                    if (shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && WeekDay == ddlWeek.SelectedValue && SubjectId == ddlSubject.SelectedValue)
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "This Subject already Exist.";

                    }
                    else if (shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && WeekDay == ddlWeek.SelectedValue && (DateTime.Parse(txtStart.Text) >= StartTime && DateTime.Parse(txtStart.Text) <= EndTime))
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "This time already Exist.";
                    }
                    else if (shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && WeekDay == ddlWeek.SelectedValue && (DateTime.Parse(txtEnd.Text) >= StartTime && DateTime.Parse(txtEnd.Text) <= EndTime))
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "This time already Exist.";
                    }


                }
            }

            return isReq;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValue() == false)
            {
                ListAdd();
            }
            
        }

        private void ListAdd()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Shift", typeof(String)));
            dt.Columns.Add(new DataColumn("Class", typeof(String)));
            dt.Columns.Add(new DataColumn("ClassId", typeof(String)));
            dt.Columns.Add(new DataColumn("WeekDay", typeof(String)));
            dt.Columns.Add(new DataColumn("Subject", typeof(String)));
            dt.Columns.Add(new DataColumn("SubjectId", typeof(String)));
            dt.Columns.Add(new DataColumn("StartTime", typeof(String)));
            dt.Columns.Add(new DataColumn("EndTime", typeof(String)));

            if (ViewState["VSCS"] != null)
            {
                dt = (DataTable)ViewState["VSCS"];
            }
            DataRow dr = dt.NewRow();
            dr[0] = ddlShift.SelectedValue;
            dr[1] = ddlClass.SelectedItem.Text;
            dr[2] = ddlClass.SelectedValue;
            dr[3] = ddlWeek.SelectedValue;
            dr[4] = ddlSubject.SelectedItem.Text;
            dr[5] = ddlSubject.SelectedValue;
            dr[6] = txtStart.Text;
            dr[7] = txtEnd.Text;
            dt.Rows.Add(dr);

            gvClassSchedule.DataSource = dt;
            gvClassSchedule.DataBind();
            ViewState["VSCS"] = dt;

        }

        List<EClassSchedule> collection = new List<EClassSchedule>();

        private void Save()
        {
            if (gvClassSchedule.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                if (ViewState["VSCS"] != null)
                {
                    dt = (DataTable)ViewState["VSCS"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EClassSchedule objclss = new EClassSchedule();
                        objclss.Shift = dt.Rows[i]["Shift"].ToString();
                        objclss.ClassId = int.Parse(dt.Rows[i]["ClassId"].ToString());
                        objclss.WeekDay = dt.Rows[i]["WeekDay"].ToString();
                        objclss.SubjectId = int.Parse(dt.Rows[i]["SubjectId"].ToString());
                        objclss.StartTime = DateTime.Parse(dt.Rows[i]["StartTime"].ToString());
                        objclss.EndTime = DateTime.Parse(dt.Rows[i]["EndTime"].ToString());
                        objclss.EntryBy = int.Parse(Session["UserId"].ToString());
                        collection.Add(objclss);
                    }
                    int save = objclsSBll.InsertUpdateDelete_ClassScheduleInfo(collection);
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

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT ClassSchedule.Shift, Con_Class.ClassName Class, ClassSchedule.ClassId,
            ClassSchedule.WeekDay, Con_Subject.SubjectName Subject, ClassSchedule.SubjectId SubjectId, 
            CAST(ClassSchedule.StartTime as TIME)  StartTime, CAST(ClassSchedule.EndTime as TIME) EndTime
            FROM            ClassSchedule INNER JOIN
            Con_Class ON ClassSchedule.ClassId = Con_Class.ClassId INNER JOIN
            Con_Subject ON ClassSchedule.SubjectId = Con_Subject.SubjectId
            WHERE(Shift = '" + ddlShift.SelectedValue + "') AND(ClassSchedule.ClassId = " + ddlClass.SelectedValue + ")";
            dt = objc.Loaddt(sqlStr);
            gvClassSchedule.DataSource = dt;
            gvClassSchedule.DataBind();

            ViewState["VSCS"] = dt;
        }
    }
}