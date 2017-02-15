using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IDAL
{
    public interface pictureIDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int picid);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Entity.pictureEntity model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.pictureEntity model);

        /// <summary>
        /// 更新一条数据-所有者
        /// </summary>
        bool UpdateOwner(Entity.pictureEntity model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int picid);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.pictureEntity GetModel(int picid);

        /// <summary>
        /// 将Table转化为实体
        /// </summary>
        Entity.pictureEntity DataRowToModel(DataRow row);
        
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