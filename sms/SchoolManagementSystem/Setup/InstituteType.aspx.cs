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
    
    public partial class InstituteType : System.Web.UI.Page
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

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getInstituteTypeInfo();
            if (dt.Rows.Count > 0)
            {
                gvInstituteType.DataSource = dt;
                gvInstituteType.DataBind();
            }
            else
            {
                gvInstituteType.DataSource = null;
                gvInstituteType.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_InstituteTypeInfo(1, txtInstituteTypeName.Text, int.Parse(Session["UserId"].ToString()), int.Parse(ddlIsActive.SelectedValue), 0);
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }

            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_InstituteTypeInfo(2, txtInstituteTypeName.Text, int.Parse(Session["UserId"].ToString()), int.Parse(ddlIsActive.SelectedValue), int.Parse(hdnUpdateInstituteTypeId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtInstituteTypeName.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }
        protected void gvInstituteType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnInstituteTypeId = (HiddenField)gvInstituteType.Rows[rowIndex].FindControl("hdnInstituteTypeId");
            Label lblInstituteType = (Label)gvInstituteType.Rows[rowIndex].FindControl("lblInstituteType");

            if (e.CommandName == "editc")
            {
                hdnUpdateInstituteTypeId.Value = hdnInstituteTypeId.Value;
                txtInstituteTypeName.Text = lblInstituteType.Text;
                ddlIsActive.SelectedValue = ddlIsActive.SelectedValue;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_InstituteTypeInfo(3, lblInstituteType.Text, int.Parse(Session["UserId"].ToString()), int.Parse(ddlIsActive.SelectedValue), int.Parse(hdnInstituteTypeId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}