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
        if (Session["id"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (IsPostBack)
            return;
        if (Session["seeker_message"] != null)
        {
            compose();
            compose1();
            var id = (from a in linq_obj.user_registration_tbls
                      where a.intglcode == Convert.ToInt32(Session["seeker_message"])
                      select a).Single();
            txt_message_to.Text = id.login_email;
            Session["seeker_id"] = id.intglcode;
            Session["seeker_message"] = null;
            Session["contacts"] = null;
            Session["outbox_message"] = null;
        }
        else if (Session["outbox_message"] != null)
        {
            Session["contacts"] = null;
            outbox();
        }
        else if (Session["compose_message"] != null)
        {
            compose1();
            compose();
            Session["compose_message"] = null;
        }
        else if (Session["contacts"] != null)
        {

            contact();
            Session["contacts"] = null;
        }

        else
        {

            inbox();
        }
       
        if (Session["code"] != null)
        {

            outbox_panel.Visible = false;
            inbox_panel.Visible = false;
            outbox_panel.Visible = false;
            compose_panel.Visible = false;
            //contacts_panel.Visible = false;
            compose_panel1.Visible = false;
            //pnl_outbox.Visible = false;
            //pnl_outbox_subject.Visible = false;
            pnl_outbox_subject_replay.Visible = true;
            var id = (from a in linq_obj.sender_messages
                      join b in linq_obj.user_registration_tbls on a.sender_id equals b.intglcode
                      where a.intglcode == Convert.ToInt32(Session["code"]) && a.receiver_id == Convert.ToInt32(Session["id"].ToString()) && a.status == "true"
                      select new
                      {
                          Message_to = b.company_name,
                          date1 = a.receiver_msg_datetime,
                          subject = a.receiver_subject,
                          message = a.receiver_message,
                      }).Single();
            lbl_messge_to1.Text = id.Message_to;
            lbl_date1.Text = Convert.ToString(id.date1);
            lbl_subject_list1.Text = id.subject;
            lbl_message_all1.Text = id.message;

            Session["code"] = null;


        }
        else if (Session["code2"] != null)
        {
            inbox_panel.Visible = false;
            outbox_panel.Visible = false;
            compose_panel.Visible = false;
            //contacts_panel.Visible = false;
            outbox_panel.Visible = false;
            compose_panel1.Visible = false;
            pnl_outbox_subject.Visible = true;
            pnl_outbox_subject_replay.Visible = false;
            var id = (from a in linq_obj.sender_messages
                      join b in linq_obj.user_registration_tbls on a.sender_id equals b.intglcode
                      where a.intglcode == Convert.ToInt32(Session["code2"])
                      select new
                      {
                          Message_to = b.company_name,
                          date1 = a.receiver_msg_datetime,
                          subject = a.receiver_subject,
                          message = a.receiver_message,
                      }).Single();
            lbl_messge_to.Text = id.Message_to;
            lbl_date.Text = Convert.ToString(id.date1);
            lbl_subject_list.Text = id.subject;
            lbl_message_all.Text = id.message;

            Session["code2"] = null;
        }
        else if (Session["code3"] != null)
        {
            inbox_panel.Visible = false;
            outbox_panel.Visible = false;
            compose_panel.Visible = false;
            //contacts_panel.Visible = false;
            outbox_panel.Visible = false;
            pnl_outbox_subject.Visible = false;
            pnl_outbox_subject_replay.Visible = false;
            compose_panel1.Visible = true;
            compose1();
            var id = (from a in linq_obj.sender_messages
                      join b in linq_obj.user_registration_tbls on a.sender_id equals b.intglcode
                      where a.intglcode == Convert.ToInt32(Session["code3"])
                      select new
                      {
                          Message_to = b.company_name,
                      }).Single();
            txt_message.Text = id.Message_to;
            Session["code3"] = null;
        }


    }
    protected void lnk_inbox_Click(object sender, EventArgs e)
    {
        chk_all_inbox.Checked = false;
        inbox();
    }
    protected void lnk_outbox_Click(object sender, EventArgs e)
    {
        chk_all_outbox.Checked = false;
        outbox();
    }
    protected void lnk_compose_Click(object sender, EventArgs e)
    {
        Session["outbox_message"] = null;
        Session["contacts"] = null;
        compose();
    }
    protected void lnk_contacts_Click(object sender, EventArgs e)
    {
        Session["outbox_message"] = null;
        chk_contact.Checked = false;
        contact();
    }
    private void inbox()
    {
        fill_inbox_message();
        inbox_panel.Visible = true;
        outbox_panel.Visible = false;
        compose_panel.Visible = false;
        contacts_panel.Visible = false;
        pnl_outbox_subject.Visible = false;
        pnl_outbox_subject_replay.Visible = false;
    }
    private void outbox()
    {
        fill_outbox();
        inbox_panel.Visible = false;
        outbox_panel.Visible = true;
        compose_panel.Visible = false;
        contacts_panel.Visible = false;
        pnl_outbox_subject.Visible = false;
        pnl_outbox_subject_replay.Visible = false;
    }
    private void compose()
    {

        inbox_panel.Visible = false;
        outbox_panel.Visible = false;
        compose_panel.Visible = true;
        contacts_panel.Visible = false;
        pnl_outbox_subject.Visible = false;
        pnl_outbox_subject_replay.Visible = false;
        compose_panel1.Visible = false;
        clear();
    }
    private void compose1()
    {
        inbox_panel.Visible = false;
        outbox_panel.Visible = false;
        compose_panel.Visible = false;
        contacts_panel.Visible = false;
        pnl_outbox_subject.Visible = false;
        pnl_outbox_subject_replay.Visible = false;
        compose_panel1.Visible = true;
        clear();
    }
    private void contact()
    {
        fill_contact_message();
        inbox_panel.Visible = false;
        outbox_panel.Visible = false;
        compose_panel.Visible = false;
        contacts_panel.Visible = true;
        pnl_outbox_subject.Visible = false;
        pnl_outbox_subject_replay.Visible = false;
    }
    private void fill_inbox_message()
    {
        var id = (from a in linq_obj.sender_messages
                  join b in linq_obj.user_registration_tbls on a.sender_id equals b.intglcode
                  where a.receiver_id == Convert.ToInt32(Session["id"].ToString()) && a.status == "true"
                  select new
                  {
                      code = a.intglcode,

                      sender_name = b.company_name,
                      message_title = a.receiver_subject,
                      message_date = a.receiver_msg_datetime.Value.ToShortDateString(),
                  }).ToList();

        inbox_repeter.DataSource = id;
        inbox_repeter.DataBind();
        if (id.Count == 0)
        {
            lbl_error_inbox.Visible = true;
        }
        else
        {
            lbl_error_inbox.Visible = false;
        }

    }
    private void fill_outbox()
    {
        var id = (from a in linq_obj.sender_messages
                  join b in linq_obj.user_registration_tbls on a.receiver_id equals b.intglcode


                  where a.sender_id == Convert.ToInt32(Session["id"].ToString()) && a.receiver_outbox == "True"
                  select new
                  {
                      code = a.intglcode,
                      code252 = a.intglcode,
                      receiver_name = b.company_name,
                      message_title = a.receiver_subject,
                      message_date = a.receiver_msg_datetime.Value.ToShortDateString()

                  }).Distinct().ToList();
        sentmail_repeater.DataSource = id;
        sentmail_repeater.DataBind();
        if (id.Count == 0)
        {
            lbl_error_outbox.Visible = true;
        }
        else
        {
            lbl_error_outbox.Visible = false;
        }
    }
    private void fill_contact_message()
    {
        var id = (from a in linq_obj.sender_messages
                  join b in linq_obj.user_registration_tbls on a.receiver_id equals b.intglcode

                  where a.receiver_id != Convert.ToInt32(Session["id"]) && a.receiver_status == "true"
                  select new
                  {
                      code = a.intglcode,
                      consultant_name = b.company_name,
                      consultant_email = b.login_email,
                      phone_no = b.telephone,
                      code252 = b.intglcode
                  }).Distinct().ToList();

        contacts_repeter.DataSource = id;
        contacts_repeter.DataBind();
        if (id.Count == 0)
        {
            lbl_error_contact.Visible = true;
        }
        else
        {
            lbl_error_contact.Visible = false;
        }
    }
    protected void link_send_message_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());

        Session["seeker_message"] = code;
        Response.Redirect("Instant_message.aspx");

    }
    protected void btn_send_Click(object sender, EventArgs e)
    {
        int b = 0;
        var id = (from a in linq_obj.user_registration_tbls
                  where a.login_email == txt_message_to.Text
                  select a).Single();
        b = id.intglcode;

        linq_obj.insert_sender_message(Convert.ToInt32(Session["id"]), b, txt_subject.Text, txt_msg.Text.ToString(), "True", Convert.ToDateTime(System.DateTime.Now.ToString()), "true", "true");
        Session["seeker_id"] = null;
        clear();

    }
    private void clear()
    {
        txt_message_to.Text = "";
        txt_subject.Text = "";
        txt_msg.Text = "";

    }
    protected void txt_message_to_TextChanged(object sender, EventArgs e)
    {
        var id = (from a in linq_obj.user_registration_tbls
                  where a.login_email == txt_message_to.Text
                  select a).ToList();
        if (id.Count == 0)
        {
            lbl_message_to_error.Visible = true;
        }
        else
        {
            lbl_message_to_error.Visible = false;
        }
    }
    protected void lbk_delete_Click(object sender, EventArgs e)
    {
        if (inbox_panel.Visible == true)
        {
            // CheckBox chkFlag = inbox_repeter.FindControl("CheckBox1") as CheckBox;
            foreach (RepeaterItem ri in inbox_repeter.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;
                if (chkFlag.Checked)
                {

                    int Key = Convert.ToInt32((ri.FindControl("HiddenField1") as HiddenField).Value);



                    var id = (from a in linq_obj.sender_messages
                              where a.intglcode == Key
                              select a).Single();
                    if (id.status == "true")
                    {
                        id.status = "false";
                        linq_obj.SubmitChanges();
                    }
                    else
                    {
                        id.status = "true";
                        linq_obj.SubmitChanges();
                    }

                }
            }
            fill_inbox_message();
            chk_all_inbox.Checked = false;
        }
        else if (outbox_panel.Visible == true)
        {
            foreach (RepeaterItem ri in sentmail_repeater.Items)
            {
                CheckBox chkFlag = ri.FindControl("checkbox1") as CheckBox;
                if (chkFlag.Checked)
                {

                    int Key = Convert.ToInt32((ri.FindControl("HiddenField1") as HiddenField).Value);



                    var id = (from a in linq_obj.sender_messages
                              where a.intglcode == Key
                              select a).Single();
                    if (id.receiver_outbox == "True")
                    {
                        id.receiver_outbox = "False";
                        linq_obj.SubmitChanges();
                    }
                    else
                    {
                        id.receiver_outbox = "True";
                        linq_obj.SubmitChanges();
                    }

                }
            }
            fill_outbox();
            chk_all_outbox.Checked = false;
        }

        else if (contacts_panel.Visible == true)
        {
            foreach (RepeaterItem ri in contacts_repeter.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;
                if (chkFlag.Checked)
                {

                    int Key = Convert.ToInt32((ri.FindControl("HiddenField1") as HiddenField).Value);



                    var id = (from a in linq_obj.sender_messages
                              where a.intglcode == Key
                              select a).Single();
                    if (id.receiver_status == "true")
                    {
                        id.receiver_status = "false";
                        linq_obj.SubmitChanges();
                    }

                }
            }
            fill_contact_message();
            chk_contact.Checked = false;
        }

    }

    protected void chk_all_inbox_CheckedChanged1(object sender, EventArgs e)
    {
        if (chk_all_inbox.Checked == true)
        {
            foreach (RepeaterItem ri in inbox_repeter.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;

                if (chkFlag.Checked != true)
                {
                    chkFlag.Checked = true;
                }

            }
        }
        else if (chk_all_inbox.Checked == false)
        {
            foreach (RepeaterItem ri in inbox_repeter.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;

                if (chkFlag.Checked != false)
                {
                    chkFlag.Checked = false;
                }

            }
        }
    }
    protected void chk_all_outbox_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_all_outbox.Checked == true)
        {
            foreach (RepeaterItem ri in sentmail_repeater.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;

                if (chkFlag.Checked != true)
                {
                    chkFlag.Checked = true;
                }

            }
        }
        else if (chk_all_outbox.Checked == false)
        {
            foreach (RepeaterItem ri in sentmail_repeater.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;

                if (chkFlag.Checked != false)
                {
                    chkFlag.Checked = false;
                }

            }
        }
    }
    protected void chk_contact_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_contact.Checked == true)
        {
            foreach (RepeaterItem ri in contacts_repeter.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;

                if (chkFlag.Checked != true)
                {
                    chkFlag.Checked = true;
                }
            }
        }
        else if (chk_contact.Checked == false)
        {
            foreach (RepeaterItem ri in contacts_repeter.Items)
            {
                CheckBox chkFlag = ri.FindControl("CheckBox1") as CheckBox;

                if (chkFlag.Checked != false)
                {
                    chkFlag.Checked = false;
                }
            }
        }
    }
    protected void lnk_inbox_Click1(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());
        Session["code"] = code;
        Response.Redirect("Instant_message.aspx");
    }
    protected void link_detail_msg_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());
        Session["code2"] = code;
        Response.Redirect("Instant_message.aspx");
    }
    protected void btn_send1_Click(object sender, EventArgs e)
    {
        int b = 0;
        var id = (from a in linq_obj.user_registration_tbls
                  where a.company_name == lbl_messge_to1.Text
                  select a).Single();
        b = id.intglcode;
        linq_obj.insert_sender_message(Convert.ToInt32(Session["id"]), b, lbl_subject_list1.Text, txt_discription.Text, "True", Convert.ToDateTime(System.DateTime.Now), "true", "true");
        Response.Redirect("Instant_message.aspx");
    }
    protected void btn_send11_Click(object sender, EventArgs e)
    {
        int b = 0;
        var id = (from a in linq_obj.user_registration_tbls
                  where a.company_name == lbl_messge_to1.Text
                  select a).Single();
        b = id.intglcode;
        linq_obj.insert_sender_message(Convert.ToInt32(Session["id"]), b, lbl_subject_list1.Text, txt_discription.Text, "True", Convert.ToDateTime(System.DateTime.Now), "true", "true");
        Response.Redirect("Instant_message.aspx");
    }
    protected void link_relay_Click(object sender, EventArgs e)
    {
        txt_discription.Visible = true;
        btn_send1.Visible = true;
    }
    protected void link_replay_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());
        Session["code3"] = code;
        Response.Redirect("Instant_message.aspx");
    }
    protected void btn_send11_Click1(object sender, EventArgs e)
    {
        linq_obj.insert_sender_message(Convert.ToInt32(Session["id"]), b, lbl_subject_list1.Text, txt_discription.Text, "True", Convert.ToDateTime(System.DateTime.Now), "true", "true");
        Response.Redirect("Instant_message.aspx");
    }
}