using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 建议：
    ///     初级用户应有至少查看自己的记录的权限
    /// </summary>
    public class OperatorIController : Controller
    {
        // GET: OperatorI
        public ActionResult Index()
        {
            //ViewBag.UsrName = name;
            Object obj= Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        //建议：出入库记录使用一个页面，同时增加标识是否为入库
        public ActionResult ImStock()
        {

            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult OutStock()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        public ActionResult Repair()
        {
            Object obj = Session["Usr"];
            //网页信息
            ViewBag.UsrName = ((Models.User)obj).name;//用户名
            return View();
        }
        /// <summary>
        /// 出入库记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ImExStockAct(string time,string record_user,
            string tool_code,string[] tool_model,string tool_location , 
            string[] tool_partno, string produce_line, string tool_family, 
            string tool_name, string rent_user,int is_im)
        {
            Models.ImExReq req = new Models.ImExReq
            {
                //建议：tool_model与tool_partno应为数组
                creatdate = DateTime.Parse(time),
                applicant = record_user,
                is_im=is_im!=0,
                
                tool = new Models.Tool
                {
                    code = tool_code,
                    model = tool_model,
                    location=tool_location,
                    part_no=tool_partno,
                    //疑问：produce_line whats this
                    family=tool_family,
                    name=tool_name,
                    //疑问：rent_user whats this
                }
            };
            //数据库储存该请求
            bool f=req.Creat(((Models.User)Session["Usr"]).name);
            //疑问：成功或失败后应该返回什么？
            if (f)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// 维修请求
        /// </summary>
        /// <returns></returns>
        public ActionResult RepairReq(string time, string record_user,
            string tool_code, string[] tool_model, string tool_location,
            string[] tool_partno, string produce_line, string tool_family,
            string tool_name, string rent_user)
        {
            Models.RepairReq req = new Models.RepairReq
            {
                //建议：tool_model与tool_partno应为数组
                creatdate = DateTime.Parse(time),
                applicant = record_user,

                tool = new Models.Tool
                {
                    code = tool_code,
                    model = tool_model,
                    location = tool_location,
                    part_no = tool_partno,
                    //疑问：produce_line whats this
                    family = tool_family,
                    name = tool_name,
                    //疑问：rent_user whats this
                }
            };
            //数据库储存该请求
            bool f = req.Creat(((Models.User)Session["Usr"]).name);
            //疑问：成功或失败后应该返回什么？
            if (f)
            {
                return View();
            }
            else
            {
                return View();
            }
        }


    }
}