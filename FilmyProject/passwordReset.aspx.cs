using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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
    public partial class passwordReset : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "critic" || Session["role"].ToString() == "admin")
            {
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (ifCriticExists())
            {
                sendPasswordRecovery(getCriticByUsername());
                Response.Redirect("login.aspx");
            } else {
                Response.Write("<script>alert('Username does not match any registrated user.');</script>");
            }
            usernameBox.Text = "";
            
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

        string[] getCriticByUsername()
        {
            try
            {
                string[] critic_info = new string[3];
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM critics WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    critic_info[0] = reader["first_name"].ToString();
                    critic_info[1] = reader["email"].ToString();
                    critic_info[2] = reader["password"].ToString();

                    // Use the retrieved data as needed (e.g., display it in your ASP.NET Web Forms page)
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
                return critic_info;
            }
            
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); return null;
            }
        }

        void sendPasswordRecovery(string[] critic_info)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Filmy Community Help Center", "filmy.community.help@gmail.com"));
            message.To.Add(new MailboxAddress("Password Reset for " + critic_info[0], critic_info[1]));

            message.Subject = "Password Reset Request";

            message.Body = new TextPart("html")
            {
                Text = "<!DOCTYPE html><html><head>  <meta charset=\"UTF-8\">  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Password Reset Request!</title>  <style>    /* Global CSS styles */    body {      font-family: Arial, sans-serif;      background-color: #f5f5f5;    }    /* Container styles */    .container {      max-width: 600px;      margin: 0 auto;      padding: 20px;      background-color: #f2eaff;      border-radius: 5px;      box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);    }    /* Heading styles */    h1 {      color: #3a256d;      margin-top: 0;      text-align: center;    }    /* Content styles */    p {      color: #5d487f;      line-height: 1.5;    }    /* Footer styles */    .footer {      text-align: center;      margin-top: 20px;      color: #999999;    } #passkey {  background-color: black; color: black; display: inline; transition: .5s; -webkit-transition: .5s;  } #passkey:hover {  background-color: transparent;  color: #3a256d;  } </style></head><body>  <div class=\"container\">    <h1>Password Recovery</h1>    <p>Dear " + critic_info[0] + ",</p>    <p>We received a request to recover your account password.</p>    <p>Please ensure that you securely store this password and consider changing it after logging in for security purposes.</p>   <p>Here, is your password: <span id=\"passkey\"><strong>" + critic_info[2] + "</strong></span></p> <p><strong>If you did not request a password recovery, change your password and contact our support team immediately.</strong></p>  <div class=\"footer\">      <p>Best regards,</p>      <p>The Filmy Team</p>    </div>  </div></body></html>"
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