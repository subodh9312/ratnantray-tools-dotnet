<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ManageProfile.aspx.cs" Inherits="mytemplate.Account.ManageProfile" %>

<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagName="GridViewPager"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset class="register">
        <legend>
            <asp:Label ID="FieldsetLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                Text="Update Your Profile" /></legend>
        <table cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td width="70%">
                    <table cellpadding="2" cellspacing="2" width="90%">
                        <tr>
                            <td align="right">
                                <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName" Text="First Name"
                                    ViewStateMode="Disabled" EnableViewState="false" />
                            </td>
                            <td>
                                <asp:TextBox ID="FirstName" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstName"
                                    CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                                    ValidationGroup="RegisterUserValidationGroup" Text="*" Display="Dynamic" ViewStateMode="Disabled"
                                    EnableViewState="false" EnableClientScript="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName" ViewStateMode="Disabled"
                                    EnableViewState="false" Text="Last Name" />
                            </td>
                            <td>
                                <asp:TextBox ID="LastName" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                                <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName"
                                    Display="Dynamic" CssClass="failureNotification" ErrorMessage="Last Name is required."
                                    ToolTip="Last Name is required." ValidationGroup="RegisterUserValidationGroup"
                                    Text="*" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EducationLabel" runat="server" AssociatedControlID="Education" ViewStateMode="Disabled"
                                    EnableViewState="false" Text="Education" />
                            </td>
                            <td>
                                <asp:TextBox ID="Education" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="CellNo1Label" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    AssociatedControlID="CellNo1" Text="Cell No. 1" />
                            </td>
                            <td>
                                <asp:TextBox ID="CellNo1" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    Text="" />
                                <asp:RegularExpressionValidator ID="CellNoRFV" runat="server" ControlToValidate="CellNo1"
                                    ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Cell No. Only Numbers are allowed"
                                    Text="*" Display="Dynamic" EnableClientScript="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="CellNo2Label" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    AssociatedControlID="CellNo2" Text="Cell No. 2" />
                            </td>
                            <td>
                                <asp:TextBox ID="CellNo2" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    Text="" />
                                <asp:RegularExpressionValidator ID="CellNo2RFV" runat="server" ControlToValidate="CellNo2"
                                    ValidationExpression="[0-9]*" ErrorMessage="Please enter a Valid Cell No. Only Numbers are allowed"
                                    Text="*" Display="Dynamic" EnableClientScript="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="DirectNoLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    Text="Direct No." AssociatedControlID="DirectNo" />
                            </td>
                            <td>
                                <asp:TextBox ID="DirectNo" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                    Text="" />
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
                            <td align="right">
                                <asp:Label ID="OrganisationLabel" runat="server" AssociatedControlID="Organisation"
                                    ViewStateMode="Disabled" EnableViewState="false" Text="Organisation" />
                            </td>
                            <td>
                                <asp:TextBox ID="Organisation" TextMode="MultiLine" Width="97%" Rows="3" runat="server"
                                    ViewStateMode="Disabled" EnableViewState="false" />
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
                            <td align="right">
                                <asp:Label ID="UploadPhotoLabel" runat="server" AssociatedControlID="UploadPhoto"
                                    ViewStateMode="Disabled" EnableViewState="false" Text="Profile Picture" />
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
                </td>
                <td width="30%" valign="top">
                    <asp:Image ID="ProfilePicture" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                        Height="80px" Width="120px" AlternateText="Your Profile Picture" ToolTip="Your Profile Picture"
                        ImageAlign="Right" />
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        <asp:Button ID="Submit" runat="server" Text="Update Profile" ViewStateMode="Disabled"
            Width="150px" EnableViewState="false" OnClick="Submit_Click" />
    </p>
</asp:Content>
