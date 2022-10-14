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
    /// Users数据访问对象
    /// </summary>
    public partial class Dal_Users
    {
        /// <summary>
        /// 实例化Users数据访问对象
        /// </summary>
        public Dal_Users()
        {
            
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="adminsMod">验证的Admins帐号与密码</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Login(Mod_Users Mod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将AdminUser存入
                new SqlParameter("@UserName",SqlDbType.NVarChar,100){Value = Mod.UserName ?? (object)DBNull.Value},
                //将AdminPwd存入
                new SqlParameter("@UserPwd",SqlDbType.Char,47){Value = Mod.UserPwd ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Users Where UserName = @UserName And UserPwd = @UserPwd;", sqlParameters) > 0;
        }
        /// <summary>
        /// 查询得到Users表中所有信息
        /// </summary>
        /// <returns>查询到的所有Users数据模型对象集合</returns>
        public List<Mod_Users> GetAllModel()
        {
            //创建存储查找到的Users表中信息集合
            List<Mod_Users> list = new List<Mod_Users>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select UserID,UserName,UserPwd,UserEmail,UserSex,UserNick From Users;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个Users数据模型对象
                        Mod_Users usersMod = new Mod_Users();
                        //存储查询到的UserID数据
                        usersMod.UserID = sqlReader.GetInt32(0);
                        //存储查询到的UserName数据
                        usersMod.UserName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //存储查询到的UserPwd数据
                        usersMod.UserPwd = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的UserEmail数据
                        usersMod.UserEmail = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的UserSex数据
                        usersMod.UserSex = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的UserNick数据
                        usersMod.UserNick = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //将Users数据模型对象存储到集合中
                        list.Add(usersMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的Users数据模型对象数据存入数据库，并将自动编号值存入，传入Users数据模型对象中
        /// </summary>
        /// <param name="usersMod">要进行添加到数据库的Users数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_Users usersMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将UserName存入
                new SqlParameter("@userName",SqlDbType.NVarChar,100){Value = usersMod.UserName ?? (object)DBNull.Value},
                //将UserPwd存入
                new SqlParameter("@userPwd",SqlDbType.Char,47){Value = usersMod.UserPwd ?? (object)DBNull.Value},
                //将UserEmail存入
                new SqlParameter("@userEmail",SqlDbType.VarChar,50){Value = usersMod.UserEmail ?? (object)DBNull.Value},
                //将UserSex存入
                new SqlParameter("@userSex",SqlDbType.VarChar,10){Value = usersMod.UserSex ?? (object)DBNull.Value},
                //将UserNick存入
                new SqlParameter("@userNick",SqlDbType.NVarChar,100){Value = usersMod.UserNick ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Insert Into Users(UserName,UserPwd,UserEmail,UserSex,UserNick) OutPut Inserted.UserID Values(@userName,@userPwd,@userEmail,@userSex,@userNick);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成UserID
                    usersMod.UserID = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个Users数据模型对象
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns>如果查找到此记录就返回Users数据模型对象，否则返回null</returns>
        public Mod_Users GetModel(int userID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = userID}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select Top 1 UserID,UserName,UserPwd,UserEmail,UserSex,UserNick From Users Where UserID = @userID;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个Users数据模型对象
                    Mod_Users usersMod = new Mod_Users();
                    //存储查询到的UserID数据
                    usersMod.UserID = sqlReader.GetInt32(0);
                    //存储查询到的UserName数据
                    usersMod.UserName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                    //存储查询到的UserPwd数据
                    usersMod.UserPwd = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                    //存储查询到的UserEmail数据
                    usersMod.UserEmail = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                    //存储查询到的UserSex数据
                    usersMod.UserSex = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                    //存储查询到的UserNick数据
                    usersMod.UserNick = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                    //将Users数据模型对象返回
                    return usersMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int userID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = userID}
            };
            //执行一条按照UserID删除记录语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery("Delete From Users Where UserID = @userID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int userID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = userID}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Users Where UserID = @userID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="usersMod">Users</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_Users usersMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = usersMod.UserID},
                //将UserName存入
                new SqlParameter("@userName",SqlDbType.NVarChar,100){Value = usersMod.UserName ?? (object)DBNull.Value},
                //将UserPwd存入
                new SqlParameter("@userPwd",SqlDbType.Char,47){Value = usersMod.UserPwd ?? (object)DBNull.Value},
                //将UserEmail存入
                new SqlParameter("@userEmail",SqlDbType.VarChar,50){Value = usersMod.UserEmail ?? (object)DBNull.Value},
                //将UserSex存入
                new SqlParameter("@userSex",SqlDbType.VarChar,10){Value = usersMod.UserSex ?? (object)DBNull.Value},
                //将UserNick存入
                new SqlParameter("@userNick",SqlDbType.NVarChar,100){Value = usersMod.UserNick ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return DBHelper.ExecuteNonQuery("Update Users Set UserName = @userName,UserPwd = @userPwd,UserEmail = @userEmail,UserSex = @userSex,UserNick = @userNick Where UserID = @userID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="usersMod">验证的Users数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_Users usersMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将UserID存入
                new SqlParameter("@userID",SqlDbType.Int,4){Value = usersMod.UserID},
                //将UserName存入
                new SqlParameter("@userName",SqlDbType.NVarChar,100){Value = usersMod.UserName ?? (object)DBNull.Value},
                //将UserPwd存入
                new SqlParameter("@userPwd",SqlDbType.Char,47){Value = usersMod.UserPwd ?? (object)DBNull.Value},
                //将UserEmail存入
                new SqlParameter("@userEmail",SqlDbType.VarChar,50){Value = usersMod.UserEmail ?? (object)DBNull.Value},
                //将UserSex存入
                new SqlParameter("@userSex",SqlDbType.VarChar,10){Value = usersMod.UserSex ?? (object)DBNull.Value},
                //将UserNick存入
                new SqlParameter("@userNick",SqlDbType.NVarChar,100){Value = usersMod.UserNick ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Users Where UserID = @userID And UserName = @userName And UserPwd = @userPwd And UserEmail = @userEmail And UserSex = @userSex And UserNick = @userNick;", sqlParameters) > 0;
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
                    ? "Select Count(*) From Users;"
                    : "Select Count(*) From Users Where " + where;
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
                    ? "Delete From Users;"
                    : "Delete From Users Where " + where;
            //执行删除语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_Users> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<Mod_Users> list = new List<Mod_Users>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select UserID,UserName,UserPwd,UserEmail,UserSex,UserNick From Users;"
                    : "Select UserID,UserName,UserPwd,UserEmail,UserSex,UserNick From Users Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个Users数据模型对象
                        Mod_Users usersMod = new Mod_Users();
                        //存储查询到的UserID数据
                        usersMod.UserID = sqlReader.GetInt32(0);
                        //存储查询到的UserName数据
                        usersMod.UserName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //存储查询到的UserPwd数据
                        usersMod.UserPwd = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的UserEmail数据
                        usersMod.UserEmail = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的UserSex数据
                        usersMod.UserSex = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的UserNick数据
                        usersMod.UserNick = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //将Users数据模型对象存储到集合中
                        list.Add(usersMod);
                    }
                }
            }
            //返回查找到的Users对象的集合
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
                    ? "Select Count(*) From Users;"
                    : "Select Count(*) From Users Where " + where;
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
        /// <returns>查询到的Users数据模型对象集合</returns>
        public List<Mod_Users> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储Users数据模型对象的集合
            List<Mod_Users> list = new List<Mod_Users>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From Users) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From Users Where " +
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
                        //创建一个Users数据模型对象
                        Mod_Users usersMod = new Mod_Users();
                        //存储查询到的UserID数据
                        usersMod.UserID = sqlReader.GetInt32(0);
                        //存储查询到的UserName数据
                        usersMod.UserName = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //存储查询到的UserPwd数据
                        usersMod.UserPwd = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的UserEmail数据
                        usersMod.UserEmail = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的UserSex数据
                        usersMod.UserSex = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的UserNick数据
                        usersMod.UserNick = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //将Users数据模型对象存储到集合中
                        list.Add(usersMod);
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
        /// <returns>查询到的Users数据模型对象集合</returns>
        public List<Mod_Users> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的Users数据模型对象集合</returns>
        public List<Mod_Users> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
