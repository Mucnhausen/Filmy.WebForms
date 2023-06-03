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
    public partial class critic : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                getCriticByUsername();
            } else { Response.Write("No such critic found"); Response.End(); }
        }
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
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }
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
                    username.Text = reader["username"].ToString();
                    first_name.Text = reader["first_name"].ToString();
                    last_name.Text = reader["last_name"].ToString();
                    email.Text = reader["email"].ToString();
                    phone.Text = reader["tel"].ToString();
                    country.Text = reader["country"].ToString();
                    birth_date.Text = DateTime.Parse(reader["birth_date"].ToString()).ToString("yyyy-MM-dd");
                    reg_date.Text = DateTime.Parse(reader["reg_date"].ToString()).ToString("yyyy-MM-dd");
                    description.Text = reader["description"].ToString();
                    pending.Text = reader["pending"].ToString();
                    articles.Text = reader["articles"].ToString();
                    Image1.ImageUrl = reader["image_path"].ToString();

                    // Use the retrieved data as needed (e.g., display it in your ASP.NET Web Forms page)
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}