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
    public partial class Subject : System.Web.UI.Page
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
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_SubjectInfo(1, txtClass.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }

            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_SubjectInfo(2, txtClass.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateClsId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtClass.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getSubjectInfo();
            if (dt.Rows.Count > 0)
            {
                gvClass.DataSource = dt;
                gvClass.DataBind();
            }
            else
            {
                gvClass.DataSource = null;
                gvClass.DataBind();
            }
        }

        protected void gvClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnClsId = (HiddenField)gvClass.Rows[rowIndex].FindControl("hdnclsId");
            Label lblCategory = (Label)gvClass.Rows[rowIndex].FindControl("lblClass");

            if (e.CommandName == "editc")
            {
                hdnUpdateClsId.Value = hdnClsId.Value;
                txtClass.Text = lblCategory.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_SubjectInfo(3, lblCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnClsId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}