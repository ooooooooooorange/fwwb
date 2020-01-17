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
            return View();
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
        public ActionResult Test()
        {
            ViewBag.Message = "Login";
            //Models.User.Login(...);
            if (ViewBag.Password == null)
                return Redirect("/Home/Index");
            return Redirect("/Home/VView");
        }
    }
}