<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCaptcha.ascx.cs" Inherits="mytemplate.UserControls.Captcha.MyCaptcha" %>
<asp:HiddenField ID="GeneratedTextHidden" runat="server" Value="" EnableViewState="false" ViewStateMode="Disabled" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ViewStateMode="Disabled" EnableViewState="false">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ImageButton" EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <table>
            <tr>
                <td align="center">
                    <asp:ImageButton ID="ImageButton" runat="server" Font-Size="Small" OnClick="ImageButton_Click" ImageAlign="Left"
                        CausesValidation="false" ImageUrl="~/DynamicData/Content/Images/refresh.png" Height="50px" Width="50px" ToolTip="Refresh Code"
                        EnableViewState="false" ViewStateMode="Disabled" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td rowspan="4">
                    <asp:Image ID="ImgCaptcha" rel="nofollow,noindex,canonical" runat="server" Width="150px" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <small>Enter Code:</small>
                    <br />
                    <asp:TextBox runat="server" ID="TxtCaptcha" MaxLength="5" Width="70px" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
