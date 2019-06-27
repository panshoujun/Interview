using algorithm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Father father = new Father();
            father.PrintNew();
            father = new Son();
            father.PrintNew();
            #region 不借用第三个变量,怎么把a,b的值互换
            int a = 3;
            int b = 5;
            Console.WriteLine(string.Format("不借用第三个变量,怎么把a,b的值互换,改变前a={0},b={1}", a, b));
            Helper.Exchange(ref a, ref b);
            Console.WriteLine(string.Format("不借用第三个变量,怎么把a,b的值互换,改变后a={0},b={1}", a, b));
            Console.WriteLine();
            #endregion

            #region 1-2+3-4+……+m
            Console.WriteLine(string.Format("1-2+3-4+……+m,方法一Sum(5)={0}", Helper.Sum(5)));
            Console.WriteLine(string.Format("1-2+3-4+……+m,方法二Sum2(5)={0}", Helper.Sum2(5)));
            Console.WriteLine();
            #endregion

            #region 1、1、2、3、5、8、13、21、34......  求第30位数是多少
            Console.WriteLine(string.Format("1、1、2、3、5、8、13、21、34......  求第30位数是多少,方法一Foo(50)={0}", Helper.Foo(30)));
            Console.WriteLine();
            #endregion

            #region 数组反转置顶开始位置和结束位置
            int[] arryInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] arryString = { "a", "b", "c", "d" };
            Console.WriteLine(string.Format("数组反转置前arryInt={0}", string.Join(",", arryInt)));
            Helper.Reverse<int>(arryInt, 0, 1);
            Console.WriteLine(string.Format("数组反转置后arryInt={0}", string.Join(",", arryInt)));

            Console.WriteLine(string.Format("数组反转置前arryString={0}", string.Join(",", arryString)));
            Helper.Reverse<string>(arryString, 0, 2);
            Console.WriteLine(string.Format("数组反转置后arryString={0}", string.Join(",", arryString)));

            Console.WriteLine();
            #endregion

            #region 删除集合给定元素
            ArrayList aList = new ArrayList { 'a', 'b', 'c', 'c', 1, 1, 2 };
            Console.WriteLine(string.Format("删除集合给定元素前aList={0}", string.Join(",", aList)));
            Helper.deleteForm(aList, 1);
            Console.WriteLine(string.Format("删除集合给定元素后aList={0}", string.Join(",", aList)));
            Console.WriteLine();
            #endregion

            #region 数组合并去重
            int[] arryA = { 1, 2, 3, 4, 5 };
            int[] arryB = { 3, 5, 6 };
            string[] outputA = Array.ConvertAll<int, string>(arryA, i => i.ToString());
            Console.WriteLine(string.Format("数组合并去重数组arryA={0}", string.Join(",", outputA)));
            string[] outputB = Array.ConvertAll<int, string>(arryB, i => i.ToString());
            Console.WriteLine(string.Format("数组合并去重数组arryB={0}", string.Join(",", outputB)));

            var resultArray = Helper.CombinedArray(arryA, arryB);
            string[] outputResult = Array.ConvertAll<int, string>(resultArray, i => i.ToString());
            Console.WriteLine(string.Format("数组合并去重数组resultArray={0}", string.Join(",", outputResult)));
            Console.WriteLine();
            #endregion

            #region 两个数组  [n] [m]  n>m  第一个数组的数字无序排列 第二个数组为空 取出第一个数组的最小值 放到第二个数组中第一个位置, 依次类推. 不能改变A数组，不能对之进行排序，也不可以倒到别的数组中。
            int[] n = { -20, 9, 7, 37, 38, 69, 89, -1, 59, 29, 0, -25, 39, 900, 22, 13, 55 };
            int[] m = new int[10];
            Helper.GetArr2(n, m);
            string[] outputM = Array.ConvertAll<int, string>(m, i => i.ToString());
            Console.WriteLine(string.Format("数组outputM={0}", string.Join(",", outputM)));
            Console.WriteLine();
            #endregion

            #region 产生一个int数组，长度为100，并向其中随机插入1-100，并且不能重复。
            var array = Helper.CreateArr(10);
            string[] outputArray = Array.ConvertAll<int, string>(array, i => i.ToString());
            Console.WriteLine(string.Format("数组outputArray={0}", string.Join(",", outputArray)));
            Console.WriteLine();
            #endregion

            #region 字符串处理

            #region 字符串倒序输出
            string str1 = "123456";
            Console.WriteLine(string.Format("字符串倒序输出前str1={0}", str1));
            str1 = Helper.Reverse(str1);
            Console.WriteLine(string.Format("字符串倒序输出后str1={0}", str1));
            Console.WriteLine();
            #endregion

            #region 请将字符串"I am a student"按单词逆序输出如"student a am I"
            string str2 = "I am a student";
            Console.WriteLine(string.Format("按单词逆序输出前str2={0}", str2));
            str2 = Helper.ReverseWord(str2);
            Console.WriteLine(string.Format("按单词逆序输出后str2={0}", str2));
            Console.WriteLine();
            #endregion

            #endregion

            #region 一口井深7米,一直蜗牛往上爬,白天爬3米,晚上掉2米。几天爬出去
            int iOut = Helper.Out();
            Console.WriteLine(string.Format("一口井深7米,一直蜗牛往上爬,白天爬3米,晚上掉2米。几天爬出去。iOut={0}", iOut));
            Console.WriteLine();
            #endregion


            #region 冒泡排序
            int[] arrySoftByBubble = { -20, 9, 7, 37, 38, 69, 89, -1, 59, 29, 0, -25, 39, 900, 22, 13, 55 };
            Helper.SoftByBubble(arrySoftByBubble, false);
            Console.WriteLine($"冒泡排序排序后={string.Join(",", arrySoftByBubble)}");
            Console.WriteLine();
            #endregion

            #region 有一个8个数的数组{1,2,3,3,4,5,6,6}，计算其中不重复数字的个数。
            int[] arryCalNotRepeat = { 1, 2, 3, 3, 4, 5, 6, 6 };
            //CalNotRepeat(arryCalNotRepeat);
            Console.WriteLine($"计算后={Helper.CalNotRepeat(arryCalNotRepeat)}");
            Console.WriteLine($"计算后2={Helper.CalNotRepeatNew(arryCalNotRepeat)}");
            Console.WriteLine();
            #endregion

            #region
            Helper.InvertedPrintTriangle(10);
            Helper.PrintTriangle(10);            
            #endregion

            Console.ReadLine();
        }
    }
}
