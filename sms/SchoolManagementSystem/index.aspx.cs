using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            infoH1.InnerText = "Welcome!";
            infoa1.InnerText = "The Best School";
           // imgSlider1.Src = "~/assets/img/users/cancel.png";
            imgS1.ImageUrl = "~/assets/site/images/2.png";
        }
    }
}