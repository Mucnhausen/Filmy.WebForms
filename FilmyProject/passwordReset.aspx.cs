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
        // SqlConnection object for connecting to the database
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        // Event handler for the page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user's role is "critic" or "admin"
            if (Session["role"].ToString() == "critic" || Session["role"].ToString() == "admin")
            {
                // If the user is a critic or an admin, display an error message and end the response
                Response.Write("You have no rights to view the content of that page");
                Response.End();
            }
        }

        // Method to display a toast notification on the web page
        void displayToast(String type, String title, String message)
        {
            // Register a startup script to display the toastr notification using client-side code
            ClientScript.RegisterStartupScript(this.GetType(), "toastr_custom", "toastr." + type + "('" + message + "', '" + title + "', { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000 });", true);
        }

        // Event handler for the submit button click event
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            // Check if the critic exists in the database
            if (ifCriticExists())
            {
                // Send password recovery email and display a success message
                sendPasswordRecovery(getCriticByUsername());
                displayToast("success", "PASSWORD REQUEST", "Request was sent successfully.");
                Response.Redirect("login.aspx");
            }
            else
            {
                // Display an error message if the username does not match any registered user
                displayToast("error", "Username", "Username does not match any registered user.");
            }
            // Clear the username text box
            usernameBox.Text = "";
        }

        // Method to check if a critic with the given username exists in the database
        bool ifCriticExists()
        {
            try
            {
                // Create a SqlCommand object to execute a query and check the count of matching usernames
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from critics where username = @username", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    con.Close();
                    if (userCount > 0)
                    {
                        // Return true if the count is greater than 0
                        return true;
                    }
                    else
                    {
                        // Return false if the count is 0
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                Response.Write("<script>alert('An error occurred. Try again later.\n" + ex.Message + "');</script>");
                return false;
            }
        }

        // Method to get the critic's information by username from the database
        string[] getCriticByUsername()
        {
            try
            {
                // Array to store the critic's information
                string[] critic_info = new string[3];
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM critics WHERE username=@username", con);
                cmd.Parameters.AddWithValue("@username", usernameBox.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve the critic's information from the database
                    critic_info[0] = reader["first_name"].ToString();
                    critic_info[1] = reader["email"].ToString();
                    critic_info[2] = reader["password"].ToString();
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
                return critic_info;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return null;
            }
        }

        // Method to send a password recovery email
        void sendPasswordRecovery(string[] critic_info)
        {
            // Create a MimeMessage object to compose the email
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Filmy Community Help Center", "filmy.community.help@gmail.com"));
            message.To.Add(new MailboxAddress("Password Reset for " + critic_info[0], critic_info[1]));

            message.Subject = "Password Reset Request";

            // Define the HTML body for the email
            message.Body = new TextPart("html")
            {
                Text = "<!DOCTYPE html><html><head>  <meta charset=\"UTF-8\">  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">  <title>Password Reset Request!</title>  <style>    /* Global CSS styles */    body {      font-family: Arial, sans-serif;      background-color: #f5f5f5;    }    /* Container styles */    .container {      max-width: 600px;      margin: 0 auto;      padding: 20px;      background-color: #f2eaff;      border-radius: 5px;      box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);    }    /* Heading styles */    h1 {      color: #3a256d;      margin-top: 0;      text-align: center;    }    /* Content styles */    p {      color: #5d487f;      line-height: 1.5;    }    /* Footer styles */    .footer {      text-align: center;      margin-top: 20px;      color: #999999;    } #passkey {  background-color: black; color: black; display: inline; transition: .5s; -webkit-transition: .5s;  } #passkey:hover {  background-color: transparent;  color: #3a256d;  } </style></head><body>  <div class=\"container\">    <h1>Password Recovery</h1>    <p>Dear " + critic_info[0] + ",</p>    <p>We received a request to recover your account password.</p>    <p>Please ensure that you securely store this password and consider changing it after logging in for security purposes.</p>   <p>Here, is your password: <span id=\"passkey\"><strong>" + critic_info[2] + "</strong></span></p> <p><strong>If you did not request a password recovery, change your password and contact our support team immediately.</strong></p>  <div class=\"footer\">      <p>Best regards,</p>      <p>The Filmy Team</p>    </div>  </div></body></html>"
            };

            // Create an SMTP client and send the message
            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("filmy.community.help@gmail.com", "doadkcgpdoymsyjh");
                client.Send(message);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");
            }
            finally
            {
                // Disconnect and dispose the SMTP client
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
