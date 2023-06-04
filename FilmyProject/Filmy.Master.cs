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
                ExitLink.Visible = false;

                NameLabel.Visible = false; NameLabel.Text = null;

                Admin_loginLink.Visible = true;
                Reviews_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
                Critics_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
                Movies_managmentLink.Visible = false;

                OwnProfile_Link.Visible = false;
                OwnReviews_Link.Visible = false;
            }
            else if (Session["role"].ToString() == "critic")
            {
                LoginLink.Visible = false;
                SigninLink.Visible = false;
                ExitLink.Visible = true;

                NameLabel.Visible = true; NameLabel.Text = "Welcome " + Session["username"];

                Admin_loginLink.Visible = false;
                Reviews_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
                Critics_managmentLink.Visible = false;
                Critics_applicationsLink.Visible = false;
                Movies_managmentLink.Visible = false;

                OwnProfile_Link.Visible = true;
                OwnReviews_Link.Visible = true;
            }
            else if (Session["role"].ToString() == "admin")
            {
                LoginLink.Visible = false;
                SigninLink.Visible = false;
                ExitLink.Visible = true;

                NameLabel.Visible = true; NameLabel.Text = "ADMIN: " + Session["username"];

                Admin_loginLink.Visible = false;
                Reviews_managmentLink.Visible = true;
                Critics_applicationsLink.Visible = true;
                Critics_managmentLink.Visible = true;
                Critics_applicationsLink.Visible = true;
                Movies_managmentLink.Visible = true;

                OwnProfile_Link.Visible = false;
                OwnReviews_Link.Visible = false;
            }
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void SigninLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("signin.aspx");
        }

        protected void ExitLink_Click(object sender, EventArgs e)
        {
            Session["role"] = "visitor"; Session["username"] = "Unknown";
            Response.Redirect("index.aspx");
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["role"] = "visitor";
            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["role"] = "critic";
            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["role"] = "admin";
            Response.Redirect(Request.RawUrl);
        }

        protected void OwnProfile_Link_Click(object sender, EventArgs e)
        {
            Response.Redirect("criticsProfile.aspx");
        }

        protected void OwnReviews_Link_Click(object sender, EventArgs e)
        {
            Response.Redirect("criticsOwnReviews.aspx");
        }

        protected void Movies_managmentLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("moviesManagment.aspx");
        }
    }
}