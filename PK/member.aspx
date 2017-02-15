<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="PK.member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>成员卡牌</title>
    <link href="css/member.css" rel="stylesheet" />
</head>
<body>
    <form>
        <div id="stickey_return" onclick="ReturnMain()">
            <span><a >返回主页</a></span>
        </div>
        <h1>
            <asp:Label id="memebername" runat="server" Text=""></asp:Label><span>的卡牌</span>
        </h1>
        <!-- 显示用户卡牌 -->
        <%=ShowContent()%>
        <!-- 保存用户数据 -->
        <div style="display:none;">
            <asp:Label id="username" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script type="text/javascript">
    //返回主页
    function ReturnMain() {
        var username = $("#username").text();
        window.location.href = "main.aspx?username=" + username;
    }
</script>

