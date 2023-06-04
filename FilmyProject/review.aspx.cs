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
        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the review exists
            if (ifReviewExists())
            {
                // If the review exists, retrieve and display its details
                getReviewById();
            }
            else
            {
                // If the review doesn't exist, display an error message and end the response
                Response.Write("No such review found");
                Response.End();
            }
        }

        // Method to check if a review exists in the database
        bool ifReviewExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from reviews where Id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    int reviewCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();

                    // Return true if the review count is greater than 0, indicating the review exists
                    if (reviewCount > 0)
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
                // Display an error message if an exception occurs
                Response.Write("<script>alert('An error occurred. Try again later. \n " + ex.Message + " ');</script>");
                return false;
            }
        }

        // Method to retrieve and display a review's details
        void getReviewById()
        {
            try
            {
                string movie_id = null;

                // Retrieve the review details from the database
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * from reviews where Id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display the critic's username and review text
                        username.Text = reader["critic_username"].ToString();
                        review_text.Text = reader["review_text"].ToString();
                        movie_id = reader["movie_id"].ToString();

                        // Display the review's publish date
                        review_publish_date.Text = DateTime.Parse(reader["date"].ToString()).ToString("dd MMMM yyyy");

                        // Get the review rating and display star rating icons
                        int review_rating = Int32.Parse(reader["rating"].ToString());
                        starRating(review_rating, "starsPlaceholderREVIEW");
                    }

                    reader.Close();
                    con.Close();
                }

                // Retrieve the critic's details from the database
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * from critics where username = @username", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", username.Text.ToString());
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display the critic's first name and last name
                        first_name.Text = reader["first_name"].ToString();
                        last_name.Text = reader["last_name"].ToString();
                    }

                    reader.Close();
                    con.Close();
                }

                // Retrieve the movie's details from the database
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * from movies where id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", movie_id);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Get the movie rating and display star rating icons
                        int movie_rating = Int32.Parse(reader["rating"].ToString());
                        starRating(movie_rating, "starsPlaceholderMOVIE");

                        // Display the movie's title, budget, genres, actors, producers, and publish date
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
                // Display an error message if an exception occurs
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Method to display star rating icons based on the rating value
        void starRating(int rating, string div)
        {
            int full_stars = rating / 2;
            bool half_stars = false;
            int modifier = 0;

            // Check if there is a half-star rating
            if (rating % 2 != 0)
            {
                half_stars = true;
                modifier = 1;
            }

            // Find the placeholder div for star ratings
            HtmlGenericControl starsPlaceholder = container.FindControl(div) as HtmlGenericControl;

            // Add full star icons based on the number of full stars
            for (int i = 0; i < full_stars; i++)
            {
                HtmlGenericControl star = new HtmlGenericControl("span");
                star.Attributes["class"] = "fa fa-star checked";
                starsPlaceholder.Controls.Add(star);
            }

            // Add a half star icon if applicable
            if (half_stars)
            {
                HtmlGenericControl half_star = new HtmlGenericControl("span");
                half_star.Attributes["class"] = "fa fa-star-half-stroke checked";
                starsPlaceholder.Controls.Add(half_star);
            }

            // Add empty star icons for the remaining space
            for (int i = full_stars; i < 5 - modifier; i++)
            {
                HtmlGenericControl star = new HtmlGenericControl("span");
                star.Attributes["class"] = "fa fa-star fa-regular";
                starsPlaceholder.Controls.Add(star);
            }
        }
    }
}
