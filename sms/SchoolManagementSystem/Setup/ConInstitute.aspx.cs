using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using DAL.Entity;

namespace SchoolManagementSystem.Setup
{
    public partial class ConInstitute : System.Web.UI.Page
    {
        InstituteBLL objInsBLL = new InstituteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlInstitutionType, @"SELECT InstituteTypeId,InstituteTypeName FROM Con_InstituteType ORDER BY InstituteTypeName", "InstituteTypeName","InstituteTypeId");
                CommonDAL.ddlLoad(ddlDistrict, @"SELECT DistrictId, DistrictName FROM Con_District ORDER BY DistrictName", "DistrictName", "DistrictId");
                loadGrid();
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Con_Upazila WHERE (DistrictId = "+ddlDistrict.SelectedValue+") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");  
        }

        private void loadGrid()
        {
            DataTable dt = new DataTable();
            dt = objInsBLL.Get_SpInstituteList();
            if (dt.Rows.Count>0)
            {
                gvInstitute.DataSource = dt;
                gvInstitute.DataBind();
            }
            else
            {
                gvInstitute.DataSource = null;
                gvInstitute.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            Save();
        }

        private void Save()
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();
            objEIns.EIIN_RegistrationNo = txtEIIN.Text;
            objEIns.InstituteName = txtInstituteName.Text;
            objEIns.Email = txtEmail.Text;
            objEIns.Phone = txtPhone.Text;
            objEIns.Fax = txtFax.Text;
            objEIns.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEIns.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEIns.Address = txtAddress.Text;
            objEIns.InstituteTypeId = int.Parse(ddlInstitutionType.SelectedValue);
            objEIns.EntryBy = int.Parse(Session["UserId"].ToString());
            objEIns.IsActive = true;
            if(btnSave.Text == "Save")
            {
                objEIns.action = 1;
                objEIns.InstituteId = 0;

            }

            else if (btnSave.Text == "Update")
            {
                objEIns.action = 2;
                objEIns.InstituteId = int.Parse(hdnUpdateInstituteId.Value);
            }

            save = objInsBLL.InsertUpdateDelete_InstituteInfo(objEIns);
            if (save > 0)
            {
                rmMsg.SuccessMessage = btnSave.Text +" Successfull";
                loadGrid();
            }

        }

        private void DeleteIns(int InstituteId)
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();
            objEIns.EIIN_RegistrationNo = "";
            objEIns.InstituteName = "";
            objEIns.Email = "";
            objEIns.Phone = "";
            objEIns.Fax = "";
            objEIns.DistrictId = 0;
            objEIns.UpazilaId = 0;
            objEIns.Address = "";
            objEIns.InstituteTypeId = 0;
            objEIns.EntryBy = 0;
            objEIns.IsActive = true;
 
            objEIns.action = 3;
            objEIns.InstituteId = InstituteId;
            save = objInsBLL.InsertUpdateDelete_InstituteInfo(objEIns);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Delete Successfull";
                loadGrid();
            }
        }

        protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnInstituteId = (HiddenField)gvInstitute.Rows[rowIndex].FindControl("hdnInstituteId");
            if (e.CommandName == "editc")
            {
                
                btnSave.Text = "Update";
                FillControl(int.Parse(hdnInstituteId.Value));
            }
            else if (e.CommandName=="deletec")
            {
                DeleteIns(int.Parse(hdnInstituteId.Value));
            }
        }


        private void FillControl(int InstituteId)
        {
            DataTable dt = new DataTable();
            dt = objInsBLL.Get_SpInstituteList(InstituteId);
            if (dt.Rows.Count>0)
            {
                hdnUpdateInstituteId.Value = InstituteId.ToString();
                txtEIIN.Text = dt.Rows[0]["EIIN_RegistrationNo"].ToString();
                txtInstituteName.Text = dt.Rows[0]["InstituteName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();
                CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Con_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                (ddlInstitutionType.SelectedValue) = dt.Rows[0]["InstituteTypeId"].ToString();
            }
        }
    }
}