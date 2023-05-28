using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class signin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "admin" || Session["role"].ToString() == "critic")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }
        void displayToast(String type, String title, String message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                displayToast("error", "Username", "This username is already taken.");
            }
            else
            {
                addNewCritic();
                displayToast("success" , "SIGN IN", "You are successfully signed in.");
                sendSuccessSignInEmail();
                clearForm();
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

        void addNewCritic()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO critics(username,first_name,last_name,reg_date,birth_date,country,tel,email,articles,description,image_path,password, pending) " +
                    "values(@username,@first_name,@last_name,@reg_date,@birth_date,@country,@tel,@email,@articles,@description,@image_path,@password, @pending)", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@first_name", first_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", last_nameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@birth_date", DateTime.Parse(birth_dateBox.Text.Trim()).ToString("dd\\/MM\\/yyyy"));
                cmd.Parameters.AddWithValue("@country", countryBox.Text.Trim());
                cmd.Parameters.AddWithValue("@tel", phoneBox.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.Trim());
                cmd.Parameters.AddWithValue("@articles", 0);
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.Trim());
                cmd.Parameters.AddWithValue("@image_path", "images\\main_content\\critic_default.png");
                cmd.Parameters.AddWithValue("@password", passwordBox.Text.Trim());
                cmd.Parameters.AddWithValue("@pending", "processing");
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
            passwordBox.Text = "";
            first_nameBox.Text = "";
            last_nameBox.Text = "";
            usernameBox.Text = "";
            birth_dateBox.Text = "";
            countryBox.Text = "";
            phoneBox.Text = "";
            descriptionBox.Text = "";
        }


        void sendSuccessSignInEmail()
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Filmy Community Help Center", "filmy.community.help@gmail.com"));
            message.To.Add(new MailboxAddress(usernameBox.Text.Trim(), emailBox.Text.Trim()));

            message.Subject = "Welcome, " + first_nameBox.Text.Trim();

            message.Body = new TextPart("html")
            {
                Text = "<!DOCTYPE html><html><head>  <meta charset=\"UTF-8\">  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Welcome to our site!</title>  <style>    /* Global CSS styles */    body {      font-family: Arial, sans-serif;      background-color: #f5f5f5;    }    /* Container styles */    .container {      max-width: 600px;      margin: 0 auto;      padding: 20px;      background-color: #f2eaff;      border-radius: 5px;      box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);    }    /* Heading styles */    h1 {      color: #3a256d;      margin-top: 0;      text-align: center;    }    /* Content styles */    p {      color: #5d487f;      line-height: 1.5;    }    /* Button styles */    .button {      display: inline-block;      padding: 10px 20px;      background-color: #693ba3;      color: #ffffff;      text-decoration: none;      border-radius: 4px;    }    /* Footer styles */    .footer {      text-align: center;      margin-top: 20px;      color: #999999;    }  </style></head><body>  <div class=\"container\">    <h1>Welcome to Filmy!</h1>    <p>Dear " + first_nameBox.Text.Trim() + " ,</p>    <p>Thank you for registering on our site. We are thrilled to have you as a part of our community of movie enthusiasts!</p>    <p>As a registered movie critic, you'll have the opportunity to share your valuable reviews with our audience.</p>    <p>Start exploring our site today and let us know if you have any questions or need assistance. We're here to help!</p>    <p>      <a style=\"color: white\" class=\"button\" href=\"mailto:filmy.community.help@gmail.com?subject=" + usernameBox.Text.Trim() + "&body={Describe the encountered problem}\">Ask for support</a>    </p>    <div class=\"footer\">      <p>Best regards,</p>      <p>The Filmy Team</p>    </div>  </div></body></html>"
            };


            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("filmy.community.help@gmail.com", "doadkcgpdoymsyjh");
                client.Send(message);
            }
            catch (Exception ex) { Response.Write("<script>alert(' " + ex.Message + " ');</script>"); }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}