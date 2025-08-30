using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.dashboard
{
    public partial class login : System.Web.UI.Page
    {
        AuthBLL objAuthBLL = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RememberMe();
            }
        }


        private void RememberMe()
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["Value"] = Request.Cookies["Password"].Value;
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Attributes["Value"] = "";

            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                DataTable dtloginInfo = new DataTable();
                dtloginInfo = objAuthBLL.ChekUserInfo(txtUsername.Text.Trim(), txtPassword.Text);

                if (dtloginInfo.Rows.Count > 0)
                {
                    Session["UserId"] = dtloginInfo.Rows[0]["UserId"].ToString();
                    Session["Username"] = dtloginInfo.Rows[0]["FullName"].ToString();
                    Session["UserImg"] = dtloginInfo.Rows[0]["UserImage"].ToString();
                    CreateCookie();
                    Response.Redirect("~/dashboard/admin-index.aspx");
                }
                else
                {
                    rmMsg.FailureMessage = "Incorrect Username or Password";

                }
            }

        }

        private void CreateCookie()
        {
            if (cbRemember.Checked)
            {

                HttpCookie auth = new HttpCookie("auth");
                auth["UserName"] = "";
                auth["Password"] = "";
                Response.Cookies.Add(auth);

                Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(30);

                Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();

            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);
            }


        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtUsername.Text == "")
            {
                rmMsg.FailureMessage = "Username can't be empty";
                txtUsername.Focus();
                IsReq = true;
            }
            else if (txtPassword.Text == "")
            {
                rmMsg.SuccessMessage = "Password can't be empty";
                txtPassword.Focus();
                IsReq = true;
            }

            return IsReq;

        }
    }
}