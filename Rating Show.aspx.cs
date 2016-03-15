using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instant_message : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (IsPostBack)
            return;
        fill_user_data();
    }
    private void fill_user_data()
    {
        var id = (from a in linq_obj.user_registration_tbls
                  join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                  where a.intglcode == Convert.ToInt32(Session["id"])
                  select new
                  {
                      code = a.intglcode,
                      Rating = a.ratings,
                      Rating2 = a.ratings2,
                      Rating3 = a.ratings3,
                      Rating4 = a.ratings4
                  }).Single();
        Rating1.CurrentRating = Convert.ToInt32(id.Rating);
        Rating2.CurrentRating = Convert.ToInt32(id.Rating2);
        Rating3.CurrentRating = Convert.ToInt32(id.Rating3);
        Rating4.CurrentRating = Convert.ToInt32(id.Rating4);
    }
    protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        this.Rating1.ReadOnly = true;
    }
    protected void Rating1_Changed2(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        this.Rating1.ReadOnly = true;
    }
    protected void Rating1_Changed3(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        this.Rating1.ReadOnly = true;
    }
    protected void Rating1_Changed4(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        this.Rating1.ReadOnly = true;
    }
}