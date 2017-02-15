<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlist.aspx.cs" Inherits="PK.userlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户列表</title>
    <meta name="viewport" content="initial-scale = 1.0, maximum-scale = 1.0, user-scalable = no, width = device-width">
    <link rel="stylesheet" href="css/userlist_styles.css" type="text/css" media="screen" />
    <link href="css/userlist_menu_style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/userlist_footer.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <%--<h1>用户列表</h1>--%>

    <!-- 所有用户列表 -->
    <div id="menu" style="float: left">
        <span style="float: left; margin-top: 15px; margin-left: 45px; color: white;">点击添加好友</span>
        <ul id="accordion" class="accordion">
            <li>
                <div class="link"><i class="fa"></i>Treasure<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <%=BindDragons()%>
                </ul>
            </li>
            <li>
                <div class="link"><i class="fa"></i>十一期<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <%--<li><a id="test" onclick="Add(this)">测试用户</a></li>--%>
                    <%=BindTerm11()%>
                </ul>
            </li>
            <li>
                <div class="link"><i class="fa"></i>十二期<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <%=BindTerm12()%>
                </ul>
            </li>
            <li>
                <div class="link"><i class="fa"></i>十三期<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <%=BindTerm13()%>
                </ul>
            </li>
            <li>
                <div class="link"><i class="fa"></i>十四期<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <%=BindTerm14()%>
                </ul>
            </li>
        </ul>
    </div>

    <!-- 用户常用好友 -->
    <form runat="server">
        <div class="case-content">
            <%=ShowFriends()%>
            <%--<div id="friend111" class="case-item" onclick="InputPassword(this)">
                <div class="ih-item circle effect1">
                    <a href="#">
                        <img class="img_wrong" src="image/wrong.png" style="float: right; width: 15px; height: 15px; display: none" />
                        <div class="spinner"></div>
                        <div class="img">
                            <h3 id="">测试</h3>
                        </div>
                        <div class="info">
                            <div class="info-back">
                                <h3>点击添加</h3>
                            </div>
                        </div>
                    </a>
                </div>
            </div>--%>
        </div>
        <div style="display: none;">
            <asp:Label ID="username" runat="server" Text=""></asp:Label>
            <asp:Label ID="gametype" runat="server" Text=""></asp:Label>
        </div>
    </form>


    <!-- 底部固定栏 -->
    <div id="stickey_footer">
        <ul id="social_icons">
            <li><a href="#"><span>Developers: Francis Louise Ledary</span></a></li>
        </ul>
        <ul id="footer_menu">
            <li><a onclick="ReturnMain()">返回主页</a>
            <li><a onclick="ChangeToNormal()">关闭重置</a>
            <li><a onclick="ChangeToDelete()">重置好友</a>
        </ul>
    </div>

</body>
<script src="js/jquery-1.9.1.min.js"></script>
<script src="js/userlist_menu.js"></script>
<script type="text/javascript">
    //控制页面内提示文字
    var game_type = $("#gametype").text();
    var info_word = "";
    if (game_type == "PK") { info_word = "验证" }
    if (game_type == "CheckCard") { info_word = "查看" }
    if (game_type == "Plunder") { info_word = "掠夺" }
    //添加用户为自己常用好友
    function Add(e) {
        var friend_id = e.id;
        var name = $("#" + friend_id).html();
        var content = "<div id=\"friend" + friend_id + "\" class=\"case-item\" onclick=\"" + game_type + "(this)\"><div class=\"ih-item circle effect1\"><a href=\"#\"><img class=\"img_wrong\" src=\"image/wrong.png\" style=\"float: right; width: 15px; height: 15px;display:none\" /><div class=\"spinner\"></div><div class=\"img\"><h3 id=\"" + friend_id + "\">" + name + "</h3></div><div class=\"info\"><div class=\"info-back\"><h3 class=\"info-word\">" + info_word + "</h3></div></div></a></div></div>";

        $.ajax({
            url: "userlist.aspx/AddFriend",
            data: "{'username':'" + $('#username').text() + "','friend_id':'" + friend_id + "'}",
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.d == "true") {
                    $(".case-content").append(content);
                }
                else {
                    alert(result.d);
                }
            },
            error: function (err) {
                alert("未知错误");
            }
        });
    }
    //删除好友
    function Delete(e) {
        var friend_id = e.id;
        $.ajax({
            url: "userlist.aspx/DeleteFriend",
            data: "{'username':'" + $('#username').text() + "','friend_id':'" + friend_id + "'}",
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.d == true) {
                    $("#" + friend_id).remove();
                }
                if (result.d == false) { alert("删除失败"); }
            },
            error: function (err) {
                alert("未知错误");
            }
        });
    }


    //重置好友-切换到删除模式
    function ChangeToDelete() {
        $(".case-item").removeAttr("onclick");//删除onclick事件
        $(".case-item").attr("onclick", "Delete(this);");//添加新的onclick事件
        $(".img_wrong").css("display", "block");//使删除图标可见
        $(".info-word").html("删除");//改变提示文字
    }
    //关闭重置-切换到正常模式
    function ChangeToNormal() {
        $(".case-item").removeAttr("onclick");//删除onclick事件
        $(".case-item").attr("onclick", "");//添加新的onclick事件
        $(".img_wrong").css("display", "none");//使删除图标不可见
        $(".info-word").html(info_back);//恢复提示文字
    }
    //返回主页
    function ReturnMain() {
        var username = $('#username').text();
        window.location.href = "main.aspx?username=" + username;
    }
</script>

<script type="text/javascript">
    //【查看卡牌模式】
    function CheckCard(e) {
        var member_name = $("#" + (e.id).substr(6)).html();
        var username = $('#username').text();
        window.location.href = "member.aspx?member_name=" + member_name + "&username=" + username;
    }

    //【掠夺模式】
    function Plunder(e) {
        var username = $('#username').text();
        var friend_name = $("#" + (e.id).substr(6)).html();
        window.location.href = "plunder.aspx?username1=" + username + "&username2=" + friend_name;
    }

    //【PK】：1.显示好友密码输入框
    function InputPassword(e) {
        $("#span_password").remove();
        if ($('#span_password').length && $('#span_password').length > 0) {
        } else {
            var circle_id = e.id;
            var content = "<span id=\"span_password\"><input id=\"friend_password\" type=password style=\"width:70px;height:23px\"/><input type=\"button\" value=\"确认\" onclick=\"PK('" + circle_id + "')\"/></span>";
            $("#" + circle_id).append(content);
            $("#friend_password").focus();
        }
    }
    //【PK】：2.禁止回车事件，防止刷新页面
    $(document).keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') { return false; }
    });
    //【PK】：3.进入PK模式
    function PK(circle_id) {
        var username = $('#username').text();//获得用户姓名
        var friendid = circle_id.substr(6);//获得好友id
        var friendname = $("#" + friendid).html();//获得好友姓名
        var friendpassword = $('#friend_password').val();//获得好友密码
        $("#span_password").remove();//移除密码输入框，以免万一
        $.ajax({//验证好友密码
            url: "userlist.aspx/VerifyPassword",
            data: "{'name':'" + friendname + "','password':'" + friendpassword + "'}",
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.d == true) {
                    window.location.href = "pk.aspx?username1=" + username + "&username2=" + friendname;
                }
                if (result.d == false) { alert("密码错误"); }
            },
            error: function (err) {
                alert("未知错误");
            }
        });
    } 
</script>
</html>
