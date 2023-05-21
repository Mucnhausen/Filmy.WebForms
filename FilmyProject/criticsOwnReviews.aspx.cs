using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class criticsOwnReviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "admin" || Session["role"].ToString() == "visitor")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }
    }
}