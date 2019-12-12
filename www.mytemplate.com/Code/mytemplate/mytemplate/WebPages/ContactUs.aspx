<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="mytemplate.WebPages.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Contact Us Page</h1>
    <div class="justified">
        <asp:Panel ID="SubmitPanel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
            DefaultButton="Submit">
            <fieldset>
                <legend>Have a Message </legend>
                <table cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name" ViewStateMode="Disabled"
                                EnableViewState="false" Text="Name" />
                        </td>
                        <td>
                            <asp:TextBox ID="Name" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="NameValidator" runat="server" ControlToValidate="Name"
                                Display="Dynamic" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="false"
                                Text="*" ErrorMessage="Name is required." ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="EmailLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                AssociatedControlID="Email" Text="Email" />
                        </td>
                        <td>
                            <asp:TextBox ID="Email" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="EmailReqValidator" runat="server" ControlToValidate="Email"
                                Display="Dynamic" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                Text="*" ErrorMessage="Email is required" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ViewStateMode="Disabled"
                                Text="*" EnableViewState="false" Display="Dynamic" EnableClientScript="true"
                                ControlToValidate="Email" ErrorMessage="Please enter a valid Email Address" ForeColor="Red"
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="MessageLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false"
                                AssociatedControlID="MessageTextBox" Text="Message" />
                        </td>
                        <td>
                            <asp:TextBox ID="MessageTextBox" runat="server" Width="90%" TextMode="MultiLine" Columns="80"
                                Rows="4" ViewStateMode="Disabled" EnableViewState="false" />
                            <asp:RequiredFieldValidator ID="MessageValidator" runat="server" ControlToValidate="MessageTextBox"
                                Display="Dynamic" ViewStateMode="Disabled" EnableViewState="false" EnableClientScript="true"
                                Text="*" ErrorMessage="Message is required." ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="Submit" runat="server" Text="  Submit  " OnClick="Submit_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="ResultPanel" runat="server" Visible="false">
            <asp:Label ID="Result" runat="server" Font-Bold="true" Text="Result" />
        </asp:Panel>
    </div>
</asp:Content>
