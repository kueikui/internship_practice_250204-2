<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="test.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- jQuery（放在最前面）-->
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- Bootstrap 5 JavaScript (包含 Popper.js) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="d-flex justify-content-center align-items-center vh-100">
                <div class="card shadow-lg p-4" style="width: 400px; background-color: #b6d7ff;">
                    <div class="card-body text-center">
                        account: &nbsp <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                        password:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
                        <br />
                        
                        <asp:Button ID="Button3" runat="server" Text="login" OnClick="login_Click" class="btn btn-info" ValidationGroup="LoginValidation" />
                        <asp:Button ID="Button4" runat="server" Text="sign up" OnClick="sign_up_Click" class="btn btn-info"/><br />
                        
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#FF5050"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入帳號" ControlToValidate="TextBox3" ForeColor="#FF5050" ValidationGroup="LoginValidation"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請輸入密碼" ControlToValidate="TextBox4" ForeColor="#FF5050" ValidationGroup="LoginValidation"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="密碼格式錯誤" ControlToValidate="TextBox4" ValidationExpression="^[0-9]*$" ForeColor="#FF5050" ValidationGroup="LoginValidation"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
