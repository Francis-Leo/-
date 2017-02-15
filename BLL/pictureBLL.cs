using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using IDAL;

namespace BLL
{
    public class pictureBLL
    {
        Factory.Factory factory = new Factory.Factory();
        pictureIDAL Ipicture;
        userIDAL Iuser;

        /// <summary>
        /// 在member页面显示该成员的所有卡牌
        /// </summary>
        public string ShowMemberPicture(string member_name)
        {
            string strWhere = " owner='" + member_name + "'";
            Ipicture = factory.CreatPictureIDAL();
            DataSet picture = Ipicture.GetList(strWhere);

            StringBuilder sb = new StringBuilder();
            if (picture != null && picture.Tables.Count > 0)
            {
                for (int i = 0; i < picture.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<div class=\"pic ls\">");
                    sb.Append("<a href=\"#\" class=\"tn\"><img src=\"" + picture.Tables[0].Rows[i]["path"] + "\"></a>");
                    sb.Append("<ul>" + picture.Tables[0].Rows[i]["name"] + "</ul>");
                    sb.Append("</div>");
                    sb.Append("");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 通过用户名随机得到该用户的一张图片
        /// </summary>
        public Entity.pictureEntity ShowPictureByUsername(string username)
        {
            Entity.pictureEntity model = new Entity.pictureEntity();

            string strWhere = " owner='" + username + "'";
            Ipicture = factory.CreatPictureIDAL();
            DataSet picture = Ipicture.GetList(strWhere);

            StringBuilder sb = new StringBuilder();
            if (picture != null && picture.Tables[0].Rows.Count > 0)
            {
                int i = GetPicNum(picture.Tables[0].Rows.Count);
                sb.Append("<img src=\"" + picture.Tables[0].Rows[i - 1]["path"] + "\">");

                model.picid = (int)(picture.Tables[0].Rows[i - 1]["picid"]);
                model.name = picture.Tables[0].Rows[i - 1]["name"].ToString();
                model.other = sb.ToString();//用于存储临时的html语句
                model.chapter = picture.Tables[0].Rows[i - 1]["chapter"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 获得随机图片
        /// </summary>
        public int GetPicNum(int amount)
        {
            int Result;
            Random ro = new Random();
            Result = ro.Next(1, amount);
            return Result;
        }

        /// <summary>
        /// 抢夺对方卡牌—王璐—2017-1-22 15:17:24
        /// </summary>
        public string Plunder(Entity.pictureEntity picture, string username1,string username2, string inputword)
        {
            string result = "拼写错误";
            Ipicture = factory.CreatPictureIDAL();
            Iuser = factory.CreatUserIDAL();

            //统一为小写，然后进行比较
            inputword = inputword.ToLower();
            picture.name = picture.name.ToLower();
            if (inputword == picture.name)
            {
                picture.owner = username1;
                
                bool flag = Ipicture.UpdateOwner(picture);
                if (flag)
                {
                    //更新两位玩家的卡牌数量
                    Entity.userEntity userentity1 = Iuser.GetModel(username1);
                    Entity.userEntity userentity2 = Iuser.GetModel(username2);
                    userentity1.amount =userentity1.amount +1;
                    userentity2.amount =userentity2.amount-1;
                    Iuser.UpdateAmount(userentity2);
                    Iuser.UpdateAmount(userentity1);
                    result = "成功掠夺！！！";
                }
                else
                {
                    result = "sorry，数据库更新失败";
                }

            }
            return result;
        }

        /// <summary>
        /// PK后更新卡牌的主人
        /// </summary>
        public bool PK(string picid,string winner,string loser)
        {
            bool flag = false;
            Entity.pictureEntity picture = new Entity.pictureEntity();
            picture.picid = int.Parse(picid);
            picture.owner = winner;
            Ipicture = factory.CreatPictureIDAL();
            flag = Ipicture.UpdateOwner(picture);

            //更新两位玩家的卡牌数量
            Iuser = factory.CreatUserIDAL();
            Entity.userEntity user_winner = Iuser.GetModel(winner);
            Entity.userEntity user_loser = Iuser.GetModel(loser);
            user_winner.amount = user_winner.amount + 1;
            user_loser.amount = user_loser.amount - 1;
            Iuser.UpdateAmount(user_winner);
            Iuser.UpdateAmount(user_loser);

            return flag;
        }

    }
}