<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ranking.aspx.cs" Inherits="PK.ranking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PK排行榜</title>
    <link href="css/ranking_component.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <h1 style="color: #31bc86; font-size: 3.5em; margin-bottom: 0; margin-top: 20px; text-align: center;">排行榜</h1>
        <div id="stickey_return" onclick="ReturnMain()">
            <span><a>返回主页</a></span>
        </div>
        <div class="component">
            <table>
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Grade</th>
                        <th>Name</th>
                        <th>Cards</th>
                    </tr>
                </thead>
                <tbody>
                    <%=ShowRanking()%>
                </tbody>
            </table>
        </div>

    </div>
    <!-- 保存用户数据 -->
    <div style="display: none;">
        <asp:Label ID="username" runat="server" Text=""></asp:Label>
    </div>
</body>
<script src="js/jquery.min.js"></script>
<script src="js/jquery.ba-throttle-debounce.min.js"></script>
<script src="js/jquery.stickyheader.js"></script>
<script type="text/javascript">
    //返回主页
    function ReturnMain() {
        var username = $("#username").text();
        window.location.href = "main.aspx?username=" + username;
    }
</script>
</html>
