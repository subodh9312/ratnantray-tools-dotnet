<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="mytemplate.Account.ChangePassword" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <p>
        New passwords are required to be a minimum of
        <%= Membership.MinRequiredPasswordLength %>
        characters in length.
    </p>
    <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/" OnSendingMail="ChangeUserPassword_SendingMail"
        EnableViewState="false" RenderOuterTable="false" SuccessPageUrl="ChangePasswordSuccess.aspx">
        <ChangePasswordTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
            </span>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="ChangeUserPasswordValidationGroup" />
            <fieldset>
                <legend>Account Information</legend>
                <table width="100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"
                                ViewStateMode="Disabled" EnableViewState="false" Text="Old Password" />
                        </td>
                        <td>
                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" ViewStateMode="Disabled"
q                                EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                Display="Dynamic" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                                ValidationGroup="ChangeUserPasswordValidationGroup" Text="*" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"
                                ViewStateMode="Disabled" EnableViewState="false" Text="New Password" />
                        </td>
                        <td>
                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                                ValidationGroup="ChangeUserPasswordValidationGroup" ViewStateMode="Disabled"
                                EnableViewState="false" EnableClientScript="true" Text="*" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
                                ViewStateMode="Disabled" EnableViewState="false" Text="Confirm New Password" />
                        </td>
                        <td>
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                CssClass="failureNotification" ErrorMessage="Confirm New Password is required."
                                ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup"
                                Display="Dynamic" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                Text="*" />
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                                ErrorMessage="The Confirm New Password must match the New Password entry." ViewStateMode="Disabled"
                                EnableViewState="false" EnableClientScript="true" Text="*" ValidationGroup="ChangeUserPasswordValidationGroup" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                    Text="Change Password" ValidationGroup="ChangeUserPasswordValidationGroup" Width="200px" />
                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel" Width="100px" />
            </p>
        </ChangePasswordTemplate>
        <MailDefinition BodyFileName="~/DynamicData/Content/EmailTemplates/PasswordChangeNotification.htm"
            IsBodyHtml="True" Priority="High" Subject="My Template: Password change notification...">
        </MailDefinition>
    </asp:ChangePassword>
</asp:Content>
