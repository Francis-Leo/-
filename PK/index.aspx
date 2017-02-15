<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PK.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/index.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    	<div class="customer">
		<div class="container">
			<div class="customer-heading">
				<h3>牛津卡牌</h3>
			</div>
			<div class="customer-heading-grids">
				<div class="col-md-3 customer-grid">
					<div class="customer-img">
						<img src="image/c1.jpg" onclick="CheckCard()" />
						<h5>查看卡牌</h5>
                        <asp:TextBox ID="member_name" runat="server" CssClass="text-center" Text="请输入你要查看的对象"></asp:TextBox>
					</div>
				</div>
                <div class="col-md-3 customer-grid">
					<div class="customer-img">
						<img src="image/c4.jpg" onclick="Plunder()" />
						<h5>海盗模式</h5>
                        <asp:TextBox ID="plunder_name" runat="server" CssClass="text-center" Text="请输入你要掠夺的对象"></asp:TextBox>
					</div>
				</div>
				<div class="col-md-3 customer-grid">					
					<div class="customer-img">
						<img src="image/c2.jpg" onclick="PK()" />
						<h5>PK模式</h5>
                        <asp:TextBox ID="pk_name" runat="server" CssClass="text-center" Text="请输入你要PK的对象"></asp:TextBox>
					</div>
				</div>
				<div class="col-md-3 customer-grid">
					<div class="customer-img">
						<img src="image/c3.jpg" onclick="Ranking()" />
						<h5>排行榜</h5>
					</div>
				</div>
				<div class="clearfix"> </div>
			</div>
		</div>
	</div>

    <input type="hidden" id="username1" value="" runat="server"> 

    </form>
</body>
    <script src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        $(function ClearText() {
            $("#member_name").click(function () {
                $("#member_name").val("");
            });
            $("#pk_name").click(function () {
                $("#pk_name").val("");
            });
            $("#plunder_name").click(function () {
                $("#plunder_name").val("");
            });
        });

        function CheckCard() {
            var member_name = $('#member_name').val();
            window.location.href = "member.aspx?member_name=" + member_name;
        }

        function PK() {
            var username1 = $('#username1').val();
            var username2 = $('#pk_name').val();
            window.location.href = "pk.aspx?username1=" + username1 + "&username2=" + username2;
        }

        function Plunder() {
            var username1 = $('#username1').val();
            var username2 = $('#plunder_name').val();
            window.location.href = "plunder.aspx?username1=" + username1 + "&username2=" + username2;
        }

        function Ranking() {
            window.location.href = "ranking.aspx";
        }

    </script>
</html>
