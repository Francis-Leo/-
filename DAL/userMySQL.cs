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
    public class userMySQL:userIDAL
    {

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user");
            strSql.Append(" where uid=" + uid + " ");
            return DbHelperMySQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Entity.userEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            #region 拼接SQL
            if (model.amount != null)
            {
                strSql1.Append("amount,");
                strSql2.Append("'" + model.amount + "',");
            }
            if (model.grade != null)
            {
                strSql1.Append("grade,");
                strSql2.Append("'" + model.grade + "',");
            }
            if (model.name != null)
            {
                strSql1.Append("name,");
                strSql2.Append("'" + model.name + "',");
            }
            if (model.other != null)
            {
                strSql1.Append("other,");
                strSql2.Append("" + model.other + ",");
            }
            if (model.password != null)
            {
                strSql1.Append("password,");
                strSql2.Append("'" + model.password + "',");
            }
            if (model.rank != null)
            {
                strSql1.Append("rank,");
                strSql2.Append("'" + model.rank + "',");
            }
            if (model.uid != null)
            {
                strSql1.Append("uid,");
                strSql2.Append("'" + model.uid + "',");
            }
            #endregion   
            strSql.Append("insert into user(");
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
        /// 更新一条数据-全部更新
        /// </summary>
        public bool Update(Entity.userEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user set ");
            #region 拼接SQL
            if (model.amount != null)
            {
                strSql.Append("amount='" + model.amount + "',");
            }
            else
            {
                strSql.Append("amount= null ,");
            }
            if (model.grade != null)
            {
                strSql.Append("grade='" + model.grade + "',");
            }
            else
            {
                strSql.Append("grade= null ,");
            }
            if (model.password != null)
            {
                strSql.Append("password='" + model.password + "',");
            }
            else
            {
                strSql.Append("password= null ,");
            }
            if (model.name != null)
            {
                strSql.Append("name=" + model.name + ",");
            }
            else
            {
                strSql.Append("name= null ,");
            }
            if (model.other != null)
            {
                strSql.Append("other='" + model.other + "',");
            }
            else
            {
                strSql.Append("other= null ,");
            }
            if (model.rank != null)
            {
                strSql.Append("rank='" + model.rank + "',");
            }
            else
            {
                strSql.Append("rank= null ,");
            }
            if (model.uid != null)
            {
                strSql.Append("uid='" + model.uid + "',");
            }
            else
            {
                strSql.Append("uid= null ,");
            }
            #endregion
            strSql.Append(" where uid=" + model.uid + "");
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
        /// 更新一条数据-用户密码
        /// </summary>
        public bool UpdatePwd(Entity.userEntity model)
        {
            //TODO
            return true;
        }

        /// <summary>
        /// 更新一条数据-用户卡牌数量
        /// </summary>
        public bool UpdateAmount(Entity.userEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user set ");
            #region 拼接SQL
            if (model.amount != null)
            {
                strSql.Append("amount='" + model.amount + "',");
            }
            else
            {
                strSql.Append("amount= null ,");
            }
            if (model.uid != null)
            {
                strSql.Append("uid='" + model.uid + "',");
            }
            else
            {
                strSql.Append("uid= null ,");
            }
            #endregion
            strSql.Append(" where uid=" + model.uid + "");
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
        /// 更新一条数据-用户好友
        /// </summary>
        public bool UpdateFriends(Entity.userEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user set ");
            #region 拼接SQL
            if (model.friends != null)
            {
                strSql.Append("friends='" + model.friends + "',");
            }
            else
            {
                strSql.Append("friends= null ,");
            }
            if (model.uid != null)
            {
                strSql.Append("uid='" + model.uid + "',");
            }
            else
            {
                strSql.Append("uid= null ,");
            }
            #endregion
            strSql.Append(" where uid=" + model.uid + "");
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
        public bool Delete(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user ");
            strSql.Append(" where uid=" + uid + "");
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
        /// 得到一个对象实体-通过姓名-暂用
        /// </summary>
        public Entity.userEntity GetModel(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" uid,name,password,grade,amount,friends,state,rank,other ");
            strSql.Append(" from user ");
            strSql.Append(" where name= '" + username + "'");
            Entity.userEntity model = new Entity.userEntity();
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
        /// 得到一个对象实体-通过ID
        /// </summary>
        public Entity.userEntity GetModelByID(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" uid,name,password,grade,amount,friends,state,rank,other ");
            strSql.Append(" from user ");
            strSql.Append(" where uid= '" + uid + "'");
            Entity.userEntity model = new Entity.userEntity();
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
        public Entity.userEntity DataRowToModel(DataRow row)
        {
            Entity.userEntity model = new Entity.userEntity();
            if (row != null)
            {
                if (row["uid"] != null && row["uid"].ToString() != "")
                {
                    model.uid = int.Parse(row["uid"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = int.Parse(row["amount"].ToString());
                }
                if (row["grade"] != null)
                {
                    model.grade = row["grade"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["other"] != null)
                {
                    model.other = row["other"].ToString();
                }
                if (row["rank"] != null)
                {
                    model.rank = row["rank"].ToString();
                }
                if (row["state"] != null)
                {
                    model.state = row["state"].ToString();
                }
                if (row["friends"] != null)
                {
                    model.friends = row["friends"].ToString();
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
            strSql.Append("select uid,name,password,grade,amount,state,rank,other ");
            strSql.Append(" FROM user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM user ");
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
        //放置新添加的方法

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
        //        strSql.Append("order by T.uid desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from user T ");
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
        //    strSql.Append("SELECT * from user ");
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