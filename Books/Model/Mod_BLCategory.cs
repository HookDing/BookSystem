using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// BLCategory数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_BLCategory
    {
        /// <summary>
        /// 初始化BLCategory数据模型对象
        /// </summary>
        public Mod_BLCategory()
        {
            
        }
        /// <summary>
        /// 初始化BLCategory数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="bLID">BLID</param>
        public Mod_BLCategory(int bLID)
        {
            //给BLID字段赋值
            this.BLID = bLID;
        }
        /// <summary>
        /// 初始化BLCategory数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="bLID">BLID</param>
        /// <param name="bLName">BLName</param>
        public Mod_BLCategory(int bLID,string bLName)
        {
            //给BLID字段赋值
            this.BLID = bLID;
            //给BLName字段赋值
            this.BLName = bLName;
        }
        
		//属性存储数据的变量
        private int _bLID;
        private string _bLName;
        
        /// <summary>
        /// BLID
        /// </summary>
        public int BLID
        {
            get { return this._bLID; }
            set { this._bLID = value; }
        }
        /// <summary>
        /// BLName
        /// </summary>
        public string BLName
        {
            get { return this._bLName; }
            set { this._bLName = value; }
        }
        
        /// <summary>
        /// 对比两个BLCategory数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的BLCategory数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成BLCategory数据模型对象
            Mod_BLCategory bLCategoryMod = obj as Mod_BLCategory;
            //判断是否转换成功
            if (bLCategoryMod == null) return false;
            //进行匹配属性的值
            return
                //判断BLID是否一致
                this.BLID == bLCategoryMod.BLID &&
                //判断BLName是否一致
                this.BLName == bLCategoryMod.BLName;
        }
        /// <summary>
        /// 将当前BLCategory数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将BLCategory数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将BLID进行按位异或运算处理
                this.BLID.GetHashCode() ^
                //将BLName进行按位异或运算处理
                (this.BLName == null ? 2147483647 : this.BLName.GetHashCode());
        }
        /// <summary>
        /// 将当前BLCategory数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前BLCategory数据模型对象转换成字符串副本
            return
                "[" +
                //将BLID转换成字符串
                this.BLID +
                "]";
        }
    }
}
