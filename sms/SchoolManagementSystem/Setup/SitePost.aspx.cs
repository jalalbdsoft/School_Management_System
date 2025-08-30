using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SchoolManagementSystem.Setup
{
    public partial class SitePost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlCategory, "SELECT  CategoryId, Category FROM dbo.Site_Category ORDER BY Category", "Category", "CategoryId");
                CommonDAL.ddlLoad(ddlSubCategory, "SELECT  SubCategoryId, SubCategory FROM dbo.Site_SubCategory ORDER BY SubCategory", "SubCategory", "SubCategoryId");
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "SELECT SubCategoryId, SubCategory FROM dbo.Site_SubCategory WHERE (CategoryId = " + ddlCategory.SelectedValue + ")";
            CommonDAL.ddlLoad(ddlSubCategory, str, "SubCategory", "SubCategoryId");
        }
    }
}