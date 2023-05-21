using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class Filmy : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(DropDownList1.SelectedValue);
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void SigninLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("signin.aspx");
        }

        protected void Admin_loginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void Reviews_managmentLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("reviewsManagment.aspx");
        }

        protected void Critics_managmentLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("criticsManagment.aspx");
        }

        protected void Critics_applicationsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("criticsApplications.aspx");
        }
    }
}