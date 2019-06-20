using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithm
{
    /// <summary>
    /// 算法帮助类
    /// </summary>
    public static class Helper
    {
        #region 不借用第三个变量,怎么把a,b的值互换
        public static void Exchange(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        #endregion

        #region 1-2+3-4+……+m
        public static int Sum(int num)
        {
            if (num <= 0)
                throw new Exception("参数不合法");
            int Sum = 0;
            for (int i = 0; i < num + 1; i++)
            {
                if ((i % 2) == 1)
                    Sum += i;
                else
                    Sum = Sum - i;
            }
            return Sum;
        }

        public static int Sum2(int num)
        {
            if (num <= 0)
                throw new Exception("参数不合法");
            int Sum = (num + 1) / 2;
            if ((num % 2) == 0)
                Sum = -Sum;
            return Sum;
        }
        #endregion

        #region 1、1、2、3、5、8、13、21、34......  求第30位数是多少
        public static int Foo(int i)
        {
            if (i <= 0)
                return 0;
            else if (i > 0 && i <= 2)
                return 1;
            else
                return Foo(i - 1) + Foo(i - 2);
        }
        #endregion

        #region 数组反转置顶开始位置和结束位置
        public static void Reverse(int[] arry, int begin, int end)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            if (begin < 0 || end < 0)
                throw new Exception("开始或者结束位置所以没有正确设置");
            if (end > arry.Length)
                throw new Exception("结束位置超出数组长度");
            while (begin < end)
            {
                int temp = arry[end];
                arry[end] = arry[begin];
                arry[begin] = temp;
                begin++;
                end--;
            }

        }

        public static void Reverse<T>(T[] arry, int begin, int end)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            if (begin < 0 || end < 0)
                throw new Exception("开始或者结束位置所以没有正确设置");
            if (end > arry.Length)
                throw new Exception("结束位置超出数组长度");
            while (begin < end)
            {
                T temp = arry[end];
                arry[end] = arry[begin];
                arry[begin] = temp;
                begin++;
                end--;
            }

        }
        #endregion

        #region 删除集合给定元素
        public static void deleteForm(ArrayList aList, object key)
        {
            if (null == aList)
                throw new Exception("aList不能为null");
            //if (aList.Contains(key)) aList.Remove(key);//删除单个
            while (aList.Contains(key))//删除所有
                aList.Remove(key);
        }
        #endregion

        #region 数组合并去重
        public static int[] CombinedArray(int[] a, int[] b)
        {
            if (null == a || null == b)
                throw new Exception("arry不能为null");
            var _list = a.ToList();
            foreach (var item in b)
            {
                if (!_list.Contains(item))
                    _list.Add(item);
            }
            return _list.ToArray();
        }
        #endregion

        #region 两个数组  [n] [m]  n>m  第一个数组的数字无序排列 第二个数组为空 取出第一个数组的最小值 放到第二个数组中第一个位置, 依次类推. 不能改变A数组，不能对之进行排序，也不可以倒到别的数组中。

        /// <summary>
        /// 两个数组  [n] [m]  n>m  第一个数组的数字无序排列 第二个数组为空 取出第一个数组的最小值
        /// 放到第二个数组中第一个位置, 依次类推. 不能改变A数组，不能对之进行排序，也不可以倒到别的数组中。
        /// </summary>
        public static void GetArr(int[] n, int[] m)
        {
            if (n.Length <= m.Length)
                throw new Exception("参数不合法");
            int intTmp = n[0];
            int intMaxNum;
            for (int i = 0; i < n.Length; i++)
                intTmp = n[i] > intTmp ? n[i] : intTmp;
            intMaxNum = intTmp;
            for (int j = 0; j < m.Length; j++)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (j == 0)
                        intTmp = n[i] < intTmp ? n[i] : intTmp;
                    else
                    {
                        if (n[i] > m[j - 1])
                            intTmp = n[i] < intTmp ? n[i] : intTmp;
                    }
                }
                m[j] = intTmp;
                intTmp = intMaxNum;
            }
        }

        public static void GetArr2(int[] n, int[] m)
        {
            if (n.Length <= m.Length)
                throw new Exception("参数不合法");
            int intTmp = n[0];
            int intMaxNum;
            for (int i = 0; i < n.Length; i++)
                intTmp = n[i] > intTmp ? n[i] : intTmp;
            intMaxNum = intTmp;
            for (int j = m.Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (j == m.Length - 1)
                        intTmp = n[i] < intTmp ? n[i] : intTmp;
                    else
                    {
                        if (n[i] > m[j + 1])
                            intTmp = n[i] < intTmp ? n[i] : intTmp;
                    }
                }
                m[j] = intTmp;
                intTmp = intMaxNum;
            }
        }
        #endregion

        #region 产生一个int数组，长度为100，并向其中随机插入1-100，并且不能重复。
        public static int[] CreateArr(int count = 1)
        {
            if (count < 0)
                throw new Exception("参数不合法");
            int[] intArr = new int[count];
            List<int> myList = new List<int>();
            Random rnd = new Random();
            while (myList.Count < count)
            {
                int num = rnd.Next(1, count + 1);
                if (!myList.Contains(num))
                    myList.Add(num);
            }
            return myList.ToArray();
        }
        #endregion

        #region 字符串处理

        /// <summary>
        /// 字符串倒序输出 123456 输出654321
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Reverse(string str = "123456")
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("参数不合法");
            StringBuilder sb = new StringBuilder(str.Length);
            for (int index = str.Length - 1; index >= 0; index--)
                sb.Append(str[index]);
            return sb.ToString();
        }

        /// <summary>
        /// 请将字符串"I am a student"按单词逆序输出如"student a am I"
        /// </summary>
        /// <param name="str">字符串参数</param>
        /// <param name="str">分割字符串</param>
        /// <returns></returns>
        public static string ReverseWord(string str = "I am a student", string split = " ")
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("参数不合法");
            StringBuilder sb = new StringBuilder(str.Length);
            string[] n = str.Split(split);
            for (int i = n.Length - 1; i >= 0; i--)
            {
                sb.Append(n[i]);
                if (i != 0)
                    sb.Append(" ");
            }
            return sb.ToString();
        }

        static string Reverse0(string str = "I am a student")
        {
            string strReturn = "";
            foreach (char c in str)
            {
                strReturn = c + strReturn;
            }
            Console.Write(strReturn);
            return strReturn;
        }

        public static void Reverse1(string S = "I am a student")
        {
            Console.Write(S.Reverse());
        }

        public static void Reverse2(string S = "I am a student")
        {
            for (int i = S.Length - 1; i >= 0; i--)
            {
                Console.Write(S.Substring(i, 1));
            }
        }
        #endregion

        #region 一口井深7米,一直蜗牛往上爬,白天爬3米,晚上掉2米。几天爬出去
        public static int Out(int high = 7, int add = 3, int reduce = 2)
        {
            int result = 1;
            while (high > 3)
            {
                result++;
                high = high - add + reduce;
            }
            return result;
        }

        #endregion

        #region 排序

        /// <summary>
        /// 冒泡排序 0升序 1降序
        /// </summary>
        /// <param name="arry">数组</param>
        /// <param name="isAsc">排序方式</param>
        public static void SoftByBubble(int[] arry, bool isAsc = true)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            int temp = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = i + 1; j < arry.Length; j++)
                {
                    if (arry[i] > arry[j] == isAsc)
                    {
                        temp = arry[i];
                        arry[i] = arry[j];
                        arry[j] = temp;
                    }

                }
            }
        }
        #endregion

        #region 有一个8个数的数组{1,2,3,3,4,5,6,6}，计算其中不重复数字的个数。
        public static int CalNotRepeat(int[] arry)
        {
            int result = 0;
            if (null == arry)
                throw new Exception("arry不能为null");
            HashSet<int> hs = new HashSet<int>();
            foreach (var item in arry)
                hs.Add(item);
            result = hs.Count;
            return result;
        }

        public static int CalNotRepeatNew(int[] arry)
        {
            int result = 0;
            if (null == arry)
                throw new Exception("arry不能为null");
            List<int> list = new List<int>();
            foreach (var item in arry)
            {
                if (!list.Contains(item))
                    list.Add(item);
            }
            result = list.Count;
            return result;
        }
        #endregion

        #region 打印出由*号组成的倒三角形的图案
        /// <summary>
        /// ******* 4*2-1 要求：	1、输入倒三角的行数，行数范围3-18，对于不在范围的行数，抛出提示.
        /// *****	3*2-1	2、在控制台打印出指定行数的倒三角形。
        /// ***2 (2*2)-1
        /// *1 (1*2)-1
        /// 公式 (n*2)-1
        /// </summary>
        /// <param name="num"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void PrintTriangle(int num, int min = 3, int max = 18)
        {
            if (num < min || num > max)
                throw new Exception("参数错误。");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Clear();
                string space = "".PadLeft(i, ' ');//生成空格,规则:行首空格数=行数-1
                sb.Append(space);
                string star = "".PadLeft((num - i) * 2 - 1, '*');//生成星号,规则:行号*2-1,行号=num-i
                sb.Append(star);
                Console.WriteLine(sb);
            }
        }
        public static void InvertedPrintTriangle(int num, int min = 3, int max = 18)
        {
            if (num < min || num > max)
                throw new Exception("参数错误。");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Clear();
                string space = "".PadLeft(num - i - 1, ' ');//生成空格,规则:行首空格数=总行数-当前行数-1-1
                sb.Append(space);
                string star = "".PadLeft(i * 2 + 1, '*');//生成星号,规则:行号*2-1,行号=num-i
                sb.Append(star);
                Console.WriteLine(sb);
            }
        }
        public static void PrintTriangleMy(int row, int min = 3, int max = 18)
        {
            if (row < min || row > max)
                throw new Exception("参数错误。");
            while (row > 0)
            {
                Print(row);
                Console.WriteLine("");
                row--;
            }
        }
        public static void Print(int count)
        {
            while (count > 0)
            {
                Console.Write("*");
                count--;
            }
        }
        #endregion
    }
}
