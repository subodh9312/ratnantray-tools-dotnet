<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Footsteps.Account.ChangePassword" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="bg1">
        <div class="main">
            <h2>
                Change Password</h2>
            <div id="ContactForm" class="article">
                <p>
                    Please fill out the form to verify your identity. The new password is required to
                    be a minimum of
                    <%= Membership.MinRequiredPasswordLength %>
                    characters in length. Once the password is updated you would receive an confirmation
                    email to the registered email address present in our system.
                </p>
                <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/"
                    OnSendingMail="ChangeUserPassword_SendingMail" EnableViewState="false" RenderOuterTable="false"
                    SuccessPageUrl="ChangePasswordSuccess.aspx">
                    <ChangePasswordTemplate>
                        <span class="failureNotification">
                            <asp:Literal ID="FailureText" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                        </span>
                        <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="servicesList"
                            ValidationGroup="ChangeUserPasswordValidationGroup" DisplayMode="BulletList"
                            EnableClientScript="true" />
                        <div class="wrapper">
                            <span>Old Password</span>
                            <div class="bg">
                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                    EnableViewState="false" CssClass="input" />
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                    Display="None" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                                    ValidationGroup="ChangeUserPasswordValidationGroup" Text="*" />
                            </div>
                        </div>
                        <div class="wrapper">
                            <span>New Password</span>
                            <div class="bg">
                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                    EnableViewState="false" CssClass="input" />
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                    CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                                    ValidationGroup="ChangeUserPasswordValidationGroup" ViewStateMode="Disabled"
                                    Display="None" EnableViewState="false" EnableClientScript="true" Text="*" />
                            </div>
                        </div>
                        <div class="wrapper">
                            <span>Confirm New Password</span>
                            <div class="bg">
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                    EnableViewState="false" CssClass="input" />
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="failureNotification" ErrorMessage="Confirm New Password is required."
                                    ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup"
                                    Display="None" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                    Text="*" />
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                    ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="None"
                                    ErrorMessage="The Confirm New Password must match the New Password entry." ViewStateMode="Disabled"
                                    EnableViewState="false" EnableClientScript="true" Text="*" ValidationGroup="ChangeUserPasswordValidationGroup" />
                            </div>
                        </div>
                        <div class="clearfix">
                            <br />
                        </div>
                        <p>
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                Text="Change Password" ValidationGroup="ChangeUserPasswordValidationGroup" CssClass="button1" />
                            &nbsp;
                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" CssClass="button1" />
                        </p>
                    </ChangePasswordTemplate>
                    <MailDefinition BodyFileName="~/DynamicData/Content/EmailTemplates/PasswordChangeNotification.htm"
                        IsBodyHtml="True" Priority="High" Subject="Footsteps Infotech Inc.: Password change notification...">
                    </MailDefinition>
                </asp:ChangePassword>
            </div>
        </div>
    </div>
</asp:Content>
