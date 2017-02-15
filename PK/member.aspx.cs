using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PK
{
    public partial class member : System.Web.UI.Page
    {
        static string member_name = "";
        static string user_name = "";
        pictureBLL bll = new pictureBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["member_name"]) != null)
            {
                member_name = Request.QueryString["member_name"].ToString();
                user_name = Request.QueryString["username"].ToString();
            }
            this.memebername.Text = member_name;
            this.username.Text = user_name;
        }

        /// <summary>
        /// 显示用户卡片
        /// </summary>
        public string ShowContent()
        {
            string content=bll.ShowMemberPicture(member_name);
            return content;
        }
    }
}