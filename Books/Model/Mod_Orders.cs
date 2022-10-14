using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// Orders数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_Orders
    {
        /// <summary>
        /// 初始化Orders数据模型对象
        /// </summary>
        public Mod_Orders()
        {
            
        }
        /// <summary>
        /// 初始化Orders数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="orderID">OrderID</param>
        public Mod_Orders(int orderID)
        {
            //给OrderID字段赋值
            this.OrderID = orderID;
        }
        /// <summary>
        /// 初始化Orders数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="orderID">OrderID</param>
        /// <param name="userID">UserID</param>
        /// <param name="aMID">AMID</param>
        /// <param name="orderNum">OrderNum</param>
        /// <param name="orderDate">OrderDate</param>
        /// <param name="orderState">OrderState</param>
        /// <param name="orderMoney">OrderMoney</param>
        public Mod_Orders(int orderID,int? userID,int? aMID,string orderNum,DateTime? orderDate,int? orderState,decimal? orderMoney)
        {
            //给OrderID字段赋值
            this.OrderID = orderID;
            //给UserID字段赋值
            this.UserID = userID;
            //给AMID字段赋值
            this.AMID = aMID;
            //给OrderNum字段赋值
            this.OrderNum = orderNum;
            //给OrderDate字段赋值
            this.OrderDate = orderDate;
            //给OrderState字段赋值
            this.OrderState = orderState;
            //给OrderMoney字段赋值
            this.OrderMoney = orderMoney;
        }
        
		//属性存储数据的变量
        private int _orderID;
        private int? _userID;
        private int? _aMID;
        private string _orderNum;
        private DateTime? _orderDate;
        private int? _orderState;
        private decimal? _orderMoney;
        
        /// <summary>
        /// OrderID
        /// </summary>
        public int OrderID
        {
            get { return this._orderID; }
            set { this._orderID = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>
        public int? UserID
        {
            get { return this._userID; }
            set { this._userID = value; }
        }
        /// <summary>
        /// AMID
        /// </summary>
        public int? AMID
        {
            get { return this._aMID; }
            set { this._aMID = value; }
        }
        /// <summary>
        /// OrderNum
        /// </summary>
        public string OrderNum
        {
            get { return this._orderNum; }
            set { this._orderNum = value; }
        }
        /// <summary>
        /// OrderDate
        /// </summary>
        public DateTime? OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }
        /// <summary>
        /// OrderState
        /// </summary>
        public int? OrderState
        {
            get { return this._orderState; }
            set { this._orderState = value; }
        }
        /// <summary>
        /// OrderMoney
        /// </summary>
        public decimal? OrderMoney
        {
            get { return this._orderMoney; }
            set { this._orderMoney = value; }
        }
        
        /// <summary>
        /// 对比两个Orders数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的Orders数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成Orders数据模型对象
            Mod_Orders ordersMod = obj as Mod_Orders;
            //判断是否转换成功
            if (ordersMod == null) return false;
            //进行匹配属性的值
            return
                //判断OrderID是否一致
                this.OrderID == ordersMod.OrderID &&
                //判断UserID是否一致
                this.UserID == ordersMod.UserID &&
                //判断AMID是否一致
                this.AMID == ordersMod.AMID &&
                //判断OrderNum是否一致
                this.OrderNum == ordersMod.OrderNum &&
                //判断OrderDate是否一致
                this.OrderDate == ordersMod.OrderDate &&
                //判断OrderState是否一致
                this.OrderState == ordersMod.OrderState &&
                //判断OrderMoney是否一致
                this.OrderMoney == ordersMod.OrderMoney;
        }
        /// <summary>
        /// 将当前Orders数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将Orders数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将OrderID进行按位异或运算处理
                this.OrderID.GetHashCode() ^
                //将UserID进行按位异或运算处理
                (this.UserID == null ? 2147483647 : this.UserID.GetHashCode()) ^
                //将AMID进行按位异或运算处理
                (this.AMID == null ? 2147483647 : this.AMID.GetHashCode()) ^
                //将OrderNum进行按位异或运算处理
                (this.OrderNum == null ? 2147483647 : this.OrderNum.GetHashCode()) ^
                //将OrderDate进行按位异或运算处理
                (this.OrderDate == null ? 2147483647 : this.OrderDate.GetHashCode()) ^
                //将OrderState进行按位异或运算处理
                (this.OrderState == null ? 2147483647 : this.OrderState.GetHashCode()) ^
                //将OrderMoney进行按位异或运算处理
                (this.OrderMoney == null ? 2147483647 : this.OrderMoney.GetHashCode());
        }
        /// <summary>
        /// 将当前Orders数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前Orders数据模型对象转换成字符串副本
            return
                "[" +
                //将OrderID转换成字符串
                this.OrderID +
                "]";
        }
    }
}
