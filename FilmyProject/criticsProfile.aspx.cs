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

        // Function to display toast notification
        void displayToast(String type, String title, String message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileType = Path.GetFileName(FileUpload1.PostedFile.ContentType);
                string previousPath = getPreviousPicturePath();

                if (Path.GetExtension(previousPath) != fileType && Path.GetFileName(Path.GetDirectoryName(previousPath)) != "main_content")
                {
                    File.Delete(Server.MapPath("\\") + previousPath);
                }

                string fileName = Session["username"] + "." + Path.GetFileName(FileUpload1.PostedFile.ContentType);
                string filePath = Server.MapPath("~/images/critics/") + fileName;
                FileUpload1.SaveAs(filePath);
                updateCriticImage("images/critics/" + fileName);
                Image1.ImageUrl = "images/critics/" + fileName;
                displayToast("success", "Picture", "Critic picture updated successfully.");
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            updateCritic();
            FillCriticData();
        }

        protected void savePasswordBtn_Click(object sender, EventArgs e)
        {
            updateCriticPassword();
            FillCriticData();
        }

        // Function to update the critic image path in the database
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

        // Function to update the critic's password in the database
        void updateCriticPassword()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE critics SET password=@password WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@password", passwordBox.Text.Trim());
                cmd.Parameters.AddWithValue("@username", Session["username"]);
                cmd.ExecuteNonQuery();
                con.Close();

                displayToast("success", "Password", "Password updated successfully.");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Function to get the previous picture path of the critic from the database
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return null;
            }
        }

        // Function to fill the critic's data in the form
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
                    passwordBox.Attributes["value"] = reader["password"].ToString();
                    descriptionBox.Text = reader["description"].ToString();

                    Image1.ImageUrl = reader["image_path"].ToString();
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

        // Function to update the critic's information in the database
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

                displayToast("success", "Info", "Info updated successfully.");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
