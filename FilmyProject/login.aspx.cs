﻿using System;
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
            // Check if the user has the role of "admin" or "critic" and restrict access to the page
            if (Session["role"].ToString() == "admin" || Session["role"].ToString() == "critic")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        // Function to display a toast notification
        void displayToast(String type, String title, String message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        protected void password_resetLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("passwordReset.aspx");
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            // Check if the provided credentials are correct for a critic
            if (ifCriticCredentialsCorrect())
            {
                Session["username"] = usernameBox.Text;
                Session["role"] = "critic";
                Response.Redirect("index.aspx");
            }
            else
            {
                displayToast("error", "Username or password", "Username or password does not match any registered critic.");
            }
        }

        bool ifCriticCredentialsCorrect()
        {
            try
            {
                // Check if the username and password match any entry in the critics table
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM critics WHERE username = @username AND password = @password", con))
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
                Response.Write("<script>alert('An error occurred. Try later \n " + ex.Message + " ');</script>");
                return false;
            }
        }
    }
}
