<%@ Page Language="C#" CodeBehind="RSS.aspx.cs" Inherits="mytemplate.RSS" Async="true" %>


<asp:GridView ID="GridView1" DataSourceID="DetailsDataSource" runat="server" 
    OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
</asp:GridView>
<asp:DomainDataSource ID="DetailsDataSource" runat="server" />

<asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
    <asp:DynamicRouteExpression />
</asp:QueryExtender>
