using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IDAL
{
    public interface userIDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int uid);
       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Entity.userEntity model);
       
        /// <summary>
        /// 更新一条数据-全部信息
        /// </summary>
        bool Update(Entity.userEntity model);
        
        /// <summary>
        /// 更新一条数据-用户密码
        /// </summary>
        bool UpdatePwd(Entity.userEntity model);

        /// <summary>
        /// 更新一条数据-用户卡牌数量
        /// </summary>
        bool UpdateAmount(Entity.userEntity model);

        /// <summary>
        /// 更新一条数据-用户好友
        /// </summary>
        bool UpdateFriends(Entity.userEntity model);
       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int uid);
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.userEntity GetModel(string username);

        /// <summary>
        /// 得到一个对象实体-通过ID
        /// </summary>
        Entity.userEntity GetModelByID(int uid);
        
        /// <summary>
        /// 将Table转化为实体
        /// </summary>
        Entity.userEntity DataRowToModel(DataRow row);
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获取记录总数
        /// </summary>
        int GetRecordCount(string strWhere);
       
    }
}