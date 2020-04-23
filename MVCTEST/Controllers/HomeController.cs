using MVCTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTEST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["message"] = "这是ViewData(string)";


            Student stu = new Student { Age = 10, Name = "潘守军", NO = "NO001" };
            ViewBag.ViewBagStu = stu;
            ViewData["ViewDataStu"] = stu;
            TempData["TempDataStu"] = stu;

            return View();
        }


        public ActionResult Index2()
        {
            Student stu = new Student { Age = 10, Name = "潘守军", NO = "NO001" };
            ViewBag.ViewBagStu = stu;
            ViewData["ViewDataStu"] = stu;
            TempData["TempDataStu"] = stu;

            return RedirectToAction("index3");
        }

        public ActionResult Index3()
        {
            var stu=ViewBag.ViewBagStu;
            var stu2 = ViewData["ViewDataStu"];
            var stu3 = TempData["TempDataStu"];
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            string message = ViewData["message"] as string;
            var stu = ViewBag.ViewBagStu;
            var stu2 = ViewData["ViewDataStu"];
            var stu3 = TempData["TempDataStu"];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}