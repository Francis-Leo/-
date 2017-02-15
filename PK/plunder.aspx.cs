using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Web.Services;

namespace PK
{
    public partial class plunder : System.Web.UI.Page
    {
        static string picture_content;

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
                pictureEntity picture2 = bll.ShowPictureByUsername(user_name2);
                picture_content = picture2.other;
                this.picid2.Text = picture2.picid.ToString();
                this.picture_name2.Text = picture2.name;
            }
        }

        /// <summary>
        /// 显示被掠夺对象的图片
        /// </summary>
        public static string ShowPicture()
        {
            return picture_content;
        }

        /// <summary>
        /// 处理抢夺的卡牌
        /// </summary>
        [WebMethod]
        public static string Plunder(string picid,string picture_name,string inputword,string username1,string username2) 
        {
            Entity.pictureEntity picture = new pictureEntity();
            picture.picid = int.Parse(picid);
            picture.name = picture_name;
            picture.owner = username2;
            pictureBLL bll = new pictureBLL();
            string result = bll.Plunder(picture,username1,username2,inputword);
            return result;
        }


    }
}