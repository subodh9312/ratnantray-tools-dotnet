﻿    <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentComments.ascx.cs"
    Inherits="mytemplate.UserControls.RecentComments.RecentComments" EnableViewState="false"
    ViewStateMode="Disabled" %>
<asp:GridView ID="RecentComents" runat="server" AllowPaging="false" AllowSorting="false"
    AutoGenerateColumns="false" AutoGenerateDeleteButton="false" BorderStyle="None"
    Width="100%" GridLines="None" EnableViewState="false" ViewStateMode="Disabled">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                Recent Comments
            </HeaderTemplate>
            <ItemTemplate>
                <table width="100%" cellpadding="1" cellspacing="1">
                    <tr>
                        <td width="5%">
                            &nbsp;
                        </td>
                        <td width="85%">
                            <li>
                                <%# mytemplate.Controller.Utilities.
                                            BizUtility.ToUpperInvariant(Eval("SubmitterName").ToString()) %>
                                &nbsp;says :
                                <%# GetDisplayText(mytemplate.Controller.Utilities.BizUtility.ToUpperInvariant(Eval("CommentText").ToString()))%></li>
                        </td>
                        <td width="10%">
                            <a href='#' style="color: Blue;">
                                    &raquo;&raquo;&raquo;
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <HeaderStyle Width="100%" CssClass="Rss" />
            <FooterStyle Width="100%" CssClass="Rss" />
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#E0E0E0" />
    <RowStyle BackColor="#F0F0F0" />
</asp:GridView>
