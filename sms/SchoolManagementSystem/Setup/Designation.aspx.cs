using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class Designation : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Text = "Save";
                LoadGrid();
            }
            
        }

       protected void btnSave_Click(object sender, EventArgs e)
        {
            bool IsAct = chkIsActive.Checked == true? true:false;
            if (txtDesignaiton.Text != "")
            {
                if (btnSave.Text == "Save")
                {
                    int Save = objSetup.InsertUpdateDelete_DesignationInfo(1, txtDesignaiton.Text, int.Parse(Session["UserId"].ToString()), int.Parse(ddlPosition.SelectedValue) ,IsAct, 0);
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Save done";
                        LoadGrid();
                    }

                }
                else if (btnSave.Text == "Update")
                {
                    int Save = objSetup.InsertUpdateDelete_DesignationInfo(2, txtDesignaiton.Text, int.Parse(Session["UserId"].ToString()), int.Parse(ddlPosition.SelectedValue),IsAct, int.Parse(hdnUpdateDesignationId.Value));
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Update done";

                        txtDesignaiton.Text = "";
                        btnSave.Text = "Save";
                        LoadGrid();

                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "Give correct information";
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getDesignationInfo();
            if (dt.Rows.Count > 0)
            {
                gvDesignation.DataSource = dt;
                gvDesignation.DataBind();
            }
            else
            {
                gvDesignation.DataSource = null;
                gvDesignation.DataBind();
            }
        }

        protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDesignationId = (HiddenField)gvDesignation.Rows[rowIndex].FindControl("hdnDesignationId");
            Label lblDesignationName = (Label)gvDesignation.Rows[rowIndex].FindControl("lblDesignationName");
            Label lblPosition = (Label)gvDesignation.Rows[rowIndex].FindControl("lblPosition");
            CheckBox chkIsActive1  = (CheckBox)gvDesignation.Rows[rowIndex].FindControl("chkIsActive1");

            if (e.CommandName == "editc")
            {
                hdnUpdateDesignationId.Value = hdnDesignationId.Value;
                txtDesignaiton.Text = lblDesignationName.Text;
                ddlPosition.SelectedValue = lblPosition.Text;
                chkIsActive.Checked = chkIsActive1.Checked;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_DesignationInfo(3, lblDesignationName.Text, int.Parse(Session["UserId"].ToString()), int.Parse(ddlPosition.SelectedValue), true, int.Parse(hdnDesignationId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}