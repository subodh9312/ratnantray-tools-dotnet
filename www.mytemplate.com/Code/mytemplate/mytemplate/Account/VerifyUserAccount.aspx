<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="VerifyUserAccount.aspx.cs" Inherits="mytemplate.Account.VerifyUserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="InformationLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnSignIn" runat="server" OnClick="btnSignIn_Click" Text="Sign In" Width="100px" />
    </p>
</asp:Content>
