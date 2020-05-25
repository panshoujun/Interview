using Common;
using Common.SqlHelper.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Dto;

namespace WebApplication.Common
{
    /// <summary>
    /// 数据初始化
    /// </summary>
    public class DataInit
    {
        public static void InitData()
        {
            InitProductList();
            InitProductSecKill();
        }

        public static void InitProductList()
        {

        }

        /// <summary>
        /// 初始化秒杀商品
        /// </summary>
        public static void InitProductSecKill()
        {
            var resp = MysqlHelper.ExecuteObjects<List<ProductDto>>("select * from Product");

            RedisCacheHelper.Add<List<ProductDto>>("productlist",resp.Data, DateTime.Now.AddMinutes(30));
            foreach (var item in resp.Data)
            {
                RedisCacheHelper.Add<int>(item.ID.ToString(), item.Count, DateTime.Now.AddMinutes(30));
            }
        }
    }
}