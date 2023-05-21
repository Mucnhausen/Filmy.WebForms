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
            if (Session["role"].ToString() == "visitor")
            {
                LoginLink.Visible = true;
                SigninLink.Visible = true;
                DropDownList1.Visible = false;

                Admin_loginLink.Visible = true;
                Reviews_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
                Critics_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
            }
            else if (Session["role"].ToString() == "critic")
            {
                LoginLink.Visible = false;
                SigninLink.Visible = false;
                DropDownList1.Visible = true;

                Admin_loginLink.Visible = false;
                Reviews_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
                Critics_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
            }
            else if (Session["role"].ToString() == "admin")
            {
                LoginLink.Visible = false;
                SigninLink.Visible = false;
                DropDownList1.Visible = false;

                Admin_loginLink.Visible = false;
                Reviews_managmentLink.Visible = true;
                Critics_applicationsLink.Visible = true;
                Critics_managmentLink.Visible = true;
                Critics_applicationsLink.Visible = true;
            }
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