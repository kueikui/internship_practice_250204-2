<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="test.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- 引入 Bootstrap 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid"><!--<div class="container-fluid d-flex justify-content-end">-->
                <div class="ms-auto">
                    <asp:Button runat="server" Text="Logout" OnClick="logout_Click" CssClass="btn btn-danger" style="float:right;"/>
                </div>
            </div>
        </nav>
        <div class="container mt-4">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-primary text-white">
                <HeaderStyle CssClass="table-warning text-white" />
                <RowStyle CssClass="table-light" />
            </asp:GridView>

            <div class="d-flex justify-content-between mt-3">
                <asp:Button ID="Export" runat="server" Text="Export" OnClick="Export_Click" CssClass="btn btn-primary"/>
                <asp:Button ID="Import" runat="server" Text="Import" OnClick="Import_Click" CssClass="btn btn-primary"/>
            </div>
        </div>
    </form>
</body>
</html>
