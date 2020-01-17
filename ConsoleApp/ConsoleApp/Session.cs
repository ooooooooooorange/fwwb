using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp
{
    /// <summary>
    /// 用以在服务端保存客户信息
    /// </summary>
    class Session
    {
        /// <summary>
        /// 常量超时时间，以决定是否视为退出登录
        /// </summary>
        private const int OVERTIME = 5;
        private User user { get; set; }
        private DateTime last_time { get; set; }
        private IPAddress usr_addr { get; set; }
        /// <summary>
        /// 根据设定的超时时间返回真值，一确实是否下线
        /// </summary>
        /// <returns></returns>
        public bool IsOverTie()
        {
            return (DateTime.Now - last_time).TotalMinutes > OVERTIME;
        }
        public void Purchase(String info)
        {

        }
        public String SendPurchase()
        {

        }
        public void ReadPurchase(params String[] vs )
        {
        
        }
    }
}
/**
    在Session中发送以及生成
     各类请求
        请求方法包括：生成（接收），审批（初审，终审）（接收，发送），读取（按照器件编号，按照经手人编号）（发送）（是否已审批（历史记录））
        请求有
     */