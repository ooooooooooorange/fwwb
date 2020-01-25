using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 商量:
    /// 需考虑哪些东西在页面显示，哪些存在客户端
    /// A:由服务器一次性传输所有信息，客户端对相应操作做出响应
    /// B:客户端仅显示基本信息，详细信息由客户发起请求后，再向服务器发起请求
    /// </summary>
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BoughtFinalDeal()
        {
            //TODO:获取采购申请列表
            return View();
        }
        public ActionResult ScrapFinalDeal()
        {
            //TODO:获取报废申请列表
            return View();
        }
        /// <summary>
        /// 通过工单号进行查/同/拒操作
        /// PS：若选择A方案，则无查
        /// </summary>
        /// <param name="req_id">操作单号</param>
        /// <param name="statu">所要进行的操作
        /// "get"查看详情   "refuse"回绝  "acept"同意
        /// </param>
        /// <returns></returns>
        public ActionResult ReqAction(string req_id,string statu)
        {
            //TODO:对申请进行相应操作
            return View();
        }

    }
}