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
        fill_rate1();
    }
    private void fill_rate1()
    {
        var id = (from a in linq_obj.City_masters
                  select a).ToList();
        rdb1.DataSource = id;
        rdb1.DataBind();
        rdb2.DataSource = id;
        rdb2.DataBind();
        rdb3.DataSource = id;
        rdb3.DataBind();
        rdb4.DataSource = id;
        rdb4.DataBind();

    }
    private void fill_all_member()
    {
        var id = (from a in linq_obj.user_registration_tbls
                  join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                  where a.intglcode != Convert.ToInt32(Session["id"])
                  orderby a.intglcode descending
                  select new
                  {
                      code = a.intglcode,
                       online_status = a.online_status,
                      Rating = a.ratings,
                      Rating2 = a.ratings2,
                      Rating3 = a.ratings3,
                      Rating4 = a.ratings4
                  }).ToList();
        DataList1.DataSource = id;
        DataList1.DataBind();
        foreach (GridViewRow row in DataList1.Rows)
        {
            LinkButton lnk = row.FindControl("LinkButton1") as LinkButton;
            if (lnk.Text == "Active")
            {
                Label lbl = row.FindControl("lbl_online") as Label;
                ImageButton btn = row.FindControl("img_green") as ImageButton;
                btn.Visible = true;
                lbl.Visible = true;

            }
            else if (lnk.Text == "Deactive")
            {
                ImageButton btn = row.FindControl("img_grey") as ImageButton;
                btn.Visible = true;
                Label lbl = row.FindControl("lbl_offline") as Label;
                lbl.Visible = true;
            }
        }
    }
    protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {

    }
    protected void Rating1_Changed2(object sender, AjaxControlToolkit.RatingEventArgs e)
    {

    }
    protected void Rating1_Changed3(object sender, AjaxControlToolkit.RatingEventArgs e)
    {

    }
    protected void Rating1_Changed4(object sender, AjaxControlToolkit.RatingEventArgs e)
    {

    }
    protected void link_online_message_Click(object sender, EventArgs e)
    {

        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        //foreach (GridViewRow row1 in DataList1.Rows)
        //{
        //    TextBox txtBox1 = (TextBox)row1.FindControl("txt_email");

        //}  
        abc = Convert.ToInt32(DataList1.DataKeys[gRow.RowIndex].Value.ToString());
        var id = (from a in linq_obj.user_registration_tbls
                  where a.intglcode == abc
                  select a).Single();
        if (id.status == "Active")
        {
            this.mp1.Show();
            txt_email.Text = id.login_email;
        }

        txt_message.Text = "";
        txt_title.Text = "";

    }
    protected void link_rate_now_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;

        abc = Convert.ToInt32(DataList1.DataKeys[gRow.RowIndex].Value.ToString());
        ViewState["ratecode"] = abc;
        var id = (from a in linq_obj.user_registration_tbls
                  where a.intglcode == abc
                  select a).Single();
        if (id.status == "Active")
        {
            this.mp2.Show();

        }


    }
    protected void btn_rate_now_Click(object sender, EventArgs e)
    {
        var id10 = (from a in linq_obj.member_rateings
                    where a.user_id == Convert.ToInt32(Session["id"].ToString()) && a.member_directory_id == Convert.ToInt32(ViewState["ratecode"].ToString())
                    select a).ToList();

        if (id10.Count <= 0)
        {
            linq_obj.insert_menber_retings(Convert.ToInt16(rdb1.SelectedValue), Convert.ToInt32(ViewState["ratecode"].ToString()), Convert.ToInt32(Session["id"].ToString()));
            linq_obj.SubmitChanges();
            var id = (from a in linq_obj.member_rateings
                      where a.member_directory_id == Convert.ToInt32(ViewState["ratecode"].ToString())
                      select a).ToList();
            int raj = 0;
            for (int i = 0; i < id.Count(); i++)
            {
                raj = raj + Convert.ToInt32(id[i].rating);
            }
            int padu = raj / id.Count();
            var id2 = (from a in linq_obj.user_registration_tbls
                       where a.intglcode == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            id2[0].ratings = padu;
            linq_obj.SubmitChanges();
            linq_obj.insert_menber_retings2(Convert.ToInt16(rdb2.SelectedValue), Convert.ToInt32(ViewState["ratecode"].ToString()), Convert.ToInt32(Session["id"].ToString()));
            linq_obj.SubmitChanges();
            var id3 = (from a in linq_obj.member_rateing2s
                       where a.member_directory_id == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            int raj1 = 0;
            for (int i = 0; i < id3.Count(); i++)
            {
                raj1 = raj1 + Convert.ToInt32(id3[i].rating);
            }
            int padu1 = raj1 / id3.Count();

            var id4 = (from a in linq_obj.user_registration_tbls
                       where a.intglcode == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            id4[0].ratings2 = padu1;
            linq_obj.SubmitChanges();
            linq_obj.insert_menber_retings3(Convert.ToInt16(rdb3.SelectedValue), Convert.ToInt32(ViewState["ratecode"].ToString()), Convert.ToInt32(Session["id"].ToString()));
            linq_obj.SubmitChanges();
            var id5 = (from a in linq_obj.member_rateing3s
                       where a.member_directory_id == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            int raj2 = 0;
            for (int i = 0; i < id5.Count(); i++)
            {
                raj2 = raj2 + Convert.ToInt32(id5[i].rating);
            }
            int padu2 = raj2 / id5.Count();

            var id6 = (from a in linq_obj.user_registration_tbls
                       where a.intglcode == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            id6[0].ratings3 = padu2;
            linq_obj.SubmitChanges();
            linq_obj.insert_menber_retings4(Convert.ToInt16(rdb4.SelectedValue), Convert.ToInt32(ViewState["ratecode"].ToString()), Convert.ToInt32(Session["id"].ToString()));
            linq_obj.SubmitChanges();
            var id7 = (from a in linq_obj.member_rateing4s
                       where a.member_directory_id == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            int raj3 = 0;
            for (int i = 0; i < id7.Count(); i++)
            {
                raj3 = raj3 + Convert.ToInt32(id7[i].rating);
            }
            int padu3 = raj3 / id7.Count();

            var id8 = (from a in linq_obj.user_registration_tbls
                       where a.intglcode == Convert.ToInt32(ViewState["ratecode"].ToString())
                       select a).ToList();
            id8[0].ratings4 = padu3;
            linq_obj.SubmitChanges();
            rdb1.SelectedIndex = -1;
            rdb2.SelectedIndex = -1;
            rdb3.SelectedIndex = -1;
            rdb4.SelectedIndex = -1;
            fill_all_member();
            Page.RegisterStartupScript("onload", "<script language='javascript'>alert('Your Rating Submit Successfully')</script>");
        }
        else
        {
            rdb1.SelectedIndex = -1;
            rdb2.SelectedIndex = -1;
            rdb3.SelectedIndex = -1;
            rdb4.SelectedIndex = -1;
            Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** You Are Already Rateing This Directory**')</script> ");
        }

    }

  
}