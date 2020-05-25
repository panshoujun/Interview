using Common;
using Common.SqlHelper.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Common;
using WebApplication.Models.Dto;
using WebApplication.Models.Dto.Base;

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

            DataInit.InitData();

            return View(resp.Data);
        }


        public ActionResult BuyProduct(BuyProductDto dto)
        {
            var data = RedisCacheHelper.Get<List<ProductDto>>("productlist");
            ViewData["ServerIP"] = $"服务器IP={IPHepler.GetLocalIP()}";
            var count = RedisCacheHelper.Decrement(dto.ProductID.ToString(), dto.BuyCount);
            BaseDtoResp<string> resp = new BaseDtoResp<string>();
            if (count >= 0)
            {
                resp.IsSuccess = MysqlHelper.ExecuteSql($"update Product set count=count-{dto.BuyCount} where ID={dto.ProductID}") > 0;
                resp.Msg = "商品购买成功";
            }
            else
            {
                resp.Msg = "商品已卖完";
            }


            //RedisCacheHelper.Add<Student>(stu.NO, stu, DateTime.Now.AddMinutes(15));
            return Json(resp);
        }
    }
}