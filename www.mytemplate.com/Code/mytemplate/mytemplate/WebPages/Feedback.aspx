<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Feedback.aspx.cs" Inherits="mytemplate.WebPages.Feedback" %>

<%@ Register Src="../UserControls/Captcha/MyCaptcha.ascx" TagName="MyCaptcha" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="SubmitPanel" runat="server">
        <h1>
            Feedback</h1>
        <hr />
        <p style="padding-left: 10px; text-align: justify;">
            <b>Welcome!</b></p>
        <p style="padding-left: 10px; text-align: justify;">
            Thank you for taking time to give us your feedback. It would take less than two
            minutes to complete this form.</p>
        <p style="padding-left: 10px; text-align: justify;">
            We hope to use this information to improve and help better My Template
            and help you serve in a better way.</p>
        <p style="padding-left: 10px; text-align: justify;">
            <b>1. How would you rate your overall experience on the site?</b>
            <asp:RadioButtonList ID="Experience" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                AppendDataBoundItems="false" AutoPostBack="false">
                <asp:ListItem Text="Satisfactory" Value="Satisfactory" />
                <asp:ListItem Text="Un-Satisfactory" Value="UnSatisfactory" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="Experience"
                ErrorMessage="*" Display="Dynamic" ForeColor="Red" /></p>
        <p style="padding-left: 10px; text-align: justify; width: 680px;">
            <b>2. What part of this site are you dissatisfied with?</b></p>
        <p style="padding-left: 10px; text-align: justify;">
            <asp:DropDownList ID="Dissatisfied" runat="server" Width="355px">
                <asp:ListItem Text="Please Select one of the following" />
                <asp:ListItem Value="Design">Design, Layout and ease of Navigation</asp:ListItem>
                <asp:ListItem Value="Download">Page Download Speed</asp:ListItem>
                <asp:ListItem Value="OrganizationOfContent">Organizaton of Content</asp:ListItem>
                <asp:ListItem Value="QualityOfContent">Quality of Content</asp:ListItem>
                <asp:ListItem Value="OccuranceOfErrors">Occurance of Errors</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="*" ForeColor="Red"
                Display="Static" ControlToValidate="Dissatisfied" />
        </p>
        <p style="padding-left: 10px; text-align: justify;">
            <b>3. What exactly would you like us to correct?</b>
            <br />
            <asp:TextBox ID="Corrections" runat="server" Height="75px" MaxLength="500" TextMode="MultiLine"
                Width="350px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!"
                Display="Static" ControlToValidate="Corrections" ForeColor="Red" /></p>
        <p style="padding-left: 10px; text-align: justify;">
            <b>4. How would you rate this website with respect to other sites of this genre?</b>
            <asp:RadioButtonList ID="Comparison" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                AppendDataBoundItems="false" AutoPostBack="false">
                <asp:ListItem Text="Better than" />
                <asp:ListItem Text="Similar" />
                <asp:ListItem Text="Worse Than" />
            </asp:RadioButtonList>
        </p>
        <p style="padding-left: 10px; text-align: justify; width: 680px;">
            Please name the website you are comparing this one with-<br />
            <asp:TextBox ID="Competitor" runat="server" MaxLength="100" Width="350px" />
        </p>
        <p style="padding-left: 10px; text-align: justify;">
            <b>5. Suggestions to make this site better</b>
            <br />
            <asp:TextBox ID="Suggestions" runat="server" Height="75px" MaxLength="500" TextMode="MultiLine"
                Width="350px" /></p>
        <hr />
        <h3>
            Tell us about yourself</h3>
        <table cellpadding="2" cellspacing="2" width="100%" align="center">
            <tr>
                <td align="right">
                    Name:
                </td>
                <td>
                    <asp:TextBox ID="Name" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV" runat="server" ControlToValidate="Name" ErrorMessage="Required!"
                        ForeColor="Red" Display="Static" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    City/Location:
                </td>
                <td>
                    <asp:TextBox ID="CityLocation" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CityLocation"
                        ErrorMessage="Required!" ForeColor="Red" Display="Static" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Email address:
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server" />
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="REV" runat="server" ControlToValidate="Email"
                        ErrorMessage="Invalid!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ForeColor="Red" Display="Static" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Contact Number:
                </td>
                <td>
                    <asp:TextBox ID="ContactNumber" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblCheckResult" runat="server" ForeColor="Red" Text="" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <uc1:MyCaptcha ID="MyCaptcha1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="Submit" runat="server" Text="  Submit  " OnClick="Submit_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="ResultPanel" runat="server" Visible="false">
        <asp:Label ID="Result" runat="server" Font-Bold="true" Text="Result"></asp:Label>
    </asp:Panel>
</asp:Content>
