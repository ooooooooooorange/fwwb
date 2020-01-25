using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Home/Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }
        public ActionResult VView()
        {

            ViewBag.Message = "main";

            if (ViewBag.Password == "")
                return Contact();
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user_type"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult Test(int user_type,string username,string password)
        {
            ViewBag.Message = "Login";
            //Models.User.Login(...);
            //return RedirectToAction("Index","Manager");
            //Models.User user=Models.User.Login(username,password, (Models.UserType)user_type);
            //TODO:进行登录验证并根据相应结果与类型返回相应页面

            if (password == null)
                return RedirectToAction("Error", "Shared");
            return RedirectToAction("Index","Manager");
            /*switch (ViewBag.UserType)
            {
                case 0: return Redirect("~/Home/Index");
                case 1: return Redirect("~/Home/VView");
                default: return Redirect("~/Shared/Error");
            }*/
        }
        /// <summary>
        /// 登出操作
        /// </summary>
        /// <returns>删除登录信息并返回登录页面</returns>
        public ActionResult Test()
        {
            //YODO:删除登录信息
            //返回登录页面
            return RedirectToAction("Login", "Home");
        }
    }
}