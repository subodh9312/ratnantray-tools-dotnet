<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePasswordSuccess.aspx.cs" Inherits="Footsteps.Account.ChangePasswordSuccess" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="bg1">
        <div class="main">
            <p>
                Your password has been changed successfully. Use the new password to login into
                the account. You will now be redirected to login page for re-logging.
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
