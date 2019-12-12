<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Footsteps.Account.Login" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="bg1">
        <div class="main">
            <h2>
                Account Login</h2>
            <div class="article">
                Please enter your username and password.
                <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false" Text=" Register here " />
                if you don't have an account.
                <p>
                    Forgot password?
                    <asp:HyperLink ID="ForgotPassword" runat="server" EnableViewState="false" Text=" Click here " />
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
                        <div id="ContactForm">
                            <div class="wrapper">
                                <span>Username (Email Id.)</span>
                                <div class="bg">
                                    <asp:TextBox ID="UserName" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        CssClass="input" />
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        Display="None" CssClass="failureNotification" ErrorMessage="User Name is required."
                                        ToolTip="User Name is required." ValidationGroup="LoginUserValidationGroup" Text="*"
                                        ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                                </div>
                            </div>
                            <div class="wrapper">
                                <span>Password</span>
                                <div class="bg">
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                        EnableViewState="false" CssClass="input" />
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        Display="None" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="clearfix">
                                <br />
                            </div>
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                                CssClass="button1" />
                        </div>
                    </LayoutTemplate>
                </asp:Login>
            </div>
            <asp:Label ID="CompleteLoginMessage" runat="server" ForeColor="Red" Font-Bold="False"
                ViewStateMode="Disabled" EnableViewState="false" Font-Italic="False" Font-Size="Small" />
            <br />
            <asp:Button ID="SendMail" runat="server" OnClick="SendMail_Click" Visible="False" />
        </div>
    </div>
</asp:Content>
