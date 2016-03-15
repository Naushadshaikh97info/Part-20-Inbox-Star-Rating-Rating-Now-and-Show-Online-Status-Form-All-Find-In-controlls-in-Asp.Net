using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_directory : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static string service = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_all_member();
        fill_country();

        if (Session["username"] == null)
        {
            Response.Redirect("Login_form.aspx");
        }
    }
    private void fill_country()
    {
        var id = (from a in linq_obj.Country_masters
                  select a).ToList();
        ddl_country_search.DataSource = id;
        ddl_country_search.DataBind();
        ddl_country_search.Items.Insert(0, "--Select Country--");
    }
    private void fill_all_member()
    {
        var id = (from a in linq_obj.user_registration_tbls
                  join b in linq_obj.Country_masters on a.country_name equals b.intglcode
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
                      online_status = a.online_status  
                  }).ToList();
        DataList1.DataSource = id;
        DataList1.DataBind();
        foreach (DataListItem item in DataList1.Items)
        {
            LinkButton lnk = item.FindControl("LinkButton1") as LinkButton;
            if (lnk.Text == "Active")
            {

                ImageButton btn = item.FindControl("img_green") as ImageButton;
                btn.Visible = true;
            }
            else if (lnk.Text == "Deactive")
            {
                ImageButton btn = item.FindControl("img_grey") as ImageButton;
                btn.Visible = true;
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
                              online_status = a.online_status
                          }).ToList();
                DataList1.DataSource = id;
                DataList1.DataBind();
                foreach (DataListItem item in DataList1.Items)
                {
                    LinkButton lnk = item.FindControl("LinkButton1") as LinkButton;
                    if (lnk.Text == "Active")
                    {
                        ImageButton btn = item.FindControl("img_green") as ImageButton;
                        btn.Visible = true;
                    }
                    else if (lnk.Text == "Deactive")
                    {
                        ImageButton btn = item.FindControl("img_grey") as ImageButton;
                        btn.Visible = true;
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
                          online_status = a.online_status
                      }).ToList();

            DataList1.DataSource = id;
            DataList1.DataBind();
            foreach (DataListItem item in DataList1.Items)
            {
                LinkButton lnk = item.FindControl("LinkButton1") as LinkButton;
                if (lnk.Text == "Active")
                {
                    ImageButton btn = item.FindControl("img_green") as ImageButton;
                    btn.Visible = true;
                }
                else if (lnk.Text == "Deactive")
                {
                    ImageButton btn = item.FindControl("img_grey") as ImageButton;
                    btn.Visible = true;
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
                              online_status = a.online_status
                          }).ToList();

                DataList1.DataSource = id;
                DataList1.DataBind();
                foreach (DataListItem item in DataList1.Items)
                {
                    LinkButton lnk = item.FindControl("LinkButton1") as LinkButton;
                    if (lnk.Text == "Active")
                    {
                        ImageButton btn = item.FindControl("img_green") as ImageButton;
                        btn.Visible = true;
                    }
                    else if (lnk.Text == "Deactive")
                    {
                        ImageButton btn = item.FindControl("img_grey") as ImageButton;
                        btn.Visible = true;
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
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        TextBox cbl2 = (TextBox)e.Item.FindControl("txt_email");

        string strId1 = DataList1.DataKeys[e.Item.ItemIndex].ToString();

        var id2 = (from a in linq_obj.user_registration_tbls
                   join b in linq_obj.Country_masters on a.country_name equals b.intglcode
                   where a.intglcode == Convert.ToInt32(strId1)
                   select new
                   {
                       code = a.intglcode,
                       login_email = a.login_email,
                   }).Single();

        cbl2.Text = id2.login_email;
        ViewState["email"] = cbl2.Text;

        CheckBoxList cbl = (CheckBoxList)e.Item.FindControl("chk_service");

        string strId = DataList1.DataKeys[e.Item.ItemIndex].ToString();

        var id = (from a in linq_obj.user_registration_tbls
                  where a.intglcode == Convert.ToInt32(strId)
                  select a).Single();

        string[] abc = id.area_of_services.Split(',');
        for (int i = 0; i < abc.Length; i++)
        {
            string xyz = abc[i].ToString();
            for (int j = 0; j < cbl.Items.Count; j++)
            {
                if (cbl.Items[j].Value == xyz)
                {
                    cbl.Items[j].Selected = true;
                }
            }
        }
    }
    protected void btn_send_Click(object sender, EventArgs e)
    {
        string email = string.Empty;
        string title = string.Empty;
        string message = string.Empty;

            foreach (DataListItem item in this.DataList1.Items)
            {
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                email = (item.FindControl("txt_email") as TextBox).Text;
                title = (item.FindControl("txt_title") as TextBox).Text;
                message = (item.FindControl("txt_message") as TextBox).Text;


                int alpesh = DataList1.Items[i].ItemIndex;
                int naushad = Convert.ToInt32(DataList1.DataKeys[alpesh].ToString());

                int b = 0;

                string naushad1 = ViewState["email"].ToString();

                var id = (from a in linq_obj.user_registration_tbls
                          where a.intglcode == naushad
                          select a).Single(); 

                b = id.intglcode;

                linq_obj.insert_sender_message(Convert.ToInt32(Session["id"]), b, title, message, "True", Convert.ToDateTime(System.DateTime.Now), "true", "true");
                linq_obj.SubmitChanges();
               
            }
                break;
        }
    }
    protected void link_online_message_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        string commandArgument = btnsubmit.CommandArgument;
        DataList item = btnsubmit.NamingContainer as DataList;
        HiddenField hf = item.FindControl("hiddenField") as HiddenField;
    }
}



