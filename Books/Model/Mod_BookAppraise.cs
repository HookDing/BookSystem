using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// BookAppraise数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_BookAppraise
    {
        /// <summary>
        /// 初始化BookAppraise数据模型对象
        /// </summary>
        public Mod_BookAppraise()
        {
            
        }
        /// <summary>
        /// 初始化BookAppraise数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="bAID">BAID</param>
        public Mod_BookAppraise(int bAID)
        {
            //给BAID字段赋值
            this.BAID = bAID;
        }
        /// <summary>
        /// 初始化BookAppraise数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="bAID">BAID</param>
        /// <param name="oDID">ODID</param>
        /// <param name="bADesc">BADesc</param>
        /// <param name="bAPoint">BAPoint</param>
        /// <param name="bADate">BADate</param>
        public Mod_BookAppraise(int bAID,int? oDID,string bADesc,int? bAPoint,DateTime? bADate)
        {
            //给BAID字段赋值
            this.BAID = bAID;
            //给ODID字段赋值
            this.ODID = oDID;
            //给BADesc字段赋值
            this.BADesc = bADesc;
            //给BAPoint字段赋值
            this.BAPoint = bAPoint;
            //给BADate字段赋值
            this.BADate = bADate;
        }
        
		//属性存储数据的变量
        private int _bAID;
        private int? _oDID;
        private string _bADesc;
        private int? _bAPoint;
        private DateTime? _bADate;
        
        /// <summary>
        /// BAID
        /// </summary>
        public int BAID
        {
            get { return this._bAID; }
            set { this._bAID = value; }
        }
        /// <summary>
        /// ODID
        /// </summary>
        public int? ODID
        {
            get { return this._oDID; }
            set { this._oDID = value; }
        }
        /// <summary>
        /// BADesc
        /// </summary>
        public string BADesc
        {
            get { return this._bADesc; }
            set { this._bADesc = value; }
        }
        /// <summary>
        /// BAPoint
        /// </summary>
        public int? BAPoint
        {
            get { return this._bAPoint; }
            set { this._bAPoint = value; }
        }
        /// <summary>
        /// BADate
        /// </summary>
        public DateTime? BADate
        {
            get { return this._bADate; }
            set { this._bADate = value; }
        }
        
        /// <summary>
        /// 对比两个BookAppraise数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的BookAppraise数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成BookAppraise数据模型对象
            Mod_BookAppraise bookAppraiseMod = obj as Mod_BookAppraise;
            //判断是否转换成功
            if (bookAppraiseMod == null) return false;
            //进行匹配属性的值
            return
                //判断BAID是否一致
                this.BAID == bookAppraiseMod.BAID &&
                //判断ODID是否一致
                this.ODID == bookAppraiseMod.ODID &&
                //判断BADesc是否一致
                this.BADesc == bookAppraiseMod.BADesc &&
                //判断BAPoint是否一致
                this.BAPoint == bookAppraiseMod.BAPoint &&
                //判断BADate是否一致
                this.BADate == bookAppraiseMod.BADate;
        }
        /// <summary>
        /// 将当前BookAppraise数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将BookAppraise数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将BAID进行按位异或运算处理
                this.BAID.GetHashCode() ^
                //将ODID进行按位异或运算处理
                (this.ODID == null ? 2147483647 : this.ODID.GetHashCode()) ^
                //将BADesc进行按位异或运算处理
                (this.BADesc == null ? 2147483647 : this.BADesc.GetHashCode()) ^
                //将BAPoint进行按位异或运算处理
                (this.BAPoint == null ? 2147483647 : this.BAPoint.GetHashCode()) ^
                //将BADate进行按位异或运算处理
                (this.BADate == null ? 2147483647 : this.BADate.GetHashCode());
        }
        /// <summary>
        /// 将当前BookAppraise数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前BookAppraise数据模型对象转换成字符串副本
            return
                "[" +
                //将BAID转换成字符串
                this.BAID +
                "]";
        }
    }
}
