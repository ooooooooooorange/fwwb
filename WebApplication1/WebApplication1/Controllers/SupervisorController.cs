using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 商量：
    ///     关于查看类别信息
    ///     A：加载页面时，传输全部类别具体信息
    ///     B：在查看某一类别时，传输其相关信息
    /// </summary>
    public class SupervisorController : Controller
    {
        // GET: Supervisor
        public ActionResult Index(string name)
        {
            return View();
        }
        public ActionResult BoughtDeal()
        {
            return View();
        }
        public ActionResult ClassRevise()
        {
            return View();
        }
        public ActionResult ScrapDeal()
        {
            return View();
        }
        /// <summary>
        /// 创建工夹具类别（可用于修改？）
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatClass()
        {
            return View();
        }
        /// <summary>
        /// 采购入库的申请处理
        /// </summary>
        /// <returns></returns>
        public ActionResult BoughtActt()
        {
            return View();
        }
        /// <summary>
        /// 报废申请处理
        /// </summary>
        /// <returns></returns>
        public ActionResult ScrapAct()
        {
            return View();
        }
    }
}