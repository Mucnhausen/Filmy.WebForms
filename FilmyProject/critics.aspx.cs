using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlDataSource1.SelectCommand = "SELECT m.movie_name AS movie_name, m.genres AS genres, m.actors AS actors, m.producers AS producers, r.review_text AS review_text, r.rating AS rating, r.date AS review_date FROM reviews r JOIN movies m ON r.movie_id = m.ID ";
        }
    }
}