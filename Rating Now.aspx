<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Instant_message.aspx.cs" Inherits="Instant_message" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .ratingEmpty {
            background-image: url(./ratingStarEmpty.gif);
            width: 18px;
            height: 18px;
        }

        .ratingFilled {
            background-image: url(./ratingStarFilled.gif);
            width: 18px;
            height: 18px;
        }

        .ratingSaved {
            background-image: url(./ratingStarSaved.gif);
            width: 18px;
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="span4 post_page_cont" style="width: 100%;">
        <asp:HiddenField runat="server" ID="hiddenField" Value='<%# Eval("code") %>' />
        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("online_status") %>' Visible="false"></asp:LinkButton>
        <asp:ImageButton ID="img_green" runat="server" ImageUrl="~/content/images/green.png" Visible="false" Height="10" Style="width: 10px !important; margin-bottom: 0px; margin-right: 0px;" />
        <asp:ImageButton ID="img_grey" runat="server" ImageUrl="~/content/images/grey_btn.png" Visible="false" Height="10" Style="width: 10px !important; margin-bottom: 0px; margin-right: 0px;" />

        <asp:LinkButton ID="link_online_message" runat="server" CommandArgument='<%#Eval("code") %>' OnClick="link_online_message_Click">
            <asp:Label ID="lbl_online" runat="server" Text="Online" Visible="false"></asp:Label><asp:Label ID="lbl_offline" runat="server" Text="Offline" Visible="false"></asp:Label>
            | Instant Message
        </asp:LinkButton><br />
        <br />
        <table>
            <tr>
                <td style="width: 67.5%;">Quality of Service :</td>
                <td>
                    <cc2:Rating ID="Rating1" OnChanged="Rating1_Changed" runat="server" AutoPostBack="true" ReadOnly="true"
                        StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                        FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating") %>'>
                    </cc2:Rating>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 67.6%;">Cost :</td>
                <td>
                    <cc2:Rating ID="Rating2" OnChanged="Rating1_Changed2" runat="server" AutoPostBack="true" ReadOnly="true"
                        StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                        FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating2") %>'>
                    </cc2:Rating></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 67.6%;">Timing of Payment :</td>
                <td>
                    <cc2:Rating ID="Rating3" OnChanged="Rating1_Changed3" runat="server" AutoPostBack="true" ReadOnly="true"
                        StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                        FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating3") %>'>
                    </cc2:Rating></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 67.6%;">Recommend this :</td>
                <td>
                    <cc2:Rating ID="Rating4" OnChanged="Rating1_Changed4" runat="server" AutoPostBack="true" ReadOnly="true"
                        StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                        FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating4") %>'>
                    </cc2:Rating></td>
            </tr>
        </table>
        <br />
        <asp:LinkButton ID="link_rate_now" runat="server" CssClass="btn1" Style="float: right; margin-right: 10px;" CommandArgument='<%#Eval("code") %>' OnClick="link_rate_now_Click">Rate Now</asp:LinkButton><br />

    </div>

</asp:Content>

