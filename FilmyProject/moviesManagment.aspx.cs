using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                if (ifMovieExists())
                {
                    string fileType = Path.GetFileName(FileUpload1.PostedFile.ContentType);
                    string previousPath = getPreviousPicturePath();
                    if (Path.GetExtension(previousPath) != fileType && Path.GetFileName(Path.GetDirectoryName(previousPath)) != "main_content")
                    {
                        File.Delete(Server.MapPath("\\") + previousPath);
                    }
                    string fileName = idBox.Text.Trim() + "." + Path.GetFileName(FileUpload1.PostedFile.ContentType);
                    string filePath = Server.MapPath("~/images/movies/") + fileName;
                    FileUpload1.SaveAs(filePath);
                    updateMovieImage("images/movies/" + fileName);
                    DataBind();
                    displayToast("success", "Picture", "Movie poster updated successfully.");
                }
                else { displayToast("error", "Movie", "Movie ID does not match any movie."); }
        }
        void updateMovieImage(String file_path)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE movies SET image_path=@image_path WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@image_path", file_path);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        String getPreviousPicturePath()
        {
            try
            {
                String path = null;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM movies WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    path = reader["image_path"].ToString();
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
                return path;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); return null;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO movies(movie_name,date,genres,actors,producers,rating,description,budget,image_path) " +
                    "values(@title,@date,@genres,@actors,@producers,@rating,@description,@budget,@image_path)", con);
                cmd.Parameters.AddWithValue("@title", titleBox.Text.Trim());
                cmd.Parameters.AddWithValue("@genres", genresBox.Text.Trim());
                cmd.Parameters.AddWithValue("@actors", actorsBox.Text.Trim());
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@producers", producersBox.Text.Trim());
                cmd.Parameters.AddWithValue("@rating", ratingBox.Text.Trim());
                cmd.Parameters.AddWithValue("@budget", budgetBox.Text.Trim());
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
                cmd.Parameters.AddWithValue("@image_path", "images/main_content/default_movie.jpg");
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