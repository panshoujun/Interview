using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Dto
{
    public class BuyProductDto
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount { get; set; }
    }
}