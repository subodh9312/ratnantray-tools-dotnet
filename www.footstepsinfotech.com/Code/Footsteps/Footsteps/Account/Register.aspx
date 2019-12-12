<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Footsteps.Account.Register" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="bg1">
        <div class="main" id="content">
            <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser"
                CompleteSuccessText="Your account has been created, but before you can login you must first verify your email address. A message has been sent to the email address you specified. Please check your mailbox (inbox and spam) and follow the instructions in that email to verify your account."
                ContinueDestinationPageUrl="~/" DisableCreatedUser="true" DuplicateUserNameErrorMessage="User Name already in use! Please enter a different user name."
                RequireEmail="true" OnSendingMail="RegisterUser_SendingMail" AutoGeneratePassword="true">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server" ViewStateMode="Disabled"
                        EnableViewState="false" />
                    <asp:PlaceHolder ID="navigationPlaceholder" runat="server" ViewStateMode="Disabled"
                        EnableViewState="false" />
                </LayoutTemplate>
                <MailDefinition BodyFileName="~/DynamicData/Content/EmailTemplates/AccountActivation.htm"
                    IsBodyHtml="True" Priority="High" />
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                        <ContentTemplate>
                            <h2>
                                Let's work Together</h2>
                            <p>
                                Use the form below to apply @ Footsteps Infotech Inc. You can update your profile
                                any time or even delete your account.
                                <br />
                                Passwords are required to be a minimum of&nbsp;<%= Membership.MinRequiredPasswordLength %>&nbsp;
                                characters in length.
                            </p>
                            <span class="failureNotification">
                                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                            </span>
                            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="servicesList"
                                ValidationGroup="RegisterUserValidationGroup" />
                            <br />
                            <div id="ContactForm">
                                <div class="wrapper">
                                    <span>First Name:</span>
                                    <div class="bg">
                                        <asp:TextBox ID="FirstName" runat="server" EnableViewState="false" ViewStateMode="Disabled"
                                            CssClass="input" />
                                        <asp:RequiredFieldValidator ID="FirstNameRFV" runat="server" ViewStateMode="Disabled"
                                            EnableViewState="false" Display="None" ControlToValidate="FirstName" ValidationGroup="RegisterUserValidationGroup"
                                            ToolTip="Enter your First Name Here" ErrorMessage="Please enter your First Name"
                                            Text="*" EnableClientScript="true" />
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <span>Last Name:</span>
                                    <div class="bg">
                                        <asp:TextBox ID="LastName" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                            CssClass="input" />
                                        <asp:RequiredFieldValidator ID="LastNameRFV" runat="server" ViewStateMode="Disabled"
                                            EnableViewState="false" Display="None" ControlToValidate="LastName" ValidationGroup="RegisterUserValidationGroup"
                                            ToolTip="Enter your First Name Here" ErrorMessage="Please enter your First Name"
                                            Text="*" EnableClientScript="true" />
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <span>Eductional Qualification:</span>
                                    <div class="bg">
                                        <asp:TextBox ID="Education" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                            CssClass="input" />
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <span>Email Id:</span>
                                    <div class="bg">
                                        <asp:TextBox ID="UserName" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                            ToolTip="Email address would be treated as your username" CssClass="input" />
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            Display="None" CssClass="failureNotification" ErrorMessage="Email Id is required."
                                            ToolTip="User Name is required." ValidationGroup="RegisterUserValidationGroup"
                                            Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                                        <asp:RegularExpressionValidator ID="EmailAsUsernameValidation" runat="server" ControlToValidate="UserName"
                                            Display="None" CssClass="failureNotification" ErrorMessage="Please enter a valid Email address."
                                            ValidationGroup="RegisterUserValidationGroup" ToolTip="Please enter a valid Email address."
                                            Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <span>Contact No:</span>
                                    <div class="bg">
                                        <asp:TextBox ID="ContactNo" runat="server" EnableViewState="false" ViewStateMode="Disabled"
                                            CssClass="input" />
                                        <asp:RegularExpressionValidator ID="CellNoRFV" runat="server" ControlToValidate="ContactNo"
                                            ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Cell No. Only Numbers are allowed"
                                            Text="*" Display="None" EnableClientScript="true" />
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <span>Work Preference:</span>
                                    <div class="bg">
                                        <div id="pseudo">
                                            <asp:DropDownList ID="WorkPrefrence" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                                AppendDataBoundItems="false">
                                                <asp:ListItem Text="Dhule" Value="Dhule" Selected="True" />
                                                <asp:ListItem Text="Pune" Value="Pune" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="wrapper">
                                    <span>Resume Doc:</span>
                                    <script type="text/javascript" src="/Scripts/js/fileUpload.js"></script>
                                    <div class="fileUpload">
                                        <label class="file-upload">
                                            <span>Upload Resume</span>
                                            <asp:FileUpload ID="UploadPhoto" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                            <asp:RegularExpressionValidator ID="FileUploadExtensionValidator" runat="server"
                                                ControlToValidate="UploadPhoto" ViewStateMode="Disabled" EnableViewState="false"
                                                ValidationGroup="RegisterUserValidationGroup" SetFocusOnError="true" ValidationExpression="(.*?)\.(pdf)$"
                                                ForeColor="Red" EnableClientScript="true" Display="None" ErrorMessage="Only pdf files are accepted." />
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                                <br />
                            </div>
                            <asp:TextBox ID="Email" ViewStateMode="Disabled" EnableViewState="false" runat="server"
                                Visible="false" />
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" ViewStateMode="Disabled"
                                EnableViewState="false" Visible="false" />
                            <p>
                                <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Submit"
                                    ValidationGroup="RegisterUserValidationGroup" CssClass="button1" />
                                &nbsp;
                                <asp:Button ID="CancelButton" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    ValidationGroup="RegisterUserValidationGroup" CssClass="button1" Text="Reset"
                                    OnClick="CancelButton_Click" CausesValidation="false" />
                            </p>
                        </ContentTemplate>
                        <CustomNavigationTemplate>
                        </CustomNavigationTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </div>
    </div>
</asp:Content>
