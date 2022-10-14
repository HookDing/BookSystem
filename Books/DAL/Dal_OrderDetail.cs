using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using Books.Model;
using Model;

namespace Books.DAL
{
    /// <summary>
    /// OrderDetail数据访问对象
    /// </summary>
    public partial class Dal_OrderDetail
    {
        /// <summary>
        /// 实例化OrderDetail数据访问对象
        /// </summary>
        public Dal_OrderDetail()
        {

        }

        /// <summary>
        /// 根据OrderID查询订单详情信息
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns>Model：View_OrderDetail</returns>
        public View_OrderDetail GetView_OrderDetails(int OrderID)
        {
            string sql = $@"select OrderNum,OrderDate,OrderMoney,OrderState,UserName,AMUser,AMTel,AMAddress,ODCount
from OrderDetail,AddressManager,Users,Orders
where Orders.AMID=AddressManager.AMID
and Orders.OrderID={OrderID}";
            SqlDataReader dr = DBHelper.ExecuteReader(sql);
            View_OrderDetail info = new View_OrderDetail();
            if (dr.Read())
            {
                info.OrderNum = dr.IsDBNull(0) ? null : (string)dr.GetString(0);
                info.OrderDate = dr.IsDBNull(1) ? null : (DateTime?)dr.GetDateTime(1);
                info.OrderMoney = dr.IsDBNull(2) ? null : (decimal?)dr.GetDecimal(2);
                info.OrderState = dr.IsDBNull(3) ? null : (int?)dr.GetInt32(3);
                info.UserName = dr.IsDBNull(4) ? null : (string)dr.GetString(4);
                info.AMUser = dr.IsDBNull(5) ? null : (string)dr.GetString(5);
                info.AMTel = dr.IsDBNull(6) ? null : (string)dr.GetString(6);
                info.AMAddress = dr.IsDBNull(7) ? null : (string)dr.GetString(7);
                info.ODCount = dr.IsDBNull(8) ? 0 : dr.GetInt32(8);
            }
            return info;
        }
        /// <summary>
        /// 根据OrderID查询订单书籍列表
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns>List：View_OrderDetail</returns>
        public List<View_OrderDetail> GetView_ODBooks(int OrderID)
        {
            List<View_OrderDetail> list = new List<View_OrderDetail>();
            string sql = $"select BookTitle,BookMoney,ODCount,ODMoney from Books,OrderDetail where OrderDetail.BookID=Books.BookID and OrderDetail.OrderID={OrderID}";
            SqlDataReader dr = DBHelper.ExecuteReader(sql);
            while (dr.Read())
            {
                View_OrderDetail info = new View_OrderDetail();
                info.BookTitle = dr.GetString(0);
                info.BookMoney=dr.GetDecimal(1);
                info.ODCount = dr.GetInt32(2);
                info.ODMoney = dr.GetDecimal(3);
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 查询得到OrderDetail表中所有信息
        /// </summary>
        /// <returns>查询到的所有OrderDetail数据模型对象集合</returns>
        public List<Mod_OrderDetail> GetAllModel()
        {
            //创建存储查找到的OrderDetail表中信息集合
            List<Mod_OrderDetail> list = new List<Mod_OrderDetail>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select ODID,OrderID,BookID,ODPrice,ODCount,ODMoney From OrderDetail;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个OrderDetail数据模型对象
                        Mod_OrderDetail orderDetailMod = new Mod_OrderDetail();
                        //存储查询到的ODID数据
                        orderDetailMod.ODID = sqlReader.GetInt32(0);
                        //存储查询到的OrderID数据
                        orderDetailMod.OrderID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BookID数据
                        orderDetailMod.BookID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的ODPrice数据
                        orderDetailMod.ODPrice = sqlReader.IsDBNull(3) ? null : (decimal?)sqlReader.GetDecimal(3);
                        //存储查询到的ODCount数据
                        orderDetailMod.ODCount = sqlReader.IsDBNull(4) ? null : (int?)sqlReader.GetInt32(4);
                        //存储查询到的ODMoney数据
                        orderDetailMod.ODMoney = sqlReader.IsDBNull(5) ? null : (decimal?)sqlReader.GetDecimal(5);
                        //将OrderDetail数据模型对象存储到集合中
                        list.Add(orderDetailMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的OrderDetail数据模型对象数据存入数据库，并将自动编号值存入，传入OrderDetail数据模型对象中
        /// </summary>
        /// <param name="orderDetailMod">要进行添加到数据库的OrderDetail数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_OrderDetail orderDetailMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = orderDetailMod.OrderID ?? (object)DBNull.Value},
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = orderDetailMod.BookID ?? (object)DBNull.Value},
                //将ODPrice存入
                new SqlParameter("@oDPrice",SqlDbType.Decimal,10){Value = orderDetailMod.ODPrice ?? (object)DBNull.Value},
                //将ODCount存入
                new SqlParameter("@oDCount",SqlDbType.Int,4){Value = orderDetailMod.ODCount ?? (object)DBNull.Value},
                //将ODMoney存入
                new SqlParameter("@oDMoney",SqlDbType.Decimal,14){Value = orderDetailMod.ODMoney ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Insert Into OrderDetail(OrderID,BookID,ODPrice,ODCount,ODMoney) OutPut Inserted.ODID Values(@orderID,@bookID,@oDPrice,@oDCount,@oDMoney);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成ODID
                    orderDetailMod.ODID = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个OrderDetail数据模型对象
        /// </summary>
        /// <param name="oDID">ODID</param>
        /// <returns>如果查找到此记录就返回OrderDetail数据模型对象，否则返回null</returns>
        public Mod_OrderDetail GetModel(int oDID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = oDID}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select Top 1 ODID,OrderID,BookID,ODPrice,ODCount,ODMoney From OrderDetail Where ODID = @oDID;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个OrderDetail数据模型对象
                    Mod_OrderDetail orderDetailMod = new Mod_OrderDetail();
                    //存储查询到的ODID数据
                    orderDetailMod.ODID = sqlReader.GetInt32(0);
                    //存储查询到的OrderID数据
                    orderDetailMod.OrderID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                    //存储查询到的BookID数据
                    orderDetailMod.BookID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                    //存储查询到的ODPrice数据
                    orderDetailMod.ODPrice = sqlReader.IsDBNull(3) ? null : (decimal?)sqlReader.GetDecimal(3);
                    //存储查询到的ODCount数据
                    orderDetailMod.ODCount = sqlReader.IsDBNull(4) ? null : (int?)sqlReader.GetInt32(4);
                    //存储查询到的ODMoney数据
                    orderDetailMod.ODMoney = sqlReader.IsDBNull(5) ? null : (decimal?)sqlReader.GetDecimal(5);
                    //将OrderDetail数据模型对象返回
                    return orderDetailMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="oDID">ODID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int oDID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = oDID}
            };
            //执行一条按照ODID删除记录语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery("Delete From OrderDetail Where ODID = @oDID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="oDID">ODID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int oDID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = oDID}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From OrderDetail Where ODID = @oDID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="orderDetailMod">OrderDetail</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_OrderDetail orderDetailMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = orderDetailMod.ODID},
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = orderDetailMod.OrderID ?? (object)DBNull.Value},
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = orderDetailMod.BookID ?? (object)DBNull.Value},
                //将ODPrice存入
                new SqlParameter("@oDPrice",SqlDbType.Decimal,10){Value = orderDetailMod.ODPrice ?? (object)DBNull.Value},
                //将ODCount存入
                new SqlParameter("@oDCount",SqlDbType.Int,4){Value = orderDetailMod.ODCount ?? (object)DBNull.Value},
                //将ODMoney存入
                new SqlParameter("@oDMoney",SqlDbType.Decimal,14){Value = orderDetailMod.ODMoney ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return DBHelper.ExecuteNonQuery("Update OrderDetail Set OrderID = @orderID,BookID = @bookID,ODPrice = @oDPrice,ODCount = @oDCount,ODMoney = @oDMoney Where ODID = @oDID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="orderDetailMod">验证的OrderDetail数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_OrderDetail orderDetailMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将ODID存入
                new SqlParameter("@oDID",SqlDbType.Int,4){Value = orderDetailMod.ODID},
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = orderDetailMod.OrderID ?? (object)DBNull.Value},
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = orderDetailMod.BookID ?? (object)DBNull.Value},
                //将ODPrice存入
                new SqlParameter("@oDPrice",SqlDbType.Decimal,10){Value = orderDetailMod.ODPrice ?? (object)DBNull.Value},
                //将ODCount存入
                new SqlParameter("@oDCount",SqlDbType.Int,4){Value = orderDetailMod.ODCount ?? (object)DBNull.Value},
                //将ODMoney存入
                new SqlParameter("@oDMoney",SqlDbType.Decimal,14){Value = orderDetailMod.ODMoney ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From OrderDetail Where ODID = @oDID And OrderID = @orderID And BookID = @bookID And ODPrice = @oDPrice And ODCount = @oDCount And ODMoney = @oDMoney;", sqlParameters) > 0;
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
                    ? "Select Count(*) From OrderDetail;"
                    : "Select Count(*) From OrderDetail Where " + where;
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
                    ? "Delete From OrderDetail;"
                    : "Delete From OrderDetail Where " + where;
            //执行删除语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_OrderDetail> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<Mod_OrderDetail> list = new List<Mod_OrderDetail>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select ODID,OrderID,BookID,ODPrice,ODCount,ODMoney From OrderDetail;"
                    : "Select ODID,OrderID,BookID,ODPrice,ODCount,ODMoney From OrderDetail Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个OrderDetail数据模型对象
                        Mod_OrderDetail orderDetailMod = new Mod_OrderDetail();
                        //存储查询到的ODID数据
                        orderDetailMod.ODID = sqlReader.GetInt32(0);
                        //存储查询到的OrderID数据
                        orderDetailMod.OrderID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BookID数据
                        orderDetailMod.BookID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的ODPrice数据
                        orderDetailMod.ODPrice = sqlReader.IsDBNull(3) ? null : (decimal?)sqlReader.GetDecimal(3);
                        //存储查询到的ODCount数据
                        orderDetailMod.ODCount = sqlReader.IsDBNull(4) ? null : (int?)sqlReader.GetInt32(4);
                        //存储查询到的ODMoney数据
                        orderDetailMod.ODMoney = sqlReader.IsDBNull(5) ? null : (decimal?)sqlReader.GetDecimal(5);
                        //将OrderDetail数据模型对象存储到集合中
                        list.Add(orderDetailMod);
                    }
                }
            }
            //返回查找到的OrderDetail对象的集合
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
                    ? "Select Count(*) From OrderDetail;"
                    : "Select Count(*) From OrderDetail Where " + where;
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
        /// <returns>查询到的OrderDetail数据模型对象集合</returns>
        public List<Mod_OrderDetail> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储OrderDetail数据模型对象的集合
            List<Mod_OrderDetail> list = new List<Mod_OrderDetail>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From OrderDetail) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From OrderDetail Where " +
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
                        //创建一个OrderDetail数据模型对象
                        Mod_OrderDetail orderDetailMod = new Mod_OrderDetail();
                        //存储查询到的ODID数据
                        orderDetailMod.ODID = sqlReader.GetInt32(0);
                        //存储查询到的OrderID数据
                        orderDetailMod.OrderID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BookID数据
                        orderDetailMod.BookID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的ODPrice数据
                        orderDetailMod.ODPrice = sqlReader.IsDBNull(3) ? null : (decimal?)sqlReader.GetDecimal(3);
                        //存储查询到的ODCount数据
                        orderDetailMod.ODCount = sqlReader.IsDBNull(4) ? null : (int?)sqlReader.GetInt32(4);
                        //存储查询到的ODMoney数据
                        orderDetailMod.ODMoney = sqlReader.IsDBNull(5) ? null : (decimal?)sqlReader.GetDecimal(5);
                        //将OrderDetail数据模型对象存储到集合中
                        list.Add(orderDetailMod);
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
        /// <returns>查询到的OrderDetail数据模型对象集合</returns>
        public List<Mod_OrderDetail> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的OrderDetail数据模型对象集合</returns>
        public List<Mod_OrderDetail> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
