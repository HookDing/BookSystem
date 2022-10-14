using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// Admins数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_Admins
    {
        /// <summary>
        /// 初始化Admins数据模型对象
        /// </summary>
        public Mod_Admins()
        {
            
        }
        /// <summary>
        /// 初始化Admins数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="adminID">AdminID</param>
        public Mod_Admins(int adminID)
        {
            //给AdminID字段赋值
            this.AdminID = adminID;
        }
        /// <summary>
        /// 初始化Admins数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="adminID">AdminID</param>
        /// <param name="adminUser">AdminUser</param>
        /// <param name="adminPwd">AdminPwd</param>
        public Mod_Admins(int adminID,string adminUser,string adminPwd)
        {
            //给AdminID字段赋值
            this.AdminID = adminID;
            //给AdminUser字段赋值
            this.AdminUser = adminUser;
            //给AdminPwd字段赋值
            this.AdminPwd = adminPwd;
        }
        
		//属性存储数据的变量
        private int _adminID;
        private string _adminUser;
        private string _adminPwd;
        
        /// <summary>
        /// AdminID
        /// </summary>
        public int AdminID
        {
            get { return this._adminID; }
            set { this._adminID = value; }
        }
        /// <summary>
        /// AdminUser
        /// </summary>
        public string AdminUser
        {
            get { return this._adminUser; }
            set { this._adminUser = value; }
        }
        /// <summary>
        /// AdminPwd
        /// </summary>
        public string AdminPwd
        {
            get { return this._adminPwd; }
            set { this._adminPwd = value; }
        }
        
        /// <summary>
        /// 对比两个Admins数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的Admins数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成Admins数据模型对象
            Mod_Admins adminsMod = obj as Mod_Admins;
            //判断是否转换成功
            if (adminsMod == null) return false;
            //进行匹配属性的值
            return
                //判断AdminID是否一致
                this.AdminID == adminsMod.AdminID &&
                //判断AdminUser是否一致
                this.AdminUser == adminsMod.AdminUser &&
                //判断AdminPwd是否一致
                this.AdminPwd == adminsMod.AdminPwd;
        }
        /// <summary>
        /// 将当前Admins数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将Admins数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将AdminID进行按位异或运算处理
                this.AdminID.GetHashCode() ^
                //将AdminUser进行按位异或运算处理
                (this.AdminUser == null ? 2147483647 : this.AdminUser.GetHashCode()) ^
                //将AdminPwd进行按位异或运算处理
                (this.AdminPwd == null ? 2147483647 : this.AdminPwd.GetHashCode());
        }
        /// <summary>
        /// 将当前Admins数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前Admins数据模型对象转换成字符串副本
            return
                "[" +
                //将AdminID转换成字符串
                this.AdminID +
                "]";
        }
    }
}
