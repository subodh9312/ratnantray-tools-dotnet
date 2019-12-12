<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comment.ascx.cs" Inherits="Footsteps.UserControls.CommentCtrl.CommentCtrl" %>
<%@ Register Src="~/UserControls/Captcha/MyCaptcha.ascx" TagName="MyCaptcha" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false"
    EnableViewState="false" ViewStateMode="Disabled">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="SubmitComment" EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <asp:GridView ID="GV1" runat="server" CellPadding="4" Width="100%" AllowPaging="True"
            PageSize="5" AutoGenerateColumns="False" DataKeyNames="Id" GridLines="None" ViewStateMode="Disabled"
            EnableViewState="false">
            <AlternatingRowStyle BackColor="#F2FAFD" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Here's what some of the user have to say.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <span>
                            <%# Footsteps.Controller.Utilities.BizUtility.ToUpperInvariant(Eval("SubmitterName").ToString())  %>
                            <small>said -</small></span>&nbsp; on <small>
                                <%# String.Format("{0:dddd, MMMM d}", Eval("SubmitDate")) %></small>
                        <div class="blockquote">
                            <%# Eval("CommentText").ToString() %>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="Rss" />
            <EditRowStyle BackColor="#ECF9FD" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#FAFDFE" ForeColor="#003399" BorderColor="#393939" BorderWidth="1px"
                BorderStyle="Solid" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <hr />
        <table cellspacing="1" cellpadding="1" width="100%">
            <tr>
                <td colspan="4" class="Rss">
                    <b>Travelled this route? Have your say here.</b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="color: #393939; text-align: right;">
                    <strong>Name</strong>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="SubmitterName" runat="server" MaxLength="100" ValidationGroup="CommentGroup"
                        EnableViewState="false" ViewStateMode="Disabled" Width="90%" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                        ValidationGroup="CommentGroup" Display="Dynamic" ControlToValidate="SubmitterName"
                        ForeColor="Red" EnableClientScript="true" EnableViewState="false" ViewStateMode="Disabled" />
                </td>
                <td style="color: #393939; text-align: right;">
                    <strong>Email</strong>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="SubmitterEmail" runat="server" MaxLength="100" EnableViewState="false"
                        ViewStateMode="Disabled" Width="79%" />
                    <asp:RequiredFieldValidator ID="RFV" runat="server" EnableClientScript="true" EnableViewState="false"
                        ViewStateMode="Disabled" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ControlToValidate="SubmitterEmail"
                        SetFocusOnError="true" ToolTip="Email Address" ValidationGroup="CommentGroup" />
                    <asp:RegularExpressionValidator ID="REV" runat="server" EnableClientScript="true"
                        EnableViewState="false" ViewStateMode="Disabled" ErrorMessage="*" ForeColor="Red"
                        ControlToValidate="SubmitterEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        SetFocusOnError="True" ValidationGroup="CommentGroup" Display="Dynamic" ToolTip="Email Address" />
                </td>
                <td style=" color: #393939; text-align: right;">
                    <strong>Website</strong>
                </td>
                <td>
                    <asp:TextBox ID="WebsiteText" runat="server" MaxLength="80" EnableViewState="false"
                        ViewStateMode="Disabled" Width="90%" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" EnableClientScript="true"
                        EnableViewState="false" ViewStateMode="Disabled" ErrorMessage="*" ForeColor="Red"
                        ControlToValidate="WebsiteText" ValidationGroup="CommentGroup" Display="Dynamic"
                        ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" SetFocusOnError="True"
                        ToolTip="Your Website Address" />
                </td>
            </tr>
            <tr>
                <td style="color: #393939; text-align: right;">
                    <strong>Comment</strong>&nbsp;
                </td>
                <td colspan="3">
                    <asp:TextBox ID="CommentText" TextMode="MultiLine" runat="server" Width="90%" EnableViewState="false"
                        ViewStateMode="Disabled" Rows="6" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required!"
                        ControlToValidate="CommentText" ForeColor="Red" ValidationGroup="CommentGroup"
                        EnableViewState="false" ViewStateMode="Disabled" />
                </td>
            </tr>
            <tr align="left">
                <td colspan="3" width="60%">
                    <uc1:MyCaptcha ID="MyCaptcha1" runat="server" />
                    <asp:Label ID="lblCheckResult" runat="server" Text="" ForeColor="Red" />
                </td>
                <td colspan="1" width="40%">
                    <asp:Button ID="SubmitComment" ForeColor="White" BackColor="#393939" runat="server"
                        CausesValidation="true" Text=" Submit Comment " OnClick="SubmitComment_Click"
                        OnClientClick="if(Page_IsValid) { if(this.innerHTML == 'Submitting...') { return false; } alert('Submitting... Please wait! \n\n\n The process can take upto 30 seconds...');}" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <i><b>
                        <asp:Label ID="SubmitConfirmation" runat="server" Visible="False" ForeColor="Red" /></b></i>
                </td>
            </tr>
        </table>
        <hr />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="HiddenEntityId" runat="server" EnableViewState="false" ViewStateMode="Disabled" />
<asp:HiddenField ID="HiddedEntityType" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
