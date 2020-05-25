using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Dto
{
    public class ProductDto
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}