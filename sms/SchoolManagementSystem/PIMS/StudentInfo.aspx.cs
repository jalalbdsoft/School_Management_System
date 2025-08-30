using BLL;
using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        StudentBLL objStuBLL = new StudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlDistrict, "SELECT DistrictID, DistrictName from Con_District", "DistrictName", "DistrictId");
                
                CommonDAL.ddlLoad(ddlReligion, "SELECT ReligionID, ReligionName from Conf_Religion ORDER BY ReligionId", "ReligionName", "ReligionId");
               
            }

            //txtStartingSalary.Attributes.Add("OnKeyUp", "chkNumber('" + txtStartingSalary.ClientID + "')");
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Con_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
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
            
            if (txtFirstName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter First Name";
                txtFirstName.Focus();
            }
            else if (txtLastName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = " Please Enter Last Name";
                txtLastName.Focus();
            }
        
            
            else if (txtDOB.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Date of Birth";
                txtDOB.Focus();
            }
           
            else if (ddlReligion.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Religion";
                ddlReligion.Focus();
            }
            else if (ddlGender.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Gender";
                ddlGender.Focus();
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter District";
                ddlDistrict.Focus();
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedValue == "-1")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Upazila";
                ddlUpazila.Focus();
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Address";
                txtAddress.Focus();
            }
            else if (txtEmail.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Email Address";
                txtEmail.Focus();
            }
            else if (txtPhone.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Contact Number";
                txtPhone.Focus();
            }
            else if (ddlBloodGroup.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Blood Group";
                ddlBloodGroup.Focus();
            }
            return IsReq;

        }

        private void Save()
        {
            int save = 0;
            EStudent objEStu = new EStudent();

            objEStu.RegistrationNo = txtRegistration.Text;
            objEStu.FirstName=txtFirstName.Text;
            objEStu.LastName=txtLastName.Text;
            objEStu.ContactNo=txtPhone.Text;
            objEStu.Email= txtEmail.Text;
            objEStu.Nationality= txtNationality.Text;
            objEStu.ReligionId= int.Parse(ddlReligion.SelectedValue);
            objEStu.Gender = ddlGender.SelectedValue;
            objEStu.DOB = txtDOB.Text;
            objEStu.BloodGroup= ddlBloodGroup.SelectedValue;
            objEStu.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEStu.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEStu.Address = txtAddress.Text;
            objEStu.FatherName = txtFatherName.Text;
            objEStu.FatherContact = txtFatherContact.Text;
            objEStu.FatherOccupation = txtFatherOccupation.Text;
            objEStu.MotherName = txtMotherName.Text;
            objEStu.MotherContact = txtMotherContact.Text;
            objEStu.MotherOccupation = txtMotherOccupation.Text;
            objEStu.GuardianName = txtGuardian.Text;
            objEStu.GuardianRelation = txtRelation.Text ;
            objEStu.GuardianContact = txtGuardianContact.Text;
            objEStu.StudentImg="1.png";
            objEStu.EntryBy= int.Parse(Session["UserId"].ToString());
            objEStu.IsActive = true;



            if (btnSave.Text == "Save")
            {
                objEStu.action = 1;
                objEStu.StudentId = 0;

            }

            else if (btnSave.Text == "Update")
            {
                objEStu.action = 2;
                objEStu.StudentId = int.Parse(hdnUpdateStudentId.Value);
            }

            save = objStuBLL.InsertUpdateDelete_StudentInfo(objEStu);
            if (save > 0)
            {
                rmMsg.SuccessMessage = btnSave.Text + " " + "Successfull";
               
           

            }

        }

    }
}