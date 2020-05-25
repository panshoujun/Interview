using Common;
using Common.SqlHelper.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Dto;

namespace WebApplication.Controllers
{
    public class ProductMngController : Controller
    {
        // GET: ProductMng
        public ActionResult Index()
        {
            var list = MysqlHelper.ExecuteObjects<ProductDto>("select * from Product");
            ViewData["message"] = $"ID={IPHepler.GetLocalIP()}";
            return View(list);
        }
    }
}