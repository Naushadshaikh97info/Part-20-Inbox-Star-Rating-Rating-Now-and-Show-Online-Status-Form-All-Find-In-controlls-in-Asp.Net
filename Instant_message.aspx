<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Instant_message.aspx.cs" Inherits="Instant_message" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ckeditor/adapters/jquery.js" type="text/javascript"></script>

    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>

    <script src="ckeditor/config.js" type="text/javascript"></script>

    <script src="ckeditor/ckeditor_basic.js" type="text/javascript"></script>

    <script src="ckeditor/themes/default/theme.js" type="text/javascript"></script>
    <style id="Style1" type="text/css" runat="server">
        .shadetabs {
            list-style-type: none;
            margin-bottom: 0;
            margin-left: 0;
            margin-top: 1px;
            padding: 3px 0;
            text-align: left;
        }


            .shadetabs li {
                display: inline;
                margin: 0;
                font-size: 13px !important;
            }

        .LinkButton {
            color: #003366;
            margin-right: 3px;
            padding: 8px 12px;
            position: relative;
            text-decoration: none;
            z-index: 1;
            border: 1px solid #ccc;
            background-image: linear-gradient(#def, #fff);
        }


            .LinkButton:hover {
                /*background: none repeat scroll 0 0 #439EF7;*/
                color: black;
                text-decoration: none;
            }

        .admin-content-wrapper {
            border: 1px solid #e1e1e1;
            height: auto !important;
            margin-bottom: 1em;
            float: left;
            padding: 25px 12px 12px;
            width: 938px;
        }

        .arrow-n,
        .arrow-e,
        .arrow-s,
        .arrow-w {
            border-style: dashed;
            border-color: transparent;
            border-width: 0.53em;
            display: -moz-inline-box;
            display: inline-block;
            height: 0;
            line-height: 0;
            position: relative;
            vertical-align: middle;
        }

        .arrow-e {
            border-left-width: 0.6em;
            border-left-style: solid;
            border-left-color: #666;
            left: 1.25em;
            color: #439EF7;
        }
    </style>
    <style>
        body {
            font-family: sans-serif;
        }

        table, caption, tbody, tfoot, thead, tr, th, td {
            background: transparent;
            border: 0;
            margin: 0;
            padding: 0;
            vertical-align: baseline;
        }

        div#mail {
            width: 100%;
            /*margin: 20px auto;*/
        }

        .mailinbox tbody tr td {
            background: #fafafa;
        }

        .mailinbox tbody tr.unread td {
            background: #fff;
            font-weight: bold;
        }

        .mailinbox tbody tr.selected td {
            background: #FFFFD2;
        }

        .mailinbox thead th, .mailinbox tfoot th {
            border: 1px solid #ccc;
            border-right: 0;
        }

        .mailinbox tfoot th {
            border-bottom: 1px solid #ccc !important;
        }

        .mailinbox a.title {
            font-weight: normal;
            text-decoration: none;
        }

        .mailinbox tbody tr.unread a.title {
            font-weight: bold;
        }

        .mailinbox td.star, .mailinbox td.attachment {
            text-align: center;
        }

        .msgstar {
            display: inline-block;
            width: 16px;
            height: 16px;
            background: url(images/unstar.png) no-repeat 0 0;
            cursor: pointer;
            opacity: 0.5;
        }

            .msgstar:hover {
                opacity: 1;
            }

        .starred {
            background-image: url(images/star.png);
            opacity: 1;
        }



        .table-bordered caption + thead tr:first-child th:first-child, .table-bordered caption + tbody tr:first-child td:first-child, .table-bordered colgroup + thead tr:first-child th:first-child, .table-bordered colgroup + tbody tr:first-child td:first-child {
            border-top-left-radius: 0;
        }

        .table-bordered caption + thead tr:first-child th:last-child, .table-bordered caption + tbody tr:first-child td:last-child, .table-bordered colgroup + thead tr:first-child th:last-child, .table-bordered colgroup + tbody tr:first-child td:last-child {
            border-top-right-radius: 0;
        }

        .table-bordered thead:first-child tr:first-child th:first-child,
        .table-bordered tbody:first-child tr:first-child td:first-child,
        .table-bordered thead:first-child tr:first-child th:last-child,
        .table-bordered tbody:first-child tr:first-child td:last-child,
        .table-bordered thead:last-child tr:last-child th:first-child,
        .table-bordered tbody:last-child tr:last-child td:first-child,
        .table-bordered tfoot:last-child tr:last-child td:first-child {
            -moz-border-radius: 0;
            -webkit-border-radius: 0;
            border-radius: 0;
        }


        .table {
            margin-bottom: 0;
            width: 84%;
            font-size: 14px;
        }

            .table th {
                background: #fcfcfc;
            }

            .table tfoot th {
                border-bottom: 1px solid #ddd;
            }

            .table th.aligncenter, .table td.aligncenter {
                text-align: center;
            }

            .table tr {
                padding: 5px;
                height: 28px;
            }

        table td.center, table th.center {
            text-align: center;
        }

        .clearall {
            clear: both;
        }

        .mailinbox thead th, .mailinbox tfoot th {
            background: rgb(237,237,237);
            background: -moz-linear-gradient(top, rgba(237,237,237,1) 0%, rgba(222,222,222,1) 100%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(237,237,237,1)), color-stop(100%,rgba(222,222,222,1)));
            background: -webkit-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(222,222,222,1) 100%);
            background: -o-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(222,222,222,1) 100%);
            background: -ms-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(222,222,222,1) 100%);
            background: linear-gradient(to bottom, rgba(237,237,237,1) 0%,rgba(222,222,222,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ededed', endColorstr='#dedede',GradientType=0 );
        }
    </style>
    <link href="css/css3-gmail-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header_page">
        <div class="container">
            <div class="row-fluid">
                <div class="span6">
                    <h4>Instant Message</h4>
                </div>
                <div class="breadcrumbss">

                    <ul class="page_parents pull-right">
                        <li>You are here: </li>
                        <li><a href="Default.aspx">Home</a>/</li>

                        <li>Instant Message</li>

                    </ul>
                </div>

            </div>
        </div>

    </div>
    <div>
        <div id="mail">

            <div style="width: 940px;">
                <div style="float: left; width: 150px; margin-left: 4%;">

                    <asp:LinkButton ID="lnk_compose" runat="server" CssClass="bttn red" OnClick="lnk_compose_Click">Compose</asp:LinkButton>
                </div>
                <div style="margin-left: 10px;">
                    <ul class="grouped">
                        <li style="margin-right: 20px;"></li>
                        <li><a href="Instant_message.aspx" class="bttn refresh">Refresh</a></li>
                        <%--  <li><a href="#" class="bttn mark_read">Mark as Read</a></li>--%>

                        <li>
                            <asp:LinkButton ID="lbk_delete" runat="server" class="bttn delete" OnClick="lbk_delete_Click">Delete</asp:LinkButton>
                            <%--<a href="#" class="bttn icon delete">Delete</a>--%></li>

                    </ul>
                </div>
            </div>
            <div style="width: 940px;">
                <div style="float: left; margin-top: -8px; width: 187px;">
                    <ul style="width: 20px; list-style: none;">
                        <li>
                            <asp:LinkButton ID="lnk_inbox" runat="server" CssClass="bttn blue" OnClick="lnk_inbox_Click">Inbox</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk_outbox" runat="server" CssClass="bttn blue" OnClick="lnk_outbox_Click">Sent Mail</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk_contacts" runat="server" CssClass="bttn blue" OnClick="lnk_contacts_Click">Contacts</asp:LinkButton></li>

                    </ul>
                </div>

            </div>

        </div>
        <asp:Button ID="modelPopup" runat="server" Style="display: none" />
        <asp:Panel ID="inbox_panel" runat="server" Visible="false">
            <div>
                <asp:UpdatePanel ID="uup1" runat="server">
                    <ContentTemplate>

                        <table class="table table-bordered mailinbox" style="border-collapse: collapse; margin-top: 10px;" border="0" cellpadding="5" cellspacing="3">

                            <thead>
                                <tr>
                                    <th class="head1 aligncenter">

                                        <asp:CheckBox ID="chk_all_inbox" runat="server" AutoPostBack="true" OnCheckedChanged="chk_all_inbox_CheckedChanged1" Text=" " Height="17px" Style="margin: 0px 0px 0px 0px;" />

                                        <%--<input type="checkbox" class="checkall" name="" style="display: block;" />--%>
                                    </th>

                                    <th class="head1">Sender</th>
                                    <th class="head0">Subject</th>

                                    <th class="head0">Date </th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="inbox_repeter" runat="server">
                                <ItemTemplate>
                                    <tbody>
                                        <tr class="unread">
                                            <td class="aligncenter">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text=" " Height="17px" Style="margin: 0px 0px 0px 0px;" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                            </td>

                                            <td><%#Eval("sender_name") %></td>
                                            <td>
                                                <asp:LinkButton ID="lnk_inbox" runat="server" class="title" CommandArgument='<%#Eval("code") %>' OnClick="lnk_inbox_Click1"><%#Eval("message_title") %></asp:LinkButton>
                                            </td>

                                            <td class="date"><%#Eval("message_date") %>
                                                <div style="float: right;">
                                                    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>--%>
                                                    <asp:LinkButton ID="link_replay" CssClass="bttn1 blue1" CommandArgument='<%#Eval("code") %>' OnClick="link_replay_Click" runat="server">Replay</asp:LinkButton>
                                                    <%-- </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="link_replay" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                                </div>
                                            </td>
                                        </tr>

                                        <%--<tr>
                    <td class="aligncenter">
                        <input type="checkbox" class="checkbox" name="" style="display:block;" /></td>
                    
                    <td>Itzurkarthi</td>
                    <td><a href="" class="title">Identifying Browser Window Screen Size & Name with JQuery</a></td>
                    
                    <td class="date">June 19</td>
                </tr>--%>
                                    </tbody>
                                </ItemTemplate>
                            </asp:Repeater>


                        </table>
                        <div style="margin-left: 151px; margin-top: 10px; text-align: center; width: 789px; float: left;">
                            <asp:Label ID="lbl_error_inbox" runat="server" ForeColor="Red" Text="This Message is Not Found" Visible="false"></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chk_all_inbox" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>

        </asp:Panel>

        <asp:Panel ID="outbox_panel" runat="server" Visible="false">
            <div>
                <asp:UpdatePanel ID="up_outbox" runat="server">
                    <ContentTemplate>
                        <table class="table table-bordered mailinbox" style="border-collapse: collapse; margin-top: 10px;" border="0" cellpadding="5" cellspacing="3">

                            <thead>
                                <tr>
                                    <th class="head1 aligncenter">
                                        <asp:CheckBox ID="chk_all_outbox" runat="server" Text=" " AutoPostBack="true" OnCheckedChanged="chk_all_outbox_CheckedChanged" Height="17px" Style="margin: 0px 0px 0px 0px;" />
                                        <%-- <input type="checkbox" class="checkall" name="" style="display: block;" />--%>
                                    </th>

                                    <th class="head1">To</th>
                                    <th class="head0">Subject</th>

                                    <th class="head0">Date</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="sentmail_repeater" runat="server">
                                <ItemTemplate>
                                    <tbody>
                                        <tr class="unread">
                                            <td class="aligncenter">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text=" " Height="17px" Style="margin: 0px 0px 0px 0px;" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                            </td>

                                            <td><%#Eval("receiver_name") %></td>
                                            <td>
                                                <asp:LinkButton ID="link_detail_msg" runat="server" class="title" CommandArgument='<%#Eval("code252") %>' OnClick="link_detail_msg_Click"><%#Eval("message_title") %></asp:LinkButton></td>

                                            <td class="date"><%#Eval("message_date") %></td>
                                        </tr>



                                    </tbody>
                                </ItemTemplate>
                            </asp:Repeater>

                        </table>
                        <div style="background-color: #e6e6e6; margin-left: 151px; margin-top: 10px; text-align: center; width: 789px; float: left;">
                            <asp:Label ID="lbl_error_outbox" runat="server" ForeColor="Red" Text="This Message is Not Found" Visible="false"></asp:Label>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chk_all_outbox" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>

        </asp:Panel>
        <asp:Panel ID="pnl_outbox_subject" runat="server" Visible="false">

            <div style="background-color: #E6E6E6; float: left; width: 690px; padding: 20px;">
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="Message_to" runat="server" Text="Message to :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_messge_to" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="date" runat="server" Text="Date :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="subject" runat="server" Text="Subject :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_subject_list" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="lbl_description" runat="server" Text="Description :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_message_all" runat="server" Text=""></asp:Label>
                    </div>
                </div>


            </div>
        </asp:Panel>
        <asp:Panel ID="pnl_outbox_subject_replay" runat="server" Visible="false">

            <div style="background-color: #E6E6E6; float: left; width: 690px; padding: 20px;">
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="Message_to1" runat="server" Text="Message to :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_messge_to1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="date1" runat="server" Text="Date :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_date1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="subject1" runat="server" Text="Subject :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_subject_list1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <div style="float: left; width: 110px; font-weight: 700;">
                        <asp:Label ID="lbl_description1" runat="server" Text="Description :"></asp:Label>
                    </div>
                    <div style="width: 540px; float: left;">
                        <asp:Label ID="lbl_message_all1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 690px; float: left;">
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div style="width: 690px; float: left;">
                    <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div style="width: 690px; margin-top: 20px; float: left;">
                    <asp:LinkButton ID="link_relay" CssClass="bttn1 blue1" OnClick="link_relay_Click" runat="server">Replay</asp:LinkButton>
                    <asp:TextBox ID="txt_discription" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div style="width: 540px; margin-left: 17px; float: right;">
                    <asp:Button ID="btn_send1" runat="server" Visible="false" CssClass="bttn blue" Text="Send" OnClick="btn_send1_Click" />
                </div>

            </div>
            <div>
            </div>
        </asp:Panel>
        <asp:Panel ID="compose_panel" runat="server" Visible="false">
            <div class="admin-content-wrapper" style="float: left;">

                <div>
                    <div>
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <div style="float: left; width: 200px;">
                                    <asp:Label ID="lbl_message_to" runat="server" Text="Message to :"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox ID="txt_message_to" runat="server" AutoPostBack="true" OnTextChanged="txt_message_to_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lbl_message_to_error" runat="server" ForeColor="Red" Text="Not Existing User" Visible="false"></asp:Label>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txt_message_to" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <div style="float: left; width: 200px;">
                            <asp:Label ID="lbl_subject" runat="server" Text="Subject :"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txt_subject" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_subject" Display="None" ErrorMessage="Enter Title" ValidationGroup="msg"></asp:RequiredFieldValidator>
                        </div>
                    </div>



                    <div>

                        <div style="float: left; width: 200px;">
                            <asp:Label ID="lbl_message" runat="server" Text="Message :"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txt_msg" runat="server" TextMode="MultiLine" Width="300px" Height="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_msg" Display="None" ErrorMessage="Enter Message" ValidationGroup="msg"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div>
                        <div>
                            <asp:Button ID="btn_send" runat="server" CssClass="bttn blue" Text="Send" OnClick="btn_send_Click" ValidationGroup="msg" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="msg" ShowMessageBox="true" ShowSummary="false" />
                        </div>
                    </div>
                </div>


            </div>
        </asp:Panel>
        <asp:Panel ID="compose_panel1" runat="server" Visible="false">
            <div class="admin-content-wrapper" style="float: left;">

                <div>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="float: left; width: 200px;">
                                    <asp:Label ID="Label1" runat="server" Text="Message to :"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox ID="txt_message" runat="server" AutoPostBack="true" OnTextChanged="txt_message_to_TextChanged"></asp:TextBox>
                                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Not Existing User" Visible="false"></asp:Label>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txt_message_to" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <div style="float: left; width: 200px;">
                            <asp:Label ID="Label3" runat="server" Text="Subject :"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_subject" Display="None" ErrorMessage="Enter Title" ValidationGroup="msg"></asp:RequiredFieldValidator>
                        </div>
                    </div>



                    <div>

                        <div style="float: left; width: 200px;">
                            <asp:Label ID="Label4" runat="server" Text="Message :"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Width="300px" Height="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_msg" Display="None" ErrorMessage="Enter Message" ValidationGroup="msg"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div>
                        <div>
                            <asp:Button ID="btn_send11" runat="server" CssClass="bttn blue" Text="Send" OnClick="btn_send11_Click1" ValidationGroup="msg" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="msg" ShowMessageBox="true" ShowSummary="false" />
                        </div>
                    </div>
                </div>


            </div>
        </asp:Panel>
        <asp:Panel ID="contacts_panel" runat="server" Visible="false">
            <div>
                <asp:UpdatePanel ID="up_contact" runat="server">
                    <ContentTemplate>
                        <table class="table table-bordered mailinbox" style="border-collapse: collapse; margin-top: 10px;" border="0" cellpadding="5" cellspacing="3">

                            <thead>
                                <tr>
                                    <th class="head1 aligncenter">
                                        <asp:CheckBox ID="chk_contact" runat="server" Text=" " AutoPostBack="true" OnCheckedChanged="chk_contact_CheckedChanged" Height="17px" Style="margin: 0px 0px 0px 0px;" />
                                        <%--<input type="checkbox" class="checkall" name="" style="display: block;" />--%>
                                    </th>


                                    <th class="head1">Conatact Name</th>
                                    <th class="head0">Email ID</th>

                                    <th class="head0">Mobile No</th>
                                    <th class="head0">Send message</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="contacts_repeter" runat="server">
                                <ItemTemplate>
                                    <tbody>
                                        <tr class="unread">
                                            <td class="aligncenter">
                                                <%--  <input type="checkbox" class="checkbox" name="" style="display: block;" />--%>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text=" " Height="17px" Style="margin: 0px 0px 0px 0px;" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                            </td>
                                            <td><%#Eval("consultant_name") %></td>
                                            <td><a href="" class="title"><%#Eval("consultant_email") %></a></td>

                                            <td class="date"><%#Eval("phone_no") %></td>
                                            <td>
                                                <asp:LinkButton ID="link_send_message" runat="server" CommandArgument='<%#Eval("code252") %>'
                                                    OnClick="link_send_message_Click">Send Private Message</asp:LinkButton></td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div style="background-color: #e6e6e6; margin-left: 151px; margin-top: 10px; text-align: center; width: 789px; float: left;">
                            <asp:Label ID="lbl_error_contact" runat="server" ForeColor="Red" Text="This Contact is Not Found" Visible="false"></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chk_contact" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>


            </div>

        </asp:Panel>
    </div>

</asp:Content>

