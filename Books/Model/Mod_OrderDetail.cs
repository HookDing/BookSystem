using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// OrderDetail数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_OrderDetail
    {
        /// <summary>
        /// 初始化OrderDetail数据模型对象
        /// </summary>
        public Mod_OrderDetail()
        {
            
        }
        /// <summary>
        /// 初始化OrderDetail数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="oDID">ODID</param>
        public Mod_OrderDetail(int oDID)
        {
            //给ODID字段赋值
            this.ODID = oDID;
        }
        /// <summary>
        /// 初始化OrderDetail数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="oDID">ODID</param>
        /// <param name="orderID">OrderID</param>
        /// <param name="bookID">BookID</param>
        /// <param name="oDPrice">ODPrice</param>
        /// <param name="oDCount">ODCount</param>
        /// <param name="oDMoney">ODMoney</param>
        public Mod_OrderDetail(int oDID,int? orderID,int? bookID,decimal? oDPrice,int? oDCount,decimal? oDMoney)
        {
            //给ODID字段赋值
            this.ODID = oDID;
            //给OrderID字段赋值
            this.OrderID = orderID;
            //给BookID字段赋值
            this.BookID = bookID;
            //给ODPrice字段赋值
            this.ODPrice = oDPrice;
            //给ODCount字段赋值
            this.ODCount = oDCount;
            //给ODMoney字段赋值
            this.ODMoney = oDMoney;
        }
        
		//属性存储数据的变量
        private int _oDID;
        private int? _orderID;
        private int? _bookID;
        private decimal? _oDPrice;
        private int? _oDCount;
        private decimal? _oDMoney;
        
        /// <summary>
        /// ODID
        /// </summary>
        public int ODID
        {
            get { return this._oDID; }
            set { this._oDID = value; }
        }
        /// <summary>
        /// OrderID
        /// </summary>
        public int? OrderID
        {
            get { return this._orderID; }
            set { this._orderID = value; }
        }
        /// <summary>
        /// BookID
        /// </summary>
        public int? BookID
        {
            get { return this._bookID; }
            set { this._bookID = value; }
        }
        /// <summary>
        /// ODPrice
        /// </summary>
        public decimal? ODPrice
        {
            get { return this._oDPrice; }
            set { this._oDPrice = value; }
        }
        /// <summary>
        /// ODCount
        /// </summary>
        public int? ODCount
        {
            get { return this._oDCount; }
            set { this._oDCount = value; }
        }
        /// <summary>
        /// ODMoney
        /// </summary>
        public decimal? ODMoney
        {
            get { return this._oDMoney; }
            set { this._oDMoney = value; }
        }
        
        /// <summary>
        /// 对比两个OrderDetail数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的OrderDetail数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成OrderDetail数据模型对象
            Mod_OrderDetail orderDetailMod = obj as Mod_OrderDetail;
            //判断是否转换成功
            if (orderDetailMod == null) return false;
            //进行匹配属性的值
            return
                //判断ODID是否一致
                this.ODID == orderDetailMod.ODID &&
                //判断OrderID是否一致
                this.OrderID == orderDetailMod.OrderID &&
                //判断BookID是否一致
                this.BookID == orderDetailMod.BookID &&
                //判断ODPrice是否一致
                this.ODPrice == orderDetailMod.ODPrice &&
                //判断ODCount是否一致
                this.ODCount == orderDetailMod.ODCount &&
                //判断ODMoney是否一致
                this.ODMoney == orderDetailMod.ODMoney;
        }
        /// <summary>
        /// 将当前OrderDetail数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将OrderDetail数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将ODID进行按位异或运算处理
                this.ODID.GetHashCode() ^
                //将OrderID进行按位异或运算处理
                (this.OrderID == null ? 2147483647 : this.OrderID.GetHashCode()) ^
                //将BookID进行按位异或运算处理
                (this.BookID == null ? 2147483647 : this.BookID.GetHashCode()) ^
                //将ODPrice进行按位异或运算处理
                (this.ODPrice == null ? 2147483647 : this.ODPrice.GetHashCode()) ^
                //将ODCount进行按位异或运算处理
                (this.ODCount == null ? 2147483647 : this.ODCount.GetHashCode()) ^
                //将ODMoney进行按位异或运算处理
                (this.ODMoney == null ? 2147483647 : this.ODMoney.GetHashCode());
        }
        /// <summary>
        /// 将当前OrderDetail数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前OrderDetail数据模型对象转换成字符串副本
            return
                "[" +
                //将ODID转换成字符串
                this.ODID +
                "]";
        }
    }
}
