using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Text;
using Books.Model;
using Model;

namespace Books.DAL
{
    /// <summary>
    /// BookAppraise数据访问对象
    /// </summary>
    public partial class Dal_BookAppraise
    {
        /// <summary>
        /// 实例化BookAppraise数据访问对象
        /// </summary>
        public Dal_BookAppraise()
        {

        }
        /// <summary>
        /// 查询得到BookAppraise表中所有信息
        /// </summary>
        /// <returns>查询到的所有BookAppraise数据模型对象集合</returns>
        public List<Mod_BookAppraise> GetAllModel()
        {
            //创建存储查找到的BookAppraise表中信息集合
            List<Mod_BookAppraise> list = new List<Mod_BookAppraise>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select BAID,ODID,BADesc,BAPoint,BADate From BookAppraise;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个BookAppraise数据模型对象
                        Mod_BookAppraise bookAppraiseMod = new Mod_BookAppraise();
                        //存储查询到的BAID数据
                        bookAppraiseMod.BAID = sqlReader.GetInt32(0);
                        //存储查询到的ODID数据
                        bookAppraiseMod.ODID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BADesc数据
                        bookAppraiseMod.BADesc = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的BAPoint数据
                        bookAppraiseMod.BAPoint = sqlReader.IsDBNull(3) ? null : (int?)sqlReader.GetInt32(3);
                        //存储查询到的BADate数据
                        bookAppraiseMod.BADate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //将BookAppraise数据模型对象存储到集合中
                        list.Add(bookAppraiseMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的BookAppraise数据模型对象数据存入数据库，并将自动编号值存入，传入BookAppraise数据模型对象中
        /// </summary>
        /// <param name="bookAppraiseMod">要进行添加到数据库的BookAppraise数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_BookAppraise bookAppraiseMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = bookAppraiseMod.ODID ?? (object)DBNull.Value},
                //将BADesc存入
                new SqlParameter("@bADesc",SqlDbType.NVarChar,1000){Value = bookAppraiseMod.BADesc ?? (object)DBNull.Value},
                //将BAPoint存入
                new SqlParameter("@bAPoint",SqlDbType.Int,4){Value = bookAppraiseMod.BAPoint ?? (object)DBNull.Value},
                //将BADate存入
                new SqlParameter("@bADate",SqlDbType.DateTime,16){Value = bookAppraiseMod.BADate ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Insert Into BookAppraise(ODID,BADesc,BAPoint,BADate) OutPut Inserted.BAID Values(@oDID,@bADesc,@bAPoint,@bADate);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成BAID
                    bookAppraiseMod.BAID = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个BookAppraise数据模型对象
        /// </summary>
        /// <param name="bAID">BAID</param>
        /// <returns>如果查找到此记录就返回BookAppraise数据模型对象，否则返回null</returns>
        public Mod_BookAppraise GetModel(int bAID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BAID存入
                new SqlParameter("@bAID",SqlDbType.Int,4){Value = bAID}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select Top 1 BAID,ODID,BADesc,BAPoint,BADate From BookAppraise Where BAID = @bAID;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个BookAppraise数据模型对象
                    Mod_BookAppraise bookAppraiseMod = new Mod_BookAppraise();
                    //存储查询到的BAID数据
                    bookAppraiseMod.BAID = sqlReader.GetInt32(0);
                    //存储查询到的ODID数据
                    bookAppraiseMod.ODID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                    //存储查询到的BADesc数据
                    bookAppraiseMod.BADesc = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                    //存储查询到的BAPoint数据
                    bookAppraiseMod.BAPoint = sqlReader.IsDBNull(3) ? null : (int?)sqlReader.GetInt32(3);
                    //存储查询到的BADate数据
                    bookAppraiseMod.BADate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                    //将BookAppraise数据模型对象返回
                    return bookAppraiseMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="bAID">BAID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int bAID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BAID存入
                new SqlParameter("@bAID",SqlDbType.Int,4){Value = bAID}
            };
            //执行一条按照BAID删除记录语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery("Delete From BookAppraise Where BAID = @bAID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="bAID">BAID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int bAID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@bAID",SqlDbType.Int,4){Value = bAID}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From BookAppraise Where BAID = @bAID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="bookAppraiseMod">BookAppraise</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_BookAppraise bookAppraiseMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BAID存入
                new SqlParameter("@bAID",SqlDbType.Int,4){Value = bookAppraiseMod.BAID},
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = bookAppraiseMod.ODID ?? (object)DBNull.Value},
                //将BADesc存入
                new SqlParameter("@bADesc",SqlDbType.NVarChar,1000){Value = bookAppraiseMod.BADesc ?? (object)DBNull.Value},
                //将BAPoint存入
                new SqlParameter("@bAPoint",SqlDbType.Int,4){Value = bookAppraiseMod.BAPoint ?? (object)DBNull.Value},
                //将BADate存入
                new SqlParameter("@bADate",SqlDbType.DateTime,16){Value = bookAppraiseMod.BADate ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return DBHelper.ExecuteNonQuery("Update BookAppraise Set ODID = @oDID,BADesc = @bADesc,BAPoint = @bAPoint,BADate = @bADate Where BAID = @bAID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="bookAppraiseMod">验证的BookAppraise数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_BookAppraise bookAppraiseMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BAID存入
                new SqlParameter("@bAID",SqlDbType.Int,4){Value = bookAppraiseMod.BAID},
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = bookAppraiseMod.ODID ?? (object)DBNull.Value},
                //将BADesc存入
                new SqlParameter("@bADesc",SqlDbType.NVarChar,1000){Value = bookAppraiseMod.BADesc ?? (object)DBNull.Value},
                //将BAPoint存入
                new SqlParameter("@bAPoint",SqlDbType.Int,4){Value = bookAppraiseMod.BAPoint ?? (object)DBNull.Value},
                //将BADate存入
                new SqlParameter("@bADate",SqlDbType.DateTime,16){Value = bookAppraiseMod.BADate ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From BookAppraise Where BAID = @bAID And ODID = @oDID And BADesc = @bADesc And BAPoint = @bAPoint And BADate = @bADate;", sqlParameters) > 0;
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
                    ? "Select Count(*) From BookAppraise;"
                    : "Select Count(*) From BookAppraise Where " + where;
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
                    ? "Delete From BookAppraise;"
                    : "Delete From BookAppraise Where " + where;
            //执行删除语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<View_BookAppraise> GetModelListBySqlStr(string where)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<View_BookAppraise> list = new List<View_BookAppraise>();
            string sql = where;
            //执行查找语句
            SqlParameter[] sqlParameters = null;
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个BookAppraise数据模型对象
                        View_BookAppraise info = new View_BookAppraise();
                        info.UserNick = sqlReader["UserNick"].ToString();
                        info.BADate = Convert.ToDateTime(sqlReader["BADate"].ToString());
                        info.BAPoint = Convert.ToInt32(sqlReader["BAPoint"].ToString());
                        info.BADesc = sqlReader["BADesc"].ToString();
                        info.BookID = Convert.ToInt32(sqlReader["BookID"].ToString());
                        list.Add(info);
                    }
                }
            }
            //返回查找到的BookAppraise对象的集合
            return list;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_BookAppraise> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<Mod_BookAppraise> list = new List<Mod_BookAppraise>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select BAID,ODID,BADesc,BAPoint,BADate From BookAppraise;"
                    : "Select BAID,ODID,BADesc,BAPoint,BADate From BookAppraise Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个BookAppraise数据模型对象
                        Mod_BookAppraise bookAppraiseMod = new Mod_BookAppraise();
                        //存储查询到的BAID数据
                        bookAppraiseMod.BAID = sqlReader.GetInt32(0);
                        //存储查询到的ODID数据
                        bookAppraiseMod.ODID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BADesc数据
                        bookAppraiseMod.BADesc = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的BAPoint数据
                        bookAppraiseMod.BAPoint = sqlReader.IsDBNull(3) ? null : (int?)sqlReader.GetInt32(3);
                        //存储查询到的BADate数据
                        bookAppraiseMod.BADate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //将BookAppraise数据模型对象存储到集合中
                        list.Add(bookAppraiseMod);
                    }
                }
            }
            //返回查找到的BookAppraise对象的集合
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
                    ? "Select Count(*) From BookAppraise;"
                    : "Select Count(*) From BookAppraise Where " + where;
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
        /// <returns>查询到的BookAppraise数据模型对象集合</returns>
        public List<Mod_BookAppraise> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储BookAppraise数据模型对象的集合
            List<Mod_BookAppraise> list = new List<Mod_BookAppraise>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From BookAppraise) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From BookAppraise Where " +
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
                        //创建一个BookAppraise数据模型对象
                        Mod_BookAppraise bookAppraiseMod = new Mod_BookAppraise();
                        //存储查询到的BAID数据
                        bookAppraiseMod.BAID = sqlReader.GetInt32(0);
                        //存储查询到的ODID数据
                        bookAppraiseMod.ODID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BADesc数据
                        bookAppraiseMod.BADesc = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的BAPoint数据
                        bookAppraiseMod.BAPoint = sqlReader.IsDBNull(3) ? null : (int?)sqlReader.GetInt32(3);
                        //存储查询到的BADate数据
                        bookAppraiseMod.BADate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //将BookAppraise数据模型对象存储到集合中
                        list.Add(bookAppraiseMod);
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
        /// <returns>查询到的BookAppraise数据模型对象集合</returns>
        public List<Mod_BookAppraise> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的BookAppraise数据模型对象集合</returns>
        public List<Mod_BookAppraise> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
