using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// BSCategory数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_BSCategory
    {
        /// <summary>
        /// 初始化BSCategory数据模型对象
        /// </summary>
        public Mod_BSCategory()
        {
            
        }
        /// <summary>
        /// 初始化BSCategory数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="bSID">BSID</param>
        public Mod_BSCategory(int bSID)
        {
            //给BSID字段赋值
            this.BSID = bSID;
        }
        /// <summary>
        /// 初始化BSCategory数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="bSID">BSID</param>
        /// <param name="bLID">BLID</param>
        /// <param name="bSName">BSName</param>
        public Mod_BSCategory(int bSID,int? bLID,string bSName)
        {
            //给BSID字段赋值
            this.BSID = bSID;
            //给BLID字段赋值
            this.BLID = bLID;
            //给BSName字段赋值
            this.BSName = bSName;
        }
        
		//属性存储数据的变量
        private int _bSID;
        private int? _bLID;
        private string _bSName;
        
        /// <summary>
        /// BSID
        /// </summary>
        public int BSID
        {
            get { return this._bSID; }
            set { this._bSID = value; }
        }
        /// <summary>
        /// BLID
        /// </summary>
        public int? BLID
        {
            get { return this._bLID; }
            set { this._bLID = value; }
        }
        /// <summary>
        /// BSName
        /// </summary>
        public string BSName
        {
            get { return this._bSName; }
            set { this._bSName = value; }
        }
        
        /// <summary>
        /// 对比两个BSCategory数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的BSCategory数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成BSCategory数据模型对象
            Mod_BSCategory bSCategoryMod = obj as Mod_BSCategory;
            //判断是否转换成功
            if (bSCategoryMod == null) return false;
            //进行匹配属性的值
            return
                //判断BSID是否一致
                this.BSID == bSCategoryMod.BSID &&
                //判断BLID是否一致
                this.BLID == bSCategoryMod.BLID &&
                //判断BSName是否一致
                this.BSName == bSCategoryMod.BSName;
        }
        /// <summary>
        /// 将当前BSCategory数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将BSCategory数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将BSID进行按位异或运算处理
                this.BSID.GetHashCode() ^
                //将BLID进行按位异或运算处理
                (this.BLID == null ? 2147483647 : this.BLID.GetHashCode()) ^
                //将BSName进行按位异或运算处理
                (this.BSName == null ? 2147483647 : this.BSName.GetHashCode());
        }
        /// <summary>
        /// 将当前BSCategory数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前BSCategory数据模型对象转换成字符串副本
            return
                "[" +
                //将BSID转换成字符串
                this.BSID +
                "]";
        }
    }
}
