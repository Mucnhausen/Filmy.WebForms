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
    public partial class criticsApplications : System.Web.UI.Page
    {
        // Establishing a connection to the database using the connection string from the configuration file
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if the user's role is "critic" or "visitor" and preventing access if it is
            if (Session["role"].ToString() == "critic" || Session["role"].ToString() == "visitor")
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

        protected void findBtn_Click(object sender, EventArgs e)
        {
            // Checking if the critic exists
            if (ifCriticExists())
            {
                // Retrieving critic information if they exist
                getCriticByUsername();
            }
            else
            {
                // Displaying an error toast notification if the critic does not exist
                displayToast("error", "Username", "Username does not match any registered critic.");
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            // Accepting the critic
            acceptCritic();
            // Refreshing the GridView
            GridView1.DataBind();
            // Clearing the form
            clearForm();
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            // Declining the critic
            declineCritic();
            // Refreshing the GridView
            GridView1.DataBind();
            // Clearing the form
            clearForm();
        }

        // Function to check if the critic exists
        bool ifCriticExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from critics where username = @username AND pending = 'processing'", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
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
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Setting the text of various text boxes with the critic's information
                    first_nameBox.Text = reader["first_name"].ToString();
                    last_nameBox.Text = reader["last_name"].ToString();
                    emailBox.Text = reader["email"].ToString();
                    birth_dateBox.Text = DateTime.Parse(reader["birth_date"].ToString()).ToString("yyyy-MM-dd");
                    countryBox.Text = reader["country"].ToString();
                    phoneBox.Text = reader["tel"].ToString();
                    descriptionBox.Text = reader["description"].ToString();
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

        // Function to accept the critic
        void acceptCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE critics SET pending = 'active' WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();

                // Displaying a success toast notification
                displayToast("success", "Critic", "Critic accepted successfully.");
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Function to decline the critic
        void declineCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM critics WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();

                // Displaying a warning toast notification
                displayToast("warning", "Critic", "Critic declined successfully.");
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Function to clear the form
        void clearForm()
        {
            emailBox.Text = "";
            first_nameBox.Text = "";
            last_nameBox.Text = "";
            usernameBox.Text = "";
            birth_dateBox.Text = "";
            countryBox.Text = "";
            phoneBox.Text = "";
            descriptionBox.Text = "";
        }
    }
}
