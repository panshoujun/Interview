using algorithm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyConsoleApplication
{
    class Program
    {
        readonly Copy copy1= new Copy() { Age = "2", name = "a" };
        const Copy copy2 = null;//new Copy (){  Age="2",name="a"};
           
        static int a = 0;
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();            
            string astr = "123";
            string bstr = "123";
            Console.WriteLine($"astr==bstr 是 {astr == bstr}");
            Console.WriteLine($"astr.Equals(bstr) 是 {astr.Equals(bstr)}");

            Copy copya = new Copy() { Age = "1", name = "a" };
            Copy copyb = new Copy() { Age = "1", name = "a" };
            Console.WriteLine($"copya==copyb 是 {copya == copyb}");
            Console.WriteLine($"copya.Equals(copyb) 是 {copya.Equals(copyb)}");
            //Thread thread = new Thread(PrintNumbers);
            //thread.Start();
            //PrintNumbers();
            //Console.ReadLine();
            //return;

            Father father = new Father();
            father.PrintNew();
            father = new Son();
            father.PrintNew();
            Copy copy = new Copy() { Age = "1", name = "a" };
            var copy2 = copy.Clone();
            if (copy == copy2)
            {
                Console.WriteLine("copy==copy2");
            }
            var copy3 = copy;
            if (copy == copy3)
            {
                Console.WriteLine("copy==copy3");
            }
            string s1 = "1\\//2\\//3\\//4";
            var s2 = s1.Split("\\//");
            if (Program.a is System.ValueType)
            {
                Console.WriteLine("Program.a is System.ValueType");
            }
            Ref(ref Program.a);
            Ref2(out Program.a);
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


            List<string> bList = new List<string> { "a", "b", "c", "c", "1", "2", "3", "1" };
            Console.WriteLine(string.Format("删除集合给定元素前aList={0}", string.Join(",", bList)));
            Helper.deleteForm(bList, "1", true);
            Console.WriteLine(string.Format("删除集合给定元素后aList={0}", string.Join(",", bList)));
            Console.WriteLine();
            #endregion

            #region 数组合并去重
            int[] arryA = { 1, 2, 3, 4, 4, 5 };
            int[] arryB = { 3, 5, 6 };
            //string[] outputA = Array.ConvertAll<int, string>(arryA, i => i.ToString());
            Console.WriteLine(string.Format("数组合并去重数组arryA={0}", string.Join(",", arryA)));
            //string[] outputB = Array.ConvertAll<int, string>(arryB, i => i.ToString());
            Console.WriteLine(string.Format("数组合并去重数组arryB={0}", string.Join(",", arryB)));

            var resultArray = Helper.CombinedArrayNew<int>(arryA, arryB);
            //string[] outputResult = Array.ConvertAll<int, string>(resultArray, i => i.ToString());
            Console.WriteLine(string.Format("数组合并去重数组resultArray={0}", string.Join(",", resultArray)));
            Console.WriteLine();
            #endregion

            #region 两个数组  [n] [m]  n>m  第一个数组的数字无序排列 第二个数组为空 取出第一个数组的最小值 放到第二个数组中第一个位置, 依次类推. 不能改变A数组，不能对之进行排序，也不可以倒到别的数组中。
            int[] n = { -20, 9, 7, 37, 38, 69, 89, -1, 59, 29, 0, -25, 39, 900, 22, 13, 55 };
            int[] m = new int[10];
            Helper.GetArr(n, m);
            Console.WriteLine(string.Format("数组outputM={0}", string.Join(",", m)));
            Helper.GetArr2(n, m);
            Console.WriteLine(string.Format("数组outputM={0}", string.Join(",", m)));
            Helper.GetArrNew(n, m);
            Console.WriteLine(string.Format("取最大数组outputM={0}", string.Join(",", m)));
            Helper.GetArr2New(n, m);
            Console.WriteLine(string.Format("取最大数组outputM={0}", string.Join(",", m)));
            Console.WriteLine();
            #endregion

            #region 产生一个int数组，长度为100，并向其中随机插入1-100，并且不能重复。
            var array = Helper.CreateArr(10);
            string[] outputArray = Array.ConvertAll<int, string>(array, i => i.ToString());
            Console.WriteLine(string.Format("数组outputArray={0}", string.Join(",", outputArray)));

            var arrayNew = Helper.CreateArr(10, 1, 10);
            Console.WriteLine(string.Format("数组outputArray={0}", string.Join(",", arrayNew)));
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

            Helper.SoftByBubble(arrySoftByBubble, true);
            Console.WriteLine($"冒泡排序排序后={string.Join(",", arrySoftByBubble)}");
            Console.WriteLine();

            int[] arrySoftBySelect = { -20, 9, 7, 37, 38, 69, 89, -1, 59, 29, 0, -25, 39, 900, 22, 13, 55 };
            Helper.SoftBySelect(arrySoftBySelect, false);
            Console.WriteLine($"选择排序排序后={string.Join(",", arrySoftBySelect)}");
            Console.WriteLine();

            int[] arrySoftByInsert = { -20, 9, 7, 37, 38, 69, 89, -1, 59, 29, 0, -25, 39, 900, 22, 13, 55 };
            Helper.SoftByInsert(arrySoftByInsert, true);
            Console.WriteLine($"插入排序排序后={string.Join(",", arrySoftByInsert)}");
            Console.WriteLine();
            #endregion

            #region 有一个8个数的数组{1,2,3,3,4,5,6,6}，计算其中不重复数字的个数。
            int[] arryCalNotRepeat = { 1, 2, 3, 3, 4, 5, 6, 6 };
            //CalNotRepeat(arryCalNotRepeat);
            Console.WriteLine($"计算后={Helper.CalNotRepeat(arryCalNotRepeat)}");
            Console.WriteLine($"计算后2={Helper.CalNotRepeatNew(arryCalNotRepeat)}");
            Console.WriteLine($"计算后2={Helper.CalNotRepeatNew2(arryCalNotRepeat)}");
            Console.WriteLine();
            #endregion

            #region 打印三角形
            Helper.InvertedPrintTriangle(10);
            Helper.PrintTriangle(10);
            #endregion

            #region 进制转换
            int converNumber = -100;
            Console.WriteLine($"转换前{converNumber},转换后{Helper.Conver(converNumber, "0123", 4)}");
            #endregion

            #region 求s=a+aa+aaa  例如2+22+222
            Console.WriteLine($"求和结果:{Helper.Sum3(2, 3)}");
            Console.WriteLine($"求和结果:{Helper.Sum3(2, 4)}");
            #endregion

            #region 字符串查找第一个不重复的字母
            Console.WriteLine($"求和结果:{Helper.FindChar("aa")}");
            #endregion

            #region 一球从100米高度自由落下
            decimal sum;
            decimal now;
            Helper.Run(100, 0.5m, 1, out sum, out now);
            Console.WriteLine($"求和结果:sum={sum},now={now}");
            Helper.Run(100, 0.5m, 3, out sum, out now);
            Console.WriteLine($"求和结果:sum={sum},now={now}");
            Helper.Run(100, 0.5m, 10, out sum, out now);
            Console.WriteLine($"求和结果:sum={sum},now={now}");
            #endregion

            #region 求连续子数组的最大和
            int[] arr = { 1, -2, 1, 10, -4, 7, 2, -5 };//{ 1, 4, -5, 9, 8, 3, -6 };//{ 2, 3, -6, 4, 6, 2, -2, 5, -9 };//
            var GetMaxAddAndArray = Helper.GetMaxAddAndArray(arr);
            Console.WriteLine($"求连续子数组的最大和:sum={GetMaxAddAndArray.Item1},arr={string.Join(',', (int[])GetMaxAddAndArray.Item2)}");
            var GetMaxAddAndArray2 = Helper.GetMaxAddAndArray2(arr);
            Console.WriteLine($"求连续子数组的最大和:sum={GetMaxAddAndArray2.Item1},arr={string.Join(',', (int[])GetMaxAddAndArray2.Item2)}");
            Console.WriteLine($"求连续子数组的最大和:sum={Helper.GetMaxAddOfArray3(arr)}");
            Console.WriteLine($"求连续子数组的最大和:sum={Helper.GetMaxAddOfArray4(arr)}");
            #endregion

            #region n阶台阶，一次走一步或两步，有多少种走法
            //Console.WriteLine($"走阶梯算法0:sum={Helper.findStep2(0)}");
            Console.WriteLine($"走阶梯算法1:sum={Helper.findStep2(1)}");
            Console.WriteLine($"走阶梯算法2:sum={Helper.findStep2(2)}");
            Console.WriteLine($"走阶梯算法3:sum={Helper.findStep2(3)}");
            Console.WriteLine($"走阶梯算法4:sum={Helper.findStep2(4)}");
            Console.WriteLine($"走阶梯算法5:sum={Helper.findStep2(5)}");
            #endregion

            #region  找出一个数组中重复次数大于minTimes的数字
            int[] arrFindDuplication = { 1, 2, 5, 1, 3, 1, 9, 20, 15, 5, 2, 9, 3, 15, 2 };
            var temp = Helper.FindDuplication(arrFindDuplication, 5);
            string[] outputFindDuplication = Array.ConvertAll<int, string>(Helper.FindDuplicationLq(arrFindDuplication, 5), i => i.ToString());
            Console.WriteLine($"FindDuplication={string.Join(",", outputFindDuplication)}");
            #endregion


            Console.ReadLine();
        }

        public static void Ref(ref int a)
        {

        }

        public static void Ref2(out int a)
        {
            a = 0;
        }

        #region
        static void PrintNumbers()
        {
            Console.WriteLine("starting---------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

        }
        #endregion
    }
}
