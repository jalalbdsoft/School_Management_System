using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace SchoolManagementSystem.Setup
{
    public partial class Employee : System.Web.UI.Page
    {
        EmployeeBLL objEmpBLL = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlDistrict, "SELECT DistrictID, DistrictName from Con_District", "DistrictName", "DistrictId");
                CommonDAL.ddlLoad(ddlDesignation, "SELECT DesignationID, DesignationName from Con_Designation ORDER BY DesignationId", "DesignationName", "DesignationId");
                CommonDAL.ddlLoad(ddlReligion, "SELECT ReligionID, ReligionName from Conf_Religion ORDER BY ReligionId", "ReligionName", "ReligionId");
                loadGrid();
            }

            txtStartingSalary.Attributes.Add("OnKeyUp", "chkNumber('" + txtStartingSalary.ClientID + "')");
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Con_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }

        private void loadGrid()
        {
            DataTable dt = new DataTable();
            dt = objEmpBLL.Get_SpEmployeeList();
            if (dt.Rows.Count > 0)
            {
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
            else
            {
                gvEmployee.DataSource = null;
                gvEmployee.DataBind();
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
            if (ddlEmployeeType.Text == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Employee Type";
                ddlEmployeeType.Focus();
            }
            else if (txtFirstName.Text == "")
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
            else if (ddlDesignation.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Designation";
                ddlDesignation.Focus();
            }
            else if (txtStartingSalary.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Starting Salary";
                txtStartingSalary.Focus();
            }
            else if (txtNationality.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Nationality";
                txtNationality.Focus();
            }
            else if (txtNID.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter NID";
                txtNID.Focus();
            }
            else if (txtDOB.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Date of Birth";
                txtDOB.Focus();
            }
            else if (txtDOJ.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Date of Joining";
                txtDOJ.Focus();
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
            EEmployee objEEmp = new EEmployee();

            objEEmp.FirstName = txtFirstName.Text;
            objEEmp.LastName = txtLastName.Text;
            objEEmp.DesignationId = int.Parse(ddlDesignation.SelectedValue);
            objEEmp.EmployeeType = ddlEmployeeType.SelectedValue;
            objEEmp.StartingSalary = float.Parse(txtStartingSalary.Text);
            objEEmp.Nationality = txtNationality.Text;
            objEEmp.NID = txtNID.Text;
            objEEmp.DOB = txtDOB.Text;
            objEEmp.JoiningDate = txtDOJ.Text;
            objEEmp.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEEmp.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEEmp.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEEmp.Address = txtAddress.Text;
            objEEmp.Email = txtEmail.Text;
            objEEmp.ContactNo = txtPhone.Text;
            objEEmp.Gender = ddlGender.SelectedValue;
            objEEmp.BloodGroup = ddlBloodGroup.SelectedValue;
            objEEmp.EmpImg = "1.png";
            objEEmp.EntryBy = int.Parse(Session["UserId"].ToString());
            objEEmp.IsActive = true;


            if (btnSave.Text == "Save")
            {
                objEEmp.action = 1;
                objEEmp.EmployeeId = 0;

            }

            else if (btnSave.Text == "Update")
            {
                objEEmp.action = 2;
                objEEmp.EmployeeId = int.Parse(hdnUpdateEmployeeId.Value);
            }

            save = objEmpBLL.InsertUpdateDelete_EmployeeInfo(objEEmp);
            if (save > 0)
            {
                rmMsg.SuccessMessage = btnSave.Text +" "+"Successfull";
                loadGrid();
                ClearFields();

            }

        }

       

        private void DeleteEmp(int EmployeeId)
        {
            int save = 0;
            EEmployee objEEmp = new EEmployee();

            objEEmp.FirstName = "";
            objEEmp.LastName = "";
            objEEmp.DesignationId = 0;
            objEEmp.EmployeeType = "";
            objEEmp.StartingSalary = 0;
            objEEmp.Nationality = "";
            objEEmp.NID = "";
            objEEmp.DOB = "2022-07-10 00:00:00.000";
            objEEmp.JoiningDate = "2022-07-10 00:00:00.000";
            objEEmp.DistrictId = 0;
            objEEmp.UpazilaId = 0;
            objEEmp.ReligionId = 0;
            objEEmp.Address = "";
            objEEmp.Email = "";
            objEEmp.ContactNo = "";
            objEEmp.Gender = "";
            objEEmp.BloodGroup = "";
            objEEmp.EmpImg = "";
            objEEmp.EntryBy = 0;
            objEEmp.IsActive = true;


            objEEmp.action = 3;
            objEEmp.EmployeeId = EmployeeId;
            save = objEmpBLL.InsertUpdateDelete_EmployeeInfo(objEEmp);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Delete Successfull";
                loadGrid();

            }
        }

        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnEmployeeId = (HiddenField)gvEmployee.Rows[rowindex].FindControl("hdnEmployeeId");


            if (e.CommandName == "editc")
            {  
                btnSave.Text = "Update";
                FillControl(int.Parse(hdnEmployeeId.Value));
            }

            else if (e.CommandName == "deletec")
            {
                DeleteEmp(int.Parse(hdnEmployeeId.Value));
            }
        }


        private void FillControl(int EmployeeId)
        {
            DataTable dt = new DataTable();
            dt = objEmpBLL.Get_SpEmployeeList(EmployeeId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateEmployeeId.Value = EmployeeId.ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                ddlEmployeeType.SelectedValue = dt.Rows[0]["EmployeeType"].ToString();
                ddlDesignation.SelectedValue = dt.Rows[0]["DesignationId"].ToString();
                txtStartingSalary.Text = dt.Rows[0]["StartingSalary"].ToString();
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
                txtNID.Text = dt.Rows[0]["NID"].ToString();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                txtDOJ.Text = dt.Rows[0]["JoiningDate"].ToString();
                ddlReligion.SelectedValue = dt.Rows[0]["ReligionId"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();
                CommonDAL.ddlLoad(ddlUpazila, "SELECT UpazilaId, UpazilaName from Con_Upazila Where DistrictId = " + ddlDistrict.SelectedValue + "Order BY UpazilaName", "UpazilaName", "UpazilaId");
                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                ddlBloodGroup.SelectedValue = dt.Rows[0]["BloodGroup"].ToString();


            }
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlEmployeeType.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            txtStartingSalary.Text = "";
            txtNationality.Text = "";
            txtNID.Text = "";
            txtDOB.Text = "";
            txtDOJ.Text = "";
            ddlReligion.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            ddlUpazila.SelectedValue = "0";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            ddlGender.SelectedValue = "0";
            ddlBloodGroup.SelectedValue = "0";
        }
    }
}
   

