using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class critic : System.Web.UI.Page
    {
        // Establishing a connection to the database using the connection string from the configuration file
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if the critic exists
            if (ifCriticExists())
            {
                // Retrieving critic information if they exist
                getCriticByUsername();
            }
            else
            {
                // Displaying a message if the critic does not exist
                Response.Write("No such critic found");
                Response.End();
            }
        }

        // Function to check if the critic exists
        bool ifCriticExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from critics where username = @username", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", Request.QueryString["username"]);
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

        // Function to retrieve critic information by username
        void getCriticByUsername()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM critics WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", Request.QueryString["username"]);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Setting the text of various labels with the critic's information
                    username.Text = reader["username"].ToString();
                    first_name.Text = reader["first_name"].ToString();
                    last_name.Text = reader["last_name"].ToString();
                    email.Text = reader["email"].ToString();
                    phone.Text = reader["tel"].ToString();
                    country.Text = reader["country"].ToString();
                    birth_date.Text = reader["birth_date"].ToString();
                    reg_date.Text = reader["reg_date"].ToString();
                    description.Text = reader["description"].ToString();
                    pending.Text = reader["pending"].ToString();
                    articles.Text = reader["articles"].ToString();
                    Image1.ImageUrl = reader["image_path"].ToString();
                }

                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
