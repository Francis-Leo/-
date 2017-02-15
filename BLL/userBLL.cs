using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using DAL;
using Factory;
using IDAL;
using System.Data;
using System.Text;


namespace BLL
{
    public class userBLL
    {
        Factory.Factory factory = new Factory.Factory();
        userIDAL Iuser;

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public userEntity GetModelByUsername(string username)
        {
            Iuser = factory.CreatUserIDAL();
            return Iuser.GetModel(username);
        }

        /// <summary>
        /// 显示排行榜
        /// </summary>
        public string ShowRanking()
        {
            Iuser = factory.CreatUserIDAL();
            DataSet user = Iuser.GetList("ORDER BY amount DESC");
            StringBuilder sb = new StringBuilder();
            if (user != null && user.Tables.Count > 0)
            {
                for (int i = 0; i < user.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td class=\"no\">" + (i + 1) + "</td>");
                    sb.Append("<td class=\"grade\">" + user.Tables[0].Rows[i]["grade"] + "</td>");
                    sb.Append("<td class=\"name\">" + user.Tables[0].Rows[i]["name"] + "</td>");
                    sb.Append("<td class=\"amount\">" + user.Tables[0].Rows[i]["amount"] + "</td>");
                    sb.Append("</tr>");
                }
            }
            return sb.ToString();
        }

        #region 显示用户好友
        /// <summary>
        /// 显示用户的好友
        /// </summary>
        public string ShowFriends(string username, string gametype)
        {
            StringBuilder sb = new StringBuilder();
            Iuser = factory.CreatUserIDAL();
            userEntity user = Iuser.GetModel(username);
            string[] strArray = user.friends.ToString().Split('/');
            foreach (string str in strArray)
            {
                if (str != null && str.Trim() != "")
                {
                    int friend_id = int.Parse(str);
                    userEntity friend = Iuser.GetModelByID(friend_id);
                    string name = friend.name.ToString();
                    sb.Append(GetHtml(str, name, gametype));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 拼接html-这部分代码分离出来方便阅读
        /// </summary>
        public string GetHtml(string uid, string name, string gametype)
        {
            StringBuilder sb = new StringBuilder();
            string eventname = "";
            string tip = "";
            if (gametype == "PK") { eventname = "InputPassword"; tip = "验证"; }
            if (gametype == "CheckCard") { eventname = "CheckCard"; tip = "查看"; }
            if (gametype == "Plunder") { eventname = "Plunder"; tip = "掠夺"; }
            sb.Append("<div id=\"friend" + uid + "\" class=\"case-item\" onclick=\"" + eventname + "(this)\">");
            sb.Append("<div class=\"ih-item circle effect1\">");
            sb.Append("<a href=\"#\">");
            sb.Append("<img class=\"img_wrong\" src=\"image/wrong.png\" style=\"float: right; width: 15px; height: 15px;display:none\" />");
            sb.Append("<div class=\"spinner\"></div>");
            sb.Append("<div class=\"img\">");
            sb.Append("<h3 id=\"" + uid + "\">" + name + "</h3>");
            sb.Append("</div>");
            sb.Append("<div class=\"info\">");
            sb.Append("<div class=\"info-back\">");
            sb.Append("<h3 class=\"info-word\">" + tip + "</h3>");
            sb.Append("</div></div></a></div></div>");
            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// 根据期数获得用户列表
        /// </summary>
        public string GetUserlistByTerm(string term)
        {
            Iuser = factory.CreatUserIDAL();
            DataSet user = Iuser.GetList(" where grade = '" + term + "'");
            StringBuilder sb = new StringBuilder();
            if (user != null && user.Tables.Count > 0)
            {
                for (int i = 0; i < user.Tables[0].Rows.Count; i++)
                {
                    if (user.Tables[0].Rows[i]["state"].ToString() == "激活")
                    {
                        sb.Append("<li><a id=\"" + user.Tables[0].Rows[i]["uid"] + "\" onclick=\"Add(this)\">" + user.Tables[0].Rows[i]["name"] + "</a></li>");
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 添加好友
        /// </summary>
        public string AddFriend(string username, string friend_id)
        {
            bool flag = false;
            string result = "";
            Iuser = factory.CreatUserIDAL();
            userEntity user = Iuser.GetModel(username);
            //验证是否添加用户
            string[] strArray = user.friends.ToString().Split('/');
            foreach (string str in strArray)
            {
                if (str == friend_id)
                {
                    result = "已经添加过该用户了~";
                }
            }
            //验证添加结果
            if (result.Trim() == "")
            {
                user.friends = user.friends.ToString() + "/" + friend_id;
                flag = Iuser.UpdateFriends(user);
                result = "不知为何，添加失败。。。";
                if (flag) { result = "true"; }
            }
            return result;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        public bool DeleteFriend(string username, string friend_id)
        {
            bool flag = false;
            string friendlist = "";
            friend_id = friend_id.Substring(6);
            Iuser = factory.CreatUserIDAL();
            userEntity user = Iuser.GetModel(username);
            string[] strArray = user.friends.ToString().Split('/');
            foreach (string str in strArray)
            {
                if (str != friend_id && str!="")
                {
                    friendlist = friendlist + "/" + str;
                }
            }
            user.friends = friendlist;
            flag = Iuser.UpdateFriends(user);
            return flag;
        }
    }
}