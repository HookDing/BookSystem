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
    /// Books数据访问对象
    /// </summary>
    public partial class Dal_Books
    {
        /// <summary>
        /// 实例化Books数据访问对象
        /// </summary>
        public Dal_Books()
        {

        }

        //public int GetCount()
        //{
        //    int count = 0;
        //    using (SqlDataReader sqlReader = DBHelper.ExecuteReader("select Count(*) from Books"))
        //    {
        //        //判断是否查询到了数据
        //        if (sqlReader.HasRows)
        //        {
        //            count = sqlReader.GetInt32(0); 
        //                //int.Parse(sqlReader.ToString());
        //        }
        //    }
        //    return count;
        //}
        public static List<View_Books> GetTablePage(proc_page proc)
        {
            //创建存储查找到的Books表中信息集合
            List<View_Books> list = new List<View_Books>();
            SqlParameter p = new SqlParameter();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteProcPage(proc, p))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        View_Books info = new View_Books();
                        info.BLName = (string)sqlReader["BLName"];
                        info.BLID = (System.Int32)sqlReader["BLID"];
                        info.BSName = (string)sqlReader["BSName"];
                        info.BSID = (System.Int32)sqlReader["BSID"];
                        info.BookID = (System.Int32)sqlReader["BookID"];
                        info.BookTitle = (System.String)sqlReader["BookTitle"];
                        info.BookAuthor = (System.String)sqlReader["BookAuthor"];
                        info.BookPublish = (System.String)sqlReader["BookPublish"];
                        info.ISBN = (System.String)sqlReader["ISBN"];
                        info.BookCount = (System.Int32)sqlReader["BookCount"];
                        info.BookMoney = (System.Decimal)sqlReader["BookMoney"];
                        info.BookPrice = (System.Decimal)sqlReader["BookPrice"];
                        info.BookDesc = (System.String)sqlReader["BookDesc"];
                        info.BookAuthorDesc = (System.String)sqlReader["BookAuthorDesc"];
                        info.BookComm = (System.String)sqlReader["BookComm"];
                        info.BookContent = (System.String)sqlReader["BookContent"];
                        info.BookSale = (System.Int32)sqlReader["BookSale"];
                        info.BookDeport = (System.Int32)sqlReader["BookDeport"];
                        info.BookIsBuy = (System.Boolean)sqlReader["BookIsBuy"];
                        info.BookIsHot = (System.Boolean)sqlReader["BookIsHot"];
                        list.Add(info);
                    }
                }
            }
            proc.DataCount = (int)p.Value > 1 ? (int)p.Value : 1;
            //返回查询到的信息集合
            return list;

        }
        /// <summary>
        /// 查询得到Books表中所有信息
        /// </summary>
        /// <returns>查询到的所有Books数据模型对象集合</returns>
        public List<Mod_Books> GetAllModel()
        {
            //创建存储查找到的Books表中信息集合
            List<Mod_Books> list = new List<Mod_Books>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select BookID,BSID,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot,BookIsDelete,BookBuyDate,BookHotDate From Books;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个Books数据模型对象
                        Mod_Books booksMod = new Mod_Books();
                        //存储查询到的BookID数据
                        booksMod.BookID = sqlReader.GetInt32(0);
                        //存储查询到的BSID数据
                        booksMod.BSID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BookTitle数据
                        booksMod.BookTitle = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的BookAuthor数据
                        booksMod.BookAuthor = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的BookPublish数据
                        booksMod.BookPublish = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的ISBN数据
                        booksMod.ISBN = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //存储查询到的BookCount数据
                        booksMod.BookCount = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                        //存储查询到的BookMoney数据
                        booksMod.BookMoney = sqlReader.IsDBNull(7) ? null : (decimal?)sqlReader.GetDecimal(7);
                        //存储查询到的BookPrice数据
                        booksMod.BookPrice = sqlReader.IsDBNull(8) ? null : (decimal?)sqlReader.GetDecimal(8);
                        //存储查询到的BookDesc数据
                        booksMod.BookDesc = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                        //存储查询到的BookAuthorDesc数据
                        booksMod.BookAuthorDesc = sqlReader.IsDBNull(10) ? null : (string)sqlReader.GetString(10);
                        //存储查询到的BookComm数据
                        booksMod.BookComm = sqlReader.IsDBNull(11) ? null : (string)sqlReader.GetString(11);
                        //存储查询到的BookContent数据
                        booksMod.BookContent = sqlReader.IsDBNull(12) ? null : (string)sqlReader.GetString(12);
                        //存储查询到的BookSale数据
                        booksMod.BookSale = sqlReader.IsDBNull(13) ? null : (int?)sqlReader.GetInt32(13);
                        //存储查询到的BookDeport数据
                        booksMod.BookDeport = sqlReader.IsDBNull(14) ? null : (int?)sqlReader.GetInt32(14);
                        //存储查询到的BookIsBuy数据
                        booksMod.BookIsBuy = sqlReader.IsDBNull(15) ? null : (bool?)sqlReader.GetBoolean(15);
                        //存储查询到的BookIsHot数据
                        booksMod.BookIsHot = sqlReader.IsDBNull(16) ? null : (bool?)sqlReader.GetBoolean(16);
                        //存储查询到的BookIsDelete数据
                        booksMod.BookIsDelete = sqlReader.IsDBNull(17) ? null : (bool?)sqlReader.GetBoolean(17);
                        //存储查询到的BookBuyDate数据
                        booksMod.BookBuyDate = sqlReader.IsDBNull(18) ? null : (DateTime?)sqlReader.GetDateTime(18);
                        //存储查询到的BookHotDate数据
                        booksMod.BookHotDate = sqlReader.IsDBNull(19) ? null : (DateTime?)sqlReader.GetDateTime(19);
                        //将Books数据模型对象存储到集合中
                        list.Add(booksMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的Books数据模型对象数据存入数据库，并将自动编号值存入，传入Books数据模型对象中
        /// </summary>
        /// <param name="booksMod">要进行添加到数据库的Books数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_Books booksMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BSID存入
                new SqlParameter("@bSID",SqlDbType.Int,4){Value = booksMod.BSID ?? (object)DBNull.Value},
                //将BookTitle存入
                new SqlParameter("@bookTitle",SqlDbType.NVarChar,2000){Value = booksMod.BookTitle ?? (object)DBNull.Value},
                //将BookAuthor存入
                new SqlParameter("@bookAuthor",SqlDbType.NVarChar,2000){Value = booksMod.BookAuthor ?? (object)DBNull.Value},
                //将BookPublish存入
                new SqlParameter("@bookPublish",SqlDbType.NVarChar,200){Value = booksMod.BookPublish ?? (object)DBNull.Value},
                //将ISBN存入
                new SqlParameter("@iSBN",SqlDbType.VarChar,100){Value = booksMod.ISBN ?? (object)DBNull.Value},
                //将BookCount存入
                new SqlParameter("@bookCount",SqlDbType.Int,4){Value = booksMod.BookCount ?? (object)DBNull.Value},
                //将BookMoney存入
                new SqlParameter("@bookMoney",SqlDbType.Decimal,10){Value = booksMod.BookMoney ?? (object)DBNull.Value},
                //将BookPrice存入
                new SqlParameter("@bookPrice",SqlDbType.Decimal,10){Value = booksMod.BookPrice ?? (object)DBNull.Value},
                //将BookDesc存入
                new SqlParameter("@bookDesc",SqlDbType.Text,2147483647){Value = booksMod.BookDesc ?? (object)DBNull.Value},
                //将BookAuthorDesc存入
                new SqlParameter("@bookAuthorDesc",SqlDbType.Text,2147483647){Value = booksMod.BookAuthorDesc ?? (object)DBNull.Value},
                //将BookComm存入
                new SqlParameter("@bookComm",SqlDbType.Text,2147483647){Value = booksMod.BookComm ?? (object)DBNull.Value},
                //将BookContent存入
                new SqlParameter("@bookContent",SqlDbType.Text,2147483647){Value = booksMod.BookContent ?? (object)DBNull.Value},
                //将BookSale存入
                new SqlParameter("@bookSale",SqlDbType.Int,4){Value = booksMod.BookSale ?? (object)DBNull.Value},
                //将BookDeport存入
                new SqlParameter("@bookDeport",SqlDbType.Int,4){Value = booksMod.BookDeport ?? (object)DBNull.Value},
                //将BookIsBuy存入
                new SqlParameter("@bookIsBuy",SqlDbType.Bit,1){Value = booksMod.BookIsBuy ?? (object)DBNull.Value},
                //将BookIsHot存入
                new SqlParameter("@bookIsHot",SqlDbType.Bit,1){Value = booksMod.BookIsHot ?? (object)DBNull.Value},
                //将BookIsDelete存入
                new SqlParameter("@bookIsDelete",SqlDbType.Bit,1){Value = booksMod.BookIsDelete ?? (object)DBNull.Value},
                //将BookBuyDate存入
                new SqlParameter("@bookBuyDate",SqlDbType.DateTime,16){Value = booksMod.BookBuyDate ?? (object)DBNull.Value},
                //将BookHotDate存入
                new SqlParameter("@bookHotDate",SqlDbType.DateTime,16){Value = booksMod.BookHotDate ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Insert Into Books(BSID,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot,BookIsDelete,BookBuyDate,BookHotDate) OutPut Inserted.BookID Values(@bSID,@bookTitle,@bookAuthor,@bookPublish,@iSBN,@bookCount,@bookMoney,@bookPrice,@bookDesc,@bookAuthorDesc,@bookComm,@bookContent,@bookSale,@bookDeport,@bookIsBuy,@bookIsHot,@bookIsDelete,@bookBuyDate,@bookHotDate);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成BookID
                    booksMod.BookID = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个Books数据模型对象
        /// </summary>
        /// <param name="bookID">BookID</param>
        /// <returns>如果查找到此记录就返回Books数据模型对象，否则返回null</returns>
        public View_Books GetModel(int bookID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = bookID}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader("Select Top 1 BookID,Books.BSID,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot,BookIsDelete,BookBuyDate,BookHotDate,BSCategory.BLID From Books ,BLCategory,BSCategory Where Books.BSID = BSCategory.BSID and BookID = @bookID;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个Books数据模型对象
                    View_Books booksMod = new View_Books();
                    //存储查询到的BookID数据
                    booksMod.BookID = sqlReader.GetInt32(0);
                    //存储查询到的BSID数据
                    booksMod.BSID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                    //存储查询到的BookTitle数据
                    booksMod.BookTitle = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                    //存储查询到的BookAuthor数据
                    booksMod.BookAuthor = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                    //存储查询到的BookPublish数据
                    booksMod.BookPublish = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                    //存储查询到的ISBN数据
                    booksMod.ISBN = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                    //存储查询到的BookCount数据
                    booksMod.BookCount = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                    //存储查询到的BookMoney数据
                    booksMod.BookMoney = sqlReader.IsDBNull(7) ? null : (decimal?)sqlReader.GetDecimal(7);
                    //存储查询到的BookPrice数据
                    booksMod.BookPrice = sqlReader.IsDBNull(8) ? null : (decimal?)sqlReader.GetDecimal(8);
                    //存储查询到的BookDesc数据
                    booksMod.BookDesc = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                    //存储查询到的BookAuthorDesc数据
                    booksMod.BookAuthorDesc = sqlReader.IsDBNull(10) ? null : (string)sqlReader.GetString(10);
                    //存储查询到的BookComm数据
                    booksMod.BookComm = sqlReader.IsDBNull(11) ? null : (string)sqlReader.GetString(11);
                    //存储查询到的BookContent数据
                    booksMod.BookContent = sqlReader.IsDBNull(12) ? null : (string)sqlReader.GetString(12);
                    //存储查询到的BookSale数据
                    booksMod.BookSale = sqlReader.IsDBNull(13) ? null : (int?)sqlReader.GetInt32(13);
                    //存储查询到的BookDeport数据
                    booksMod.BookDeport = sqlReader.IsDBNull(14) ? null : (int?)sqlReader.GetInt32(14);
                    //存储查询到的BookIsBuy数据
                    booksMod.BookIsBuy = sqlReader.IsDBNull(15) ? null : (bool?)sqlReader.GetBoolean(15);
                    //存储查询到的BookIsHot数据
                    booksMod.BookIsHot = sqlReader.IsDBNull(16) ? null : (bool?)sqlReader.GetBoolean(16);
                    //存储查询到的BookIsDelete数据
                    booksMod.BookIsDelete = sqlReader.IsDBNull(17) ? null : (bool?)sqlReader.GetBoolean(17);
                    //存储查询到的BookBuyDate数据
                    booksMod.BookBuyDate = sqlReader.IsDBNull(18) ? null : (DateTime?)sqlReader.GetDateTime(18);
                    //存储查询到的BookHotDate数据
                    booksMod.BookHotDate = sqlReader.IsDBNull(19) ? null : (DateTime?)sqlReader.GetDateTime(19);
                    //存储查询到的BLID数据
                    booksMod.BLID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(20);
                    //将Books数据模型对象返回
                    return booksMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="bookID">BookID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int bookID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = bookID}
            };
            //执行一条按照BookID删除记录语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery("Delete From Books Where BookID = @bookID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="bookID">BookID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int bookID)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = bookID}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Books Where BookID = @bookID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="booksMod">Books</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_Books booksMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = booksMod.BookID},
                //将BSID存入
                new SqlParameter("@bSID",SqlDbType.Int,4){Value = booksMod.BSID ?? (object)DBNull.Value},
                //将BookTitle存入
                new SqlParameter("@bookTitle",SqlDbType.NVarChar,2000){Value = booksMod.BookTitle ?? (object)DBNull.Value},
                //将BookAuthor存入
                new SqlParameter("@bookAuthor",SqlDbType.NVarChar,2000){Value = booksMod.BookAuthor ?? (object)DBNull.Value},
                //将BookPublish存入
                new SqlParameter("@bookPublish",SqlDbType.NVarChar,200){Value = booksMod.BookPublish ?? (object)DBNull.Value},
                //将ISBN存入
                new SqlParameter("@iSBN",SqlDbType.VarChar,100){Value = booksMod.ISBN ?? (object)DBNull.Value},
                //将BookCount存入
                new SqlParameter("@bookCount",SqlDbType.Int,4){Value = booksMod.BookCount ?? (object)DBNull.Value},
                //将BookMoney存入
                new SqlParameter("@bookMoney",SqlDbType.Decimal,10){Value = booksMod.BookMoney ?? (object)DBNull.Value},
                //将BookPrice存入
                new SqlParameter("@bookPrice",SqlDbType.Decimal,10){Value = booksMod.BookPrice ?? (object)DBNull.Value},
                //将BookDesc存入
                new SqlParameter("@bookDesc",SqlDbType.Text,2147483647){Value = booksMod.BookDesc ?? (object)DBNull.Value},
                //将BookAuthorDesc存入
                new SqlParameter("@bookAuthorDesc",SqlDbType.Text,2147483647){Value = booksMod.BookAuthorDesc ?? (object)DBNull.Value},
                //将BookComm存入
                new SqlParameter("@bookComm",SqlDbType.Text,2147483647){Value = booksMod.BookComm ?? (object)DBNull.Value},
                //将BookContent存入
                new SqlParameter("@bookContent",SqlDbType.Text,2147483647){Value = booksMod.BookContent ?? (object)DBNull.Value},
                //将BookSale存入
                new SqlParameter("@bookSale",SqlDbType.Int,4){Value = booksMod.BookSale ?? (object)DBNull.Value},
                //将BookDeport存入
                new SqlParameter("@bookDeport",SqlDbType.Int,4){Value = booksMod.BookDeport ?? (object)DBNull.Value},
                //将BookIsBuy存入
                new SqlParameter("@bookIsBuy",SqlDbType.Bit,1){Value = booksMod.BookIsBuy ?? (object)DBNull.Value},
                //将BookIsHot存入
                new SqlParameter("@bookIsHot",SqlDbType.Bit,1){Value = booksMod.BookIsHot ?? (object)DBNull.Value},
                //将BookIsDelete存入
                new SqlParameter("@bookIsDelete",SqlDbType.Bit,1){Value = booksMod.BookIsDelete ?? (object)DBNull.Value},
                //将BookBuyDate存入
                new SqlParameter("@bookBuyDate",SqlDbType.DateTime,16){Value = booksMod.BookBuyDate ?? (object)DBNull.Value},
                //将BookHotDate存入
                new SqlParameter("@bookHotDate",SqlDbType.DateTime,16){Value = booksMod.BookHotDate ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return DBHelper.ExecuteNonQuery("Update Books Set BSID = @bSID,BookTitle = @bookTitle,BookAuthor = @bookAuthor,BookPublish = @bookPublish,ISBN = @iSBN,BookCount = @bookCount,BookMoney = @bookMoney,BookPrice = @bookPrice,BookDesc = @bookDesc,BookAuthorDesc = @bookAuthorDesc,BookComm = @bookComm,BookContent = @bookContent,BookSale = @bookSale,BookDeport = @bookDeport,BookIsBuy = @bookIsBuy,BookIsHot = @bookIsHot,BookIsDelete = @bookIsDelete,BookBuyDate = @bookBuyDate,BookHotDate = @bookHotDate Where BookID = @bookID;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="booksMod">验证的Books数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_Books booksMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将BookID存入
                new SqlParameter("@bookID",SqlDbType.Int,4){Value = booksMod.BookID},
                //将BSID存入
                new SqlParameter("@bSID",SqlDbType.Int,4){Value = booksMod.BSID ?? (object)DBNull.Value},
                //将BookTitle存入
                new SqlParameter("@bookTitle",SqlDbType.NVarChar,2000){Value = booksMod.BookTitle ?? (object)DBNull.Value},
                //将BookAuthor存入
                new SqlParameter("@bookAuthor",SqlDbType.NVarChar,2000){Value = booksMod.BookAuthor ?? (object)DBNull.Value},
                //将BookPublish存入
                new SqlParameter("@bookPublish",SqlDbType.NVarChar,200){Value = booksMod.BookPublish ?? (object)DBNull.Value},
                //将ISBN存入
                new SqlParameter("@iSBN",SqlDbType.VarChar,100){Value = booksMod.ISBN ?? (object)DBNull.Value},
                //将BookCount存入
                new SqlParameter("@bookCount",SqlDbType.Int,4){Value = booksMod.BookCount ?? (object)DBNull.Value},
                //将BookMoney存入
                new SqlParameter("@bookMoney",SqlDbType.Decimal,10){Value = booksMod.BookMoney ?? (object)DBNull.Value},
                //将BookPrice存入
                new SqlParameter("@bookPrice",SqlDbType.Decimal,10){Value = booksMod.BookPrice ?? (object)DBNull.Value},
                //将BookDesc存入
                new SqlParameter("@bookDesc",SqlDbType.Text,2147483647){Value = booksMod.BookDesc ?? (object)DBNull.Value},
                //将BookAuthorDesc存入
                new SqlParameter("@bookAuthorDesc",SqlDbType.Text,2147483647){Value = booksMod.BookAuthorDesc ?? (object)DBNull.Value},
                //将BookComm存入
                new SqlParameter("@bookComm",SqlDbType.Text,2147483647){Value = booksMod.BookComm ?? (object)DBNull.Value},
                //将BookContent存入
                new SqlParameter("@bookContent",SqlDbType.Text,2147483647){Value = booksMod.BookContent ?? (object)DBNull.Value},
                //将BookSale存入
                new SqlParameter("@bookSale",SqlDbType.Int,4){Value = booksMod.BookSale ?? (object)DBNull.Value},
                //将BookDeport存入
                new SqlParameter("@bookDeport",SqlDbType.Int,4){Value = booksMod.BookDeport ?? (object)DBNull.Value},
                //将BookIsBuy存入
                new SqlParameter("@bookIsBuy",SqlDbType.Bit,1){Value = booksMod.BookIsBuy ?? (object)DBNull.Value},
                //将BookIsHot存入
                new SqlParameter("@bookIsHot",SqlDbType.Bit,1){Value = booksMod.BookIsHot ?? (object)DBNull.Value},
                //将BookIsDelete存入
                new SqlParameter("@bookIsDelete",SqlDbType.Bit,1){Value = booksMod.BookIsDelete ?? (object)DBNull.Value},
                //将BookBuyDate存入
                new SqlParameter("@bookBuyDate",SqlDbType.DateTime,16){Value = booksMod.BookBuyDate ?? (object)DBNull.Value},
                //将BookHotDate存入
                new SqlParameter("@bookHotDate",SqlDbType.DateTime,16){Value = booksMod.BookHotDate ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)DBHelper.ExecuteScalar("Select Count(*) From Books Where BookID = @bookID And BSID = @bSID And BookTitle = @bookTitle And BookAuthor = @bookAuthor And BookPublish = @bookPublish And ISBN = @iSBN And BookCount = @bookCount And BookMoney = @bookMoney And BookPrice = @bookPrice And BookDesc = @bookDesc And BookAuthorDesc = @bookAuthorDesc And BookComm = @bookComm And BookContent = @bookContent And BookSale = @bookSale And BookDeport = @bookDeport And BookIsBuy = @bookIsBuy And BookIsHot = @bookIsHot And BookIsDelete = @bookIsDelete And BookBuyDate = @bookBuyDate And BookHotDate = @bookHotDate;", sqlParameters) > 0;
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
                    ? "Select Count(*) From Books;"
                    : "Select Count(*) From Books Where " + where;
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
                    ? "Delete From Books;"
                    : "Delete From Books Where " + where;
            //执行删除语句，并返回是否删除成功
            return DBHelper.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_Books> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<Mod_Books> list = new List<Mod_Books>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select BookID,BSID,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot,BookIsDelete,BookBuyDate,BookHotDate From Books;"
                    : "Select BookID,BSID,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot,BookIsDelete,BookBuyDate,BookHotDate From Books Where" + where;
            //执行查找语句
            using (SqlDataReader sqlReader = DBHelper.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个Books数据模型对象
                        Mod_Books booksMod = new Mod_Books();
                        //存储查询到的BookID数据
                        booksMod.BookID = sqlReader.GetInt32(0);
                        //存储查询到的BSID数据
                        booksMod.BSID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BookTitle数据
                        booksMod.BookTitle = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的BookAuthor数据
                        booksMod.BookAuthor = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的BookPublish数据
                        booksMod.BookPublish = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的ISBN数据
                        booksMod.ISBN = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //存储查询到的BookCount数据
                        booksMod.BookCount = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                        //存储查询到的BookMoney数据
                        booksMod.BookMoney = sqlReader.IsDBNull(7) ? null : (decimal?)sqlReader.GetDecimal(7);
                        //存储查询到的BookPrice数据
                        booksMod.BookPrice = sqlReader.IsDBNull(8) ? null : (decimal?)sqlReader.GetDecimal(8);
                        //存储查询到的BookDesc数据
                        booksMod.BookDesc = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                        //存储查询到的BookAuthorDesc数据
                        booksMod.BookAuthorDesc = sqlReader.IsDBNull(10) ? null : (string)sqlReader.GetString(10);
                        //存储查询到的BookComm数据
                        booksMod.BookComm = sqlReader.IsDBNull(11) ? null : (string)sqlReader.GetString(11);
                        //存储查询到的BookContent数据
                        booksMod.BookContent = sqlReader.IsDBNull(12) ? null : (string)sqlReader.GetString(12);
                        //存储查询到的BookSale数据
                        booksMod.BookSale = sqlReader.IsDBNull(13) ? null : (int?)sqlReader.GetInt32(13);
                        //存储查询到的BookDeport数据
                        booksMod.BookDeport = sqlReader.IsDBNull(14) ? null : (int?)sqlReader.GetInt32(14);
                        //存储查询到的BookIsBuy数据
                        booksMod.BookIsBuy = sqlReader.IsDBNull(15) ? null : (bool?)sqlReader.GetBoolean(15);
                        //存储查询到的BookIsHot数据
                        booksMod.BookIsHot = sqlReader.IsDBNull(16) ? null : (bool?)sqlReader.GetBoolean(16);
                        //存储查询到的BookIsDelete数据
                        booksMod.BookIsDelete = sqlReader.IsDBNull(17) ? null : (bool?)sqlReader.GetBoolean(17);
                        //存储查询到的BookBuyDate数据
                        booksMod.BookBuyDate = sqlReader.IsDBNull(18) ? null : (DateTime?)sqlReader.GetDateTime(18);
                        //存储查询到的BookHotDate数据
                        booksMod.BookHotDate = sqlReader.IsDBNull(19) ? null : (DateTime?)sqlReader.GetDateTime(19);
                        //将Books数据模型对象存储到集合中
                        list.Add(booksMod);
                    }
                }
            }
            //返回查找到的Books对象的集合
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
                    ? "Select Count(*) From Books;"
                    : "Select Count(*) From Books Where " + where;
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
        /// <returns>查询到的Books数据模型对象集合</returns>
        public List<Mod_Books> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储Books数据模型对象的集合
            List<Mod_Books> list = new List<Mod_Books>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From Books) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From Books Where " +
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
                        //创建一个Books数据模型对象
                        Mod_Books booksMod = new Mod_Books();
                        //存储查询到的BookID数据
                        booksMod.BookID = sqlReader.GetInt32(0);
                        //存储查询到的BSID数据
                        booksMod.BSID = sqlReader.IsDBNull(1) ? null : (int?)sqlReader.GetInt32(1);
                        //存储查询到的BookTitle数据
                        booksMod.BookTitle = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的BookAuthor数据
                        booksMod.BookAuthor = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的BookPublish数据
                        booksMod.BookPublish = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的ISBN数据
                        booksMod.ISBN = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //存储查询到的BookCount数据
                        booksMod.BookCount = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                        //存储查询到的BookMoney数据
                        booksMod.BookMoney = sqlReader.IsDBNull(7) ? null : (decimal?)sqlReader.GetDecimal(7);
                        //存储查询到的BookPrice数据
                        booksMod.BookPrice = sqlReader.IsDBNull(8) ? null : (decimal?)sqlReader.GetDecimal(8);
                        //存储查询到的BookDesc数据
                        booksMod.BookDesc = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                        //存储查询到的BookAuthorDesc数据
                        booksMod.BookAuthorDesc = sqlReader.IsDBNull(10) ? null : (string)sqlReader.GetString(10);
                        //存储查询到的BookComm数据
                        booksMod.BookComm = sqlReader.IsDBNull(11) ? null : (string)sqlReader.GetString(11);
                        //存储查询到的BookContent数据
                        booksMod.BookContent = sqlReader.IsDBNull(12) ? null : (string)sqlReader.GetString(12);
                        //存储查询到的BookSale数据
                        booksMod.BookSale = sqlReader.IsDBNull(13) ? null : (int?)sqlReader.GetInt32(13);
                        //存储查询到的BookDeport数据
                        booksMod.BookDeport = sqlReader.IsDBNull(14) ? null : (int?)sqlReader.GetInt32(14);
                        //存储查询到的BookIsBuy数据
                        booksMod.BookIsBuy = sqlReader.IsDBNull(15) ? null : (bool?)sqlReader.GetBoolean(15);
                        //存储查询到的BookIsHot数据
                        booksMod.BookIsHot = sqlReader.IsDBNull(16) ? null : (bool?)sqlReader.GetBoolean(16);
                        //存储查询到的BookIsDelete数据
                        booksMod.BookIsDelete = sqlReader.IsDBNull(17) ? null : (bool?)sqlReader.GetBoolean(17);
                        //存储查询到的BookBuyDate数据
                        booksMod.BookBuyDate = sqlReader.IsDBNull(18) ? null : (DateTime?)sqlReader.GetDateTime(18);
                        //存储查询到的BookHotDate数据
                        booksMod.BookHotDate = sqlReader.IsDBNull(19) ? null : (DateTime?)sqlReader.GetDateTime(19);
                        //将Books数据模型对象存储到集合中
                        list.Add(booksMod);
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
        /// <returns>查询到的Books数据模型对象集合</returns>
        public List<Mod_Books> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的Books数据模型对象集合</returns>
        public List<Mod_Books> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
