using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class signin : System.Web.UI.Page
    {
        //string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                Response.Write("<script>alert('The username is already taken!');</script>");
            }
            else
            {
                addNewCritic();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            clearForm();
        }

        bool ifCriticExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from critics where username = @username", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }

        void addNewCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO critics(username,first_name,last_name,reg_date,birth_date,country,tel,email,articles,description,image_path,password) " +
                    "values(@username,@first_name,@last_name,@reg_date,@birth_date,@country,@tel,@email,@articles,@description,@image_path,@password)", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@first_name", first_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", last_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@birth_date", DateTime.Parse(birth_dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@country", countryBox.Text.Trim());
                cmd.Parameters.AddWithValue("@tel", phoneBox.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.Trim());
                cmd.Parameters.AddWithValue("@articles", 0);
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
                cmd.Parameters.AddWithValue("@image_path", "images\\main_content\\critic_default.png");
                cmd.Parameters.AddWithValue("@password", passwordBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clearForm()
        {
            emailBox.Text = "";
            passwordBox.Text = "";
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