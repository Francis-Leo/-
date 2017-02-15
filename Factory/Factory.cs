using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Configuration;
using DAL;
using IDAL;

namespace Factory
{
    public class Factory
    {
        string dbtype = System.Configuration.ConfigurationManager.AppSettings["DBType"];

        public pictureIDAL CreatPictureIDAL()
        {
            string classname = "DAL.picture" + dbtype;
            pictureIDAL Ipicture = (pictureIDAL)(Assembly.Load("DAL").CreateInstance(classname));
            return Ipicture;
        }

        public userIDAL CreatUserIDAL()
        {
            string classname = "DAL.user" + dbtype;
            userIDAL Iuser = (userIDAL)(Assembly.Load("DAL").CreateInstance(classname));
            return Iuser;
        }


    }
}