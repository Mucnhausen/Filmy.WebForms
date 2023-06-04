using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FilmyProject
{
    public partial class reviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = e.Row.DataItem as DataRowView;
                int rating = Convert.ToInt32(rowView["Rating"]);
                int full_stars = rating / 2;
                bool half_stars = false;
                int modifier = 0;
                if (rating % 2 != 0) { half_stars = true; modifier = 1;  }

                HtmlGenericControl starsPlaceholder = e.Row.FindControl("starsPlaceholder") as HtmlGenericControl;
                for (int i = 0; i < full_stars; i++)
                {
                    HtmlGenericControl star = new HtmlGenericControl("span");
                    star.Attributes["class"] = "fa fa-star checked";
                    starsPlaceholder.Controls.Add(star);
                }
                if (half_stars)
                {
                    HtmlGenericControl half_star = new HtmlGenericControl("span");
                    half_star.Attributes["class"] = "fa fa-star-half-stroke checked";
                    starsPlaceholder.Controls.Add(half_star);

                }

                for (int i = full_stars; i < 5 - modifier; i++)
                {
                    HtmlGenericControl star = new HtmlGenericControl("span");
                    star.Attributes["class"] = "fa fa-star fa-regular";
                    starsPlaceholder.Controls.Add(star);

                }
            }
        }
    }
}