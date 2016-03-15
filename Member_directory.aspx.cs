using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AjaxControlToolkit;
public partial class Member_directory : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static string service = "";
    static int abc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_rate1();

        if (Request.QueryString["code"] != null)
        {
            fill_all_member1();
            fill_country();
        }
        else
        {
            fill_all_member();
            fill_country();
        }
      

        if (Session["username"] == null)
        {
            Response.Redirect("Login_form.aspx");
        }
        
      



    }

    //protected void OnRatingChanged(object sender, RatingEventArgs e)
    //{
    //    int rowIndex1 = ((sender as Rating).NamingContainer as GridViewRow).RowIndex;
    //    int fruitId1 = Convert.ToInt32(DataList1.DataKeys[rowIndex1].Value);
    //    var id = (from a in linq_obj.member_rateings
    //              where a.user_id == Convert.ToInt32(Session["id"].ToString()) && a.member_directory_id == Convert.ToInt32(fruitId1)
    //              select a).ToList();

    //    if (id.Count <= 0)
    //    {
    //        int rowIndex = ((sender as Rating).NamingContainer as GridViewRow).RowIndex;
    //        int fruitId = Convert.ToInt32(DataList1.DataKeys[rowIndex].Value);

    //        string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    //        using (SqlConnection con = new SqlConnection(constr))
    //        {
    //            using (SqlCommand cmd = new SqlCommand("INSERT INTO member_rateing VALUES(@member_directory_id, @rating,@user_id)"))
    //            {
    //                using (SqlDataAdapter sda = new SqlDataAdapter())
    //                {
    //                    cmd.CommandType = CommandType.Text;
    //                    cmd.Parameters.AddWithValue("@rating", fruitId);
    //                    cmd.Parameters.AddWithValue("@member_directory_id", e.Value);
    //                    cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["id"].ToString()));
    //                    cmd.Connection = con;
    //                    con.Open();
    //                    cmd.ExecuteNonQuery();
    //                    con.Close();
    //                }
    //            }
    //        }
    //        var id4 = (from a in linq_obj.member_rateings
    //                   where a.member_directory_id == Convert.ToInt32(fruitId)
    //                   select a).ToList();
    //         int raj =0;
    //        for (int i = 0; i < id4.Count(); i++)
    //        {
    //           raj  =raj +  Convert.ToInt32(id4[i].rating);
    //        }
    //        int padu = raj / id4.Count();

    //        var id5 = (from a in linq_obj.user_registration_tbls
    //                   where a.intglcode == Convert.ToInt32(fruitId)
    //                   select a).ToList();
    //        id5[0].ratings = padu;
    //        linq_obj.SubmitChanges();

    //        Response.Redirect(Request.Url.AbsoluteUri);
    //    }
    //    else
    //    {
    //        Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** You Are Already Rateing This Directory**')</script> ");
    //    }


    //}

    private void fill_country()
    {
        var id = (from a in linq_obj.Country_masters
                  select a).ToList();
        ddl_country_search.DataSource = id;
        ddl_country_search.DataBind();
        ddl_country_search.Items.Insert(0, "--Select Country--");
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
                      company_name = a.company_name,
                      street_address = a.street_address,
                      city = a.city_name,
                      country = b.Country_name,
                      website = a.website,
                      mobile = a.telephone,
                      fax = a.fax,
                      foundation = a.date_of_foundation,
                      no_of_employee = a.no_of_employee,
                      director_f_name = a.director_f_name,
                      director_l_name = a.director_l_name,
                      director_email = a.director_email,
                      director_phone = a.director_phone,
                      exports_f_name = a.export_f_name,
                      exports_l_name = a.export_l_name,
                      exports_email = a.export_email,
                      exports_phone = a.export_phone,
                      Imports_f_name = a.import_f_name,
                      Imports_l_name = a.import_l_name,
                      Imports_email = a.import_email,
                      Imports_phone = a.import_phone,
                      other_service = a.other_service,
                      about_us = a.about_us,
                      image_logo = "./upload/" + a.company_logo,
                      membership_plan = a.membership,
                      area_of_services = a.area_of_services,
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
    private void fill_all_member1()
    {
        var id = (from a in linq_obj.user_registration_tbls
                  join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                  where a.intglcode != Convert.ToInt32(Session["id"]) && a.intglcode == Convert.ToInt32(Request.QueryString["code"].ToString())
                  orderby a.intglcode descending
                  select new
                  {
                      code = a.intglcode,
                      company_name = a.company_name,
                      street_address = a.street_address,
                      city = a.city_name,
                      country = b.Country_name,
                      website = a.website,
                      mobile = a.telephone,
                      fax = a.fax,
                      foundation = a.date_of_foundation,
                      no_of_employee = a.no_of_employee,
                      director_f_name = a.director_f_name,
                      director_l_name = a.director_l_name,
                      director_email = a.director_email,
                      director_phone = a.director_phone,
                      exports_f_name = a.export_f_name,
                      exports_l_name = a.export_l_name,
                      exports_email = a.export_email,
                      exports_phone = a.export_phone,
                      Imports_f_name = a.import_f_name,
                      Imports_l_name = a.import_l_name,
                      Imports_email = a.import_email,
                      Imports_phone = a.import_phone,
                      other_service = a.other_service,
                      about_us = a.about_us,
                      image_logo = "./upload/" + a.company_logo,
                      membership_plan = a.membership,
                      area_of_services = a.area_of_services,
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
    protected void btn_seacrh_Click(object sender, EventArgs e)
    {


        for (int i = 0; i < Check_service.Items.Count; i++)
        {
            if (Check_service.Items[i].Selected)
            {
                if (service == "")
                {
                    service = Check_service.Items[i].Text;
                }
                else
                {
                    service += "," + Check_service.Items[i].Text;
                }
            }
        }


        fill_search();
    }
    private void fill_search()
    {
        if ((ddl_country_search.SelectedIndex == 0 && Check_service.SelectedIndex == -1))
        {
            Page.RegisterStartupScript("onload", "<script language='javascript'>alert('Please Select all')</script>");
        }
        else if (Convert.ToInt32(ddl_country_search.SelectedIndex) == 0)
        {

            string[] words = service.Trim().Split(new char[] { ',' });

            for (int i = 0; i < words.Length; i++)
            {
                var id = (from a in linq_obj.user_registration_tbls
                          join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                          where a.intglcode != Convert.ToInt32(Session["id"])
                          orderby a.intglcode descending
                          where a.area_of_services.Contains(words[i].ToString())
                          select new
                          {
                              code = a.intglcode,
                              company_name = a.company_name,
                              street_address = a.street_address,
                              city = a.city_name,
                              country = b.Country_name,
                              website = a.website,
                              mobile = a.telephone,
                              fax = a.fax,
                              foundation = a.date_of_foundation,
                              no_of_employee = a.no_of_employee,
                              director_f_name = a.director_f_name,
                              director_l_name = a.director_l_name,
                              director_email = a.director_email,
                              director_phone = a.director_phone,
                              exports_f_name = a.export_f_name,
                              exports_l_name = a.export_l_name,
                              exports_email = a.export_email,
                              exports_phone = a.export_phone,
                              Imports_f_name = a.import_f_name,
                              Imports_l_name = a.import_l_name,
                              Imports_email = a.import_email,
                              Imports_phone = a.import_phone,
                              other_service = a.other_service,
                              about_us = a.about_us,
                              image_logo = "./upload/" + a.company_logo,
                              membership_plan = a.membership,
                              area_of_services = a.area_of_services,
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
                if (id.Count == 0)
                {
                    lbl_member_error.Visible = true;
                }
                else
                {
                    lbl_member_error.Visible = false;
                }
                service = "";
            }
        }
        else if (ddl_country_search.SelectedIndex != 0 && Check_service.SelectedIndex == -1)
        {
            var id = (from a in linq_obj.user_registration_tbls
                      join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                      where a.intglcode != Convert.ToInt32(Session["id"])
                      orderby a.intglcode descending
                      where a.country_name == Convert.ToInt32(ddl_country_search.SelectedValue)
                      select new
                      {
                          code = a.intglcode,
                          company_name = a.company_name,
                          street_address = a.street_address,
                          city = a.city_name,
                          country = b.Country_name,
                          website = a.website,
                          mobile = a.telephone,
                          fax = a.fax,
                          foundation = a.date_of_foundation,
                          no_of_employee = a.no_of_employee,
                          director_f_name = a.director_f_name,
                          director_l_name = a.director_l_name,
                          director_email = a.director_email,
                          director_phone = a.director_phone,
                          exports_f_name = a.export_f_name,
                          exports_l_name = a.export_l_name,
                          exports_email = a.export_email,
                          exports_phone = a.export_phone,
                          Imports_f_name = a.import_f_name,
                          Imports_l_name = a.import_l_name,
                          Imports_email = a.import_email,
                          Imports_phone = a.import_phone,
                          other_service = a.other_service,
                          about_us = a.about_us,
                          image_logo = "./upload/" + a.company_logo,
                          membership_plan = a.membership,
                          area_of_services = a.area_of_services,
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
            if (id.Count == 0)
            {
                lbl_member_error.Visible = true;
            }
            else
            {
                lbl_member_error.Visible = false;
            }
        }
        else
        {
            // string service = Convert.ToString(Request.QueryString["id2"].ToString());
            string[] words = service.Trim().Split(new char[] { ',' });

            for (int i = 0; i < words.Length; i++)
            {
                var id = (from a in linq_obj.user_registration_tbls
                          join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                          orderby a.intglcode descending
                          where a.intglcode != Convert.ToInt32(Session["id"])
                          where a.country_name == Convert.ToInt32(ddl_country_search.SelectedValue) && a.area_of_services.Contains(words[i].ToString())
                          select new
                          {
                              code = a.intglcode,
                              company_name = a.company_name,
                              street_address = a.street_address,
                              city = a.city_name,
                              country = b.Country_name,
                              website = a.website,
                              mobile = a.telephone,
                              fax = a.fax,
                              foundation = a.date_of_foundation,
                              no_of_employee = a.no_of_employee,
                              director_f_name = a.director_f_name,
                              director_l_name = a.director_l_name,
                              director_email = a.director_email,
                              director_phone = a.director_phone,
                              exports_f_name = a.export_f_name,
                              exports_l_name = a.export_l_name,
                              exports_email = a.export_email,
                              exports_phone = a.export_phone,
                              Imports_f_name = a.import_f_name,
                              Imports_l_name = a.import_l_name,
                              Imports_email = a.import_email,
                              Imports_phone = a.import_phone,
                              other_service = a.other_service,
                              about_us = a.about_us,
                              image_logo = "./upload/" + a.company_logo,
                              membership_plan = a.membership,
                              area_of_services = a.area_of_services,
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
                if (id.Count == 0)
                {
                    lbl_member_error.Visible = true;
                }
                else
                {
                    lbl_member_error.Visible = false;
                }
                service = "";
            }
        }
    }
    protected void DataList1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBoxList cbl1 = (CheckBoxList)e.Row.FindControl("chk_service");
            string strId = DataList1.DataKeys[e.Row.RowIndex].Values[0].ToString();



            var id = (from a in linq_obj.user_registration_tbls
                      where a.intglcode == Convert.ToInt32(strId)
                      select a).Single();

            string[] abc = id.area_of_services.Split(',');
            for (int i = 0; i < abc.Length; i++)
            {
                string xyz = abc[i].ToString();
                for (int j = 0; j < cbl1.Items.Count; j++)
                {
                    if (cbl1.Items[j].Value == xyz)
                    {
                        cbl1.Items[j].Selected = true;
                    }
                }
            }
        }
    }
    protected void btn_send_Click(object sender, EventArgs e)
    {
        int b = 0;
        var id = (from a in linq_obj.user_registration_tbls
                  where a.login_email == txt_email.Text
                  select a).Single();
        b = id.intglcode;
        linq_obj.insert_sender_message(Convert.ToInt32(Session["id"]),b, txt_title.Text, txt_message.Text, "True", Convert.ToDateTime(System.DateTime.Now), "true", "true");

        txt_message.Text = "";
        txt_title.Text = "";
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
             linq_obj.insert_menber_retings(Convert.ToInt16(rdb1.SelectedValue ), Convert.ToInt32(ViewState["ratecode"].ToString()), Convert.ToInt32(Session["id"].ToString()));
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



