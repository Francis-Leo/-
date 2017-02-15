<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plunder.aspx.cs" Inherits="PK.plunder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>掠夺</title>
    <link href="css/plunder.css" rel="stylesheet" />
    <link href="css/userlist_footer.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<h1>---- 掠夺 ----</h1>
<div id="stickey_return" onclick="ReturnMain()">
    <span><a>返回主页</a></span>
</div>
<body>
    <form id="Form1" runat="server">
        <div class="pic ls">
            <a href="#" class="tn">
                <%=ShowPicture() %>
            </a>
        </div>
        <div class="pic ls">
            <a href="#" class="tn">
                <span id="countDownTime">9</span>
            </a>
            <div>
                <input type="text" id="inputword" value="" />
                <img src="image/wrong.png" id="wrong" style="display: none; float: right; border: none; width: 100px; height: 100px; padding-right: 150px; padding-top: 20px;" />
                <img src="image/correct.png" id="correct" style="display: none; float: right; border: none; width: 100px; height: 100px; padding-right: 150px; padding-top: 20px;" />
                <input type="text" id="Text1" value="" style="display: none;" />
            </div>
        </div>
        <div id="picid" style="display: none;">
            <asp:Label ID="username1" runat="server" Text=""></asp:Label>
            <asp:Label ID="picid2" runat="server" Text=""></asp:Label>
            <asp:Label ID="username2" runat="server" Text=""></asp:Label>
            <asp:Label ID="picture_name2" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>


<script src="js/jquery-1.9.1.min.js"></script>

<script type="text/javascript">
    //页面加载时，显示图片-清空文本-设置倒计时——李鑫超——2017-1-23 08:12:38
    $(document).ready(function () {
        //用于显示界面图片
        $.ajax({
            url: "plunder.aspx/ShowPicture",
            data: "{}",
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        });

        //使输入框清空并获得焦点
        $('#inputword').val("");
        $('#inputword').focus();

        //设置定时器
        $(function () {
            var countDownTime = parseInt(8); //在这里设置每道题的答题时长
            function countDown(countDownTime) {
                var timer = setInterval(function () {
                    if (countDownTime >= 0) {
                        $("#countDownTime").text(countDownTime);
                        countDownTime--;
                    } else {
                        clearInterval(timer);
                        window.location.reload();
                    }
                }, 1000);
            }
            countDown(countDownTime);
        })
    });

    //输入回车时，获得用户输入和页面图片相关信息传入后台处理—王璐—2017-1-22 15:14:10
    $(document).keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            var ContentData = "{'picid':'" + $('#picid2').text() +
                    "','picture_name':'" + $('#picture_name2').text() +
                    "','inputword':'" + $('#inputword').val() +
                    "','username1':'" + $('#username1').text() +
                    "','username2':'" + $('#username2').text() + "'}";

            $.ajax({
                url: "plunder.aspx/Plunder",
                data: ContentData,
                type: 'Post',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d == "成功掠夺！！！") {//result结果是 成功掠夺时，界面显示对号
                        $("#correct").css("display", "block");
                    }
                    else if (result.d == "拼写错误") {//result 结果是 拼写错误，界面显示叉号
                        $("#wrong").css("display", "block");
                    }
                    else {
                        alert("更新失败");
                    }
                    window.location.reload();
                },
                error: function (err) {
                    alert("未知错误");
                }
            });
        }
    });

    //返回主页
    function ReturnMain() {
        var username = $('#username1').text();
        window.location.href = "main.aspx?username=" + username;
    }
</script>

</html>
