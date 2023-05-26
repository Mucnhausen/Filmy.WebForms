using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace FilmyProject
{
    public partial class adminLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "admin")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (ifAdminCredentialsCorrect())
            {
                Session["username"] = usernameBox.Text.Trim(); Session["role"] = "admin";
                Response.Redirect("index.aspx");
            } else { Response.Write("<script>alert('Username or password does not match any registrated user.');</script>"); }
        }
        bool ifAdminCredentialsCorrect()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM admins WHERE username = @username AND password = @password", con))
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