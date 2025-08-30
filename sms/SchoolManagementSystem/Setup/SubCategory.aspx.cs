using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace SchoolManagementSystem.Setup
{
    public partial class SubCategory : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlCategory, "SELECT  CategoryId, Category FROM dbo.Site_Category ORDER BY Category", "Category", "CategoryId");
                btnSave.Text = "Save";
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getSubCategoryInfo();
            if (dt.Rows.Count>0)
            {
                gvSubCategory.DataSource = dt;
                gvSubCategory.DataBind();
            }
            else
            {
                gvSubCategory.DataSource = null;
                gvSubCategory.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "0" && txtSubCategory.Text!="")
            {
                if (btnSave.Text == "Save")
                {
                    int Save = objSetup.InsertUpdateDelete_SubCategoryInfo(1, int.Parse(ddlCategory.SelectedValue), txtSubCategory.Text, int.Parse(Session["UserId"].ToString()), 0);
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Save done";
                        LoadGrid();
                    }

                }
                else if (btnSave.Text == "Update")
                {
                    int Save = objSetup.InsertUpdateDelete_SubCategoryInfo(2, int.Parse(ddlCategory.SelectedValue), txtSubCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateSubCatId.Value));
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Update done";
                        LoadGrid();
                        txtSubCategory.Text = "";
                        btnSave.Text = "Save";

                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "Give correct information";
            }

        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdncatId = (HiddenField)gvSubCategory.Rows[rowIndex].FindControl("hdncatId");
            HiddenField hdnSubcatId = (HiddenField)gvSubCategory.Rows[rowIndex].FindControl("hdnSubcatId");
            Label lblSubCategory = (Label)gvSubCategory.Rows[rowIndex].FindControl("lblSubCategory");

            if (e.CommandName=="editc")
            {
                ddlCategory.SelectedValue = hdncatId.Value;
                hdnUpdateSubCatId.Value = hdnSubcatId.Value;
                txtSubCategory.Text = lblSubCategory.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_SubCategoryInfo(3,1, lblSubCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnSubcatId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}