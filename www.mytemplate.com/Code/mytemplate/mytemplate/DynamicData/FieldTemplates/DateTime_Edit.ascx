<%@ Control Language="C#" CodeBehind="DateTime_Edit.ascx.cs" Inherits="mytemplate.DateTime_EditField" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>

<asp:TextBox ID="TextBox1" runat="server" CssClass="DDTextBox" Columns="20"></asp:TextBox>

<ajaxControlToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
    Enabled="True" TargetControlID="TextBox1" Animated="true">
</ajaxControlToolkit:CalendarExtender>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />
<asp:CustomValidator runat="server" ID="DateValidator" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" EnableClientScript="false" Enabled="false" OnServerValidate="DateValidator_ServerValidate" />
<asp:DomainValidator runat="server" ID="DomainValidator1" CssClass="DDControl DDValidator" Display="Static" />

