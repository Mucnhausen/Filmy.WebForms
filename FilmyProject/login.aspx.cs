using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "admin" || Session["role"].ToString() == "critic")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        protected void password_resetLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("passwordReset.aspx");
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticCredentialsCorrect())
            {
                Session["username"] = usernameBox.Text; Session["role"] = "critic";
                Response.Redirect("index.aspx");
            } else {
                Response.Write("<script>alert('Username or password does not match any registrated user.');</script>");
            }
        }

        bool ifCriticCredentialsCorrect()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM critics WHERE username = @username AND password = @password", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@password", passwordBox.Text.Trim());
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }
    }
}