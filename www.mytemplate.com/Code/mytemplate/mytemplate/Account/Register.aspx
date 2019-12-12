<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="mytemplate.Account.Register" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser"
        CompleteSuccessText="Your account has been created, but before you can login you must first verify your email address. A message has been sent to the email address you specified. Please check your mailbox (inbox and spam) and follow the instructions in that email to verify your account."
        ContinueDestinationPageUrl="~/" DisableCreatedUser="true" DuplicateUserNameErrorMessage="User Name already in use! Please enter a different user name."
        RequireEmail="true" OnSendingMail="RegisterUser_SendingMail">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server" ViewStateMode="Disabled"
                EnableViewState="false" />
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server" ViewStateMode="Disabled"
                EnableViewState="false" />
        </LayoutTemplate>
        <MailDefinition IsBodyHtml="True" Priority="High" />
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <p>
                        Use the form below to create a new account.
                        <br />
                        Passwords are required to be a minimum of
                        <%= Membership.MinRequiredPasswordLength %>
                        characters in length.
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                        ValidationGroup="RegisterUserValidationGroup" />
                    <fieldset class="register">
                        <legend>Account Information</legend>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName" ViewStateMode="Disabled"
                                        EnableViewState="false" Text="First Name" />
                                </td>
                                <td>
                                    <asp:TextBox ID="FirstName" runat="server" EnableViewState="false" ViewStateMode="Disabled" />
                                    <asp:RequiredFieldValidator ID="FirstNameRFV" runat="server" ViewStateMode="Disabled"
                                        EnableViewState="false" Display="Dynamic" ControlToValidate="FirstName" ValidationGroup="RegisterUserValidationGroup"
                                        ToolTip="Enter your First Name Here" ErrorMessage="Please enter your First Name"
                                        Text="*" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName" ViewStateMode="Disabled"
                                        EnableViewState="false" Text="Last Name" />
                                </td>
                                <td>
                                    <asp:TextBox ID="LastName" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                    <asp:RequiredFieldValidator ID="LastNameRFV" runat="server" ViewStateMode="Disabled"
                                        EnableViewState="false" Display="Dynamic" ControlToValidate="LastName" ValidationGroup="RegisterUserValidationGroup"
                                        ToolTip="Enter your First Name Here" ErrorMessage="Please enter your First Name"
                                        Text="*" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="EducationLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="Education" Text="Education" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Education" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ViewStateMode="Disabled"
                                        EnableViewState="false" Text="Email Id. <small><i>(Username)</i></small>" />
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        ToolTip="Email address would be treated as your username" />
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        Display="Dynamic" CssClass="failureNotification" ErrorMessage="User Name is required."
                                        ToolTip="User Name is required." ValidationGroup="RegisterUserValidationGroup"
                                        Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                                    <asp:RegularExpressionValidator ID="EmailAsUsernameValidation" runat="server" ControlToValidate="UserName"
                                        Display="Dynamic" CssClass="failureNotification" ErrorMessage="Please enter a valid Email address."
                                        ValidationGroup="RegisterUserValidationGroup" ToolTip="Please enter a valid Email address."
                                        Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ViewStateMode="Disabled"
                                        EnableViewState="false" Text="Password" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                        EnableViewState="false" />
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        Display="Dynamic" CssClass="failureNotification" ErrorMessage="Password is required."
                                        ToolTip="Password is required." ValidationGroup="RegisterUserValidationGroup"
                                        Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword"
                                        ViewStateMode="Disabled" EnableViewState="false" Text="Confirm Password" />
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Disabled" EnableViewState="false" />
                                    <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                        Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                                        runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup"
                                        Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                                        ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup"
                                        Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="CellNo1Label" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="CellNo1" Text="Cell No. 1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="CellNo1" runat="server" EnableViewState="false" ViewStateMode="Disabled" />
                                    <asp:RegularExpressionValidator ID="CellNoRFV" runat="server" ControlToValidate="CellNo1"
                                        ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Cell No. Only Numbers are allowed"
                                        Text="*" Display="Dynamic" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="CellNo2Label" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="CellNo2" Text="Cell No. 2" />
                                </td>
                                <td>
                                    <asp:TextBox ID="CellNo2" runat="server" EnableViewState="false" ViewStateMode="Disabled" />
                                    <asp:RegularExpressionValidator ID="CellNo2RFV" runat="server" ControlToValidate="CellNo2"
                                        ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Cell No. Only Numbers are allowed"
                                        Text="*" Display="Dynamic" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="DirectNoLabel" runat="server" AssociatedControlID="DirectNo" ViewStateMode="Disabled"
                                        EnableViewState="false" Text="Direct No." />
                                </td>
                                <td>
                                    <asp:TextBox ID="DirectNo" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                    <asp:RegularExpressionValidator ID="DirectNoRFV" runat="server" ControlToValidate="DirectNo"
                                        ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Direct No. Only Numbers are allowed"
                                        Text="*" Display="Dynamic" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="SwitchBoardNoLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="SwitchBoardNo" Text="Organisation Board No. (with Extension)" />
                                </td>
                                <td>
                                    <asp:TextBox ID="SwitchBoardNo" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                    <asp:RegularExpressionValidator ID="SwitchBoardNoRFV" runat="server" ControlToValidate="SwitchBoardNo"
                                        ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Swtich Board No. Only Numbers are allowed"
                                        Text="*" Display="Dynamic" EnableClientScript="true" />
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="Extension" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        Columns="4" />
                                    <asp:RegularExpressionValidator ID="ExtensionRFV" runat="server" ControlToValidate="Extension"
                                        ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Extension No. Only Numbers are allowed"
                                        Text="*" Display="Dynamic" EnableClientScript="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="OrganisationLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="Organisation" Text="Organisation" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Organisation" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        TextMode="MultiLine" Rows="5" Width="90%" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="CityLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="City" Text="City" />
                                </td>
                                <td>
                                    <asp:TextBox ID="City" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="ProfilePhotoLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        AssociatedControlID="UploadPhoto" Text="Profile Photo" />
                                </td>
                                <td>
                                    <asp:FileUpload ID="UploadPhoto" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                        Width="97%" />
                                    <asp:RegularExpressionValidator ID="FileUploadExtensionValidator" runat="server"
                                        ControlToValidate="UploadPhoto" ViewStateMode="Disabled" EnableViewState="false"
                                        SetFocusOnError="true" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif)$" ForeColor="Red"
                                        EnableClientScript="true" Display="Dynamic" ErrorMessage="Only jpg, jpeg, png and gif files." />
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Email" ViewStateMode="Disabled" EnableViewState="false" runat="server" Visible="false" />
                    </fieldset>
                    <p>
                        <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User"
                            ValidationGroup="RegisterUserValidationGroup" Width="100px" />
                    </p>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
