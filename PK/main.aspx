<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="PK.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>主页</title>
    <link href="css/main_style.css" rel="stylesheet" type="text/css" />
    <link href="css/main_lrtk.css" rel="stylesheet" type="text/css" />

</head>
<body>
        <form runat="server">
            <div class="container">
                <header class="clearfix">
                    <h1>牛津卡牌</h1>
                </header>
                <section>
                    <ul id="da-thumbs" class="da-thumbs">
                        <li>
                            <a id="CheckCard" onclick="Game(this)">
                                <img src="image/1.jpg" />
                                <div>
                                    <span>选择好友「点击」进行查看</span>
                                </div>
                            </a>
                            <span>查看卡牌</span>
                        </li>
                        <li>
                            <a id="PK" onclick="Game(this)">
                                <img src="image/2.jpg" />
                                <div>
                                    <span>选择好友「点击」开始PK<br/><br/>
                                        1. 需要输入好友密码验证<br/>
                                        2. ↑ 为提示，↓ 为刷新<br />
                                          &nbsp;←为左方赢，→为右方赢</span>
                                </div>
                            </a>
                            <span>PK模式</span>
                        </li>
                        <li>
                            <a id="Plunder" onclick="Game(this)">
                                <img src="image/3.jpg" />
                                <div>
                                    <span>选择好友「点击」开始掠夺</span>
                                </div>
                            </a>
                            <span>掠夺模式</span>
                        </li>
                        <li>
                            <a onclick="Ranking()">
                                <img src="image/4.jpg" />
                                <div>
                                    <span>「点击」查看排行榜<br />
                                    </span>
                                </div>
                            </a>
                            <span>排行榜</span>
                        </li>
                    </ul>
                </section>
            </div>
            <input type="hidden" id="username" value="" runat="server" />
        </form>
 
</body>
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/main_modernizr.js"></script>
<script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="js/main_jquery.hoverdir.js"></script>
<script type="text/javascript">
    //添加遮罩效果
    $(function () {
        $(' #da-thumbs > li ').each(function () { $(this).hoverdir(); });
    });
    //选择模式后，进入用户列表
    function Game(e) {
        var username = $('#username').val();
        window.location.href = "userlist.aspx?username=" + username + "&gametype=" + e.id;
    }
    //进入排行榜
    function Ranking() {
        var username = $('#username').val();
        window.location.href = "ranking.aspx?username=" + username;
    }
</script>
</html>
