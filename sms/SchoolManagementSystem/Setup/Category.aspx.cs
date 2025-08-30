using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SchoolManagementSystem.Setup
{
    public partial class Category : System.Web.UI.Page
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
            dt = objSetup.Set_getCategoryInfo();
            if (dt.Rows.Count>0)
            {
                gvCategory.DataSource = dt;
                gvCategory.DataBind();
            }
            else
            {
                gvCategory.DataSource = null;
                gvCategory.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_CategoryInfo(1, txtCategory.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (Save>0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }
                
            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_CategoryInfo(2, txtCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateCatId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtCategory.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdncatId = (HiddenField)gvCategory.Rows[rowIndex].FindControl("hdncatId");
            Label lblCategory = (Label)gvCategory.Rows[rowIndex].FindControl("lblCategory");

            if (e.CommandName=="editc")
            {
                hdnUpdateCatId.Value = hdncatId.Value;
                txtCategory.Text = lblCategory.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_CategoryInfo(3, lblCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdncatId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}