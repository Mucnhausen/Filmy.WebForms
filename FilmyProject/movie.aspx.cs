using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class movie : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ifMovieExists())
            {
                getMovieById();
            }
            else { Response.Write("No such movie found"); Response.End(); }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
                          
        }
        bool ifMovieExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from movies where Id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }
        void getMovieById()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM movies WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    title.Text = reader["movie_name"].ToString();
                    genres.Text = reader["genres"].ToString();
                    actors.Text = reader["actors"].ToString();
                    producers.Text = reader["producers"].ToString();
                    date.Text = DateTime.Parse(reader["date"].ToString()).ToString("yyyy-MM-dd");
                    string rating = reader["rating"].ToString();
                    starRating(Int32.Parse(rating));

                    budget.Text = reader["budget"].ToString();
                    review_text.Text = reader["description"].ToString();
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

        void starRating(int rating)
        {
            int full_stars = rating / 2;
            bool half_stars = false;
            int modifier = 0;
            if (rating % 2 != 0) { half_stars = true; modifier = 1; }

            // Find the placeholder span element
            HtmlGenericControl starsPlaceholder = container.FindControl("starsPlaceholder") as HtmlGenericControl;
            for (int i = 0; i < full_stars; i++)
            {
                HtmlGenericControl star = new HtmlGenericControl("span");
                star.Attributes["class"] = "fa fa-star checked";
                starsPlaceholder.Controls.Add(star);
            }
            if (half_stars)
            {
                HtmlGenericControl half_star = new HtmlGenericControl("span");
                half_star.Attributes["class"] = "fa fa-star-half-stroke checked";
                starsPlaceholder.Controls.Add(half_star);

            }

            for (int i = full_stars; i < 5 - modifier; i++)
            {
                HtmlGenericControl star = new HtmlGenericControl("span");
                star.Attributes["class"] = "fa fa-star fa-regular";
                starsPlaceholder.Controls.Add(star);

            }
        }
    }
}