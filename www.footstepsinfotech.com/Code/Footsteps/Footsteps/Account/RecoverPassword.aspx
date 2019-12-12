<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="RecoverPassword.aspx.cs" Inherits="Footsteps.Account.RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg1">
        <div class="main">
            <div id="ContactForm">
                <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" OnUserLookupError="PasswordRecovery1_UserLookupError"
                    OnLoad="PasswordRecovery1_Load" BorderStyle="None" Width="97%" OnSendingMail="PasswordRecovery1_SendingMail">
                    <SuccessTemplate>
                        <table border="0" style="font-size: 10pt;">
                            <tr>
                                <td>
                                    Your password has been sent to you.
                                </td>
                            </tr>
                        </table>
                    </SuccessTemplate>
                    <UserNameTemplate>
                        <h2>
                            Password Recovery</h2>
                        <div class="article">
                            Forgot your Password? Don't worry! Enter your username to recover the password.
                            The password would be reset and system generated password would be sent out via
                            email to the registered email address in our system.
                            <p>
                                <div class="wrapper">
                                    <span>Username (Email Id).</span>
                                    <div class="bg">
                                        <asp:TextBox ID="UserName" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                            CssClass="input" />
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            EnableViewState="false" ViewStateMode="Disabled" ErrorMessage="User Name is required."
                                            ToolTip="User Name is required." Display="None" ValidationGroup="PasswordRecovery1"
                                            Text="*" />
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False" ViewStateMode="Disabled" />
                                </div>
                                <div class="clearfix">
                                    <br />
                                </div>
                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1"
                                    ViewStateMode="Disabled" EnableViewState="false" CssClass="button1" />
                        </div>
                        </p>
                    </UserNameTemplate>
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <MailDefinition BodyFileName="~/DynamicData/Content/EmailTemplates/AccountRecoverPassword.htm"
                        IsBodyHtml="True" Priority="High" Subject="Account Password Reset" />
                    <SuccessTextStyle Font-Bold="True" ForeColor="#507CD1" />
                    <TextBoxStyle />
                    <TitleTextStyle BackColor="#025774" Font-Bold="True" ForeColor="White" />
                </asp:PasswordRecovery>
            </div>
        </div>
    </div>
</asp:Content>
