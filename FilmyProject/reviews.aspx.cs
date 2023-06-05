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
            // This event handler is called when the page loads
            // You can add code here to perform any necessary actions when the page loads
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // This event handler is called when each row in the GridView is being bound with data
            // It allows customization of the row appearance or data during the binding process

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Check if the current row is a data row

                // Get the data item associated with the current row
                DataRowView rowView = e.Row.DataItem as DataRowView;

                // Retrieve the rating value from the data item
                int rating = Convert.ToInt32(rowView["Rating"]);

                // Calculate the number of full stars, half stars, and modifier for empty stars
                int full_stars = rating / 2;
                bool half_stars = false;
                int modifier = 0;
                if (rating % 2 != 0) { half_stars = true; modifier = 1; }

                // Find the placeholder div for star ratings in the current row
                HtmlGenericControl starsPlaceholder = e.Row.FindControl("starsPlaceholder") as HtmlGenericControl;

                // Add full star icons based on the number of full stars
                for (int i = 0; i < full_stars; i++)
                {
                    HtmlGenericControl star = new HtmlGenericControl("span");
                    star.Attributes["class"] = "fa fa-star checked";
                    starsPlaceholder.Controls.Add(star);
                }

                // Add a half star icon if applicable
                if (half_stars)
                {
                    HtmlGenericControl half_star = new HtmlGenericControl("span");
                    half_star.Attributes["class"] = "fa fa-star-half-stroke checked";
                    starsPlaceholder.Controls.Add(half_star);
                }

                // Add empty star icons for the remaining space
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
