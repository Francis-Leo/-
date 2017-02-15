using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace PK
{
    public partial class login : System.Web.UI.Page
    {
        userBLL bll = new userBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string username = this.username.Text.Trim();
            string password = this.password.Text.Trim();
            if (username == "用户名" || password == "")
            {
                MessageShow(this, "请输入用户名或者密码");
                return;
            }

            userEntity user = bll.GetModelByUsername(username);
            if (user != null)
            {
                if (user.password == password)
                {
                    Response.Redirect("main.aspx?username=" + username);
                }
                else
                {
                    MessageShow(this, "密码输入错误");
                    return;
                }
            }
            else
            {
                MessageShow(this, "数据库里没有你~");
                return;
            }


        }


        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void MessageShow(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
    }
}