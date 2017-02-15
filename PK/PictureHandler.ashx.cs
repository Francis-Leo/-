using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PK
{
    /// <summary>
    /// PictureHandler 的摘要说明
    /// </summary>
    public class PictureHandler : IHttpHandler
    {

        HttpContext Context;

        /// <summary>
        /// 获取传的值,并调用其他的方法
        /// </summary>
        public void ProcessRequest(HttpContext context)
        {
            Context = context;
            context.Response.Clear();
            context.Response.ContentType = "text/html; charset=utf-8";
            //获取传来的值
            //string methodName = GetQueryString("id");

            //调用其他方法-暂时不用
            //PK.pk.userWin(methodName);
            //PK.pk.ShowPicture1();
            //PK.pk.ShowPicture2();

        }

        /// <summary>
        /// 获取传的值
        /// </summary>
        string GetQueryString(string name)
        {
            //获取传的值
            return Context.Request.Params[name];
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}