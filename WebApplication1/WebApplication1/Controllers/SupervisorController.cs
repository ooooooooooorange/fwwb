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
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult BoughtDeal()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult ClassRevise()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult ScrapDeal()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        /// <summary>
        /// 创建工夹具类别（可用于修改？）
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatFixture(string name)
        {
            //商量：除名字外，应该同时填写绝大部分类别信息
            //TODO：创建相应工夹具类别
            Models.Fixture fixture = new Models.Fixture
            {
                name = name,
            };
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