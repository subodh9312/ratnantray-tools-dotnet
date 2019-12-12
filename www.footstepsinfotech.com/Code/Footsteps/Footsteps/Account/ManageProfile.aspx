<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ManageProfile.aspx.cs" Inherits="Footsteps.Account.ManageProfile" %>

<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagName="GridViewPager"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg1">
        <div class="main">
            <h2>
                Let's work Together</h2>
            <p>
                Use the form below to apply @ Footsteps Infotech Inc. You can update your profile
                any time or even delete your account.
                <br />
                Passwords are required to be a minimum of
                <%= Membership.MinRequiredPasswordLength %>
                characters in length.
            </p>
            <span class="failureNotification">
                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="servicesList"
                ValidationGroup="RegisterUserValidationGroup" />
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
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="Email"
                            Display="None" CssClass="failureNotification" ErrorMessage="Email is required."
                            ToolTip="User Name is required." ValidationGroup="RegisterUserValidationGroup"
                            Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                        <asp:RegularExpressionValidator ID="EmailAsUsernameValidation" runat="server" ControlToValidate="Email"
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
                            <span>Update Resume</span>
                            <asp:FileUpload ID="UploadPhoto" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                            <asp:RegularExpressionValidator ID="FileUploadExtensionValidator" runat="server"
                                ControlToValidate="UploadPhoto" ViewStateMode="Disabled" EnableViewState="false"
                                SetFocusOnError="true" ValidationExpression="(.*?)\.(doc|docx|pdf)$" ForeColor="Red"
                                EnableClientScript="true" Display="None" ErrorMessage="Only doc, docx and pdf files." />
                        </label>
                    </div>
                    <div class="clearfix">
                        <br />
                    </div>
                    <div style="display: none;">
                        <asp:TextBox ID="Email" ViewStateMode="Disabled" EnableViewState="false" runat="server" />
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" ViewStateMode="Disabled"
                            EnableViewState="false" />
                    </div>
                </div>
                <div class="clearfix">
                    <br />
                </div>
                <div class="wrapper">
                    <span>View Uploaded Profile</span>
                    <div class="bg" style="background-color: transparent;">
                        <asp:HyperLink ID="ProfileHyperlink" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                            NavigateUrl="/ImageHandler.ashx?username=subodh@footstepsinfotech.com" ToolTip="View Profile"
                            Text="Click Here" />
                    </div>
                </div>
            </div>
            <p>
                <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Submit"
                    ValidationGroup="RegisterUserValidationGroup" CssClass="button1" OnClick="Submit_Click" />
            </p>
            <p>
                <asp:Label ID="ResultLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                    Text="" />
            </p>
        </div>
    </div>
</asp:Content>
