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
        // Establish a connection to the database using the connection string from the configuration file
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check the user's role and restrict access for critics and visitors
            if (Session["role"].ToString() == "visitor" || Session["role"].ToString() == "critic")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
            DataBind(); // Bind data to the controls on page load
        }

        // Method to display toast notifications
        void displayToast(String type, String title, String message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                updateCritic();
                displayToast("success", "Critic", "Critic updated successfully.");
                DataBind();
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                deleteCritic();
                displayToast("warning", "Critic", "Critic deleted successfully.");
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
            {
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
                    displayToast("success", "Picture", "Critic picture updated successfully.");
                }
                else
                {
                    displayToast("error", "Username", "Username does not match any registered critic.");
                }
            }
        }

        // Method to update the critic's image path in the database
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

        // Method to retrieve the previous picture path of the critic from the database
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return null;
            }
        }

        // Method to retrieve critic information from the database based on the provided username
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
                    // Set the values of the controls with the retrieved data
                    first_nameBox.Text = reader["first_name"].ToString();
                    last_nameBox.Text = reader["last_name"].ToString();
                    emailBox.Text = reader["email"].ToString();
                    birth_dateBox.Text = DateTime.Parse(reader["birth_date"].ToString()).ToString("yyyy-MM-dd");
                    countryBox.Text = reader["country"].ToString();
                    phoneBox.Text = reader["tel"].ToString();
                    descriptionBox.Text = reader["description"].ToString();
                    pendingBox.Text = reader["pending"].ToString();
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

        // Check if a critic exists in the database based on the provided username
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
                    if (userCount > 0)
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
                Response.Write("<script>alert('An error occurred. Try later \n " + ex.Message + " ');</script>");
                return false;
            }
        }

        // Method to update the critic's information in the database
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

        // Method to delete a critic from the database
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

        // Method to clear the form's input fields
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
