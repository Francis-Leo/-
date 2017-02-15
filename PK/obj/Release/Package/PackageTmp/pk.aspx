<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pk.aspx.cs" Inherits="PK.pk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PK</title>
    <link href="css/pk.css" rel="stylesheet" />
</head>
<div id="stickey_return" onclick="ReturnMain()">
    <span><a>返回主页</a></span>
</div>
<h1>---- PK ----</h1>
<body>
    <form runat="server">
        <%-- 图片提示 --%>
        <div id="picture_name">
            <asp:Label ID="picture_name1" runat="server" Text=""></asp:Label>
            <asp:Label ID="picture_name2" runat="server" Text=""></asp:Label>
        </div>

        <%-- PK结果图片 --%>
        <div id="result_pic" style="float:left;">
            <img id="winner1" src="image/winner_1.png" style="width:1000px;height:420px;margin-left:120px;display:none;"/>
            <img id="winner2" src="image/winner_2.png" style="width:1000px;height:420px;margin-left:120px;display:none;"/>
        </div>

        <%-- 图片展示 --%>
        <div style="position:fixed;z-index:-1;">
            <div class="pic ls">
                <a href="#" class="tn"><%=ShowPicture1() %></a>
                <div style="padding-left:100px;">
                    <span style="color:red;font-weight:bolder;">玩家一：</span><asp:Label ID="username1" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="pic ls">
                <a href="#" class="tn"><%=ShowPicture2() %></a>
                <div style="padding-left:100px;">
                    <span style="color:blue;font-weight:bolder;">玩家二：</span><asp:Label ID="username2" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <%-- 玩家姓名 --%>
        <div id="picid" style="display: none;">
            <asp:Label ID="picid1" runat="server" Text=""></asp:Label>
            <asp:Label ID="picid2" runat="server" Text=""></asp:Label>
        </div>
    </form>

</body>
<script src="js/jquery-1.9.1.min.js"></script>
<script type="text/javascript">

    //页面加载时加载图片以及保存相关信息——李鑫超——2017-1-22 16:11:28
    $(document).ready(function () {
        //加载用户1图片
        $.ajax({
            url: "pk.aspx/ShowPicture1",
            data: "{}",
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        });
        //加载用户2图片
        $.ajax({
            url: "pk.aspx/ShowPicture2",
            data: "{}",
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        });
        //隐藏图片的提示
        $('#picture_name').css('display', 'none');
    });

    //通过键盘的上下左右来进行图片的提示、刷新以及确定胜利者——李鑫超——2017-1-22 16:11:36
    $(document).keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        //键盘上键-显示图片单词提示
        if (keycode == '38') {
            $('#picture_name').css('display', 'block');
        }
        //键盘下键-重新加载页面
        if (keycode == '40') {
            window.location.reload();
            return false;
        }
        //键盘左键-左面的用户胜利
        if (keycode == '37') {
            var ContentData = "{'picid':'" + $('#picid2').text() +
                              "','winner':'" + $('#username1').text() +
                              "','loser':'" + $('#username2').text() + "'}";
            $.ajax({
                url: "pk.aspx/userWin",
                data: ContentData,
                type: 'Post',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (flag) {
                    $('#winner1').css("display", "block");
                    setTimeout("window.location.reload()", 1500);
                },
                error: function (err) {
                    alert("未知错误");
                }
            });
        }
        //键盘右键-右面的用户胜利
        if (keycode == '39') {
            var ContentData = "{'picid':'" + $('#picid1').text() +
                              "','winner':'" + $('#username2').text() +
                              "','loser':'" + $('#username1').text() + "'}";
            $.ajax({
                url: "pk.aspx/userWin",
                data: ContentData,
                type: 'Post',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (flag) {
                    $('#winner2').css("display", "block");
                    setTimeout("window.location.reload()", 1500);
                },
                error: function (err) {
                    alert("未知错误");
                }
            });
        }
    });

    //返回主页
    function ReturnMain() {
        var username = $("#username1").text();
        window.location.href = "main.aspx?username=" + username;
    }

</script>
</html>
