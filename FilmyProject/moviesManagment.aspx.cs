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

    public partial class moviesManagment : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr.info('Custom message', 'Custom Title', { timeOut: 5000 , progressBar: true , newestOnTop: true });", true);

            if (Session["role"].ToString() == "visitor" || Session["role"].ToString() == "critic")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
            DataBind();
        }
        void displayToast(String type, String title, String message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        protected void findBtn_Click(object sender, EventArgs e)
        {
            if (ifMovieExists())
            {
                getMovieById();
            } else {
                displayToast("error", "Movie ID", "Movie ID does not match any movie.");
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (ifTitleExists())
            {
                displayToast("error", "Movie Title", "Movie Title already exists.");
            }
            else
            {
                addNewMovie();
                clearForm();
                displayToast("successfull", "Movie ID", "Movie added successfully.");
                DataBind();
                
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (ifMovieExists())
            {
                updateMovie();
                displayToast("success", "Movie ID", "Movie updated successfully.");
                DataBind();

            } else {
                displayToast("error", "Movie ID", "Movie ID does not match any movie.");
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (ifMovieExists())
            {
                deleteMovie();
                clearForm();
                displayToast("warning", "Movie ID", "Movie deleted successfully.");
                DataBind();
            }
            else
            {
                displayToast("error", "Movie ID", "Movie ID does not match any movie.");
            }
        }
        void getMovieById()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM movies WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    titleBox.Text = reader["movie_name"].ToString();
                    genresBox.Text = reader["genres"].ToString();
                    actorsBox.Text = reader["actors"].ToString();
                    producersBox.Text = reader["producers"].ToString();
                    dateBox.Text = DateTime.Parse(reader["date"].ToString()).ToString("yyyy-MM-dd");
                    ratingBox.Text = reader["rating"].ToString();
                    budgetBox.Text = reader["budget"].ToString();
                    descriptionBox.Text = reader["description"].ToString();

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

        bool ifMovieExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from movies where Id = @id", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", idBox.Text.Trim());
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }

        bool ifTitleExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from movies where movie_name = @title", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@title", titleBox.Text.Trim());
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }
        void addNewMovie()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO movies(movie_name,date,genres,actors,producers,rating,description,budget) " +
                    "values(@title,@date,@genres,@actors,@producers,@rating,@description,@budget)", con);
                cmd.Parameters.AddWithValue("@title", titleBox.Text.Trim());
                cmd.Parameters.AddWithValue("@genres", genresBox.Text.Trim());
                cmd.Parameters.AddWithValue("@actors", actorsBox.Text.Trim());
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@producers", producersBox.Text.Trim());
                cmd.Parameters.AddWithValue("@rating", ratingBox.Text.Trim());
                cmd.Parameters.AddWithValue("@budget", budgetBox.Text.Trim());
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateMovie()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE movies SET movie_name=@title, genres=@genres, actors=@actors, producers=@producers, description=@description, date=@date, rating=@rating, budget=@budget WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                cmd.Parameters.AddWithValue("@title", titleBox.Text.Trim());
                cmd.Parameters.AddWithValue("@genres", genresBox.Text.Trim());
                cmd.Parameters.AddWithValue("@actors", actorsBox.Text.Trim());
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@producers", producersBox.Text.Trim());
                cmd.Parameters.AddWithValue("@rating", ratingBox.Text.Trim());
                cmd.Parameters.AddWithValue("@budget", budgetBox.Text.Trim());
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteMovie()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM movies WHERE Id = @id", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
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
            titleBox.Text = "";
            idBox.Text = "";
            dateBox.Text = "";
            budgetBox.Text = "";
            ratingBox.Text = "";
            genresBox.Text = "";
            actorsBox.Text = "";
            producersBox.Text = "";
            descriptionBox.Text = "";
        }
    }
}