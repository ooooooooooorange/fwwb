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
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult BoughtAsk()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        /// <summary>
        /// TODO:需通过数据库生成相应的请求列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RepairDeal()
        {
            Object obj = Session["Usr"];
            //网页信息
            //if (obj != null)
                ViewBag.UsrName = ((Models.User)obj).name;//用户名
            //else ViewBag.UsrName = "张三丰";
            List<string> list = new List<string> { "吴亦凡","吴世勋","鹿晗","朴灿烈",
                "张艺兴","艾琳","朴秀荣","林允儿","徐贤","郑秀晶",};

            ViewBag.RepDealNames = list;

            ViewBag.RepDealData = "{ \"Name\": 吴亦凡, \"Time\": \"2019 / 1 / 2\"}," +
                        "{ \"Name\": 吴世勋, \"Time\": \"2019/1/3\" }," +
                        "{ \"Name\": 鹿晗, \"Time\": \"2019/1/5\"}," +
                        "{ \"Name\": 朴灿烈, \"Time\": \"2019/1/8\" }," +
                        "{ \"Name\": 张艺兴, \"Time\": \"2019/1/12\" }," +
                        "{ \"Name\": 艾琳, \"Time\": \"2019/1/21\" }," +
                        "{ \"Name\": 朴秀荣, \"Time\": \"2019/2/2\"}," +
                        "{ \"Name\": 林允儿, \"Time\": \"2019/2/4\" }," +
                        "{ \"Name\": 徐贤, \"Time\": \"2019/2/7\" }," +
                        "{ \"Name\": 郑秀晶, \"Time\": \"2019/2/8\"},";

            return View();
        }
        public ActionResult ScrapAsk()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        /// <summary>
        /// TODO:需通过数据库生成相应的请求列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ToolInformation()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            List<string> list = new List<string> { "LM2132 - 1","LM2132 - 2",
                "LM2132 - 3","LM2132 - 4","LM2132 - 5",};
            ViewBag.ToolIDs = list;

            return View(); 

        }
        /// <summary>
        /// 采购入库申请处理
        /// </summary>
        /// <returns></returns>
        public ActionResult BoughtAct(string applicator, string date, string class_code,//疑问：类别代码是？
            string tool_code, HttpFileCollection http_file )//参数出字符串外，需考虑文件（照片）的传输
        {
            //TODO:处理采购请求
            Models.ReqInfo req = new Models.PurchaseReq
            {
                applicant=applicator,
                date=DateTime.Parse(date),
                fid=class_code,
                tool=new Models.Tool
                {
                    code =tool_code,
                }
            };
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
        public ActionResult ScrapReqAct(string applicator, string tool_code, string lifespan,
            string reason)//商量：似乎也应该有照片
        {
            //TODO:处理报废请求
            Models.ReqInfo req = new Models.ScrapReq
            {
                applicant=applicator,
                reason=reason,
                tool=new Models.Tool
                {
                    code=tool_code,
                }
            };
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