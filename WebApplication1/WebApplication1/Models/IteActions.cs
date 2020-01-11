﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    partial class User
    {
        /// <summary>
        /// 判断用户是否为相应角色，以确定权限
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public bool IsNotType(params UserType[] types )
        {
            foreach(UserType t in types){
                if (t != type)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 用户登录，输入类型，编号及密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <param name="tp"></param>
        /// <returns>成功返回该用户，失败返回空</returns>
        public static  User Login(String id,String pwd,UserType tp)
        {
            User ret = new User { uid = id, type = tp };
            ret.Select();
            if (pwd == ret.password)
                return ret;
            else return null;
        }
        //public 
    }
}
