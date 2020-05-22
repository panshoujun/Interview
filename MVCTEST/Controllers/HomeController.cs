using Common;
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

            var count = SQLHelper.ExecuteScalar("select COUNT(*) from Student");

            var data = SQLHelper.ExecuteDataTable("select * from Student");

            var countStudent = int.Parse(SQLHelper.ExecuteScalar("select COUNT(*) from Student where S#='10' ").ToString());
            if (countStudent > 0)
            {
                var temp = SQLHelper.ExecuteNonQuery("delete from Student where S#='10' ");
            }

            var insert = SQLHelper.ExecuteNonQuery("insert into student (s#,Sname,Sage,Ssex) values('10','aaaa','1990-04-01 00:00:00.000','男')");

            ViewData["message"] = "这是ViewData(string)";


            Student stu = new Student { Age = 320, Name = "潘守军3", NO = "NO003" };
            //Student stu = new Student { Age = 10, Name = "潘守军", NO = "NO001" }//;
            ViewBag.ViewBagStu = stu;
            ViewData["ViewDataStu"] = stu;
            TempData["TempDataStu"] = stu;

            if (!RedisCacheHelper.Exists(stu.NO))
            {
                RedisCacheHelper.Add<Student>(stu.NO, stu, DateTime.Now.AddMinutes(15));
            }
            else
            {
                var student = RedisCacheHelper.Get<Student>("NO001");
            }

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
            var stu = ViewBag.ViewBagStu;
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