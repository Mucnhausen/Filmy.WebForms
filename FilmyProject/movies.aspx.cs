using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Sample data for the GridView
                DataTable dt = new DataTable();
                dt.Columns.Add("movie_name");
                dt.Columns.Add("date");
                dt.Columns.Add("budget");
                dt.Columns.Add("genres");
                dt.Columns.Add("actors");
                dt.Columns.Add("producers");
                dt.Columns.Add("rating");
                dt.Columns.Add("description");
                dt.Columns.Add("image_path");

                // Add a row of sample data
                DataRow row = dt.NewRow();
                row["movie_name"] = "Star Wars IV: A New Hope";
                row["date"] = "May 25, 1977";
                row["budget"] = "$11 million";
                row["genres"] = "Science Fiction, Adventure";
                row["actors"] = "Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing, Alec Guinness";
                row["producers"] = "Gary Kurtz";
                row["rating"] = "4/5";
                row["description"] = "The fate of the galaxy is forever changed when Luke Skywalker discovers his powerful connection to a mysterious Force, and blasts into space to rescue Princess Leia. Mentored by a wise Jedi Master, and opposed by the menacing Darth Vader, Luke takes his first steps on a hero's journey.";
                row["image_path"] = "images\\movies\\starwars_4.jpg";

                dt.Rows.Add(row);

                // Bind the DataTable to the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}