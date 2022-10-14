using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using Books.Model;

namespace Books.DAL
{
    /// <summary>
    /// BLCategory数据访问对象
    /// </summary>
    public partial class Dal_BLCategory
    {
        /// <summary>
        /// 实例化BLCategory数据访问对象
        /// </summary>
        public Dal_BLCategory()
        {
            
        }
        /// <summary>
        /// 查询得到BLCategory表中所有信息
        /// </summary>
        /// <returns>查询到的所有BLCategory数据模型对象集合</returns>
        public List<Mod_BLCategory> GetAllModel()
        {
            //创建存储查找到的BLCategory表中信息集合
            List<Mod_BLCategory> list = new List<Mod_BLCategory>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select BLID,BLName From BLCategory;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个BLCategory数据模型对象
                        Mod_BLCategory bLCategoryMod = new Mod_BLCategory();
                        //存储查询到的BLID数据
                        bLCategoryMod.BLID = sqlReader.GetInt32(0);
                        //存储查询到的BLName数据
                        bLCategoryMod.BLName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将BLCategory数据模型对象存储到集合中
                        list.Add(bLCategoryMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的BLCategory数据模型对象数据存入数据库，并将自动编号值存入，传入BLCategory数据模型对象中
        /// </summary>
        /// <param name="bLCategoryMod">要进行添加到数据库的BLCategory数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_BLCategory bLCategoryMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BLName存入
                new SqlParameter("@bLName",SqlDbType.NVarChar,200){Value = bLCategoryMod.BLName ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Insert Into BLCategory(BLName) OutPut Inserted.BLID Values(@bLName);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成BLID
                    bLCategoryMod.BLID = sqlReader.GetInt32(0);
                    //返回添加成功
                    return true;
                }
                else
                {
                    //返回添加失败
                    return false;
                }
            }
        }
        /// <summary>
        /// 根据主键获取一条记录返回一个BLCategory数据模型对象
        /// </summary>
        /// <param name="bLID">BLID</param>
        /// <returns>如果查找到此记录就返回BLCategory数据模型对象，否则返回null</returns>
        public Mod_BLCategory GetModel(int bLID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BLID存入
                new SqlParameter("@bLID",SqlDbType.Int,4){Value = bLID}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select Top 1 BLID,BLName From BLCategory Where BLID = @bLID;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个BLCategory数据模型对象
                    Mod_BLCategory bLCategoryMod = new Mod_BLCategory();
                    //存储查询到的BLID数据
                    bLCategoryMod.BLID = sqlReader.GetInt32(0);
                    //存储查询到的BLName数据
                    bLCategoryMod.BLName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                    //将BLCategory数据模型对象返回
                    return bLCategoryMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="bLID">BLID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int bLID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BLID存入
                new SqlParameter("@@bLID",SqlDbType.Int,4){Value = bLID}
            };
            //执行一条按照BLID删除记录语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery("Delete From BLCategory Where BLID = @@bLID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="bLID">BLID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int bLID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@bLID",SqlDbType.Int,4){Value = bLID}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From BLCategory Where BLID = @bLID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="bLCategoryMod">BLCategory</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_BLCategory bLCategoryMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BLID存入
                new SqlParameter("@bLID",SqlDbType.Int,4){Value = bLCategoryMod.BLID},
                //将BLName存入
                new SqlParameter("@bLName",SqlDbType.NVarChar,200){Value = bLCategoryMod.BLName ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return DBHelper.ExecuteNonQuery("Update BLCategory Set BLName = @bLName Where BLID = @bLID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="bLCategoryMod">验证的BLCategory数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_BLCategory bLCategoryMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BLID存入
                new SqlParameter("@bLID",SqlDbType.Int,4){Value = bLCategoryMod.BLID},
                //将BLName存入
                new SqlParameter("@bLName",SqlDbType.NVarChar,200){Value = bLCategoryMod.BLName ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From BLCategory Where BLID = @bLID And BLName = @bLName;", sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>
        /// <param name="sqlParameters">SQL参数对象</param>
        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>
        public bool Exists(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Count(*) From BLCategory;"
                    : "Select Count(*) From BLCategory Where " + where;
            //返回执行完成所得到的数据集合数量并判断是否有超过一条？
            return (int)DBHelper.ExecuteScalar(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义删除【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>是否删除成功，为true成功，为false失败</returns>
        public bool Delete(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Delete From BLCategory;"
                    : "Delete From BLCategory Where " + where;
            //执行删除语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_BLCategory> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<Mod_BLCategory> list = new List<Mod_BLCategory>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select BLID,BLName From BLCategory;"
                    : "Select BLID,BLName From BLCategory Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个BLCategory数据模型对象
                        Mod_BLCategory bLCategoryMod = new Mod_BLCategory();
                        //存储查询到的BLID数据
                        bLCategoryMod.BLID = sqlReader.GetInt32(0);
                        //存储查询到的BLName数据
                        bLCategoryMod.BLName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将BLCategory数据模型对象存储到集合中
                        list.Add(bLCategoryMod);
                    }
                }
            }
            //返回查找到的BLCategory对象的集合
            return list;
        }
        /// <summary>
        /// 自定义查询出匹配记录有多少条【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>匹配记录数量</returns>
        public int GetCount(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Count(*) From BLCategory;"
                    : "Select Count(*) From BLCategory Where " + where;
            //返回执行完成所得到的数据集合
            return (int)DBHelper.ExecuteScalar(sql, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="startIndex">开始索引【从零开始】</param>
        /// <param name="endIndex">结束索引【包括当前索引指向记录】</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的BLCategory数据模型对象集合</returns>
        public List<Mod_BLCategory> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储BLCategory数据模型对象的集合
            List<Mod_BLCategory> list = new List<Mod_BLCategory>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From BLCategory) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From BLCategory Where " +
                    //将条件存入内查询，而非外查询！！！
                    where +
                    ") As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() + ";";
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个BLCategory数据模型对象
                        Mod_BLCategory bLCategoryMod = new Mod_BLCategory();
                        //存储查询到的BLID数据
                        bLCategoryMod.BLID = sqlReader.GetInt32(0);
                        //存储查询到的BLName数据
                        bLCategoryMod.BLName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将BLCategory数据模型对象存储到集合中
                        list.Add(bLCategoryMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的BLCategory数据模型对象集合</returns>
        public List<Mod_BLCategory> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
        {
            //得到开始索引
            int beginIndex = pageIndex * pageItemCount;
            //得到结束索引
            int endIndex = (beginIndex + pageItemCount) - 1;
            //调用分页获取数据方法并返回结果
            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="allItmeCount">总共有多少条记录</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的BLCategory数据模型对象集合</returns>
        public List<Mod_BLCategory> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
        {
            //得到总记录条数
            allItmeCount = this.GetCount(where, DBHelper.CopySqlParameters(sqlParameters));
            //得到开始索引
            int beginIndex = pageIndex * pageItemCount;
            //得到结束索引
            int endIndex = (beginIndex + pageItemCount) - 1;
            //调用分页获取数据方法并返回结果
            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);
        }
    }
}
