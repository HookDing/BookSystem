using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// AddressManager数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_AddressManager
    {
        /// <summary>
        /// 初始化AddressManager数据模型对象
        /// </summary>
        public Mod_AddressManager()
        {
            
        }
        /// <summary>
        /// 初始化AddressManager数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="aMID">AMID</param>
        public Mod_AddressManager(int aMID)
        {
            //给AMID字段赋值
            this.AMID = aMID;
        }
        /// <summary>
        /// 初始化AddressManager数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="aMID">AMID</param>
        /// <param name="userID">UserID</param>
        /// <param name="aMUser">AMUser</param>
        /// <param name="aMTel">AMTel</param>
        /// <param name="aMAddress">AMAddress</param>
        /// <param name="aMMark">AMMark</param>
        public Mod_AddressManager(int aMID,int? userID,string aMUser,string aMTel,string aMAddress,bool? aMMark)
        {
            //给AMID字段赋值
            this.AMID = aMID;
            //给UserID字段赋值
            this.UserID = userID;
            //给AMUser字段赋值
            this.AMUser = aMUser;
            //给AMTel字段赋值
            this.AMTel = aMTel;
            //给AMAddress字段赋值
            this.AMAddress = aMAddress;
            //给AMMark字段赋值
            this.AMMark = aMMark;
        }
        
		//属性存储数据的变量
        private int _aMID;
        private int? _userID;
        private string _aMUser;
        private string _aMTel;
        private string _aMAddress;
        private bool? _aMMark;
        
        /// <summary>
        /// AMID
        /// </summary>
        public int AMID
        {
            get { return this._aMID; }
            set { this._aMID = value; }
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
        /// AMUser
        /// </summary>
        public string AMUser
        {
            get { return this._aMUser; }
            set { this._aMUser = value; }
        }
        /// <summary>
        /// AMTel
        /// </summary>
        public string AMTel
        {
            get { return this._aMTel; }
            set { this._aMTel = value; }
        }
        /// <summary>
        /// AMAddress
        /// </summary>
        public string AMAddress
        {
            get { return this._aMAddress; }
            set { this._aMAddress = value; }
        }
        /// <summary>
        /// AMMark
        /// </summary>
        public bool? AMMark
        {
            get { return this._aMMark; }
            set { this._aMMark = value; }
        }
        
        /// <summary>
        /// 对比两个AddressManager数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的AddressManager数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成AddressManager数据模型对象
            Mod_AddressManager addressManagerMod = obj as Mod_AddressManager;
            //判断是否转换成功
            if (addressManagerMod == null) return false;
            //进行匹配属性的值
            return
                //判断AMID是否一致
                this.AMID == addressManagerMod.AMID &&
                //判断UserID是否一致
                this.UserID == addressManagerMod.UserID &&
                //判断AMUser是否一致
                this.AMUser == addressManagerMod.AMUser &&
                //判断AMTel是否一致
                this.AMTel == addressManagerMod.AMTel &&
                //判断AMAddress是否一致
                this.AMAddress == addressManagerMod.AMAddress &&
                //判断AMMark是否一致
                this.AMMark == addressManagerMod.AMMark;
        }
        /// <summary>
        /// 将当前AddressManager数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将AddressManager数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将AMID进行按位异或运算处理
                this.AMID.GetHashCode() ^
                //将UserID进行按位异或运算处理
                (this.UserID == null ? 2147483647 : this.UserID.GetHashCode()) ^
                //将AMUser进行按位异或运算处理
                (this.AMUser == null ? 2147483647 : this.AMUser.GetHashCode()) ^
                //将AMTel进行按位异或运算处理
                (this.AMTel == null ? 2147483647 : this.AMTel.GetHashCode()) ^
                //将AMAddress进行按位异或运算处理
                (this.AMAddress == null ? 2147483647 : this.AMAddress.GetHashCode()) ^
                //将AMMark进行按位异或运算处理
                (this.AMMark == null ? 2147483647 : this.AMMark.GetHashCode());
        }
        /// <summary>
        /// 将当前AddressManager数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前AddressManager数据模型对象转换成字符串副本
            return
                "[" +
                //将AMID转换成字符串
                this.AMID +
                "]";
        }
    }
}
