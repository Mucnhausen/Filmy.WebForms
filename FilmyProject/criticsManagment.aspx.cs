using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace FilmyProject
{
    public partial class criticsManagment : System.Web.UI.Page
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
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                updateCritic();
                Response.Write("<script>alert('Critic updated successfully.');</script>");
                DataBind();
            }
            //SqlDataSource1.SelectCommand = "SELECT r.ID AS review_id, m.title AS movie_title, m.description AS movie_description " +
            //   "FROM reviews_test r " +
            //   "JOIN movies_test m ON r.movie_id = m.ID " +
            //   "WHERE r.ID = 1";


        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                deleteCritic();
                Response.Write("<script>alert('Critic deleted successfully.');</script>");
                DataBind();
            }
        }

        protected void findBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                getCriticByUsername();
            }
        }
        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                if (ifCriticExists())
                {
                    string fileType = Path.GetFileName(FileUpload1.PostedFile.ContentType);
                    string previousPath = getPreviousPicturePath();
                    if (Path.GetExtension(previousPath) != fileType && Path.GetFileName(Path.GetDirectoryName(previousPath)) != "main_content")
                    {
                        File.Delete(Server.MapPath("\\") + previousPath);
                    }
                    string fileName = usernameBox.Text.Trim() + "." + Path.GetFileName(FileUpload1.PostedFile.ContentType);
                    string filePath = Server.MapPath("~/images/critics/") + fileName;
                    FileUpload1.SaveAs(filePath);
                    updateCriticImage("images/critics/" + fileName);
                    DataBind();
                    Response.Write("<script>alert('Photo uploaded successfully');</script>");
                } else { Response.Write("<script>alert('Username does not exist.');</script>"); }
        }
        void updateCriticImage(String file_path)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE critics SET image_path=@image_path WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@image_path", file_path);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM critics WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
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
                    first_nameBox.Text = reader["first_name"].ToString();
                    last_nameBox.Text = reader["last_name"].ToString();
                    emailBox.Text = reader["email"].ToString();
                    birth_dateBox.Text = DateTime.Parse(reader["birth_date"].ToString()).ToString("yyyy-MM-dd");
                    countryBox.Text = reader["country"].ToString();
                    phoneBox.Text = reader["tel"].ToString();
                    descriptionBox.Text = reader["description"].ToString();
                    pendingBox.Text = reader["pending"].ToString();

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

        void updateCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE critics SET first_name=@first_name, last_name=@last_name, birth_date=@birth_date, country=@country, tel=@tel, email=@email, description=@description, image_path=@image_path, pending=@pending WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@first_name", first_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", last_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@birth_date", DateTime.Parse(birth_dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@country", countryBox.Text.Trim());
                cmd.Parameters.AddWithValue("@tel", phoneBox.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.Trim());
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
                cmd.Parameters.AddWithValue("@image_path", "images\\main_content\\critic_default.png");
                cmd.Parameters.AddWithValue("@pending", pendingBox.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM critics WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
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
            first_nameBox.Text = "";
            last_nameBox.Text = "";
            usernameBox.Text = "";
            birth_dateBox.Text = "";
            countryBox.Text = "";
            phoneBox.Text = "";
            descriptionBox.Text = "";
            pendingBox.Text = "";
        }


    }
}