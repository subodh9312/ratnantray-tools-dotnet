<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="RecoverPassword.aspx.cs" Inherits="mytemplate.Account.RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" OnUserLookupError="PasswordRecovery1_UserLookupError"
            OnLoad="PasswordRecovery1_Load" BorderStyle="None" BorderWidth="1px" Font-Names="Verdana" UserNameLabelText="Username (Email Id)"
            BorderColor="#B5C7DE" BackColor="#ffffff" BorderPadding="4" Width="97%" OnSendingMail="PasswordRecovery1_SendingMail">
            <SuccessTemplate>
                <table border="0" style="font-size: 10pt;">
                    <tr>
                        <td>
                            Your password has been sent to you.
                        </td>
                    </tr>
                </table>
            </SuccessTemplate>
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <MailDefinition BodyFileName="~/DynamicData/Content/EmailTemplates/AccountRecoverPassword.htm"
                IsBodyHtml="True" Priority="High" Subject="Account Password Reset" />
            <SuccessTextStyle Font-Bold="True" ForeColor="#507CD1" />
            <TextBoxStyle />
            <TitleTextStyle BackColor="#025774" Font-Bold="True" ForeColor="White" />
        </asp:PasswordRecovery>
    </p>
</asp:Content>
