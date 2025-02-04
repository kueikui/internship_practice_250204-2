<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="test.signup" %>

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
                        name:  &nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                        account: &nbsp <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                        password:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="sign up" OnClick="Button1_Click" class="btn btn-success" ValidationGroup="sign up" />&nbsp
                        <asp:Button ID="Button2" runat="server" Text="back" OnClick="Button2_Click" class="btn btn-secondary"/>
                        <asp:Label ID="message" runat="server" Text="" ForeColor="#FF5050"></asp:Label><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入姓名" ForeColor="#FF5050" ControlToValidate="TextBox1" ValidationGroup="sign up"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請輸入帳號" ForeColor="#FF5050" ControlToValidate="TextBox2" ValidationGroup="sign up"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請輸入密碼" ForeColor="#FF5050" ControlToValidate="TextBox3" ValidationGroup="sign up"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="密碼格式錯誤" ControlToValidate="TextBox3" ValidationExpression="^[0-9]*$" ForeColor="#FF5050" ValidationGroup="sign up"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
