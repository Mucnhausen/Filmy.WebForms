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
    //SqlDataSource1.SelectCommand = "SELECT r.ID AS review_id, m.title AS movie_title, m.description AS movie_description " +
    //   "FROM reviews_test r " +
    //   "JOIN movies_test m ON r.movie_id = m.ID " +
    //   "WHERE r.ID = 1";
    public partial class criticsOwnReviews : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "admin" || Session["role"].ToString() == "visitor")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
            GridView1.DataBind();
            //SqlDataSource1.SelectCommand = $"SELECT * FROM reviews WHERE critic_username = \" {Session["username"]} \"";
            //SqlDataSource1.SelectCommand = $"SELECT * FROM reviews WHERE critic_username = \"" + Session["username"] + "\"";
            //string.Format("Number: {0:N}", 157);

        }
        void displayToast(String type, String title, String message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }
        protected void findBtn_Click(object sender, EventArgs e)
        {
            if (ifReviewExists())
            {
                getReviewById();
            }
            else { displayToast("error", "Review ID", "Review ID does not match any review."); }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticIsApproved())
            {
                    if (ifCriticIsApproved())
                    {
                        addNewReview();
                        clearForm();
                    displayToast("success", "Review", "Review updated successfully.");
                    GridView1.DataBind();
                    } else { displayToast("error", "Review ID", "Review ID does not match any review."); }
            } else { displayToast("error", "Approval", "You have not been approved yet to post reviews by Filmy Team. Please, wait."); }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticIsApproved())
            {
                if (ifReviewExists())
                {
                    updateReview();
                    GridView1.DataBind();
                    displayToast("success", "Review", "Review updated successfully.");
                } else { displayToast("error", "Review ID", "Review ID does not match any review."); }
            } else { displayToast("error", "Approval", "You have not been approved yet to post reviews by Filmy Team. Please, wait."); }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticIsApproved())
            {
                    if (ifReviewExists())
                {
                    deleteReview();
                    GridView1.DataBind();
                    clearForm();
                    displayToast("warning", "Review", "Review deleted successfully.");
                } else { displayToast("error", "Review ID", "Review ID does not match any review."); }
            } else { displayToast("error", "Approval", "You have not been approved yet to post reviews by Filmy Team. Please, wait."); }
        }
        bool ifCriticIsApproved()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from critics where username = @username AND pending = 'active' ", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", Session["username"]);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0) { return true; } else { return false; }
                }

            }
            catch (Exception ex) { Response.Write("<script>alert('An error occured. Try later \n " + ex.Message + " ');</script>"); return false; }
        }
        bool ifReviewExists()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from reviews where Id = @id AND critic_username = @critic_username", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@id", idBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@critic_username", Session["username"]);
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
                string movie_id = "";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM reviews WHERE Id=@id AND critic_username = @critic_username", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                cmd.Parameters.AddWithValue("@critic_username", Session["username"]);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    movie_id = reader["movie_id"].ToString();
                    ratingBox.Text = reader["rating"].ToString();
                    reviewBox.Text = reader["review_text"].ToString();

                    // Use the retrieved data as needed (e.g., display it in your ASP.NET Web Forms page)
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM movies WHERE ID=@id", con);
                cmd2.Parameters.AddWithValue("@id", movie_id);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    DropDownList1.SelectedValue = reader2["movie_name"].ToString();
                }

                reader2.Close();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        int getMovieIDByTitle()
        {
            try
            {
                int id = -1;
                SqlCommand cmd = new SqlCommand("SELECT * FROM movies WHERE movie_name=@title", con);
                cmd.Parameters.AddWithValue("@title", DropDownList1.SelectedValue);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    id = Int32.Parse(reader["ID"].ToString());

                    // Use the retrieved data as needed (e.g., display it in your ASP.NET Web Forms page)
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message); return -1;
            }
        }
        void addNewReview()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO reviews(movie_id,critic_username,review_text,date,rating) " +
                    "values(@movie_id,@critic_username,@review_text,@date,@rating)", con);
                cmd.Parameters.AddWithValue("@critic_username", Session["username"]);
                cmd.Parameters.AddWithValue("@review_text", reviewBox.Text.Trim());
                cmd.Parameters.AddWithValue("@rating", ratingBox.Text.Trim());
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@movie_id", getMovieIDByTitle());
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateReview()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE reviews SET movie_id=@movie_id, review_text=@review_text, rating=@rating WHERE Id=@id AND critic_username = @critic_username", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_id", getMovieIDByTitle());
                cmd.Parameters.AddWithValue("@review_text", reviewBox.Text.Trim());
                cmd.Parameters.AddWithValue("@rating", ratingBox.Text.Trim());
                cmd.Parameters.AddWithValue("@critic_username", Session["username"]);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteReview()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM reviews WHERE Id = @id AND critic_username = @critic_username", con);
                cmd.Parameters.AddWithValue("@id", idBox.Text.Trim());
                cmd.Parameters.AddWithValue("@critic_username", Session["username"]);
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
            idBox.Text = "";
            reviewBox.Text = "";
            ratingBox.Text = "";
            DropDownList1.SelectedIndex = 0;
        }
    }
}
