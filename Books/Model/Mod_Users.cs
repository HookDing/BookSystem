using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// Users数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_Users
    {
        /// <summary>
        /// 初始化Users数据模型对象
        /// </summary>
        public Mod_Users()
        {
            
        }
        /// <summary>
        /// 初始化Users数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="userID">UserID</param>
        public Mod_Users(int userID)
        {
            //给UserID字段赋值
            this.UserID = userID;
        }
        /// <summary>
        /// 初始化Users数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="userName">UserName</param>
        /// <param name="userPwd">UserPwd</param>
        /// <param name="userEmail">UserEmail</param>
        /// <param name="userSex">UserSex</param>
        /// <param name="userNick">UserNick</param>
        public Mod_Users(int userID,string userName,string userPwd,string userEmail,string userSex,string userNick)
        {
            //给UserID字段赋值
            this.UserID = userID;
            //给UserName字段赋值
            this.UserName = userName;
            //给UserPwd字段赋值
            this.UserPwd = userPwd;
            //给UserEmail字段赋值
            this.UserEmail = userEmail;
            //给UserSex字段赋值
            this.UserSex = userSex;
            //给UserNick字段赋值
            this.UserNick = userNick;
        }
        
		//属性存储数据的变量
        private int _userID;
        private string _userName;
        private string _userPwd;
        private string _userEmail;
        private string _userSex;
        private string _userNick;
        
        /// <summary>
        /// UserID
        /// </summary>
        public int UserID
        {
            get { return this._userID; }
            set { this._userID = value; }
        }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }
        /// <summary>
        /// UserPwd
        /// </summary>
        public string UserPwd
        {
            get { return this._userPwd; }
            set { this._userPwd = value; }
        }
        /// <summary>
        /// UserEmail
        /// </summary>
        public string UserEmail
        {
            get { return this._userEmail; }
            set { this._userEmail = value; }
        }
        /// <summary>
        /// UserSex
        /// </summary>
        public string UserSex
        {
            get { return this._userSex; }
            set { this._userSex = value; }
        }
        /// <summary>
        /// UserNick
        /// </summary>
        public string UserNick
        {
            get { return this._userNick; }
            set { this._userNick = value; }
        }
        
        /// <summary>
        /// 对比两个Users数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的Users数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成Users数据模型对象
            Mod_Users usersMod = obj as Mod_Users;
            //判断是否转换成功
            if (usersMod == null) return false;
            //进行匹配属性的值
            return
                //判断UserID是否一致
                this.UserID == usersMod.UserID &&
                //判断UserName是否一致
                this.UserName == usersMod.UserName &&
                //判断UserPwd是否一致
                this.UserPwd == usersMod.UserPwd &&
                //判断UserEmail是否一致
                this.UserEmail == usersMod.UserEmail &&
                //判断UserSex是否一致
                this.UserSex == usersMod.UserSex &&
                //判断UserNick是否一致
                this.UserNick == usersMod.UserNick;
        }
        /// <summary>
        /// 将当前Users数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将Users数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将UserID进行按位异或运算处理
                this.UserID.GetHashCode() ^
                //将UserName进行按位异或运算处理
                (this.UserName == null ? 2147483647 : this.UserName.GetHashCode()) ^
                //将UserPwd进行按位异或运算处理
                (this.UserPwd == null ? 2147483647 : this.UserPwd.GetHashCode()) ^
                //将UserEmail进行按位异或运算处理
                (this.UserEmail == null ? 2147483647 : this.UserEmail.GetHashCode()) ^
                //将UserSex进行按位异或运算处理
                (this.UserSex == null ? 2147483647 : this.UserSex.GetHashCode()) ^
                //将UserNick进行按位异或运算处理
                (this.UserNick == null ? 2147483647 : this.UserNick.GetHashCode());
        }
        /// <summary>
        /// 将当前Users数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前Users数据模型对象转换成字符串副本
            return
                "[" +
                //将UserID转换成字符串
                this.UserID +
                "]";
        }
    }
}
