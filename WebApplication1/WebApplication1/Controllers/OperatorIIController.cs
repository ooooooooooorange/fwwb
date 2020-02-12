using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class OperatorIIController : Controller
    {
        // GET: OperatorII
        public ActionResult Index(string name)
        {
            return View();
        }
        public ActionResult BoughtAsk()
        {
            return View();
        }
        public ActionResult RepairDeal()
        {
            return View();
        }
        public ActionResult ScrapAsk()
        {
            return View();
        }
        public ActionResult ToolInformation()
        {
            return View();
        }
        /// <summary>
        /// 采购入库申请处理
        /// </summary>
        /// <returns></returns>
        public ActionResult BoughtAct()//参数出字符串外，需考虑文件（照片）的传输
        {
            
            return View();
        }
        /// <summary>
        /// 报修申请处理
        /// </summary>
        /// <returns></returns>
        public ActionResult RepairAct()
        {
            return View();
        }
        /// <summary>
        /// 报废申请
        /// </summary>
        /// <returns></returns>
        public ActionResult ScrapReqAct()//商量：似乎也应该有照片
        {
            return View();
        }
        /// <summary>
        /// 工夹具信息修改
        /// </summary>
        /// <returns></returns>
        public ActionResult ToolInfEdi()
        {
            return View();
        }
    }
}