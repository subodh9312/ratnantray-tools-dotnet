<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="VerifyUserAccount.aspx.cs" Inherits="Footsteps.Account.VerifyUserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg1">
        <div class="main">
            <p>
                <asp:Label ID="InformationLabel" runat="server" ViewStateMode="Disabled" EnableViewState="false" />
            </p>
            <script type="text/javascript">
                $(document).ready(function () {
                    setTimeout(function () {
                        window.location = '<%= Footsteps.Controller.Library.Constants.ServerAddress %>' + '/Account/Login.aspx';
                    }, 3000);
                });
            </script>
        </div>
    </div>
</asp:Content>
