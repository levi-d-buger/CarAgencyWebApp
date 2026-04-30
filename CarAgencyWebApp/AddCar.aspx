<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="CarAgencyWebApp.AddCar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>إضافة سيارة</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:400px; margin:auto; padding-top:40px;">
            <h2>إضافة سيارة جديدة</h2>
            <table>
                <tr>
                    <td>الشركة المصنعة:</td>
                    <td><asp:TextBox ID="txtCompany" runat="server" /></td>
                </tr>
                <tr>
                    <td>الموديل:</td>
                    <td><asp:TextBox ID="txtModel" runat="server" /></td>
                </tr>
                <tr>
                    <td>عدد المقاعد:</td>
                    <td><asp:TextBox ID="txtSeats" runat="server" /></td>
                </tr>
                <tr>
                    <td>رقم اللوحة:</td>
                    <td><asp:TextBox ID="txtPlate" runat="server" /></td>
                </tr>
                <tr>
                    <td>السعر:</td>
                    <td><asp:TextBox ID="txtPrice" runat="server" /></td>
                </tr>
                <tr>
                    <td>اللون:</td>
                    <td>
                        <asp:DropDownList ID="ddlColor" runat="server">
                            <asp:ListItem Text="White" Value="White" />
                            <asp:ListItem Text="Black" Value="Black" />
                            <asp:ListItem Text="Blue" Value="Blue" />
                            <asp:ListItem Text="Red" Value="Red" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:Button ID="btnAddCar" runat="server" Text="إضافة السيارة" OnClick="btnAddCar_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>