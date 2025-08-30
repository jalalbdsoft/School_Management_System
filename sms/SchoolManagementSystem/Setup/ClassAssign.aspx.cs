using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class SubjectAssign : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlClassName, "SELECT  ClassId, ClassName FROM dbo.Con_Class ORDER BY ClassName", "ClassName", "ClassId");
            CommonDAL.ddlLoad(ddlSubjectName, "SELECT  SubjectId, SubjectName FROM dbo.Con_Subject ORDER BY SubjectName", "SubjectName", "SubjectId");
            CommonDAL.ddlLoad(ddlTeacherName, "SELECT EmployeeId, FirstName + ' ' + LastName AS FullName FROM EmployeeInfo WHERE(EmployeeType = 'Teacher')", "FullName", "EmployeeId");
            LoadGrid();

        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getClassAssignInfo();
            if (dt.Rows.Count > 0)
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
            if (ddlClassName.SelectedValue != "0")
            {
                if (btnSave.Text == "Save")
                {
                    int Save = objSetup.InsertUpdateDelete_ClassAssignInfo(1, int.Parse(ddlClassName.SelectedValue), int.Parse(ddlSubjectName.SelectedValue), int.Parse(ddlTeacherName.SelectedValue),txtStartTime.Text,txtEndTime.Text,  int.Parse(Session["UserId"].ToString()),true, 0);
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Save done";
                        LoadGrid();
                    }

                }
                else if (btnSave.Text == "Update")
                {
                    int Save = objSetup.InsertUpdateDelete_ClassAssignInfo(2, int.Parse(ddlClassName.SelectedValue), int.Parse(ddlSubjectName.SelectedValue), int.Parse(ddlTeacherName.SelectedValue), txtStartTime.Text, txtEndTime.Text, int.Parse(Session["UserId"].ToString()), true, 0);
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Update done";
                        LoadGrid();
                        
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
            HiddenField hdnClassAssignId = (HiddenField)gvSubCategory.Rows[rowIndex].FindControl("hdnClassAssignId");
            
            //if (e.CommandName == "editc")
            //{
            //    ddlSubjectName.SelectedValue = hdncatId.Value;
            //    hdnUpdateSubCatId.Value = hdnSubcatId.Value;
            //    ddlClassName.SelectedValue = lblSubCategory.Text;
            //    btnSave.Text = "Update";
            //}
            //else if (e.CommandName == "deletec")
            //{
            //    int delete = objSetup.InsertUpdateDelete_ClassAssignInfo(3, 1, lblSubCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnSubcatId.Value));
            //    if (delete > 0)
            //    {
            //        rmMsg.SuccessMessage = "delete done";
            //        LoadGrid();
            //    }
            //}
        }
    }

       
    }


