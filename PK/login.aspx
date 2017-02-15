<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PK.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Turkey</title>
    <meta charset="utf-8">
    <link href="css/login.css" rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css'>
    <!--//webfonts-->
</head>

<body>

    <div class="main">
        <div class="login-form">
            <h1>Turkey - 牛津卡牌</h1>
            <div class="head">
                <img src="image/turkey.jpg" alt="" />
            </div>
            <form id="Form1" runat="server">
                <asp:TextBox runat="server" ID="username" class="text" value="用户名" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '用户名';}"></asp:TextBox>
                <asp:TextBox runat="server" type="password" id="password" value="" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '';}"></asp:TextBox>
                <div class="submit">
                    <%--<input type="submit" onclick="Login_Click()" value="登 陆">--%>
                    <asp:Button ID="btn_login" runat="server" Text="登 陆" onclick="Login_Click" />
                </div>
                <p><a href="#">Forgot Password ?</a></p>
            </form>
        </div>
        <!-----start-copyright---->
        <div class="copy-right">
            <p>开发人员：李鑫超 王璐 武刚鹏</p>
        </div>
        <!-----//end-copyright---->
    </div>
</body>
</html>
