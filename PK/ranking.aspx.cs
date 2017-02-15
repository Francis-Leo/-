using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PK
{
    public partial class ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["username"]) != null)
            {
                this.username.Text = Request.QueryString["username"].ToString();
            }
        }

        /// <summary>
        /// 显示排行榜
        /// </summary>
        public string ShowRanking()
        {
            userBLL bll = new userBLL();
            string content = bll.ShowRanking();
            return content;

        }
    }
}