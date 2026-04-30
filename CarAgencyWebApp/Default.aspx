<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarAgencyWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>وكالة بيع السيارات</h2>

    <div style="margin-bottom:12px;">
        <asp:Label ID="lblCompany" runat="server" Text="اختر الشركة المصنعة:" Font-Bold="True" />
        <asp:DropDownList ID="ddlCompany" runat="server" Width="220px" />

        <asp:Button ID="btnFilterByCompany" runat="server" Text="عرض سيارات الشركة" OnClick="btnFilterByCompany_Click" />
        <asp:Button ID="btnAllCars" runat="server" Text="عرض كل السيارات" OnClick="btnAllCars_Click" />
        <asp:Button ID="btnPopularType" runat="server" Text="الموديل الأكثر شيوعاً" OnClick="btnPopularType_Click" />
        <asp:Button ID="btnPopularColor" runat="server" Text="اللون الأكثر شيوعاً" OnClick="btnPopularColor_Click" />
    </div>

    <asp:Label ID="lblStatus" runat="server" ForeColor="Green" Font-Bold="True" />

    <asp:GridView ID="gvCars" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="gvCars_RowCommand" Width="100%" CellPadding="6" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="Company" HeaderText="الشركة" />
            <asp:BoundField DataField="Model" HeaderText="الموديل" />
            <asp:BoundField DataField="Seats" HeaderText="عدد المقاعد" />
            <asp:BoundField DataField="PlateNumber" HeaderText="رقم اللوحة" />
            <asp:BoundField DataField="Price" HeaderText="السعر" />
            <asp:BoundField DataField="Color" HeaderText="اللون" />
            <asp:TemplateField HeaderText="شراء">
                <ItemTemplate>
                    <asp:Button ID="btnBuy" runat="server" Text="شراء"
                        CommandName="BuyCar"
                        CommandArgument='<%# Container.DataItemIndex %>'
                        OnClientClick="return confirm('هل أنت متأكد من شراء هذه السيارة؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvStats" runat="server" AutoGenerateColumns="True" Width="100%" CellPadding="6" GridLines="Horizontal" />
</asp:Content>