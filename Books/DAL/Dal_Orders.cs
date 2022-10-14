using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using Books.Model;
using Model;

namespace Books.DAL
{
    /// <summary>
    /// Orders数据访问对象
    /// </summary>
    public partial class Dal_Orders
    {
        /// <summary>
        /// 实例化Orders数据访问对象
        /// </summary>
        public Dal_Orders()
        {

        }
        public List<Mod_Orders> GetAllData()
        {
            //创建存储查找到的Orders表中信息集合
            List<Mod_Orders> list = new List<Mod_Orders>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select OrderID,Orders.UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney,UserName From Orders,Users where Orders.UserID=Users.UserID;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个Orders数据模型对象
                        View_Orders ordersMod = new View_Orders();
                        //存储查询到的OrderID数据
                        ordersMod.OrderID = sqlReader.GetInt32(0);
                        //存储查询到的UserID数据
                        ordersMod.UserID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的AMID数据
                        ordersMod.AMID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的OrderNum数据
                        ordersMod.OrderNum = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的OrderDate数据
                        ordersMod.OrderDate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //存储查询到的OrderState数据
                        ordersMod.OrderState = sqlReader.IsDBNull(5) ? null : (int?)sqlReader.GetInt32(5);
                        //存储查询到的OrderMoney数据
                        ordersMod.OrderMoney = sqlReader.IsDBNull(6) ? null : (decimal?)sqlReader.GetDecimal(6);
                        //UserName
                        ordersMod.UserName = sqlReader.IsDBNull(6) ? null : (string)sqlReader.GetString(7);
                        //将Orders数据模型对象存储到集合中
                        list.Add(ordersMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        public List<View_OrderBooks> GetBooksModsByPages(proc_page info)
        {
            List<View_OrderBooks> list = new List<View_OrderBooks>();

            SqlParameter sqlParameters = new SqlParameter();
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteProcPage(info, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据 
                    while (sqlReader.Read())
                    {
                        //创建一个Orders数据模型对象
                        View_OrderBooks ordersMod = new View_OrderBooks();
                        ordersMod.ISBN = sqlReader["ISBN"].ToString();
                        ordersMod.BookTitle = sqlReader["BookTitle"].ToString();
                        ordersMod.BookPrice =Convert.ToDecimal( sqlReader["BookPrice"].ToString());
                        ordersMod.BookMoney = Convert.ToDecimal(sqlReader["BookMoney"].ToString());
                        ordersMod.ODCount =int.Parse( sqlReader["ODCount"].ToString());
                        ordersMod.OrderID = int.Parse( sqlReader["OrderID"].ToString());
                        ordersMod.BookID = int.Parse( sqlReader["BookID"].ToString());
                        ordersMod.OrderState = int.Parse( sqlReader["OrderState"].ToString());
                        ordersMod.ODID = int.Parse( sqlReader["ODID"].ToString());
                        list.Add(ordersMod);
                    }
                }
            }
            info.DataCount = (int)sqlParameters.Value;
            //返回查询到的信息集合
            return list;
        }
        public List<View_Orders> GetOrdersModsByPages(proc_page info)
        {
            List<View_Orders> list = new List<View_Orders>();

            SqlParameter sqlParameters = new SqlParameter();
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteProcPage(info, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据  OrderID,Orders.UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney,UserName
                    while (sqlReader.Read())
                    {
                        //创建一个Orders数据模型对象
                        View_Orders ordersMod = new View_Orders();
                        //存储查询到的OrderID数据
                        ordersMod.OrderID = sqlReader.GetInt32(0);
                        //存储查询到的UserID数据
                        ordersMod.UserID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的AMID数据
                        ordersMod.AMID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的OrderNum数据
                        ordersMod.OrderNum = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的OrderDate数据
                        ordersMod.OrderDate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //存储查询到的OrderState数据
                        ordersMod.OrderState = sqlReader.IsDBNull(5) ? null : (int?)sqlReader.GetInt32(5);
                        //存储查询到的OrderMoney数据
                        ordersMod.OrderMoney = sqlReader.IsDBNull(6) ? null : (decimal?)sqlReader.GetDecimal(6);
                        //存储查询到的OrderMoney数据
                        ordersMod.UserName = sqlReader.IsDBNull(6) ? null : (string)sqlReader.GetString(7);
                        //将Orders数据模型对象存储到集合中
                        list.Add(ordersMod);
                    }
                }
            }
            info.DataCount = (int)sqlParameters.Value;
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 查询得到Orders表中所有信息
        /// </summary>
        /// <returns>查询到的所有Orders数据模型对象集合</returns>
        public List<Mod_Orders> GetAllModel()
        {
            //创建存储查找到的Orders表中信息集合
            List<Mod_Orders> list = new List<Mod_Orders>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select OrderID,UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney From Orders;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个Orders数据模型对象
                        Mod_Orders ordersMod = new Mod_Orders();
                        //存储查询到的OrderID数据
                        ordersMod.OrderID = sqlReader.GetInt32(0);
                        //存储查询到的UserID数据
                        ordersMod.UserID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的AMID数据
                        ordersMod.AMID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的OrderNum数据
                        ordersMod.OrderNum = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的OrderDate数据
                        ordersMod.OrderDate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //存储查询到的OrderState数据
                        ordersMod.OrderState = sqlReader.IsDBNull(5) ? null : (int?)sqlReader.GetInt32(5);
                        //存储查询到的OrderMoney数据
                        ordersMod.OrderMoney = sqlReader.IsDBNull(6) ? null : (decimal?)sqlReader.GetDecimal(6);
                        //将Orders数据模型对象存储到集合中
                        list.Add(ordersMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的Orders数据模型对象数据存入数据库，并将自动编号值存入，传入Orders数据模型对象中
        /// </summary>
        /// <param name="ordersMod">要进行添加到数据库的Orders数据模型对象</param>
        /// <returns>返回是否添加成功，为1添加成功，为0添加失败</returns>
        public int Insert(Mod_Orders info)
        {
            string sqlstr = "insert into Orders(UserID,AMID,OrderNum,OrderMoney) values(@UserID,@AMID,@OrderNum,@OrderMoney);select @@identity";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            list.Add(new SqlParameter("@AMID", info.AMID));
            list.Add(new SqlParameter("@OrderNum", info.OrderNum));
            list.Add(new SqlParameter("@OrderMoney", info.OrderMoney));
            return int.Parse(DBHelper.SelectSingle(sqlstr, list).ToString());
        }
        /// <summary>
        /// 将传入的Orders数据模型对象数据存入数据库，并将自动编号值存入，传入Orders数据模型对象中
        /// </summary>
        /// <param name="ordersMod">要进行添加到数据库的Orders数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_Orders ordersMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = ordersMod.UserID ?? (object)DBNull.Value},
                //将AMID存入
                new SqlParameter("@aMID",SqlDbType.Int,4){Value = ordersMod.AMID ?? (object)DBNull.Value},
                //将OrderNum存入
                new SqlParameter("@orderNum",SqlDbType.Char,14){Value = ordersMod.OrderNum ?? (object)DBNull.Value},
                //将OrderDate存入
                new SqlParameter("@orderDate",SqlDbType.DateTime,16){Value = ordersMod.OrderDate ?? (object)DBNull.Value},
                //将OrderState存入
                new SqlParameter("@orderState",SqlDbType.Int,4){Value = ordersMod.OrderState ?? (object)DBNull.Value},
                //将OrderMoney存入
                new SqlParameter("@orderMoney",SqlDbType.Decimal,14){Value = ordersMod.OrderMoney ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Insert Into Orders(UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney) OutPut Inserted.OrderID Values(@userID,@aMID,@orderNum,@orderDate,@orderState,@orderMoney);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成OrderID
                    ordersMod.OrderID = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个Orders数据模型对象
        /// </summary>
        /// <param name="orderID">OrderID</param>
        /// <returns>如果查找到此记录就返回Orders数据模型对象，否则返回null</returns>
        public Mod_Orders GetModel(int orderID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = orderID}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select Top 1 OrderID,UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney From Orders Where OrderID = @orderID;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个Orders数据模型对象
                    Mod_Orders ordersMod = new Mod_Orders();
                    //存储查询到的OrderID数据
                    ordersMod.OrderID = sqlReader.GetInt32(0);
                    //存储查询到的UserID数据
                    ordersMod.UserID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                    //存储查询到的AMID数据
                    ordersMod.AMID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                    //存储查询到的OrderNum数据
                    ordersMod.OrderNum = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                    //存储查询到的OrderDate数据
                    ordersMod.OrderDate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                    //存储查询到的OrderState数据
                    ordersMod.OrderState = sqlReader.IsDBNull(5) ? null : (int?)sqlReader.GetInt32(5);
                    //存储查询到的OrderMoney数据
                    ordersMod.OrderMoney = sqlReader.IsDBNull(6) ? null : (decimal?)sqlReader.GetDecimal(6);
                    //将Orders数据模型对象返回
                    return ordersMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="orderID">OrderID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int orderID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = orderID}
            };
            //执行一条按照OrderID删除记录语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery("Delete From Orders Where OrderID = @orderID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="orderID">OrderID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int orderID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = orderID}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Orders Where OrderID = @orderID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="ordersMod">Orders</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_Orders ordersMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = ordersMod.OrderID},
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = ordersMod.UserID ?? (object)DBNull.Value},
                //将AMID存入
                new SqlParameter("@aMID",SqlDbType.Int,4){Value = ordersMod.AMID ?? (object)DBNull.Value},
                //将OrderNum存入
                new SqlParameter("@orderNum",SqlDbType.Char,14){Value = ordersMod.OrderNum ?? (object)DBNull.Value},
                //将OrderDate存入
                new SqlParameter("@orderDate",SqlDbType.DateTime,16){Value = ordersMod.OrderDate ?? (object)DBNull.Value},
                //将OrderState存入
                new SqlParameter("@orderState",SqlDbType.Int,4){Value = ordersMod.OrderState ?? (object)DBNull.Value},
                //将OrderMoney存入
                new SqlParameter("@orderMoney",SqlDbType.Decimal,14){Value = ordersMod.OrderMoney ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return DBHelper.ExecuteNonQuery("Update Orders Set UserID = @userID,AMID = @aMID,OrderNum = @orderNum,OrderDate = @orderDate,OrderState = @orderState,OrderMoney = @orderMoney Where OrderID = @orderID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="ordersMod">验证的Orders数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_Orders ordersMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将OrderID存入
                new SqlParameter("@orderID",SqlDbType.Int,4){Value = ordersMod.OrderID},
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = ordersMod.UserID ?? (object)DBNull.Value},
                //将AMID存入
                new SqlParameter("@aMID",SqlDbType.Int,4){Value = ordersMod.AMID ?? (object)DBNull.Value},
                //将OrderNum存入
                new SqlParameter("@orderNum",SqlDbType.Char,14){Value = ordersMod.OrderNum ?? (object)DBNull.Value},
                //将OrderDate存入
                new SqlParameter("@orderDate",SqlDbType.DateTime,16){Value = ordersMod.OrderDate ?? (object)DBNull.Value},
                //将OrderState存入
                new SqlParameter("@orderState",SqlDbType.Int,4){Value = ordersMod.OrderState ?? (object)DBNull.Value},
                //将OrderMoney存入
                new SqlParameter("@orderMoney",SqlDbType.Decimal,14){Value = ordersMod.OrderMoney ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Orders Where OrderID = @orderID And UserID = @userID And AMID = @aMID And OrderNum = @orderNum And OrderDate = @orderDate And OrderState = @orderState And OrderMoney = @orderMoney;", sqlParameters) > 0;
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
                    ? "Select Count(*) From Orders;"
                    : "Select Count(*) From Orders Where " + where;
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
                    ? "Delete From Orders;"
                    : "Delete From Orders Where " + where;
            //执行删除语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_Orders> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<Mod_Orders> list = new List<Mod_Orders>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select OrderID,UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney From Orders;"
                    : "Select OrderID,UserID,AMID,OrderNum,OrderDate,OrderState,OrderMoney From Orders Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个Orders数据模型对象
                        Mod_Orders ordersMod = new Mod_Orders();
                        //存储查询到的OrderID数据
                        ordersMod.OrderID = sqlReader.GetInt32(0);
                        //存储查询到的UserID数据
                        ordersMod.UserID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的AMID数据
                        ordersMod.AMID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的OrderNum数据
                        ordersMod.OrderNum = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的OrderDate数据
                        ordersMod.OrderDate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //存储查询到的OrderState数据
                        ordersMod.OrderState = sqlReader.IsDBNull(5) ? null : (int?)sqlReader.GetInt32(5);
                        //存储查询到的OrderMoney数据
                        ordersMod.OrderMoney = sqlReader.IsDBNull(6) ? null : (decimal?)sqlReader.GetDecimal(6);
                        //将Orders数据模型对象存储到集合中
                        list.Add(ordersMod);
                    }
                }
            }
            //返回查找到的Orders对象的集合
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
                    ? "Select Count(*) From Orders;"
                    : "Select Count(*) From Orders Where " + where;
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
        /// <returns>查询到的Orders数据模型对象集合</returns>
        public List<Mod_Orders> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储Orders数据模型对象的集合
            List<Mod_Orders> list = new List<Mod_Orders>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From Orders) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From Orders Where " +
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
                        //创建一个Orders数据模型对象
                        Mod_Orders ordersMod = new Mod_Orders();
                        //存储查询到的OrderID数据
                        ordersMod.OrderID = sqlReader.GetInt32(0);
                        //存储查询到的UserID数据
                        ordersMod.UserID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的AMID数据
                        ordersMod.AMID = sqlReader.IsDBNull(2) ? null : (int?)sqlReader.GetInt32(2);
                        //存储查询到的OrderNum数据
                        ordersMod.OrderNum = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的OrderDate数据
                        ordersMod.OrderDate = sqlReader.IsDBNull(4) ? null : (DateTime?)sqlReader.GetDateTime(4);
                        //存储查询到的OrderState数据
                        ordersMod.OrderState = sqlReader.IsDBNull(5) ? null : (int?)sqlReader.GetInt32(5);
                        //存储查询到的OrderMoney数据
                        ordersMod.OrderMoney = sqlReader.IsDBNull(6) ? null : (decimal?)sqlReader.GetDecimal(6);
                        //将Orders数据模型对象存储到集合中
                        list.Add(ordersMod);
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
        /// <returns>查询到的Orders数据模型对象集合</returns>
        public List<Mod_Orders> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的Orders数据模型对象集合</returns>
        public List<Mod_Orders> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
