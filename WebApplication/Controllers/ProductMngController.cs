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
            var resp = MysqlHelper.ExecuteObjects<List<ProductDto>>("select * from Product");
            ViewData["ServerIP"] = $"服务器IP={IPHepler.GetLocalIP()}";
            ViewData["DataBaseUrl"] = $"数据库链接={resp.Msg}";
            return View(resp.Data);
        }
    }
}