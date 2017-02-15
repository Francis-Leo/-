using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Services;

namespace PK
{
    public partial class userlist : System.Web.UI.Page
    {
        static string UserName;
        static string GameType;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName = Request.QueryString["username"].ToString();
            GameType = Request.QueryString["gametype"].ToString();
            this.username.Text = UserName;
            this.gametype.Text = GameType;
        }

        #region 绑定各期用户
        /// <summary>
        /// 绑定每一章的卡牌
        /// </summary>
        public string BindDragons()
        {
            userBLL bll = new userBLL();
            string content = bll.GetUserlistByTerm("Treasure");
            return content;
        }
        /// <summary>
        /// 绑定11期用户
        /// </summary>
        public string BindTerm11()
        {
            userBLL bll = new userBLL();
            string content = bll.GetUserlistByTerm("11期");
            return content;
        }
        /// <summary>
        /// 绑定12期用户
        /// </summary>
        public string BindTerm12()
        {
            userBLL bll = new userBLL();
            string content = bll.GetUserlistByTerm("12期");
            return content;
        }
        /// <summary>
        /// 绑定13期用户
        /// </summary>
        public string BindTerm13()
        {
            userBLL bll = new userBLL();
            string content = bll.GetUserlistByTerm("13期");
            return content;
        }
        /// <summary>
        /// 绑定14期用户
        /// </summary>
        public string BindTerm14()
        {
            userBLL bll = new userBLL();
            string content = bll.GetUserlistByTerm("14期");
            return content;
        }
        #endregion


        /// <summary>
        /// 显示所有用户
        /// </summary>
        public string ShowFriends()
        {
            userBLL bll = new userBLL();
            string content = bll.ShowFriends(UserName, GameType);
            return content;
        }


        /// <summary>
        /// 添加好友
        /// </summary>
        [WebMethod]
        public static string AddFriend(string username, string friend_id)
        {
            userBLL bll = new userBLL();
            string result = bll.AddFriend(username, friend_id);
            return result;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        [WebMethod]
        public static bool DeleteFriend(string username, string friend_id)
        {
            bool flag = false;
            userBLL bll = new userBLL();
            flag = bll.DeleteFriend(username, friend_id);
            return flag;
        }

        /// <summary>
        /// 验证好友密码
        /// </summary>
        [WebMethod]
        public static bool VerifyPassword(string name, string password)
        {
            bool flag = false;
            userBLL bll = new userBLL();
            Entity.userEntity user = bll.GetModelByUsername(name);
            if (user.password == password) { flag = true; }
            return flag;
        }
    }
}