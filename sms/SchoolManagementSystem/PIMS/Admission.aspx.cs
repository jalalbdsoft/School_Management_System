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
    public partial class Admission : System.Web.UI.Page
    {
        AdmissionBLL objAdmBLL = new AdmissionBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnStuId.Value = Request.QueryString["StudentId"].ToString();
                CommonDAL.ddlLoad(ddlClass, "SELECT ClassId, ClassName from Con_Class", "ClassName", "ClassId");
                loadSessionYear();

                CommonDAL.ddlTextLoad(ddlStudentName, @"SELECT StudentId, FirstName + ' ' + LastName AS FullName
                        FROM  StudentProfile WHERE (StudentId = " + hdnStuId.Value + ")", "FullName", "StudentId");

                //txtStudentName.Text = objc.loadStr(@"SELECT (FirstName+' '+ LastName) AS StuName FROM StudentProfile where StudentId=" + hdnStuId.Value + "");



                loadSessionYear();

            }

            //txtStartingSalary.Attributes.Add("OnKeyUp", "chkNumber('" + txtStartingSalary.ClientID + "')");

        }

        public void RefreshParentPage()
        {
            runScript.Text = "<script>if (window.opener != null && !window.opener.closed){var hiddenfield=window.opener.ParentRefrash();hiddenfield.value='true';window.opener.document.forms[0].submit();}</script>";
        }

        private void loadSessionYear()
        {
            ListItem li1 = new ListItem("Select.....", "0");
            ListItem li2 = new ListItem((DateTime.Now.Year + 1).ToString(), (DateTime.Now.Year + 1).ToString());

            ddlSession.Items.Insert(0, li1);
            ddlSession.Items.Insert(1, li2);
            for (int i = 2; i < 50; i++)
            {
                ListItem li = new ListItem((DateTime.Now.Year - (i - 2)).ToString(), (DateTime.Now.Year - (i - 2)).ToString());
                ddlSession.Items.Insert(i, li);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckFieldValue())
            {
                Save();
            }
        }



        private bool CheckFieldValue()
        {

            bool IsReq = false;

            if (txtRegistration.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Registration No";
                txtRegistration.Focus();
            }
            else if (ddlShift.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = " Please Enter Shift";
                ddlShift.Focus();
            }


            
            return IsReq;

        }


       

        private void Save()
        {
            int save = 0;
            EAdmission objEAdm = new EAdmission();

            
 
            objEAdm.RegistrationNo=txtRegistration.Text;
            objEAdm.RegSl = int.Parse(hdnRegSl.Value)+1;
            objEAdm.StudentId = int.Parse(hdnStuId.Value);
            objEAdm.Shift=ddlShift.SelectedValue;
            objEAdm.ClassId=int.Parse(ddlClass.SelectedValue);
            objEAdm.RollNo=txtRollNo.Text;
            objEAdm.SessionYear=int.Parse(ddlSession.SelectedValue);
            objEAdm.AdmissionDate=txtDOA.Text;
            objEAdm.EntryBy= int.Parse(Session["UserId"].ToString());
            objEAdm.IsActive= true;


            if (btnSave.Text == "Save")
            {
                objEAdm.action = 1;
                objEAdm.AdmissionId = 0;

               

            }

            

            save = objAdmBLL.InsertUpdateDelete_AdmissionInfo(objEAdm);
            if (save > 0)
            {
                rmMsg.SuccessMessage = btnSave.Text + " " + "Successfull";

                RefreshParentPage();

            }

        }
         
        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRegNo();
        }

        private void loadRegNo()
        {
            if (ddlClass.SelectedValue != "0" || ddlSession.SelectedValue != "0" || ddlShift.SelectedValue != "0")
            {
                hdnRegSl.Value = objc.loadStr(@"SELECT  ISNULL(MAX(RegSl),0) AS RegSl
               FROM Student_Admission WHERE(SessionYear = " + ddlSession.SelectedValue + ") AND(Shift = '" + ddlShift.SelectedValue + "') AND(ClassId = " + ddlClass.SelectedValue + ")");

                txtRegistration.Text = "KR" + ddlSession.SelectedValue.Substring(2, 2) + ddlShift.SelectedItem.Text.Substring(0, 1) + ddlClass.SelectedValue.PadLeft(2, '0') + (int.Parse(hdnRegSl.Value) + 1).ToString().PadLeft(3, '0');
            }
            else
            {
                rmMsg.FailureMessage = "Select All Information.";
            }
        }
    }
}