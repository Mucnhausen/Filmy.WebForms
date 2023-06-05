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
        // Establishing a connection to the database using the connection string from the configuration file
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if the user's role is "admin" and preventing access if it is
            if (Session["role"].ToString() == "admin")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        // Function to display a toast notification using the Toastr library
        void displayToast(String type, String title, String message)
        {
            // Registering a startup script to display the toast notification
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            // Checking if the admin credentials are correct
            if (ifAdminCredentialsCorrect())
            {
                // Storing the username and role in session variables
                Session["username"] = usernameBox.Text.Trim();
                Session["role"] = "admin";
                // Redirecting to the index page
                Response.Redirect("index.aspx");
            }
            else
            {
                // Displaying an error toast notification if the credentials are incorrect
                displayToast("error", "Username or password", "Username or password does not match any registered critic.");
            }
        }

        // Function to check if the admin credentials are correct
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
                    if (userCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs
                Response.Write("<script>alert('An error occurred. Try again later \n " + ex.Message + " ');</script>");
                return false;
            }
        }
    }
}
