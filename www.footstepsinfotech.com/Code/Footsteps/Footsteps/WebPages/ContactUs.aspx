<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="Footsteps.WebPages.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--content -->
    <div class="main">
        <div id="content">
            <div class="wrapper">
                <h2>
                    Contact Form</h2>
                <div id="ContactForm">
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="servicesList"
                        ValidationGroup="FormValidation" />
                    <div class="wrapper">
                        <span>Name:</span>
                        <div class="bg">
                            <asp:TextBox ID="Name" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                CssClass="input" />
                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                ControlToValidate="Name" Display="None" SetFocusOnError="true" ValidationGroup="FormValidation"
                                EnableClientScript="true" ErrorMessage="Name is Required." Text="*" />
                        </div>
                    </div>
                    <div class="wrapper">
                        <span>Email:</span>
                        <div class="bg">
                            <asp:TextBox ID="Email" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                CssClass="input" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ViewStateMode="Disabled"
                                EnableViewState="false" ControlToValidate="Email" Display="None" SetFocusOnError="true"
                                Text="*" ValidationGroup="FormValidation" EnableClientScript="true" ErrorMessage="Email Id is Required." /></div>
                    </div>
                    <div class="textarea_box">
                        <span>Comments:</span>
                        <div class="bg">
                            <asp:TextBox ID="MessageTextBox" runat="server" TextMode="MultiLine" ViewStateMode="Disabled"
                                Rows="5" EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ViewStateMode="Disabled"
                                EnableViewState="false" ControlToValidate="MessageTextBox" Display="None" SetFocusOnError="true"
                                Text="*" ValidationGroup="FormValidation" EnableClientScript="true" ErrorMessage="Comment Text is Required." /></div>
                    </div>
                    <div class="clearfix">
                        <br />
                    </div>
                    <asp:Button ID="Submit" runat="server" Text="  Send " OnClick="Submit_Click" CssClass="button1"
                        ValidationGroup="FormValidation" />
                    &nbsp;
                    <asp:Button ID="Cancel" runat="server" Text="  Clear " OnClick="Cancel_Click" CssClass="button1"
                        CausesValidation="false" />
                </div>
            </div>
            <asp:Panel ID="ResultPanel" runat="server" Visible="false" ViewStateMode="Disabled"
                EnableViewState="false">
                <asp:Label ID="Result" runat="server" Font-Bold="true" Text="Result" ViewStateMode="Disabled"
                    EnableViewState="false" />
            </asp:Panel>
        </div>
    </div>
    <div class="bg1">
        <div class="main">
            <div id="content2">
                <div class="wrapper">
                    <h3>
                        Our Contacts</h3>
                    <div class="contactCol1 marg_right_40">
                        <p class="address">
                            <span class="color2">Pune</span><br />
                            <span>Amanora Park Town,</span><br />
                            <span>Sector R21, Unit 031-03-05,</span><br />
                            <span>Kharadi By pass, Pune - 411028</span><br />
                            <span>Email:</span><a href="mailto:pune@footstepsinfotech.com">pune@footstepsinfotech.com</a></p>
                    </div>
                    <div class="contactCol1">
                        <p class="address">
                            <span class="color2">Dhule</span><br />
                            <span>Footsteps Infotech Inc.,</span><br />
                            <span>3026, Agra Road,</span><br />
                            <span>Dhule - 424001</span><br />
                            <span>Email:</span><a href="mailto:dhule@footstepsinfotech.com">dhule@footstepsinfotech.com</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--content end-->
</asp:Content>
