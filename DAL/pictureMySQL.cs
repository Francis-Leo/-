using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;

namespace DAL
{
    public class pictureMySQL:pictureIDAL
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int picid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from picture");
            strSql.Append(" where picid=" + picid + " ");
            return DbHelperMySQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Entity.pictureEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            #region 拼接SQL
            if (model.chapter != null)
            {
                strSql1.Append("chapter,");
                strSql2.Append("'" + model.chapter + "',");
            }
            if (model.name != null)
            {
                strSql1.Append("name,");
                strSql2.Append("'" + model.name + "',");
            }
            if (model.other != null)
            {
                strSql1.Append("other,");
                strSql2.Append("'" + model.other + "',");
            }
            if (model.owner != null)
            {
                strSql1.Append("owner,");
                strSql2.Append("" + model.owner + ",");
            }
            if (model.path != null)
            {
                strSql1.Append("path,");
                strSql2.Append("'" + model.path + "',");
            }
            if (model.picid != null)
            {
                strSql1.Append("picid,");
                strSql2.Append("'" + model.picid + "',");
            }
            if (model.state != null)
            {
                strSql1.Append("state,");
                strSql2.Append("'" + model.state + "',");
            }
            #endregion
            strSql.Append("insert into picture(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.pictureEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update picture set ");
            #region 拼接SQL
            if (model.picid != null)
            {
                strSql.Append("picid='" + model.picid + "',");
            }
            else
            {
                strSql.Append("picid= null ,");
            }
            if (model.chapter != null)
            {
                strSql.Append("chapter='" + model.chapter + "',");
            }
            else
            {
                strSql.Append("chapter= null ,");
            }
            if (model.name != null)
            {
                strSql.Append("name='" + model.name + "',");
            }
            else
            {
                strSql.Append("name= null ,");
            }
            if (model.other != null)
            {
                strSql.Append("other=" + model.other + ",");
            }
            else
            {
                strSql.Append("other= null ,");
            }
            if (model.owner != null)
            {
                strSql.Append("owner='" + model.owner + "',");
            }
            else
            {
                strSql.Append("owner= null ,");
            }
            if (model.path != null)
            {
                strSql.Append("path='" + model.path + "',");
            }
            else
            {
                strSql.Append("path= null ,");
            }
            if (model.state != null)
            {
                strSql.Append("state='" + model.state + "',");
            }
            else
            {
                strSql.Append("state= null ,");
            }
            #endregion
            strSql.Append(" where picid=" + model.picid + "");
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            int rowsAffected = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据-所有者
        /// </summary>
        public bool UpdateOwner(Entity.pictureEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update picture set ");
            #region 拼接SQL
            if (model.picid != null)
            {
                strSql.Append("picid='" + model.picid + "',");
            }
            else
            {
                strSql.Append("picid= null ,");
            }

            if (model.owner != null)
            {
                strSql.Append("owner='" + model.owner + "',");
            }
            else
            {
                strSql.Append("owner= null ,");
            }
           
            #endregion
            strSql.Append(" where picid=" + model.picid + "");
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            int rowsAffected = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int picid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from picture ");
            strSql.Append(" where picid=" + picid + "");
            int rowsAffected = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.pictureEntity GetModel(int picid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" picid,path,name,chapter,state,owner,other ");
            strSql.Append(" from picture ");
            strSql.Append(" where picid=" + picid + "");
            Entity.pictureEntity model = new Entity.pictureEntity();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将Table转化为实体
        /// </summary>
        public Entity.pictureEntity DataRowToModel(DataRow row)
        {
            Entity.pictureEntity model = new Entity.pictureEntity();
            if (row != null)
            {
                if (row["picid"] != null && row["picid"].ToString() != "")
                {
                    model.picid = int.Parse(row["picid"].ToString());
                }
                if (row["chapter"] != null)
                {
                    model.chapter = row["chapter"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["owner"] != null)
                {
                    model.owner = row["owner"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["other"] != null)
                {
                    model.other = row["other"].ToString();
                }
                if (row["path"] != null)
                {
                    model.path = row["path"].ToString();
                }
                if (row["state"] != null)
                {
                    model.state = row["state"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select picid,path,name,chapter,state,owner,other ");
            strSql.Append(" FROM picture ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM picture ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion  BasicMethod

        #region ExtendMethod
        //新添加的方法

        /// <summary>
        /// 分页获取数据列表-暂时不用
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby);
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.picid desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from picid T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperMySQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 分页获取数据列表-暂时不用
        /// </summary>
        //public DataSet GetListByNewPage(string strWhere, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * from picture ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" limit " + startIndex + "," + endIndex + "");
        //    return DbHelperMySQL.Query(strSql.ToString());
        //}

        #endregion
    }
}