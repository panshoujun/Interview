using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTEST.Models
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string NO { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return $"我的名字叫{Name},今年{Age}岁了;序号是{NO}";
        }

    }
}