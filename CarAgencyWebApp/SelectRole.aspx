<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRole.aspx.cs" Inherits="CarAgencyWebApp.SelectRole" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>اختيار الدور</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; margin-top:50px;">
            <h2>مرحباً بك في وكالة بيع السيارات</h2>
            <p>من فضلك اختر دورك:</p>
            <asp:Button ID="btnCustomer" runat="server" Text="أنا زبون" OnClick="btnCustomer_Click" />
            <asp:Button ID="btnAdmin" runat="server" Text="أنا مدير" OnClick="btnAdmin_Click" />
        </div>
    </form>
</body>
</html>