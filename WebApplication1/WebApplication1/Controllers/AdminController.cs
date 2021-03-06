﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 管理员界面
    /// 功能：
    ///     添加删除用户
    /// </summary>
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string name)
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult UserPower()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        /// <summary>
        /// 转到相应页面并显示（后台获取）相应的所有用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRevise()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            //TODO:获取该用户下辖的所有用户信息
            return View();
        }
        
        public ActionResult Power()
        {
            /*注意：此处应至少包含角色数据有：姓名，角色列表，唯一标识符（用户ID）*/
            List<KeyValuePair<string,int[]>> user_pair = new List<KeyValuePair<string, int[]>>
            {
                new KeyValuePair<string,int[]>("张三",new int[]{ 1}),
                new KeyValuePair<string,int[]>("李四",new int[]{ 2}),
                new KeyValuePair<string,int[]>("王五",new int[]{ 3}),
                new KeyValuePair<string,int[]>("赵六",new int[]{ 4}),
            };
            
            ViewBag.UserPair = user_pair;

            return null;
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user_type"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>返回成功或失败，若失败，带有相关信息</returns>
        public ActionResult AddUser(int user_type, string username, string password)
        {
            //TODO:添加用户的操作以及设置返回信息
            Models.User usr = new Models.User
            {
                type = (Models.UserType)Enum.Parse(typeof(Models.UserType), "" + user_type),
                name=username,
                password=password,
            };
            return null;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user_type"></param>
        /// <param name="username"></param>
        /// <returns>返回删除结果以及相关信息</returns>
        public ActionResult DeleteUser(int user_type, string username)
        {
            //TODO:删除相关操作以及返回信息
            return null;
        }
    }
}