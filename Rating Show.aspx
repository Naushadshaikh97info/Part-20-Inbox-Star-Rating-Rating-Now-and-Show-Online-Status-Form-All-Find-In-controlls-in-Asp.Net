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
      <div style="margin-bottom: 10px; float: left; width: 100%; border: 1px solid #E1E1E1;">
                                    <div class="header" style="padding-bottom: 0px; margin-bottom: 8px; background: url(./img/header_.png) no-repeat scroll center center #f4f4f4;">
                                        <dl class="dl-horizontal" style="margin-bottom: 8px;">

                                            <dd style="margin-top: 8px; margin-left: 5px;">
                                                <h4>Your Ratings</h4>

                                            </dd>
                                        </dl>

                                    </div>
                                    <asp:Panel ID="Panel1" runat="server" Visible="true">
                                        <div class="standard-form row-fluid">
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


                                        </div>

                                        <div class="standard-form row-fluid">

                                            <table>
                                                <tr>
                                                    <td style="width: 67.6%;">Cost :</td>
                                                    <td>
                                                        <cc2:Rating ID="Rating2" OnChanged="Rating1_Changed2" runat="server" AutoPostBack="true" ReadOnly="true"
                                                            StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                            FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating2") %>'>
                                                        </cc2:Rating>
                                                    </td>
                                                </tr>
                                            </table>


                                        </div>
                                        <div class="standard-form row-fluid">
                                            <table>
                                                <tr>
                                                    <td style="width: 67.6%;">Timing of Payment :</td>
                                                    <td>
                                                        <cc2:Rating ID="Rating3" OnChanged="Rating1_Changed3" runat="server" AutoPostBack="true" ReadOnly="true"
                                                            StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                            FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating3") %>'>
                                                        </cc2:Rating>
                                                    </td>
                                                </tr>
                                            </table>


                                        </div>
                                        <div class="standard-form row-fluid">
                                            <table>
                                                <tr>
                                                    <td style="width: 67.6%;">Recommend this Agent :</td>
                                                    <td>
                                                        <cc2:Rating ID="Rating4" OnChanged="Rating1_Changed4" runat="server" AutoPostBack="true" ReadOnly="true"
                                                            StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                            FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating4") %>'>
                                                        </cc2:Rating>
                                                    </td>
                                                </tr>
                                            </table>


                                        </div>
                                    </asp:Panel>
                                </div>
</asp:Content>

