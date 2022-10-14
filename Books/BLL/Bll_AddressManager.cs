﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Books.DAL;
using Books.Model;

namespace Books.BLL
{
    /// <summary>
    /// AddressManager业务逻辑对象
    /// </summary>
    public partial class Bll_AddressManager
    {
        /// <summary>
        /// AddressManager数据访问对象
        /// </summary>
        private readonly Dal_AddressManager _addressManagerDal = new Dal_AddressManager();
        /// <summary>
        /// 实例化AddressManager业务逻辑对象
        /// </summary>
        public Bll_AddressManager()
        {
            
        }
        /// <summary>
        /// 查询得到AddressManager表中所有信息
        /// </summary>
        /// <returns>查询到的所有AddressManager数据模型对象集合</returns>
        public List<Mod_AddressManager> GetAllModel()
        {
            //调用数据库访问层查询表中所有信息方法并将查询结果返回
            return this._addressManagerDal.GetAllModel();
        }
        /// <summary>
        /// 将传入的AddressManager数据模型对象数据存入数据库，并将自动编号值存入，传入AddressManager数据模型对象中
        /// </summary>
        /// <param name="addressManagerMod">要进行添加到数据库的AddressManager数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public int Insert(Mod_AddressManager addressManagerMod)
        {
            //调用数据访问层的添加方法并返回是否添加成功
            return this._addressManagerDal.Insert(addressManagerMod);
        }
        /// <summary>
        /// 将传入的AddressManager数据模型对象数据存入数据库，并将自动编号值存入，传入AddressManager数据模型对象中
        /// </summary>
        /// <param name="addressManagerMod">要进行添加到数据库的AddressManager数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(Mod_AddressManager addressManagerMod)
        {
            //调用数据访问层的添加方法并返回是否添加成功
            return this._addressManagerDal.Add(addressManagerMod);
        }
        /// <summary>
        /// 根据主键获取一条记录返回一个AddressManager数据模型对象
        /// </summary>
        /// <param name="aMID">AMID</param>
        /// <returns>如果查找到此记录就返回AddressManager数据模型对象，否则返回null</returns>
        public Mod_AddressManager GetModel(int aMID)
        {
            //调用数据访问层查询方法并将查询结果返回
            return this._addressManagerDal.GetModel(aMID);
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="aMID">AMID</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int aMID)
        {
            //调用数据访问层删除方法删除指定元素并返回是否删除成功
            return this._addressManagerDal.Delete(aMID);
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="aMID">AMID</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int aMID)
        {
            //调用数据访问层判断是否有此记录方法并返回结果
            return this._addressManagerDal.Exists(aMID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="addressManagerMod">AddressManager</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(Mod_AddressManager addressManagerMod)
        {
            //调用数据访问层更新数据方法并将更新结果返回
            return this._addressManagerDal.Update(addressManagerMod);
        }
        /// <summary>
        /// 清除用户默认地址
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool SetDefalut(int UserID)
        {
            //调用数据访问层更新数据方法并将更新结果返回
            return this._addressManagerDal.SetDefalut(UserID);
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="addressManagerMod">验证的AddressManager数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(Mod_AddressManager addressManagerMod)
        {
            //调用数据访问层的判断是否有此记录方法并返回判断结果
            return this._addressManagerDal.Exists(addressManagerMod);
        }
        /// <summary>
        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>
        /// <param name="sqlParameters">SQL参数对象</param>
        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>
        public bool Exists(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层方法
            return this._addressManagerDal.Exists(where, sqlParameters);
        }
        /// <summary>
        /// 自定义删除
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>是否删除成功，为true成功，为false失败</returns>
        public bool Delete(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层的自定义删除方法并返回删除结果
            return this._addressManagerDal.Delete(where, sqlParameters);
        }
        /// <summary>
        /// 自定义查找
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<Mod_AddressManager> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层的自定义查找方法并将查找结果返回
            return this._addressManagerDal.GetModelList(where,sqlParameters);
        }
        /// <summary>
        /// 自定义查找
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>查询到的[会员名称]数据模型对象</returns>
        public List<Mod_AddressManager> GetDefaultAddress(int UserID)
        {
            string where = $" UserID = {UserID} and AMMark = 1" ;
            SqlParameter[] sqlParameters = null;
            return this._addressManagerDal.GetModelList(where, sqlParameters);
        }
        /// <summary>
        /// 自定义查询出匹配记录有多少条
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>匹配记录数量</returns>
        public int GetCount(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层自定义查询出匹配记录有多少条方法并将结果返回
            return this._addressManagerDal.GetCount(where,sqlParameters);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的AddressManager数据模型对象集合</returns>
        public List<Mod_AddressManager> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法并将查询到的数据返回
            return this._addressManagerDal.GetListByPage(where,orderby,isDesc,startIndex,endIndex,sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的AddressManager数据模型对象集合</returns>
        public List<Mod_AddressManager> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法
            return this._addressManagerDal.GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="allItmeCount">总共有多少条记录</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的AddressManager数据模型对象集合</returns>
        public List<Mod_AddressManager> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法
            return this._addressManagerDal.GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, out allItmeCount, sqlParameters);
        }
    }
}
