<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="mytemplate.Account.Login" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br />
    <p>
        Please enter your username and password.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink>
        if you don't have an account.
        <br />
        Forgot password?
        <asp:HyperLink ID="ForgotPassword" runat="server" EnableViewState="false">Click here</asp:HyperLink>
        to recover password.
    </p>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
        OnLoggedIn="LoginUser_LoggedIn" OnLoginError="LoginUser_LoginError">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Label ID="FailureText" runat="server" ForeColor="Red"></asp:Label>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" />
            <div class="accountInfo">
                <fieldset class="login">
                    <legend class="TransparentBack">Account Information</legend>
                    <table cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ViewStateMode="Disabled"
                                    EnableViewState="false" Text="Username (Email Id.)" />
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    Display="Dynamic" CssClass="failureNotification" ErrorMessage="User Name is required."
                                    ToolTip="User Name is required." ValidationGroup="LoginUserValidationGroup" Text="*"
                                    ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ViewStateMode="Disabled"
                                    EnableViewState="false" Text="Password" />
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                    EnableViewState="false" />
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    Display="Dynamic" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <p>
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                        Width="100px" />
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
    <asp:Label ID="CompleteLoginMessage" runat="server" ForeColor="Red" Font-Bold="False"
        ViewStateMode="Disabled" EnableViewState="false" Font-Italic="False" Font-Size="Small" />
    <br />
    <asp:Button ID="SendMail" runat="server" OnClick="SendMail_Click" Visible="False" />
</asp:Content>
