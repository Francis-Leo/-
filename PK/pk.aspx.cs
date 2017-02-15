using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Services;
using Entity;
using BLL;


namespace PK
{
    public partial class pk : System.Web.UI.Page
    {
        static string picture1_content;
        static string picture2_content;
        
        /// <summary>
        /// 各种赋值
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["username1"]) != null && (Request.QueryString["username2"]) != null)
            {
                string user_name1 = Request.QueryString["username1"].ToString();
                string user_name2 = Request.QueryString["username2"].ToString();
                this.username1.Text = user_name1;
                this.username2.Text = user_name2;
                pictureBLL bll = new pictureBLL();
                pictureEntity picture1 = bll.ShowPictureByUsername(user_name1);
                pictureEntity picture2 = bll.ShowPictureByUsername(user_name2);
                picture1_content = picture1.other;
                picture2_content = picture2.other;
                this.picid1.Text = picture1.picid.ToString();
                this.picid2.Text = picture2.picid.ToString();
                this.picture_name1.Text = picture1.name;
                this.picture_name2.Text = picture2.name;
            }        
        }

        /// <summary>
        /// 显示用户1图片
        /// </summary>
        public static string ShowPicture1()
        {
            return picture1_content;
        }
   
        /// <summary>
        /// 显示用户2图片
        /// </summary>
        public static string ShowPicture2()
        {
            return picture2_content;  
        }

        
        /// <summary>
        /// 处理pk结果
        /// </summary>
        [WebMethod]
        public static bool userWin(string picid,string winner,string loser)
        {
            pictureBLL bll = new pictureBLL();
            bool flag = bll.PK(picid, winner, loser);
            return flag;
        }


       

    }
}