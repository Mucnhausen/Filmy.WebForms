using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class review : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ifReviewExists())
            {
                getReviewById();
            }
            else { Response.Write("No such review found"); Response.End(); }
        }
        bool ifReviewExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from reviews where Id = @id", con))
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
        void getReviewById()
        {
            try
            {
                string movie_id = null;
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * from reviews where Id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        username.Text = reader["critic_username"].ToString();
                        review_text.Text = reader["review_text"].ToString();
                        movie_id = reader["movie_id"].ToString();

                        review_publish_date.Text = DateTime.Parse(reader["date"].ToString()).ToString("dd MMMM yyyy");

                        // rating
                        int review_rating = Int32.Parse(reader["rating"].ToString());
                        starRating(review_rating, "starsPlaceholderREVIEW");
                    }

                    reader.Close();
                    con.Close();
                }
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * from critics where username = @username", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", username.Text.ToString());
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        first_name.Text = reader["first_name"].ToString();
                        last_name.Text = reader["last_name"].ToString();
                    }

                    reader.Close();
                    con.Close();
                }
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * from movies where id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", movie_id);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // rating
                        int movie_rating = Int32.Parse(reader["rating"].ToString());
                        starRating(movie_rating, "starsPlaceholderMOVIE");

                        title.Text = reader["movie_name"].ToString();
                        budget.Text = reader["budget"].ToString();
                        genres.Text = reader["genres"].ToString();
                        actors.Text = reader["actors"].ToString();
                        producers.Text = reader["producers"].ToString();

                        movie_publish_date.Text = DateTime.Parse(reader["date"].ToString()).ToString("dd MMMM yyyy");
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void starRating(int rating, string div)
        {
            int full_stars = rating / 2;
            bool half_stars = false;
            int modifier = 0;
            if (rating % 2 != 0) { half_stars = true; modifier = 1; }

            // Find the placeholder span element
            HtmlGenericControl starsPlaceholder = container.FindControl(div) as HtmlGenericControl;
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