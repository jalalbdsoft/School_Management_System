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
    public partial class StudentList : System.Web.UI.Page
    {
        StudentBLL objStuBLL = new StudentBLL();
        AdmissionBLL objAdmBLL = new AdmissionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlDistrict, "SELECT DistrictID, DistrictName from Con_District", "DistrictName", "DistrictId");

                loadGrid(txtFirstName.Text,int.Parse(ddlDistrict.SelectedValue),0,0);
                if (hdnUpdategrid.Value=="True")
                {
                    loadGrid(txtFirstName.Text, int.Parse(ddlDistrict.SelectedValue), 0, 0);
                }
            }
                
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Con_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int upazila = ddlUpazila.SelectedIndex == -1 ? 0 : int.Parse(ddlUpazila.SelectedValue);
            loadGrid(txtFirstName.Text, int.Parse(ddlDistrict.SelectedValue), 0, 0);
        }
        private void loadGrid(string StuName, int District, int Upazila, int RollNo)
        {
            DataTable dt = new DataTable();
            dt = objStuBLL.StudentSearchByParam( StuName,  District,  Upazila,  RollNo);
            if (dt.Rows.Count > 0)
            {
                gvStudent.DataSource = dt;
                gvStudent.DataBind();
            }
            else
            {
                gvStudent.DataSource = null;
                gvStudent.DataBind();
            }
        }


        private void DeleteStu(int StudentId)
        {
            int save = 0;
            EStudent objEStu = new EStudent();

            objEStu.RegistrationNo = "";
            objEStu.FirstName = "";
            objEStu.LastName = "";
            objEStu.ContactNo = "";
            objEStu.Email = "";
            objEStu.Nationality = "";
            objEStu.ReligionId = 0;
            objEStu.Gender = "";
            objEStu.DOB = "2022-07-10 00:00:00.000";
            objEStu.BloodGroup = "";
            objEStu.DistrictId = 0;
            objEStu.UpazilaId = 0;
            objEStu.Address = "";
            objEStu.FatherName = "";
            objEStu.FatherContact = "";
            objEStu.FatherOccupation = "";
            objEStu.MotherName = "";
            objEStu.MotherContact = "";
            objEStu.MotherOccupation = "";
            objEStu.GuardianName = "";
            objEStu.GuardianContact = "";
            objEStu.GuardianRelation = "";
            objEStu.StudentImg = "";
            objEStu.EntryBy = 0;
            objEStu.IsActive = true;


            objEStu.action = 3;
            objEStu.StudentId = StudentId;
            save = objStuBLL.InsertUpdateDelete_StudentInfo(objEStu);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Delete Successfull";

                loadGrid(txtFirstName.Text, int.Parse(ddlDistrict.SelectedValue), 0, 0);
            }
        }

        private void CancelAd(int StudentId)
        {
            int save = 0;
            EAdmission objEAdm = new EAdmission(); 

            objEAdm.AdmissionId = 0;
            objEAdm.RegistrationNo = "";
            objEAdm.RegSl = 0;
            objEAdm.StudentId = 0;
            objEAdm.Shift = "";
            objEAdm.ClassId = 0;
            objEAdm.RollNo = "";
            objEAdm.SessionYear = 0;
            objEAdm.AdmissionDate = "2022-07-10 00:00:00.000";
            objEAdm.EntryBy = 0;
            objEAdm.IsActive = true;


            objEAdm.action = 4;
            objEAdm.StudentId = StudentId;
            save = objAdmBLL.InsertUpdateDelete_AdmissionInfo(objEAdm);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Admission Cancelled";

                loadGrid(txtFirstName.Text, int.Parse(ddlDistrict.SelectedValue), 0, 0);
            }
        }




        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnStudentId = (HiddenField)gvStudent.Rows[rowindex].FindControl("hdnStudentId");
           

            if (e.CommandName == "admission")
            {

                string url = "Admission.aspx?StudentId=" + hdnStudentId.Value;
                string totalUrl = "var Mleft = (screen.width/2)-(800/2);var Mtop = (screen.height/2)-(500/2);window.open( '" + url + "', null, 'height=500,width=820,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", totalUrl, true);
            }

            else if (e.CommandName == "adcancel")
            {
                CancelAd(int.Parse(hdnStudentId.Value));
            }

            else if (e.CommandName == "deletec")
            {
                DeleteStu(int.Parse(hdnStudentId.Value));
            }
        }

        protected void gvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < gvStudent.Rows.Count; i++)
            {
                Label lblClass = (Label)gvStudent.Rows[i].FindControl("lblClass");
                LinkButton lbAdCancel = (LinkButton)gvStudent.Rows[i].FindControl("lbAdCancel");
                if (lblClass.Text == "")
                {
                    lblClass.Text = "Not Admitted";
                    lbAdCancel.Visible = false;
                }

            }
        }
    }
}