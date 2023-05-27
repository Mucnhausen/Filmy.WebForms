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
using static System.Net.Mime.MediaTypeNames;

namespace FilmyProject
{
    public partial class criticsProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCriticData();
            }
            if (Session["role"].ToString() == "visitor" || Session["role"].ToString() == "admin")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileType = Path.GetFileName(FileUpload1.PostedFile.ContentType);
                string previousPath = getPreviousPicturePath();
                if (Path.GetExtension(previousPath) != fileType)
                {
                    File.Delete(Server.MapPath("\\") + previousPath);
                }
                string fileName = Session["username"] + "." + Path.GetFileName(FileUpload1.PostedFile.ContentType);
                string filePath = Server.MapPath("~/images/critics/") + fileName;
                FileUpload1.SaveAs(filePath);
                updateCriticImage("images/critics/" + fileName);
                Image1.ImageUrl = "images/critics/" + fileName;
                Response.Write("<script>alert('Photo uploaded successfully');</script>");
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            updateCritic();
            FillCriticData();
            Response.Write("<script>alert('Info updated successfully');</script>");
        }

        void updateCriticImage(String file_path)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE critics SET image_path=@image_path WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@image_path", file_path);
                cmd.Parameters.AddWithValue("@username", Session["username"]);
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
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
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

        void FillCriticData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM critics WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    first_nameBox.Text = reader["first_name"].ToString();
                    last_nameBox.Text = reader["last_name"].ToString();
                    emailBox.Text = reader["email"].ToString();
                    usernameBox.Text = Session["username"].ToString();
                    birth_dateBox.Text = DateTime.Parse(reader["birth_date"].ToString()).ToString("yyyy-MM-dd");
                    countryBox.Text = reader["country"].ToString();
                    phoneBox.Text = reader["tel"].ToString();
                    descriptionBox.Text = reader["description"].ToString();
                    
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

        void updateCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE critics SET first_name=@first_name, last_name=@last_name, birth_date=@birth_date, country=@country, tel=@tel, email=@email, description=@description WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@first_name", first_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", last_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@birth_date", DateTime.Parse(birth_dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@country", countryBox.Text.Trim());
                cmd.Parameters.AddWithValue("@tel", phoneBox.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.Trim());
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
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